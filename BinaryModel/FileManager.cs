namespace BinaryModel
{
    public class FileManager
    {
        private readonly Provider _provider = new Organizer();
        private readonly IVMContract _vm;
        private readonly int _times;
        public string _filePath;
        public List<BasicEntity> _basicEntities = new();
        public FileManager(IVMContract vm, string filePath, int times)
        {
            _vm = vm;
            _filePath = filePath;
            _times = times;
        }

        public Task GetFile()
        {
            for (int times = 0; times <= _times; times++)
            {
                _provider.MakeRequest(_filePath, _vm.Position+times);
                BasicEntity entity = CreateEntity(_vm.Position+times);
                _basicEntities.Add(entity);
            }
            return Task.CompletedTask;
        }

        private BasicEntity CreateEntity(int position)
        {
            return new BasicEntity()
            {
                StringRepresentation = _provider.StringValue,
                Bytes = _provider.GetProduct(),
                Position = "0x" + BitConverter.ToString(BitConverter.GetBytes(position)).Replace("-","")
            };
        }
    }
}