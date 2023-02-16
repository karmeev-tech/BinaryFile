using BinaryModel;
using Microsoft.Win32;
using System;
using System.Threading.Tasks;

namespace BinaryFile.VM.Commands
{
    internal class GetFileCommand : BaseCommands
    {
        readonly IVMContract _viewModel;
        public GetFileCommand(BinaryVM viewModel)
        {
            _viewModel = viewModel;
        }

        public override void Execute(object parameter)
        {
            OpenFileDialog openFileDialogue = new();
            openFileDialogue.ShowDialog();
            _viewModel.FilePath = openFileDialogue.FileName;
            if(_viewModel.FilePath == null)
            {
                throw new Exception();
            }
            FileManager fm = new(_viewModel);
            fm.GetFile(false);
        }
    }
}
