using System;
using System.Xml.Linq;
using OptimaJet.Workflow.Core.Builder;
using OptimaJet.Workflow.Core.Bus;
using OptimaJet.Workflow.Core.Model;
using OptimaJet.Workflow.Core.Runtime;
using OptimaJet.Workflow.DbPersistence;

public static class WorkflowInit
{
    private static readonly Lazy<WorkflowRuntime> LazyRuntime = new Lazy<WorkflowRuntime>(InitWorkflowRuntime);

    public static WorkflowRuntime Runtime
    {
        get { return LazyRuntime.Value; }
    }

    public static string ConnectionString { get; set; }

    private static WorkflowRuntime InitWorkflowRuntime()
    {
        if (string.IsNullOrEmpty(ConnectionString))
        {
            throw new Exception("Please init ConnectionString before calling the Runtime!");
        }

        var dbProvider = new MSSQLProvider(ConnectionString);

        var builder = new WorkflowBuilder<XElement>(
            dbProvider,
            new OptimaJet.Workflow.Core.Parser.XmlWorkflowParser(),
            dbProvider
        ).WithDefaultCache();

        var runtime = new WorkflowRuntime()
            .WithBuilder(builder)
            .WithPersistenceProvider(dbProvider)
            .EnableCodeActions()
            .SwitchAutoUpdateSchemeBeforeGetAvailableCommandsOn()
            .AsSingleServer();

        var plugin = new OptimaJet.Workflow.Plugins.BasicPlugin();
        plugin.WithActors(new List<string>() { "Manager", "Author" });
        plugin.UsersInRoleAsync = UsersInRoleAsync;

        runtime.WithPlugin(plugin);

        // events subscription
        runtime.ProcessActivityChanged += (sender, args) => { };
        runtime.ProcessStatusChanged += (sender, args) => { };

        runtime.Start();

        return runtime;
    }

    private static async Task<IEnumerable<string>> UsersInRoleAsync(string roleName, ProcessInstance processInstance)
    {
        // get userIds from database
        //using (var dbContext = new ApplicationDbContext())
        //{
        //    var roleId = await dbContext.UserRole.FirstOfDefaultAsync(r => r.Name == roleName).Id;
        //    var userIds = await dbContext.UserRole.Where(r => r.roleId == roleId).Select(userId).ToListAsync();
        //    return userIds;
        //}

        if (roleName == "Employee")
        {
            return new List<string>() { "1", "2", "3" };
        }
        if (roleName == "TechnicalManager")
        {
            return new List<string>() { "4", "5", "6" };
        }
        if (roleName == "HRManager")
        {
            return new List<string>() { "7", "8", "9" };
        }
        if (roleName == "PayrollManager")
        {
            return new List<string>() { "10", "11", "12" };
        }
        if (roleName == "CTO")
        {
            return new List<string>() { "13", "14", "15" };
        }
        return new List<string>();
    }
}