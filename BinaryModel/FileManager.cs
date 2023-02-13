using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BinaryModel
{
    public class FileManager
    {
        readonly Provider _provider = new Organizer();
        // readonly Provider _provider2 = new Organizer();
        // readonly Provider _provider3 = new Organizer();
        public string _filePath;
        readonly IVMContract _vm;

        public FileManager(IVMContract vm, string filePath)
        {
            _vm = vm;
            _filePath = filePath;
        }

        public async Task GetFile()
        {
            Task[] tasks = new Task[]
            {
                _provider.MakeRequestAsync(_filePath, _vm.Position),
                // provider2.MakeRequestAsync(_filePath, _vm.Position + 1024 * 2),
                // provider3.MakeRequestAsync(_filePath, _vm.Position + 1024 * 3)
            };
            await Task.WhenAll(tasks);
            //Update(_provider, _provider2, _provider3);
        }

        // private void Update(Provider provider, Provider provider2, Provider provider3)
        // {
        //     // _viewModel.TopSource = provider.GetProduct();
        //     // _viewModel.MiddleSource = provider2.GetProduct();
        //     // _viewModel.BottomSource = provider3.GetProduct();

        //     provider.CleanResources();
        //     provider2.CleanResources();
        //     provider3.CleanResources();
        // }
    }
}