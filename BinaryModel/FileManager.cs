using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinaryModel
{
    public class FileManager
    {
        public FileManager(IVMContract viewModel) 
        {
            ViewModel = viewModel;
        }

        EntityService _fm;
        public IVMContract ViewModel { get; }

        public void GetFile(bool UpDown)
        {
            if(UpDown)
            {
                ViewModel.Position -= 100;
            }
            _fm = new(ViewModel, ViewModel.FilePath, ViewModel.Times);
            Task task = new(_fm.FileRequest);
            Task task2 = task.ContinueWith(Update);
            task.Start();
        }
        void Update(Task t)
        {
            ViewModel.Position += ViewModel.Times;
            ViewModel.BasicEntities = _fm._basicEntities;
        }
    }
}
