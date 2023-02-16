namespace BinaryModel
{
    public class EntityService
    {
        private readonly Provider _provider = new Organizer();
        private readonly IVMContract _vm;
        private readonly int _times;
        public string _filePath;
        public List<BasicEntity> _basicEntities = new();
        public EntityService(IVMContract vm, string filePath, int times)
        {
            _vm = vm;
            _filePath = filePath;
            _times = times;
        }

        public void FileRequest()
        {
            for (int times = 0; times <= _times; times++)
            {
                _provider.MakeRequest(_filePath, _vm.Position+times);
                BasicEntity entity = CreateEntity(_vm.Position+times);
                _basicEntities.Add(entity);
            }
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