using System.Diagnostics;

namespace Narkhedegs.Tests.Helpers
{
    public static class ProcessStartInformationGenerator
    {
        public static ProcessStartInfo Default()
        {
            return new ProcessStartInfo
            {
                UseShellExecute = false,
                CreateNoWindow = true,
                ErrorDialog = false,
                WindowStyle = ProcessWindowStyle.Hidden,
                RedirectStandardError = true,
                RedirectStandardInput = true,
                RedirectStandardOutput = true,
                FileName = @"Executable.exe",
                WorkingDirectory = @"/Helpers"
            };

        }
    }
}
