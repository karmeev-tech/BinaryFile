using BinaryModel;

namespace Tests
{
    /// <summary>
    /// Class for speed checking.
    /// </summary>
    /// <returns></returns>
    internal class OrganizerExtended : Organizer
    {
        public string GetFullString()
        {
            return GetProduct();
        }

        public async Task MakeRequestAsync(string path, long position)
        {
            await StartGetter(path, position);
        }

        protected override async Task<string> StartGetter(string path, long position)
        {
            List<Task> tasks = new()
            {
                GetPart(path, position),
                GetPart(path, position * 2),
                GetPart(path, position * 3)
            };
            await tasks[0];
            await tasks[1];
            await tasks[2];
            return GetBytes(tasks);
        }
        protected string GetBytes(List<Task> tasks)
        {
            Task complete = Task.WhenAll(tasks);
            complete.Wait();
            return GetProduct();
        }
        public void Test_SyncGetter(string path, long position)
        {
            GetPart(path, position);
            GetPart(path, position * 2);
            GetPart(path, position * 3);
        }
    }
}
