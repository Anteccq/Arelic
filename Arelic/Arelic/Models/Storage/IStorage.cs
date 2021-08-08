using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Arelic.Models.Storage
{
    internal interface IStorage
    {
        Task<EncryptedMessage> ReadAsync(string path, CancellationToken cancellationToken);
        Task WriteAsync(string path, EncryptedMessage message, CancellationToken cancellationToken);
    }
}
