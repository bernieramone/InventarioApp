using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text.Json;
using System.Web.Mvc;
using UIInventario.Models;

namespace UIInventario.Controllers
{
    public class InventarioController : Controller
    {
        // GET: Inventario
        public ActionResult Index(int id)
        {
            SucursalModelView sucursal = new SucursalModelView();

            using (var client = new HttpClient())
            {

                var inventarios = client.GetAsync("http://localhost:50647/api/Inventario/" + id);
                inventarios.Wait();

                if (!inventarios.Result.IsSuccessStatusCode)
                {
                    throw new Exception();
                }

                var readLstProducts = inventarios.Result.Content.ReadAsStringAsync();
                sucursal = JsonSerializer.Deserialize<SucursalModelView>(readLstProducts.Result);

            }

            return View(sucursal);
        }

        public ActionResult GetAll()
        {
            List<SucursalModelView> lstSucursales = new List<SucursalModelView>();

            using (var client = new HttpClient())
            {
                var inventarios = client.GetAsync("http://localhost:50647/api/Inventario/");
                inventarios.Wait();

                if (!inventarios.Result.IsSuccessStatusCode)
                {
                    throw new Exception();
                }

                var readLstSucursal = inventarios.Result.Content.ReadAsStringAsync();
                var lstSucursalesUnorder = JsonSerializer.Deserialize<List<SucursalModelView>>(readLstSucursal.Result);
                var sucursales = lstSucursalesUnorder.GroupBy(x => new { x.Id, x.Nombre });


                foreach (var sucursal in sucursales)
                {
                    lstSucursales.Add(new SucursalModelView
                    {
                        Id = sucursal.Key.Id,
                        Nombre = sucursal.Key.Nombre,
                        Productos = new List<ProductoViewModel>()
                    });

                }

                foreach (var sucursal in lstSucursales)
                {
                    foreach (var item in lstSucursalesUnorder)
                    {
                        var producto = item.Productos.Where(x => x.IdSucursal == sucursal.Id).FirstOrDefault();
                        if (producto != null)
                        {
                            sucursal.Productos.Add(producto);
                        }
                    }

                }
                #region pruebas

                //GroupBy(r=> new {pp1 =  r.Field<int>("col1"), pp2 = r.Field<int>("col2")});



                //SucursalModelView sucursalModelView = new SucursalModelView();
                //sucursalModelView.Productos = new List<ProductoViewModel>();
                //var lstIdSucursale = lstSucursalesUnorder.GroupBy(x => x.Id).ToList();


                //foreach (var id in lstIdSucursale)
                //{
                //    foreach (var sucu in lstSucursalesUnorder)
                //    {
                //        if (id.Key == sucu.Id)
                //        {
                //            sucursalModelView.Nombre = sucu.Nombre;
                //            sucursalModelView.Id = sucu.Id;
                //            lstSucursales.Add(sucursalModelView);
                //        }

                //    }

                //}


                //foreach (var sucu in lstSucursalesUnorder)
                //{
                //    foreach (var id in lstIdSucursale)
                //    {
                //        if (id.Key == sucu.Id)
                //        {
                //            sucursalModelView.Nombre = sucu.Nombre;
                //            sucursalModelView.Id = sucu.Id;
                //            lstSucursales.Add(sucursalModelView);
                //        }

                //    }

                //}


                //    var productoIdSuc = sucu.Productos.Where(x => x.IdSucursal == sucursalModelView.Id).ToList();
                //    ProductoViewModel productoModel = new ProductoViewModel
                //    {
                //        Cantidad = productoIdSuc[0].Cantidad,
                //        IdSucursal = productoIdSuc[0].IdSucursal,
                //        CodigoBarras = productoIdSuc[0].CodigoBarras,
                //        Nombre = productoIdSuc[0].Nombre,
                //        PrecioUnitario = productoIdSuc[0].PrecioUnitario
                //    };

                //    sucursalModelView.Productos.Add(productoModel);

                //}
                #endregion pruebas
            }

            ViewBag.IdSucursales = lstSucursales.GroupBy(x => x.Id).ToList();

            return View(lstSucursales);
        }

        public ActionResult Create()
        {
            List<SucursalModelView> lstSucursales = new List<SucursalModelView>();

            using (var client = new HttpClient())
            {
                var inventarios = client.GetAsync("http://localhost:50647/api/Inventario/");
                inventarios.Wait();

                var productos = client.GetAsync("http://localhost:50647/api/Product/");
                productos.Wait();

                var sucursales = client.GetAsync("http://localhost:50647/api/Sucursal/");
                sucursales.Wait();




                if (!inventarios.Result.IsSuccessStatusCode)
                {
                    throw new Exception();
                }

                
            }

           // ViewBag.IdSucursales = lstSucursales.GroupBy(x => x.Id).ToList();

            //return View(lstSucursales);

            return View();
        }
    }
}