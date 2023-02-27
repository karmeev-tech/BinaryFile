using System.Text;
using Microsoft.Extensions.Primitives;

namespace BinaryModel
{
    internal class FileGetter
    {
        public byte[] _bytes = null!;
        public StringBuilder GetFile(string path, long position)
        {
            if(path== null) return null;
            StringBuilder sb = new();
            using (var stream = File.Open(path, FileMode.Open))
            {
                var reader = new BinaryReader(stream);
                reader.BaseStream.Position = position;
                byte[] data = reader.ReadBytes(10);
                _bytes = data;
                sb.AppendJoin(" ", BitConverter.ToString(data));
                stream.Flush();//IDispose
                reader.Close();
            }
            return sb;
        }
    }
}
