using System.Collections.Generic;
using System.Diagnostics;

namespace Narkhedegs
{
    /// <summary>
    /// Provides methods to build <see cref="ProcessStartInfo"/> object.
    /// </summary>
    internal interface IProcessStartInformationBuilder
    {
        /// <summary>
        /// Build <see cref="ProcessStartInfo"/> object from the given <see cref="WhistleOptions"/> object.
        /// </summary>
        /// <param name="whistleOptions"><see cref="WhistleOptions"/></param>
        /// <param name="arguments">Extra arguments for the executable.</param>
        /// <returns>
        /// <see cref="ProcessStartInfo"/>
        /// </returns>
        ProcessStartInfo Build(WhistleOptions whistleOptions, IEnumerable<string> arguments = null);
    }
}