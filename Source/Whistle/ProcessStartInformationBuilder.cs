using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace Narkhedegs
{
    /// <summary>
    /// Provides methods to build <see cref="ProcessStartInfo"/> object.
    /// </summary>
    internal class ProcessStartInformationBuilder : IProcessStartInformationBuilder
    {
        /// <summary>
        /// Build <see cref="ProcessStartInfo"/> object from the given <see cref="WhistleOptions"/> object.
        /// </summary>
        /// <param name="whistleOptions"><see cref="WhistleOptions"/></param>
        /// <param name="arguments">Extra arguments for the executable.</param>
        /// <returns>
        /// <see cref="ProcessStartInfo"/>
        /// </returns>
        public ProcessStartInfo Build(WhistleOptions whistleOptions, IEnumerable<string> arguments = null)
        {
            var processStartInformation = new ProcessStartInfo
            {
                UseShellExecute = false,
                CreateNoWindow = true,
                ErrorDialog = false,
                WindowStyle = ProcessWindowStyle.Hidden,
                RedirectStandardError = true,
                RedirectStandardInput = true,
                RedirectStandardOutput = true,
                FileName = whistleOptions.ExecutableName,
                WorkingDirectory = whistleOptions.WorkingDirectory
            };

            //Populate arguments
            var processArguments = new List<string>();

            if (whistleOptions.Arguments != null && whistleOptions.Arguments.Any())
            {
                processArguments.AddRange(whistleOptions.Arguments);
            }

            if (arguments != null)
            {
                var extraArguments = arguments as string[] ?? arguments.ToArray();
                if (extraArguments.Any())
                {
                    processArguments.AddRange(extraArguments);
                }
            }

            if (processArguments.Count > 0)
            {
                processStartInformation.Arguments = string.Join(" ", processArguments);
            }

            //Populate Environment Variables
            if (whistleOptions.EnvironmentVariables != null && whistleOptions.EnvironmentVariables.Count > 0)
            {
                foreach (var environmentVariable in whistleOptions.EnvironmentVariables)
                {
                    processStartInformation.EnvironmentVariables.Add(environmentVariable.Key, environmentVariable.Value);
                }
            }

            return processStartInformation;
        }
    }
}
