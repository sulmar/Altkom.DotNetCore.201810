using Altkom.DotNetCore.IServices;
using Altkom.DotNetCore.Models;
using Microsoft.AspNet.SignalR.Client;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Altkom.DotNetCore.WinFormsClient
{
    public partial class FrmProducts : Form
    {
        public FrmProducts()
        {
            InitializeComponent();
        }

        private async void bGetProducts_Click(object sender, EventArgs e)
        {
            //IProductsService productsService = new RestApiProductsService();
            //var products = productsService.GetAsync();
            //productBindingSource.DataSource = products;


            string url = "http://localhost:5000/";

            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(url);

            HttpResponseMessage response = await client.GetAsync("api/products");

            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();

                IList<Product> products = JsonConvert.DeserializeObject<IList<Product>>(content);

                productBindingSource.DataSource = products;
            }
        }

        private void productBindingSource_AddingNew(object sender, AddingNewEventArgs e)
        {

        }

        private async void bAddProduct_Click(object sender, EventArgs e)
        {
            Product product = new Product
            {
                Name = "New Product",
                UnitPrice = 100,
            };

            string url = "http://localhost:5000/";

            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(url);

            string json = JsonConvert.SerializeObject(product);

            HttpContent content = new StringContent(json, Encoding.UTF8, "application/json");

            HttpResponseMessage response = await client.PostAsync("api/products", content);

            if (response.IsSuccessStatusCode)
            {
                await SendProductAsync(product);
            }
        }

        private async Task SendProductAsync(Product product)
        {
            string url = "http://localhost:5010/products";

            HubConnection connection = new HubConnection(url);
            await connection.Start();
            await connection.Send(product);

        }

        private async void bRemoveProduct_Click(object sender, EventArgs e)
        {
            Product product = (Product) productBindingSource.Current;

            string url = "http://localhost:5000/";

            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(url);

            HttpResponseMessage response = await client.DeleteAsync($"api/products/{product.Id}");

            if (response.IsSuccessStatusCode)
            {
                productBindingSource.Remove(product);
            }
        }
    }
}
