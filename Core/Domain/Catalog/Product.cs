using System.Collections.Generic;

namespace Core.Domain.Catalog
{
    public class Product
    {
        private readonly IList<Store> _stores = new List<Store>();
        protected Product()
        {
        }

        public Product(string sku, string name)
        {
            SKU = sku;
            Name = name;
        }

        public int Id { get; protected set; }
        public string SKU { get; protected set; }
        public string Name { get; protected set; }

        /// <summary>
        /// List is wrapped in IEnumerable to prevent add();
        /// </summary>
        public IEnumerable<Store> Stores { get { return _stores; } }

        /// <summary>
        /// We provide a specific api
        /// </summary>
        /// <param name="name"></param>
        public void SetName(string name)
        {
            Name = name;
        }

        public void AddStore(Store store)
        {
            //Some validation could happen here
            _stores.Add(store);
        }
        

    }
}
