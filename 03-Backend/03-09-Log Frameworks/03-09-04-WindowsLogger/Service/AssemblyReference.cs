using System.IO;
using System;
using System.Reflection;
using System.Xml.Linq;

namespace Service;

public static class AssemblyReference
{
    public static readonly Assembly Assembly = typeof(AssemblyReference).Assembly;
    public static readonly string projectName = Assembly.FullName!.Split(',')[0];
    public static readonly string solutionName = "WindowsLoggerLogs";
}
