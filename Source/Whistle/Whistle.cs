using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;

namespace Narkhedegs
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
            if (whistleOptionsValidator == null)
                throw new ArgumentNullException(nameof(whistleOptionsValidator));

            if (processStartInformationBuilder == null)
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
            _whistleOptionsValidator.Validate(_whistleOptions);

            var processStartInformation = _processStartInformationBuilder.Build(_whistleOptions, arguments);

            var taskCompletionSource = new TaskCompletionSource<WhistleResponse>();
            var cancellationTokenSource = new CancellationTokenSource(_whistleOptions.ExitTimeout ?? Timeout.Infinite);
            var cancellationToken = cancellationTokenSource.Token;
            var standardOutput = new List<string>();
            var standardError = new List<string>();

            var process = new Process
            {
                StartInfo = processStartInformation,
                EnableRaisingEvents = true
            };

            process.OutputDataReceived += (sender, eventArguments) =>
            {
                if (eventArguments.Data != null)
                {
                    standardOutput.Add(eventArguments.Data);
                }
            };

            process.ErrorDataReceived += (sender, eventArguments) =>
            {
                if (eventArguments.Data != null)
                {
                    standardError.Add(eventArguments.Data);
                }
            };

            process.Exited += (sender, eventArguments) => taskCompletionSource.TrySetResult(new WhistleResponse
            {
                StandardError =
                    standardError.Count > 0 ? string.Join(string.Empty, standardError.ToArray()) : string.Empty,
                StandardOutput =
                    standardOutput.Count > 0 ? string.Join(string.Empty, standardOutput.ToArray()) : string.Empty
            });

            cancellationToken.Register(() =>
            {
                if (!taskCompletionSource.Task.IsCompleted)
                {
                    process.CloseMainWindow();
                    taskCompletionSource.TrySetException(new TimeoutException(
                        $"{_whistleOptions.ExecutableName} took more than {_whistleOptions.ExitTimeout} milliseconds to exit."));
                }
            });

            if (process.Start() == false)
            {
                taskCompletionSource.TrySetException(new InvalidOperationException($"{_whistleOptions.ExecutableName} failed to start."));
            }

            process.BeginOutputReadLine();
            process.BeginErrorReadLine();

            return taskCompletionSource.Task;
        }
    }
}
