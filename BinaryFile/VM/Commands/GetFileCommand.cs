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
            const string test = @"E:\systemfolder\1\mgpt_xl.zip";
            await new FileManager(_viewModel,test).GetFile();
            _viewModel.Position += 10;
        }
    }
}
