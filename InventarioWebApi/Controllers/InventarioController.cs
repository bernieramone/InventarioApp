using InventarioBus;
using InventarioWebApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace InventarioWebApi.Controllers
{
    public class InventarioController : ApiController
    {
        ProductoBusinnes InvetarioBusiness;

        public InventarioController()
        {
            InvetarioBusiness = new ProductoBusinnes();
        }
        [HttpGet]
        public HttpResponseMessage GetProductsBySucursal(int id)
        {
            try
            {
                var lstProducots = InvetarioBusiness.GetInventarioByIdSucursal(id);

                if (lstProducots == null || !lstProducots.Any())
                {
                    return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Lista de inventarios vacia");
                }

                SucursalModelView sucursalResponse = new SucursalModelView();
                List<ProductoViewModel> lstProductosViewModel = new List<ProductoViewModel>();

                foreach (var item in lstProducots)
                {
                    sucursalResponse.Nombre = item.Sucursal.Nombre;

                    lstProductosViewModel.Add(new ProductoViewModel { 
                        Cantidad = item.Cantidad.ToString(),
                        CodigoBarras = item.Producto.CodigoBarras,
                        Nombre = item.Producto.Nombre,
                        PrecioUnitario = item.Producto.PrecioUnitario
                    });
                }

                sucursalResponse.Productos = lstProductosViewModel;
               
                var message = Request.CreateResponse(HttpStatusCode.OK, sucursalResponse);

                return message;

            }
            catch (Exception ex)
            {

                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex);
            }
        }

        [HttpGet]
        public HttpResponseMessage GetAll()
        {
            try
            {
                var lstInvetarioAll = InvetarioBusiness.GetAllInventarios();
                List<SucursalModelView> lstSucursales = new List<SucursalModelView>();

                if (lstInvetarioAll == null || !lstInvetarioAll.Any())
                {
                    return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Lista Inventarios Vacia");
                }

                foreach (var item in lstInvetarioAll)
                {
                    lstSucursales.Add(new SucursalModelView
                    {
                        Nombre = item.Sucursal.Nombre,
                        Id = (int)item.IdSucursal,
                        Productos = new List<ProductoViewModel>
                        {
                            new ProductoViewModel
                            {
                                IdSucursal = (int)item.IdSucursal,
                                Nombre = item.Producto.Nombre,
                                Cantidad = item.Cantidad.ToString(),
                                CodigoBarras = item.Producto.CodigoBarras,
                                PrecioUnitario = item.Producto.PrecioUnitario
                            }
                        }
                        
                    });

                }

                var message = Request.CreateResponse(HttpStatusCode.OK, lstSucursales);

                return message;

            }
            catch (Exception ex)
            {

                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex);
                
            }
        }

    }
}
