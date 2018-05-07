using NUnit.Framework;

namespace cryptopals.tests
{
    [TestFixture]
    public class Set1
    {
        [Test]
        public void Challenge1()
        {
            var result = Crypto.HexStringToBase64("49276d206b696c6c696e6720796f757220627261696e206c696b65206120706f69736f6e6f7573206d757368726f6f6d");
            Assert.AreEqual("SSdtIGtpbGxpbmcgeW91ciBicmFpbiBsaWtlIGEgcG9pc29ub3VzIG11c2hyb29t", result);
        }
    }
}
