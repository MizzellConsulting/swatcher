using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BraveLantern.Swatcher.Extensions
{
    internal static class MiscExtensions
    {
        internal static string GetDescription<T>(this T enumerationValue)
            where T : struct
        {
            var type = enumerationValue.GetType();
            if (!type.IsEnum)
            {
                throw new ArgumentException($"{nameof(enumerationValue)} must be of Enum type", nameof(enumerationValue));
            }
            var memberInfo = type.GetMember(enumerationValue.ToString());
            if (memberInfo.Length > 0)
            {
                var attrs = memberInfo[0].GetCustomAttributes(typeof(DescriptionAttribute), false);

                if (attrs.Length > 0)
                {
                    return ((DescriptionAttribute)attrs[0]).Description;
                }
            }
            return enumerationValue.ToString();
        }

        internal static HResult ToHResult(this uint code)
        {
            var numericValue = code <= 0 
                ? code
                : ((code & 0x0000FFFF) | unchecked((int)0x80070000));

            return (HResult) numericValue;
        }

        internal static Exception InnermostException(this Exception source)
        {
            while (source.InnerException != null)
            {
                source = source.InnerException;
            }
            return source;
        }
    }
}
