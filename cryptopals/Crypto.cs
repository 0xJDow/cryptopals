using System;

namespace cryptopals
{
    public class Crypto
    {
        /// <summary>
        /// Converts a hexadecimal string to base64
        /// </summary>
        /// <param name="hexString">The hexadecimal string to convert</param>
        /// <returns>The base64 representation of the hexadecimal string</returns>
        public static string HexStringToBase64(string hexString)
        {
            // convert the hex string to raw bytes
            // then convert into a base64 encoded string
            return Convert.ToBase64String(HexStringToByteArray(hexString));
        }

        /// <summary>
        /// Converts a hexadecimal string to a byte array
        /// </summary>
        /// <param name="hexString">The hexadecimal string to convert</param>
        /// <returns>The hexadecimal string as a byte array</returns>
        private static byte[] HexStringToByteArray(string hexString)
        {
            // the length of the byte array is going to be half the length of the hex string 
            // since a hex digit is equivalent to half a byte. (hex digit = 4 bits, byte = 8 bits)
            var byteArrayLength = hexString.Length / 2;
            var bytes = new byte[byteArrayLength];
            for (var i = 0; i < byteArrayLength; i++)
            {
                // since 2 hex digits are equivalent to 1 byte we need to work on them in pairs
                // then convert each pair into their corresponding binary values (represented as 8 bit unsigned integers)
                bytes[i] = Convert.ToByte(hexString.Substring(i * 2, 2), 16);
            }

            return bytes;
        }
    }
}
