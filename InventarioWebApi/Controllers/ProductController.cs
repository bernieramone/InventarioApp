using InventarioWebApi.Models;
using ProductoBus;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using InventarioContext;

namespace InventarioWebApi.Controllers
{
    public class ProductController : ApiController
    {
        ProductoBusiness ProductoBus;

        public ProductController()
        {
            ProductoBus = new ProductoBusiness();
        }

        [HttpGet]
        public HttpResponseMessage GetAll()
        {
            List<ProductoViewModel> lstProductosMap = new List<ProductoViewModel>();
            var lstProductos = ProductoBus.GetListProductos();

            if (lstProductos == null || !lstProductos.Any())
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Lista Inventarios Vacia");
            }

            foreach (var item in lstProductos)
            {
                lstProductosMap.Add(new ProductoViewModel { 
                    CodigoBarras = item.CodigoBarras,
                    Nombre = item.Nombre,
                    PrecioUnitario = item.PrecioUnitario,
                    Cantidad = "",
                    IdSucursal = 0
                });

            }

            return Request.CreateResponse(HttpStatusCode.OK, lstProductosMap);
                                 
        }

        [HttpPost]
        public HttpResponseMessage Create(ProductoViewModel producto)
        {
            Producto productoCtx = new Producto
            {
                CodigoBarras = producto.CodigoBarras,
                ID = producto.IdSucursal,
                Inventarios = null,
                Nombre = producto.Nombre,
                PrecioUnitario = producto.PrecioUnitario
            };
            
            ProductoBus.Create(productoCtx);

            return Request.CreateResponse(HttpStatusCode.Created);
        }

    }
}
