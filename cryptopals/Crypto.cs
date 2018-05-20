using System;
using System.Net.NetworkInformation;
using System.Threading;

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
        /// Takes two equal-length buffers and producers their xor combination
        /// </summary>
        /// <param name="firstBuffer">The first buffer</param>
        /// <param name="secondBuffer">The second buffer</param>
        /// <returns>The XOR combination of the two buffers</returns>
        public static byte[] FixedXor(byte[] firstBuffer, byte[] secondBuffer)
        {
            // if the buffers aren't of equal length then that's a problem
            if (firstBuffer.Length != secondBuffer.Length)
                throw new ArgumentException("Buffers must be of equal length");

            // instantiate a new byte array to hold the XOR output
            byte[] output = new byte[firstBuffer.Length];

            // iterate over the buffers and perform an XOR operation against each bit
            for (var i = 0; i < firstBuffer.Length; i++)
            {
                output[i] = (byte)(firstBuffer[i] ^ secondBuffer[i]);
            }

            return output;
        }

        /// <summary>
        /// Converts a hexadecimal string to a byte array
        /// </summary>
        /// <param name="hexString">The hexadecimal string to convert</param>
        /// <returns>The hexadecimal string as a byte array</returns>
        public static byte[] HexStringToByteArray(string hexString)
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

        /// <summary>
        /// Converts a byte array to a hexadecimal string
        /// </summary>
        /// <param name="byteArray">The byte array to convert</param>
        /// <returns>The byte array as a hexadecimal string</returns>
        public static string ByteArrayToHexString(byte[] byteArray)
        {
            return BitConverter.ToString(byteArray).Replace("-", "").ToLower();
        }
    }
}
