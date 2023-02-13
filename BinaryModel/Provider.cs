namespace BinaryModel
{
    public abstract class Provider
    {
        public abstract string GetProduct();
        public abstract Task MakeRequestAsync(string path, long position);
        public abstract void CleanResources();
    }
}
