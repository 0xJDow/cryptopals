using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Threading;

namespace cryptopals
{
    public class Crypto
    {
        /// <summary>
        /// Takes two equal-length buffers and producers their xor combination
        /// </summary>
        /// <param name="firstBuffer">The first buffer</param>
        /// <param name="secondBuffer">The second buffer</param>
        /// <returns>The XOR combination of the two buffers</returns>
        public static byte[] FixedXor(byte[] firstBuffer, byte[] secondBuffer)
        {
            // if the buffers aren't of equal length
            if (firstBuffer.Length != secondBuffer.Length)
                // then that's a problem
                throw new ArgumentException("Buffers must be of equal length");

            // instantiate a new byte array to hold the XOR output
            var output = new byte[firstBuffer.Length];

            // iterate over the buffers and perform an XOR operation against each bit
            for (var i = 0; i < firstBuffer.Length; i++)
            {
                output[i] = (byte)(firstBuffer[i] ^ secondBuffer[i]);
            }

            return output;
        }

        /// <summary>
        /// Scores a given IEnumerable of byte arrays based on english character frequency
        /// </summary>
        /// <param name="input">The IEnumerable of byte arrays to be scored</param>
        /// <returns>The byte array with the highest score </returns>
        public static byte[] ScoreMessages(IEnumerable<byte[]> input)
        {
            // compare the score of each index until we find the highest score
            // and thus most likely the correct message
            return input.Aggregate((agg, next) =>
                ScoreEnglishFrequency(next) > ScoreEnglishFrequency(agg) ? next : agg);
        }

        /// <summary>
        /// Scores a given IReadOnlyCollection of bytes based on english character frequency
        /// </summary>
        /// <param name="input">The IReadOnlyCollection of bytes to be scored</param>
        /// <returns>The score</returns>
        private static int ScoreEnglishFrequency(IReadOnlyCollection<byte> input)
        {
            return input.Select<byte, int>(i =>
            {
                Helpers.EnglishCharacterFreqencies.TryGetValue((char)i, out var score);
                return score;
            }).Sum() / input.Count;
        }

        /// <summary>
        /// Takes a byte array that has been XOR'd against a single character
        /// performs an XOR operation against every unicode-16 character aganist it
        /// </summary>
        /// <param name="input">The byte array that has been XOR'd against a single character</param>
        /// <returns>A dictionary of possibile decrypted messages to be scored</returns>
        public static Dictionary<char, byte[]> BuildXorCipherDictionary(byte[] input)
        {
            var xorCipherDictionary = new Dictionary<char, byte[]>();
            for (var c = ' '; c <= '~'; c++)
            {
                xorCipherDictionary.Add(c, SingleByteXorCipher(c, input));
            }

            return xorCipherDictionary;
        }

        /// <summary>
        /// Takes a byte array and performs an XOR operation against every index
        /// </summary>
        /// <param name="key">The character we are going to perform the XOR operation against</param>
        /// <param name="input">The byte array we are going to perform the XOR operation against</param>
        /// <returns>The XOR combination of the byte array and the key</returns>
        public static byte[] SingleByteXorCipher(char key, byte[] input)
        {
            var output = new byte[input.Length];
            for (var i = 0; i < input.Length; i++)
            {
                output[i] = (byte) (input[i] ^ key);
            }

            return output;
        }
    }
}
