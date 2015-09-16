namespace Narkhedegs
{
    /// <summary>
    /// Contains the standard output and standard error responses of the executable started by <see cref="Whistle"/>.
    /// </summary>
    public class WhistleResponse
    {
        /// <summary>
        /// Standard output response of the executable started by <see cref="Whistle"/>.
        /// </summary>
        public string StandardOutput { get; set; }

        /// <summary>
        /// Standard error response of the executable started by <see cref="Whistle"/>.
        /// </summary>
        public string StandardError { get; set; }

        /// <summary>
        /// Returns true if the executable started by <see cref="Whistle"/> returns a standard error response otherwise \
        /// returns false.
        /// </summary>
        public bool HasError => !string.IsNullOrWhiteSpace(StandardError);
    }
}
