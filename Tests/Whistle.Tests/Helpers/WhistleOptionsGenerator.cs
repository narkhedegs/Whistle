using System.Collections.Generic;

namespace Narkhedegs.Diagnostics.Tests.Helpers
{
    public static class WhistleOptionsGenerator
    {
        public static WhistleOptions Default()
        {
            return new WhistleOptions
            {
                ExecutableName = "Executable.exe",
                WorkingDirectory = @"/Helpers",
                ExitTimeout = null
            };
        }

        public static WhistleOptions WithExecutableName(this WhistleOptions whistleOptions, string executableName)
        {
            whistleOptions.ExecutableName = executableName;
            return whistleOptions;
        }

        public static WhistleOptions WithNullExecutableName(this WhistleOptions whistleOptions)
        {
            return whistleOptions.WithExecutableName(null);
        }

        public static WhistleOptions WithEmptyExecutableName(this WhistleOptions whistleOptions)
        {
            return whistleOptions.WithExecutableName(string.Empty);
        }

        public static WhistleOptions WithNonExistentExecutableName(this WhistleOptions whistleOptions)
        {
            return whistleOptions.WithExecutableName(@"NonExistentExecutable.exe");
        }

        public static WhistleOptions WithExistentExecutableName(this WhistleOptions whistleOptions)
        {
            return whistleOptions.WithExecutableName(@"Executable.exe");
        }

        public static WhistleOptions WithWorkingDirectory(this WhistleOptions whistleOptions, string workingDirectory)
        {
            whistleOptions.WorkingDirectory = workingDirectory;
            return whistleOptions;
        }

        public static WhistleOptions WithNonExistentWorkingDirectory(this WhistleOptions whistleOptions)
        {
            return whistleOptions.WithWorkingDirectory(@"/NonExistentWorkingDirectory");
        }

        public static WhistleOptions WithExistentWorkingDirectory(this WhistleOptions whistleOptions)
        {
            return whistleOptions.WithWorkingDirectory(@"/Helpers");
        }

        public static WhistleOptions WithArguments(this WhistleOptions whistleOptions, IEnumerable<string> arguments)
        {
            whistleOptions.Arguments = arguments;
            return whistleOptions;
        }

        public static WhistleOptions WithExitTimeout(this WhistleOptions whistleOptions, int? exitTimeout)
        {
            whistleOptions.ExitTimeout = exitTimeout;
            return whistleOptions;
        }

        public static WhistleOptions WithEnvironmentVariable(this WhistleOptions whistleOptions, string key,
            string value)
        {
            whistleOptions.EnvironmentVariables.Add(key,value);
            return whistleOptions;
        }
    }
}
