using InventarioContext;
using InventarioWebApi.Models;
using SucursalBus;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace InventarioWebApi.Controllers
{
    public class SucursalController : ApiController
    {
        SucursalBusiness sucursalBusiness;

        public SucursalController()
        {
            sucursalBusiness = new SucursalBusiness();
        }

        [HttpGet]
        public HttpResponseMessage GetAll()
        {

            var lstSucursalesApi = sucursalBusiness.GetAll();

            if (lstSucursalesApi == null || !lstSucursalesApi.Any())
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Lista Sucursal Vacia");
            }

            List<SucursalModelView> lstSucursales = new List<SucursalModelView>();

            foreach (var item in lstSucursalesApi)  
            {
                lstSucursales.Add(new SucursalModelView
                {
                    Id = item.ID,
                    Nombre = item.Nombre,
                    Zona = item.Zona,
                    Direccion = item.Direccion

                });

            }

            return Request.CreateResponse(HttpStatusCode.OK, lstSucursales);

        }

        [HttpPost]
        public HttpResponseMessage Create(SucursalModelView sucursal)
        {
            Sucursal sucursalCtx = new Sucursal
            {
                Direccion = sucursal.Direccion,
                Nombre = sucursal.Nombre,
                Zona = sucursal.Zona
            };

            sucursalBusiness.Create(sucursalCtx);

            return Request.CreateResponse(HttpStatusCode.Created);
        }
    }
}
