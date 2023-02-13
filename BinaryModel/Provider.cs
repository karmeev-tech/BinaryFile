using BinaryModel.Interfaces;

namespace BinaryModel
{
    public abstract class Provider
    {
        public abstract string GetProduct();
        public abstract Task MakeRequestAsync(string path, long position);
        public abstract Task MakeRequest(string path, long position);
        public byte[] Bytes { get; set; } = null!;
        public IStringRepresentation StringValue { get; set; } = null!;
    }
}
