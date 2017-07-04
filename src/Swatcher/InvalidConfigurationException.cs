using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BraveLantern.Swatcher
{
    /// <summary>
    /// Class InvalidConfigurationException. This class cannot be inherited.
    /// </summary>
    /// <seealso cref="System.ApplicationException" />
    public sealed class InvalidConfigurationException : ApplicationException
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="InvalidConfigurationException"/> class.
        /// </summary>
        /// <param name="message">A message that describes the error.</param>
        public InvalidConfigurationException(string message):base(message)
        {}
    }
}
