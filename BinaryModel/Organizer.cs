namespace BinaryModel
{
    /// <summary>
    /// This class can be extended for getting more bytes in one time
    /// </summary>
    public class Organizer : Provider
    {
        private readonly FileGetter _fg = new();
        private string _fileBytes = "";

        public override string GetProduct()
        {
            return _fileBytes;
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
            _fileBytes = _fg.GetFile(path, position).ToString();//16bit
            StringValue = System.Text.Encoding.Unicode.GetString(_fg._bytes);//Unicode
            return Task.CompletedTask;
        }
    }
}