using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Arelic.Models.Cryptography
{
    public interface ICrypto
    {
        public Task<EncryptedMessage> EncryptAsync(string password, byte[] rawData, CancellationToken cancellationToken = default);
        public Task<byte[]> DecryptAsync(string password, EncryptedMessage message, CancellationToken cancellationToken = default);
    }
}
