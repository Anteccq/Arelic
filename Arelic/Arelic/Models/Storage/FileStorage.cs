using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using MessagePack;

namespace Arelic.Models.Storage
{
    public class FileStorage : IStorage
    {
        public async Task<EncryptedMessage> ReadAsync(string path, CancellationToken cancellationToken)
        {
            await using var fs = new FileStream(path, FileMode.Open, FileAccess.Read);
            var message = await MessagePackSerializer.DeserializeAsync<EncryptedMessage>(fs, cancellationToken: cancellationToken);
            return message;
        }

        public async Task WriteAsync(string path, EncryptedMessage message, CancellationToken cancellationToken)
        {
            await using var fs = new FileStream(path, FileMode.Create, FileAccess.Write);
            await MessagePackSerializer.SerializeAsync(fs, message, cancellationToken: cancellationToken);
        }
    }
}
