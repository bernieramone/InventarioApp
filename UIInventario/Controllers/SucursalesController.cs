﻿using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Web.Mvc;
using UIInventario.Models;

namespace UIInventario.Controllers
{
    public class SucursalesController : Controller
    {
        // GET: Sucursales
        public ActionResult Index()
        {
            List<SucursalModelView> lstSucursales;

            using (var client = new HttpClient())
            {

                var sucursales = client.GetAsync("http://localhost:50647/api/Sucursal/");
                sucursales.Wait();

                if (!sucursales.Result.IsSuccessStatusCode)
                {
                    throw new Exception();
                }

                var readLstProducts = sucursales.Result.Content.ReadAsStringAsync();
                lstSucursales = JsonSerializer.Deserialize<List<SucursalModelView>>(readLstProducts.Result);

            }
            return View(lstSucursales);
        }

        // GET: Sucursales/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Sucursales/Create
        [HttpPost]
        public ActionResult Create(SucursalModelView collection)
        {
            try
            {
                using (var client = new HttpClient())
                {
                    var json = JsonSerializer.Serialize(collection);
                    var response = client.PostAsync("http://localhost:50647/api/Sucursal/", new StringContent(json, Encoding.UTF8, "application/json"));
                    response.Wait();

                    if (!response.Result.IsSuccessStatusCode)
                    {
                        throw new Exception();

                    }

                }
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
             
    }
}
