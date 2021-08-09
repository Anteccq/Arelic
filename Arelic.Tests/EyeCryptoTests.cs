using System;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using Arelic.Models.Cryptography;
using Arelic.Models.Services;
using Arelic.Models.Storage;
using Xunit;

namespace Arelic.Tests
{
    public class EyeCryptoTests
    {
        [Theory]
        [InlineData("123456789", "passw0rd")]
        [InlineData("123456789 ", "p@ssW0r$")]
        [InlineData("abcdefghijk ", "123456789")]
        [InlineData("AntiqueR ", "Pendulum")]
        [InlineData("", "")]
        public async Task EncryptDecryptTest(string rawText, string password)
        {
            var rawData = Encoding.UTF8.GetBytes(rawText);
            var cry = new EyeCrypto();
            var encrypted = await cry.EncryptAsync(password, rawData);
            var decryptedData = await cry.DecryptAsync(password, encrypted);
            var actualText = Encoding.UTF8.GetString(decryptedData);
            actualText.Is(rawText);
        }

        [Fact]
        public async Task EncryptAlwaysCreateDifferentData()
        {
            var rawText = "planeText";
            var password = "password";
            var rawData = Encoding.UTF8.GetBytes(rawText);
            var cry = new EyeCrypto();
            var encrypt1 = await cry.EncryptAsync(password, rawData);
            var encrypt2 = await cry.EncryptAsync(password, rawData);
            encrypt2.EncryptedData.IsNot(encrypt1.EncryptedData);

            var decrypt1 = await cry.DecryptAsync(password, encrypt1);
            var decrypt2 = await cry.DecryptAsync(password, encrypt2);
            var actualText1 = Encoding.UTF8.GetString(decrypt1);
            var actualText2 = Encoding.UTF8.GetString(decrypt2);
            actualText1.Is(actualText2);
        }
    }
}
