using System;
using System.IO;

namespace Narkhedegs.Diagnostics
{
    /// <summary>
    /// Provides methods to validate <see cref="WhistleOptions"/>.
    /// </summary>
    internal class WhistleOptionsValidator : IWhistleOptionsValidator
    {
        /// <summary>
        /// Validates <see cref="WhistleOptions"/>. This method makes sure that - 
        /// <list type="number">
        ///     <item>
        ///         <description>
        ///         <see cref="WhistleOptions"/> object is not null.
        ///         </description>
        ///     </item> 
        ///     <item>
        ///         <description>
        ///         ExecutableName is not null or empty and it is a valid and existing path.
        ///         </description>
        ///     </item>        
        ///     <item>
        ///         <description>
        ///         If WorkingDirectory is not null or empty then it is a valid and existing path.
        ///         </description>
        ///     </item>
        /// </list>
        /// </summary>
        /// <param name="whistleOptions">
        /// <see cref="WhistleOptions"/> object to be validated.
        /// </param>
        public void Validate(WhistleOptions whistleOptions)
        {
            if (whistleOptions == null)
                throw new ArgumentNullException(nameof(whistleOptions));

            if (string.IsNullOrWhiteSpace(whistleOptions.ExecutableName))
                throw new ArgumentException("WhistleOptions.ExecutableName cannot be null or empty.",
                    nameof(whistleOptions));

            if (!File.Exists(whistleOptions.ExecutableName))
                throw new ArgumentException(
                    "Could not find the executable specified in the ExecutableName. Please make sure that the executale exists at the path specified by the ExecutableName and user has at least ReadOnly permission for the executable file.");

            if (!string.IsNullOrWhiteSpace(whistleOptions.WorkingDirectory) &&
                !Directory.Exists(whistleOptions.WorkingDirectory))
                throw new ArgumentException(
                    "Could not find directory specified in the WorkingDirectory. Please make sure that a directory exists at the path specified by the WorkingDirectory and user has at least ReadOnly permission for the directory.");

            if(whistleOptions.ExitTimeout != null && whistleOptions.ExitTimeout <= 0)
                throw new ArgumentException("ExitTimeout must be an integer value greater than zero.");
        }
    }
}
