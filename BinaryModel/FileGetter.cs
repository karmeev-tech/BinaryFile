using System.Reflection.PortableExecutable;
using System.Text;

namespace BinaryModel
{
    internal class FileGetter
    {
        public StringBuilder GetFile(string path, long position)
        {
            StringBuilder sb = new();
            using (var stream = File.Open(path, FileMode.Open))
            {
                var reader = new BinaryReader(stream);
                reader.BaseStream.Position = position;
                byte[] data = reader.ReadBytes(1024);
                sb.Append(string.Join(" ",data));
                stream.Flush();
                reader.Close();
            }
            return sb;
        }
    }
}
