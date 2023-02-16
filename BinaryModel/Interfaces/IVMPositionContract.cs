using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinaryModel.Interfaces
{
    public interface IVMPositionContract
    {
        public string FilePath { get; set; }
        public int Position { get; set; }
        public int Index { get; set; }
        public string UserInputPosition { get; set; }
    }
}
