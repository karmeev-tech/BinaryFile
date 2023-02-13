namespace BinaryModel
{
    public class Organizer : Provider
    {
#nullable disable
        private readonly FileGetter _fg = new();
        public string _fileBytes;

        public override string GetProduct()
        {
            return _fileBytes;
        }

        public override async Task MakeRequestAsync(string path, long position)
        {
            await StartGetter(path, position);
        }

        public override void CleanResources()
        {
            _fileBytes = null;
        }

        protected virtual async Task<string> StartGetter(string path, long position)
        {
            List<Task> tasks = new()
            {
                GetPart(path, position)
            };
            await tasks[0];
            return GetBytes(tasks);
        }
        protected string GetBytes(List<Task> tasks)
        {
            Task complete = Task.WhenAll(tasks);
            complete.Wait();
            return _fileBytes;
        }
        protected Task GetPart(string path, long position)
        {
            _fileBytes = _fg.GetFile(path, position).ToString();
            return Task.CompletedTask;
        }
    }
}
