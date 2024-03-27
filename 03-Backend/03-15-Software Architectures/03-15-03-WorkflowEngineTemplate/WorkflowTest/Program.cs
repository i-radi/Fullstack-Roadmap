﻿using OptimaJet.Workflow.Core.Runtime;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.IO;
using Microsoft.Extensions.Configuration;

class Program
{
    static string schemeCode = "RadiWF";
    static Guid? processId = null;
    static void Main(string[] args)
    {

        var builder = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);

        IConfigurationRoot configuration = builder.Build();
        WorkflowInit.ConnectionString = configuration[$"ConnectionStrings:DefaultConnection"]!;

        Console.WriteLine("Operation:");
        Console.WriteLine("0 - CreateInstance");
        Console.WriteLine("1 - GetAvailableCommands");
        Console.WriteLine("2 - ExecuteCommand");
        Console.WriteLine("3 - GetAvailableState");
        Console.WriteLine("4 - SetState");
        Console.WriteLine("5 - DeleteProcess");
        Console.WriteLine("9 - Exit");
        Console.WriteLine("The process isn't created.");
        CreateInstance();

        do
        {
            if (processId.HasValue)
            {
                Console.WriteLine("ProcessId = '{0}'. CurrentState: {1}, CurrentActivity: {2}",
                    processId,
                    WorkflowInit.Runtime.GetCurrentStateName(processId.Value),
                    WorkflowInit.Runtime.GetCurrentActivityName(processId.Value));
            }

            Console.Write("Enter code of operation:");
            char operation = Console.ReadLine()!.FirstOrDefault();
            Console.Write("Enter userId:");
            var userId = Console.ReadLine()?? string.Empty;

            switch (operation)
            {
                case '0':
                    CreateInstance();
                    break;
                case '1':
                    GetAvailableCommands(userId);
                    break;
                case '2':
                    ExecuteCommand(userId);
                    break;
                case '3':
                    GetAvailableState();
                    break;
                case '4':
                    SetState(userId);
                    break;
                case '5':
                    DeleteProcess();
                    break;
                case '9':
                    return;
                default:
                    Console.WriteLine("Unknown code. Please, repeat.");
                    break;
            }
            Console.WriteLine();
        } while (true);
    }

    private static void CreateInstance()
    {
        processId = Guid.NewGuid();
        try
        {
            WorkflowInit.Runtime.CreateInstance(schemeCode, processId.Value);
            Console.WriteLine("CreateInstance - OK.", processId);
        }
        catch (Exception ex)
        {
            Console.WriteLine("CreateInstance - Exception: {0}", ex.Message);
            processId = null;
        }
    }

    private static void GetAvailableCommands(string userId)
    {
        if (processId == null)
        {
            Console.WriteLine("The process isn't created. Please, create process instance.");
            return;
        }
        var commands = WorkflowInit.Runtime.GetAvailableCommands(processId.Value, userId);

        Console.WriteLine("Available commands:");
        if (commands.Count() == 0)
        {
            Console.WriteLine("Not found!");
        }
        else
        {
            foreach (var command in commands)
            {
                Console.WriteLine("- {0} (LocalizedName:{1}, Classifier:{2})",
                    command.CommandName, command.LocalizedName, command.Classifier);
            }
        }
    }

    private static void ExecuteCommand(string userId)
    {
        if (processId == null)
        {
            Console.WriteLine("The process isn't created. Please, create process instance.");
            return;
        }
        WorkflowCommand command = null;
        do
        {
            GetAvailableCommands(userId);
            Console.Write("Enter command:");
            var commandName = Console.ReadLine().ToLower().Trim();
            if (commandName == string.Empty)
                return;
            command = WorkflowInit.Runtime
                .GetAvailableCommands(processId.Value, userId)
                .Where(c => c.CommandName.Trim().ToLower() == commandName).FirstOrDefault();
            if (command == null)
                Console.WriteLine("The command isn't found.");
        } while (command == null);

        WorkflowInit.Runtime.ExecuteCommand(command, userId, userId);
        Console.WriteLine("ExecuteCommand - OK.", processId);
    }

    private static void GetAvailableState()
    {
        if (processId == null)
        {
            Console.WriteLine("The process isn't created. Please, create process instance.");
            return;
        }
        var states = WorkflowInit.Runtime
            .GetAvailableStateToSet(processId.Value, Thread.CurrentThread.CurrentCulture);
        Console.WriteLine("Available state to set:");
        if (states.Count() == 0)
        {
            Console.WriteLine("Not found!");
        }
        else
        {
            foreach (var state in states)
            {
                Console.WriteLine("- {0}", state.Name);
            }
        }
    }

    private static void SetState(string userId)
    {
        if (processId == null)
        {
            Console.WriteLine("The process isn't created. Please, create process instance.");
            return;
        }
        string stateName = string.Empty;
        WorkflowState state;
        do
        {
            GetAvailableState();
            Console.Write("Enter state:");
            stateName = Console.ReadLine().ToLower().Trim();
            if (stateName == string.Empty)
                return;
            state = WorkflowInit.Runtime
                .GetAvailableStateToSet(processId.Value, Thread.CurrentThread.CurrentCulture)
                .Where(c => c.Name.Trim().ToLower() == stateName).FirstOrDefault();
            if (state == null)
                Console.WriteLine("The state isn't found.");
            else
                break;
        } while (true);
        if (state != null)
        {
            WorkflowInit.Runtime.SetState(processId.Value, userId, userId,
                state.Name, new Dictionary<string, object>());
            Console.WriteLine("SetState - OK.", processId);
        }
    }

    private static void DeleteProcess()
    {
        if (processId == null)
        {
            Console.WriteLine("The process isn't created. Please, create process instance.");
            return;
        }
        WorkflowInit.Runtime.DeleteInstance(processId.Value);
        Console.WriteLine("DeleteProcess - OK.", processId);
        processId = null;
    }
}