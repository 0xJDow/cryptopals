using System;
using System.Collections.Generic;
using System.Linq;

namespace cryptopals
{
    public class Helpers
    {
        // English alphabet ordered by character freqency
        // https://en.wikipedia.org/wiki/Letter_frequency
        public static readonly Dictionary<char, int> EnglishCharacterFreqencies = new Dictionary<char, int>
        {
            ['e'] = 26,
            ['t'] = 25,
            ['a'] = 24,
            ['o'] = 23,
            ['i'] = 22,
            ['n'] = 21,
            ['s'] = 20,
            ['h'] = 19,
            ['r'] = 18,
            ['d'] = 17,
            ['l'] = 16,
            ['c'] = 15,
            ['u'] = 14,
            ['m'] = 13,
            ['w'] = 12,
            ['f'] = 11,
            ['g'] = 10,
            ['y'] = 9,
            ['p'] = 8,
            ['b'] = 7,
            ['v'] = 6,
            ['k'] = 5,
            ['j'] = 4,
            ['x'] = 3,
            ['q'] = 2,
            ['z'] = 1
        };

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