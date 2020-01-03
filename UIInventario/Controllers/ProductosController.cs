using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Web.Mvc;
using UIInventario.Models;

namespace UIInventario.Controllers
{
    public class ProductosController : Controller
    {
        // GET: Productos
        public ActionResult Index()
        {

            List<ProductoViewModel> lstProductos;

            using (var client = new HttpClient())
            {

                var productos = client.GetAsync("http://localhost:50647/api/Product/");
                productos.Wait();

                if (!productos.Result.IsSuccessStatusCode)
                {
                    throw new Exception();
                }

                var readLstProducts = productos.Result.Content.ReadAsStringAsync();
                lstProductos = JsonSerializer.Deserialize<List<ProductoViewModel>>(readLstProducts.Result);

            }
            return View(lstProductos);
        }

       // GET: Productos/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Productos/Create
        [HttpPost]
        public ActionResult Create(ProductoViewModel producto)
        {
            
            

            try
            {
                using (var client = new HttpClient())
                {

                    var json = JsonSerializer.Serialize(producto);
                    var productos = client.PostAsync("http://localhost:50647/api/Product/", new StringContent(json, Encoding.UTF8,"application/json"));
                    productos.Wait();

                    if (!productos.Result.IsSuccessStatusCode)
                    {
                        throw new Exception();
                    }
                                      
                }

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
        
    }
}
