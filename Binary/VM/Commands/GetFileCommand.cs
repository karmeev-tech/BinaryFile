using Binary.Model;

namespace Binary.VM.Commands
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
            var result = await FilePicker.Default.PickAsync(new PickOptions { PickerTitle = "ChooseFile"});
            if (result == null)
                return;

            _viewModel.FilePath = result.FullPath;
            FileManager fm = new(_viewModel);
            fm.GetFile();
        }
    }
}
