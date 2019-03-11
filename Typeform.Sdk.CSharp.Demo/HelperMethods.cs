using System;
using Serilog;

namespace Typeform.Sdk.CSharp.Demo
{
    public static class HelperMethods
    {
        public static void PrintStartOfNewExecution(string title)
        {
            Log.Information("------------- {title} -------------", title.ToUpper());
        }

        public static void PrintEndOfExecution<TData>(TData results)
        {
            Log.Information("{@results}", results);
            Log.Information($"-----------------------------------{Environment.NewLine}");
        }
    }
}