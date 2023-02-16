using System.Collections.ObjectModel;

namespace Binary.Model
{
    public interface IVMContract
    {
        public int Position { get; set; }
        public List<BasicEntity> BasicEntities { get; set; }
        public int Times { get; set; }
        public string FilePath { get; set; }
    }
}