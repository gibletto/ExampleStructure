namespace Core.Domain.Catalog
{
    public class Store
    {
        protected Store()
        {
        }

        public Store(string storeName)
        {
            StoreName = storeName;
        }

        public int Id { get; protected set; }
        public string StoreName { get; protected set; }
    }
}
