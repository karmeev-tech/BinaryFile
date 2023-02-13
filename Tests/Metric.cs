using System.Diagnostics;

namespace Tests
{
    internal class Metric
    {
#nullable disable
        public long _resultTime = 0;
        public string _result;
        public string _size = "10 MB";
        public string _path = @"E:\work\projects\BinaryFile\TestFiles\Persona 3 Portable [0100DCD01525A000][v0] (7.11 GB).nsz";
        public async Task Start()
        {
            await Request();
        }
        /// <summary>
        /// Тестирование ассинхронной загрузки хранилища
        /// </summary>
        /// <returns></returns>
        private async Task Request()
        {
            await Task.Run(() =>
            {
                Stopwatch stopwatch = new();
                stopwatch.Start();
                long position = 1024 * 1024 * 10;
                OrganizerExtended organizer = new();
                Task testTask = organizer.MakeRequestAsync(_path, position);
                testTask.Wait();
                stopwatch.Stop();
                _resultTime = stopwatch.ElapsedMilliseconds;
                _result = organizer.GetFullString();
            });
        }
        /// <summary>
        /// Проверка синхронной подгрузки хранилища
        /// </summary>
        private void SyncRequest()
        {
            Stopwatch stopwatch = new();
            stopwatch.Start();
            long position = 1024 * 1024 * 10;
            OrganizerExtended organizer = new();
            organizer.Test_SyncGetter(_path, position);
            stopwatch.Stop();
            _resultTime = stopwatch.ElapsedMilliseconds;
        }
    }
}
