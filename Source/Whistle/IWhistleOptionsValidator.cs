namespace Narkhedegs.Diagnostics
{
    /// <summary>
    /// Provides methods to validate <see cref="WhistleOptions"/>.
    /// </summary>
    internal interface IWhistleOptionsValidator
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
        void Validate(WhistleOptions whistleOptions);
    }
}
