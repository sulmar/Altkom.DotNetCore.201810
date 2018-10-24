using Altkom.DotNetCore.IServices;
using Altkom.DotNetCore.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace Altkom.DotNetCore.RestApiServices
{
    public class RestApiProductsService : IProductsService
    {
        public void Add(Product entity)
        {
            throw new NotImplementedException();
        }

        public Task AddAsync(Product entity)
        {
            throw new NotImplementedException();
        }

        public IList<Product> Get()
        {
            throw new NotImplementedException();
        }

        public Product Get(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<IList<Product>> GetAsync()
        {
            string url = "http://localhost:5000/";

            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(url);

            HttpResponseMessage response = await client.GetAsync("api/products");

            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();

                IList<Product> products = JsonConvert.DeserializeObject<IList<Product>>(content);

                return products;
            }

            throw new ApplicationException();
        }

        public Task<Product> GetAsync(int id)
        {
            throw new NotImplementedException();
        }

        public void Remove(int id)
        {
            throw new NotImplementedException();
        }

        public Task RemoveAsync(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(Product entity)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(Product entity)
        {
            throw new NotImplementedException();
        }
    }
}
