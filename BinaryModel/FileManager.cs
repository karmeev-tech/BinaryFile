using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BinaryModel
{
    public class FileManager
    {
        readonly Organizer _manager = new();
        readonly Organizer _manager2 = new();
        readonly Organizer _manager3 = new();
        readonly IVMContract _vm;

        public FileManager(IVMContract vm)
        {
            _vm = vm;
        }

        public async void GetFile()
        {
            Provider provider = _manager;
            Provider provider2 = _manager2;
            Provider provider3 = _manager3;

#region real
            ///<summary>
            /// Реализация для программы ниже
            /// </summary>

            //OpenFileDialog openFileDialogue = new();
            //openFileDialogue.ShowDialog();

            //Task[] tasks = new Task[]
            //{
            //    provider.MakeRequestAsync(openFileDialogue.FileName, _vm.Position),
            //    provider2.MakeRequestAsync(openFileDialogue.FileName, _vm.Position + 1024 * 2),
            //    provider3.MakeRequestAsync(openFileDialogue.FileName, _vm.Position + 1024 * 3)
            //};
#endregion

            ///<summary>
            /// Заготовка для тестирования больших файлов. Удаляем после цикла разработки
            /// </summary>

            Task[] tasks = new Task[]
            {
                provider.MakeRequestAsync(@"E:\systemfolder\1\mgpt_xl.zip", _vm.Position),
                provider2.MakeRequestAsync(@"E:\systemfolder\1\mgpt_xl.zip", _vm.Position + 1024 * 2),
                provider3.MakeRequestAsync(@"E:\systemfolder\1\mgpt_xl.zip", _vm.Position + 1024 * 3)
            };
            await Task.WhenAll(tasks);
            Update(provider, provider2, provider3);
        }

        private void Update(Provider provider, Provider provider2, Provider provider3)
        {
            // _viewModel.TopSource = provider.GetProduct();
            // _viewModel.MiddleSource = provider2.GetProduct();
            // _viewModel.BottomSource = provider3.GetProduct();

            provider.CleanResources();
            provider2.CleanResources();
            provider3.CleanResources();
        }
    }
}