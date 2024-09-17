using BazarLib.Models;
using BazarLib.Models.ApiModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

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
            await _httpClient.PutAsJsonAsync($"/api/Productos/EditProducto/{producto.ProduId}", producto);
        }

        public async Task DeleteProducto(int id)
        {
            await _httpClient.DeleteAsync($"/api/Productos/DeleteProducto/{id}");
        }


        public async Task<IEnumerable<Productos>> GetOfertas()
        {
            var lista = await _httpClient.GetFromJsonAsync<IEnumerable<Productos>>("api/Productos/GetProductos");
            var ofertas = lista.Where(x => x.IsOferta == true).ToList();
            return ofertas;
        }


        //Facturas y detalles

        public async Task<IEnumerable<Facturas>> GetFacturas()
        {
            return await _httpClient.GetFromJsonAsync<IEnumerable<Facturas>>("api/Facturas/GetFacturas");
        }

        public async Task<Facturas> GetFacturasCod(DateTime fecha)
        {
            var facts = await _httpClient.GetFromJsonAsync<IEnumerable<Facturas>>("api/Facturas/GetFacturas");
            var myfacts = facts.Where(x => x.Fecha == fecha).First();
            return myfacts;
        }

        public async Task<IEnumerable<Facturas>> GetFacturasUsu(string name)
        {
            var facts =  await _httpClient.GetFromJsonAsync<IEnumerable<Facturas>>("api/Facturas/GetFacturas");
            var myfacts = facts.Where(x => x.NombreUsu == name);
            return myfacts;
        }

        public async Task<Facturas> GetFacturaById(int id)
        {
            return await _httpClient.GetFromJsonAsync<Facturas>($"/api/Facturas/GetFacturaById/{id}");
        }

        public async Task AddFactura(Facturas factura)
        {
            await _httpClient.PostAsJsonAsync("/api/Facturas/AddFactura", factura);
        }
        public async Task AddDetalleFactura(FacturasDetalle factura)
        {
            await _httpClient.PostAsJsonAsync("/api/DetalleFacturas/AddDetalleFactura", factura);
        }

        public async Task<IEnumerable<FacturasDetalle>> GetDetalleFacturas()
        {
            return await _httpClient.GetFromJsonAsync<IEnumerable<FacturasDetalle>>("api/DetalleFacturas/GetDetalleFacturas");
        }

        public async Task<IEnumerable<FacturasDetalle>> GetDetalleFacturasId(int id)
        {
            var facts = await _httpClient.GetFromJsonAsync<IEnumerable<FacturasDetalle>>("api/DetalleFacturas/GetDetalleFacturas");
            var myfacts = facts.Where(x => x.CodFac == id);
            return myfacts;
        }

        //Usuarios

        public async Task<IEnumerable<Usuarios>> GetUsuarios()
        {
            return await _httpClient.GetFromJsonAsync<IEnumerable<Usuarios>>("api/Usuarios/GetUsuarios");
        }

        public async Task<Usuarios> ValidateUsuario(string email, string pass)
        {
            var usuarios = await _httpClient.GetFromJsonAsync<IEnumerable<Usuarios>>("api/Usuarios/GetUsuarios");
            var myuser = usuarios.Where(x => x.Email == email && x.Password == pass).First();
            return myuser;
        }

        public async Task AddUsuario(Usuarios usuario)
        {
            await _httpClient.PostAsJsonAsync("/api/Usuarios/AddUsuario", usuario);
        }

        public async Task EditUsuario(int id, Usuarios usuario)
        {
            await _httpClient.PutAsJsonAsync($"/api/Usuarios/EditUsuario/{id}", usuario);
        }

        public async Task<Usuarios> GetUsuarioById(int id)
        {
            return await _httpClient.GetFromJsonAsync<Usuarios>($"/api/Usuarios/GetUsuarioById/{id}");
        }
    }
}
