namespace BinaryModel
{
    public class Organizer : Provider
    {
        private readonly FileGetter _fg = new();
        private string _fileBytes = "";

        public override string GetProduct()
        {
            return _fileBytes;
        }

        public override async Task MakeRequestAsync(string path, long position)
        {
            await StartGetter(path, position);
        }
        public override Task MakeRequest(string path, long position)
        {
            StartGetter(path, position);
            return Task.CompletedTask;
        }
        protected virtual Task StartGetter(string path, long position)
        {
            GetPart(path, position);
            return Task.CompletedTask;
        }
        protected Task GetPart(string path, long position)
        {
            _fileBytes = _fg.GetFile(path, position).ToString();
            Bytes = _fg._bytes;
            StringValue = new ByteConverter(_fg._bytes);
            return Task.CompletedTask;
        }
    }
}