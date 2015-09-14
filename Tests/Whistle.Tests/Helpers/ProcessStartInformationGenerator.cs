using System.Diagnostics;

namespace Narkhedegs.Diagnostics.Tests.Helpers
{
    public static class ProcessStartInformationGenerator
    {
        public static ProcessStartInfo Default()
        {
            return new ProcessStartInfo
            {
                UseShellExecute = false,
                RedirectStandardError = true,
                RedirectStandardInput = true,
                RedirectStandardOutput = true,
                FileName = @"Executable.exe",
                WorkingDirectory = @"/Helpers"
            };

        }
    }
}
