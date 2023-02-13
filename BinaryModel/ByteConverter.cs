using BinaryModel.Interfaces;

namespace BinaryModel
{
    /// <summary>
    /// You can edit encoding in this class
    /// </summary>
    public class ByteConverter : IStringRepresentation
    {
        private readonly byte[] _bytes;

        public ByteConverter(byte[] bytes)
        {
            _bytes = bytes;
        }

        public string Value { get => ByteToStringConvert(); }
        private string ByteToStringConvert()
        {
            return System.Text.Encoding.Default.GetString(_bytes);
        }
    }
}