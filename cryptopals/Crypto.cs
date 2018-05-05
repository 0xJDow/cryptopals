using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cryptopals
{
    public class Crypto
    {
        /// <summary>
        /// Converts a hexadecimal string to its base64 representation
        /// </summary>
        /// <param name="hexString">The hexadecimal string to conver to base64</param>
        /// <returns>The base64 representation of the hexadecimal string</returns>
        public static string HexStringToBase64(string hexString)
        {
            // base64 encode our byte array and return it
            return Convert.ToBase64String(HexStringToByteArray(hexString));
        }

        /// <summary>
        /// Takes a hexadecimal string and returns its corresponding byte array
        /// </summary>
        /// <param name="hexString">A hexadecimal string</param>
        /// <returns>The hexadecimal string as byte array</returns>
        private static byte[] HexStringToByteArray(string hexString)
        {
            // divide by two since we're going from an array of hex digits (1 nibble)
            // to an array of bytes (2 nibbles)
            var byteArrayLength = hexString.Length / 2;
            var bytes = new byte[byteArrayLength];
            for (var i = 0; i < byteArrayLength; i++)
            {
                // split the contents into separate hex-number pairs
                // then convert each into their byte value
                bytes[i] = Convert.ToByte(hexString.Substring(i * 2, 2), 16);
            }

            return bytes;
        }
    }
}
