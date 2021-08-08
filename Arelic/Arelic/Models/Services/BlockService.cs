using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Arelic.Models.Cryptography;
using Arelic.Models.Storage;
using MessagePack;

namespace Arelic.Models.Services
{
    public class BlockService : IBlockService
    {
        private readonly ICrypto _crypto;
        private readonly IStorage _storage;

        public BlockService(ICrypto crypto, IStorage storage)
        {
            _crypto = crypto;
            _storage = storage;
        }

        public async Task<List<Block>> GetBlocksAsync(string password, string filePath, CancellationToken cancellationToken = default)
        {
            var message = await _storage.ReadAsync(filePath, cancellationToken);
            var decryptedData = await _crypto.DecryptAsync(password, message, cancellationToken);
            await using var ms = new MemoryStream();
            await ms.WriteAsync(decryptedData.AsMemory(0, decryptedData.Length), cancellationToken);
            ms.Position = 0;
            var blocks = await MessagePackSerializer.DeserializeAsync<List<Block>>(ms, cancellationToken: cancellationToken);
            return blocks;
        }

        public async Task SetBlocksAsync(string password, string filePath, List<Block> blocks, CancellationToken cancellationToken = default)
        {
            await using var ms = new MemoryStream();
            await MessagePackSerializer.SerializeAsync(ms, blocks, cancellationToken: cancellationToken);
            var encryptedData = await _crypto.EncryptAsync(password, ms.ToArray(), cancellationToken);
            await _storage.WriteAsync(filePath, encryptedData, cancellationToken);
        }
    }
}
