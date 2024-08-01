using BazarLib.Models;
using BazarLib.Models.ApiModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace BazarLib
{
    public class BazarClientService
    {
        private readonly HttpClient _httpClient;

        public BazarClientService(BazarClientOptions bazarClientOptions)
        {
            _httpClient = new HttpClient();
            _httpClient.BaseAddress = new System.Uri(bazarClientOptions.ApiBaseAddress);
        }

        //Productos
        public async Task<IEnumerable<Productos>> GetProductos()
        {
            return await _httpClient.GetFromJsonAsync<IEnumerable<Productos>>("api/Productos/GetProductos");
        }

        public async Task<Productos> GetProductoById(int id)
        {
            return await _httpClient.GetFromJsonAsync<Productos>($"/api/Productos/GetProductoById/{id}");
        }

        public async Task AddProducto(Productos producto)
        {
            await _httpClient.PostAsJsonAsync("/api/Productos/AddProducto", producto);
        }

        public async Task EditProducto(Productos producto)
        {
            await _httpClient.PutAsJsonAsync("/api/Productos/EditProducto", producto);
        }

        public async Task DeleteProducto(int id)
        {
            await _httpClient.DeleteAsync($"/api/Productos/DeleteProducto/{id}");
        }
    }
}
