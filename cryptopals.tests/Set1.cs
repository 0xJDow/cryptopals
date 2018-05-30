using System.Text;
using NUnit.Framework;

namespace cryptopals.tests
{
    [TestFixture]
    public class Set1
    {
        [Test]
        public void Challenge1()
        {
            var result = Helpers.HexStringToBase64("49276d206b696c6c696e6720796f757220627261696e206c696b65206120706f69736f6e6f7573206d757368726f6f6d");
            Assert.AreEqual("SSdtIGtpbGxpbmcgeW91ciBicmFpbiBsaWtlIGEgcG9pc29ub3VzIG11c2hyb29t", result);
        }

        [Test]
        public void Challenge2()
        {
            var firstBuffer = Helpers.HexStringToByteArray("1c0111001f010100061a024b53535009181c");
            var secondBuffer = Helpers.HexStringToByteArray("686974207468652062756c6c277320657965");
            var result = Crypto.FixedXor(firstBuffer, secondBuffer);
            Assert.AreEqual("746865206b696420646f6e277420706c6179", Helpers.ByteArrayToHexString(result));
        }

        [Test]
        public void Challenge3()
        {
            var input = Helpers.HexStringToByteArray("1b37373331363f78151b7f2b783431333d78397828372d363c78373e783a393b3736");
            var result = Crypto.ScoreMessages(Crypto.BuildXorCipherDictionary(input).Values);
            Assert.AreEqual("Cooking MC's like a pound of bacon", result);
        }
    }
}
