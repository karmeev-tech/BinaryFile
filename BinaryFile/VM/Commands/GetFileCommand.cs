using BinaryModel;

namespace BinaryFile.VM.Commands
{
    internal class GetFileCommand : BaseCommands
    {
        readonly IVMContract _viewModel;
        public GetFileCommand(BinaryVM viewModel)
        {
            _viewModel = viewModel;
        }

        public override async void Execute(object parameter)
        {
            //OpenFileDialog openFileDialogue = new();
            //openFileDialogue.ShowDialog();
            // u must get openFileDialogue.FileName; test must be delete
            string test = @"E:\systemfolder\1\mgpt_xl.zip";
            FileManager fileManager = new(_viewModel,test);
            await fileManager.GetFile();
        }
    }
}
