namespace Binary.Model
{
    public abstract class Provider
    {
        public abstract string GetProduct();
        public abstract Task MakeRequest(string path, long position);
        public string StringValue { get; set; } = null!;
    }
}
