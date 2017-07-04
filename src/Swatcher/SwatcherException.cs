using System;
using System.IO;
using System.Text;
using BraveLantern.Swatcher.Config;
using BraveLantern.Swatcher.Extensions;

namespace BraveLantern.Swatcher
{
    /// <summary>
    /// Class SwatcherException. This class cannot be inherited.
    /// </summary>
    /// <seealso cref="System.ApplicationException" />
    public sealed class SwatcherException : ApplicationException
    {
        /// <summary>
        /// The configuration for the <see cref="ISwatcher"/> that encountered an exception.
        /// </summary>
        public ISwatcherConfig Config { get; }

        /// <summary>
        /// The Windows® error code that was captured, if any.
        /// </summary>
        public int ErrorCode { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="SwatcherException"/> class.
        /// </summary>
        /// <param name="config">The configuration for the <see cref="ISwatcher"/> that encountered an exception.</param>
        /// <param name="code">The Windows® error code that was captured, if any.</param>
        public SwatcherException(ISwatcherConfig config, uint code)
            : base(CreateExceptionMessage(config, code))
        {
            Config = config;
            ErrorCode = (int)code;
            HResult = (int)code.ToHResult();
        }

        private static string CreateExceptionMessage(ISwatcherConfig config, uint code)
        {
            var hresult = code.ToHResult();

            var builder = new StringBuilder();
            builder.AppendLine($"{nameof(Swatcher)} has encountered an exception; calling {nameof(ISwatcher.Stop)}.");
            builder.Append('-', 75);
            builder.Append(Environment.NewLine);
            builder.AppendLine($"{nameof(ISwatcherConfig.Id)} : {config.Id?.ToString() ?? "null"}");
            builder.AppendLine($"{nameof(ISwatcherConfig.PathToWatch)} : {config.PathToWatch}");
            builder.AppendLine($"{nameof(BraveLantern.Swatcher.HResult)} : {hresult.ToString()}");
            builder.AppendLine($"Error Code: {code}");
            builder.AppendLine($"Message: {hresult.GetDescription()}");


            return builder.ToString();
        }
    }
}