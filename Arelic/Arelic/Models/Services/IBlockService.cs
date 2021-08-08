using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Arelic.Models.Services
{
    internal interface IBlockService
    {
        public Task<List<Block>> GetBlocksAsync(string password, string filePath, CancellationToken cancellationToken = default);

        public Task SetBlocksAsync(string password, string filePath, List<Block> blocks, CancellationToken cancellationToken = default);
    }
}
