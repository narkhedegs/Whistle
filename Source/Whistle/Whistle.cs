using System;
using System.Threading.Tasks;

namespace Narkhedegs.Diagnostics
{
    /// <summary>
    /// Provides methods to start external executable from within a .NET process.
    /// </summary>
    public class Whistle : IWhistle
    {
        private readonly IProcessStartInformationBuilder _processStartInformationBuilder;
        private readonly WhistleOptions _whistleOptions;
        private readonly IWhistleOptionsValidator _whistleOptionsValidator;

        /// <summary>
        /// Initializes a new instance of <see cref="Whistle"/> with the given <see cref="WhistleOptions"/>.
        /// </summary>
        /// <param name="options">
        /// Options that can be passed to <see cref="Whistle"/> to change its behaviour.
        /// </param>
        public Whistle(WhistleOptions options)
            : this(options, 
                   new WhistleOptionsValidator(), 
                   new ProcessStartInformationBuilder())
        {   
        }

        /// <summary>
        /// Initializes a new instance of <see cref="Whistle"/> with the given <see cref="WhistleOptions"/>.
        /// </summary>
        /// <param name="whistleOptions">Options that can be passed to <see cref="Whistle"/> to change its behaviour.</param>
        /// <param name="whistleOptionsValidator">Implementation of <see cref="IWhistleOptionsValidator"/></param>
        /// <param name="processStartInformationBuilder">Implementation of <see cref="IProcessStartInformationBuilder"/></param>
        internal Whistle(
            WhistleOptions whistleOptions, 
            IWhistleOptionsValidator whistleOptionsValidator, 
            IProcessStartInformationBuilder processStartInformationBuilder)
        {
            if(whistleOptionsValidator == null)
                throw new ArgumentNullException(nameof(whistleOptionsValidator));

            if(processStartInformationBuilder == null)
                throw new ArgumentNullException(nameof(processStartInformationBuilder));

            _whistleOptions = whistleOptions;
            _processStartInformationBuilder = processStartInformationBuilder;
            _whistleOptionsValidator = whistleOptionsValidator;
        }

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
        public Task<WhistleResponse> Blow(params string[] arguments)
        {
            throw new NotImplementedException();
        }
    }
}
