using System.Threading.Tasks;

namespace Narkhedegs.Diagnostics
{
    /// <summary>
    /// Provides methods to start external executable from within a .NET process.
    /// </summary>
    public interface IWhistle
    {
        /// <summary>
        /// Starts an external executable from within a .NET process.
        /// </summary>
        /// <param name="arguments">
        /// Set of command-line arguments to be given to the executable. Arguments specified here 
        /// will be merged with the Arguments property of <see cref="WhistleOptions"/>.
        /// </param>
        /// <returns>
        /// Standard output and standard error responses of the executable.
        /// </returns>
        Task<WhistleResponse> Blow(params string[] arguments);
    }
}
