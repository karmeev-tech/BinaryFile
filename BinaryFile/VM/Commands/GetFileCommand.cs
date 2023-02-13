using BinaryModel;
using Microsoft.Win32;
using System.Threading;
using System.Threading.Tasks;

namespace BinaryFile.VM.Commands
{
    internal class GetFileCommand : BaseCommands
    {
        readonly BinaryVM _viewModel;
        readonly Organizer _manager = new();
        readonly Organizer _manager2 = new();
        readonly Organizer _manager3 = new();

        public GetFileCommand(BinaryVM viewModel)
        {
            _viewModel = viewModel;
        }

        public override async void Execute(object parameter)
        {
            Provider provider = _manager;
            Provider provider2 = _manager2;
            Provider provider3 = _manager3;


            ///<summary>
            /// Реализация для программы ниже
            /// </summary>

            //OpenFileDialog openFileDialogue = new();
            //openFileDialogue.ShowDialog();

            //Task[] tasks = new Task[]
            //{
            //    provider.MakeRequestAsync(openFileDialogue.FileName, _viewModel.Position),
            //    provider2.MakeRequestAsync(openFileDialogue.FileName, _viewModel.Position + 1024 * 2),
            //    provider3.MakeRequestAsync(openFileDialogue.FileName, _viewModel.Position + 1024 * 3)
            //};


            ///<summary>
            /// Заготовка для тестирования больших файлов. Удаляем после цикла разработки
            /// </summary>

            Task[] tasks = new Task[]
            {
                provider.MakeRequestAsync(@"E:\work\projects\BinaryFile\TestFiles\Persona 3 Portable [0100DCD01525A000][v0] (7.11 GB).nsz", _viewModel.Position),
                provider2.MakeRequestAsync(@"E:\work\projects\BinaryFile\TestFiles\Persona 3 Portable [0100DCD01525A000][v0] (7.11 GB).nsz", _viewModel.Position + 1024 * 2),
                provider3.MakeRequestAsync(@"E:\work\projects\BinaryFile\TestFiles\Persona 3 Portable [0100DCD01525A000][v0] (7.11 GB).nsz", _viewModel.Position + 1024 * 3)
            };
            await Task.WhenAll(tasks);
            
            Update(provider, provider2, provider3);
        }

        private void Update(Provider provider, Provider provider2, Provider provider3)
        {
            _viewModel.TopSource = provider.GetProduct();
            _viewModel.MiddleSource = provider2.GetProduct();
            _viewModel.BottomSource = provider3.GetProduct();

            provider.CleanResources();
            provider2.CleanResources();
            provider3.CleanResources();
        }
    }
}
