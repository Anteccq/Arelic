using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Arelic.Models;
using Arelic.Models.Services;
using Arelic.Models.Storage;
using MessagePack;
using Reactive.Bindings;

namespace Arelic.ViewModels.MainWindowPages
{
    public class AuthPageViewModel
    {
        private readonly IBlockService _blockService;
        public ReactiveProperty<string> Password { get; }
        public AsyncReactiveCommand UnlockCommand { get; }
        public ReactiveProperty<UnlockStatus> UnlockStatus { get; }
        public ReactiveProperty<List<Block>> Blocks { get; }

        public AuthPageViewModel(IBlockService blockService)
        {
            _blockService = blockService;
            Password = new ReactiveProperty<string>();
            UnlockStatus = new ReactiveProperty<UnlockStatus>(Models.UnlockStatus.None);
            Blocks = new ReactiveProperty<List<Block>>();

            UnlockCommand = new AsyncReactiveCommand();
            UnlockCommand.Subscribe(async () =>
            {
                try
                {
                    var blocks = await _blockService.GetBlocksAsync(Password.Value, FileStorage.DefaultPath);
                    Blocks.Value = blocks;
                }
                catch (FileNotFoundException)
                {
                    UnlockStatus.Value = Models.UnlockStatus.NotFound;
                }
                catch (MessagePackSerializationException)
                {
                    UnlockStatus.Value = Models.UnlockStatus.Failed;
                }
                catch (IOException)
                {
                    UnlockStatus.Value = Models.UnlockStatus.Unknown;
                }
            });
        }

    }
}
