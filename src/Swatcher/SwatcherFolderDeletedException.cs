using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BraveLantern.Swatcher.Config;

namespace BraveLantern.Swatcher
{
    public sealed class SwatcherFolderDeletedException : DirectoryNotFoundException
    {
        public ISwatcherConfig Config { get; }

        public SwatcherFolderDeletedException(ISwatcherConfig config, uint lastError)
            :base(CreateExceptionMessage(config, lastError))
        {
            Config = config;
        }

        private static string CreateExceptionMessage(ISwatcherConfig config, uint lastError)
        {
            var builder = new StringBuilder();
            builder.AppendLine($"The {nameof(Swatcher)}'s '{nameof(config.PathToWatch)}' appears to have been deleted; calling {nameof(ISwatcher.Stop)}.");
            builder.AppendLine($"To resume the {nameof(Swatcher)}, recreate the folder and call the {nameof(ISwatcher.Start)} method.");
            builder.AppendLine(
                $"Otherwise, the {nameof(IDisposable.Dispose)} method should be called to cleanup system resources.");
            builder.Append('-', 75);
            builder.Append(Environment.NewLine);
            builder.AppendLine($"{nameof(ISwatcherConfig.Id)} : {config.Id?.ToString() ?? "null"}");
            builder.AppendLine($"{nameof(ISwatcherConfig.PathToWatch)} : {config.PathToWatch}");
            builder.AppendLine($"Windows Error : {lastError}");

            return builder.ToString();
        }
    }
}
