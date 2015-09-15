using System.Collections.Generic;

namespace Narkhedegs.Diagnostics
{
    /// <summary>
    /// Options that can be passed to <see cref="Whistle"/> to change its behaviour.
    /// </summary>
    public class WhistleOptions
    {
        public WhistleOptions()
        {
            Arguments = new List<string>();
            EnvironmentVariables = new Dictionary<string, string>();
        }

        /// <summary>
        /// Gets or sets the executable to start. The ExecutableName could be simply a name like executable.exe or 
        /// it could be a path, absolute or relative. For example /path/to/your/executable.exe or 
        /// C:\path\to\your\executable.exe
        /// </summary>
        public string ExecutableName { get; set; }

        /// <summary>
        /// Gets or sets the set of command-line arguments to use when starting the executable. Arguments specified here 
        /// will be merged with the arguments accepted by the Blow method of <see cref="Whistle"/>.
        /// </summary>
        public IEnumerable<string> Arguments { get; set; }

        /// <summary>
        /// Gets or sets the working directory for the executable to be started. If nothing is specified then the default value 
        /// for WorkingDirectory is the Current Directory.
        /// </summary>
        public string WorkingDirectory { get; set; }

        /// <summary>
        /// ExitTimeout is time in milliseconds for which Whistle will wait for the external executable to exit. If the 
        /// external executable exceeds the ExitTimeout then Whistle will terminate the executable and raise TimeoutException.
        /// If ExitTimeout is null or is not specified then the default value for ExitTimeout is infinity <see cref="System.Threading.Timeout.Infinite"/>.
        /// </summary>
        public int? ExitTimeout { get; set; }

        /// <summary>
        /// A string dictionary that provides environment variables that apply to the executable and child processes. 
        /// </summary>
        public Dictionary<string, string> EnvironmentVariables { get; set; }
    }
}
