namespace BinaryModel
{
    public class FileManager
    {
        readonly Provider _provider = new Organizer();
        readonly IVMContract _vm;
        public string _filePath;
        public List<BasicEntity> _basicEntities = new();
        public FileManager(IVMContract vm, string filePath)
        {
            _vm = vm;
            _filePath = filePath;
        }

        public Task GetFile()
        {
            for (int times = 0; times < 10; times++)
            {
                _provider.MakeRequest(_filePath, _vm.Position);
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
                Position = position
            };
        }
    }
}