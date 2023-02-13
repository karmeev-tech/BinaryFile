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
            FileManager fileManager = new(_viewModel);
        }
    }
}
