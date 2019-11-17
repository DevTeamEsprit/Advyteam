﻿using ADVYTEAM.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;

namespace ADVYTEAM.Presentation.Models
{
    public class PublicationController : Controller
    {
        // GET: Publication
        public ActionResult Index()
        {

            HttpClient Client = new HttpClient();
            Client.BaseAddress = new Uri("http://localhost:9080");
            Client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
            HttpResponseMessage responce = Client.GetAsync("/PIDEV-web/PIDEV/gestionEmploye/publication").Result;
            HttpResponseMessage responce2;
            if (responce.IsSuccessStatusCode)
            {
                IEnumerable<publication> lstPub = responce.Content.ReadAsAsync<IEnumerable<publication>>().Result;

                foreach (var pub in lstPub)
                {
                    responce2= Client.GetAsync("/PIDEV-web/PIDEV/gestionEmploye/publication/"+pub.id).Result;
                    pub.utilisateur= responce2.Content.ReadAsAsync<utilisateur>().Result;
                }

                ViewBag.result = lstPub;
            }
            else
            {
                ViewBag.result = "error";
            }

            return View();
        
    }

        // GET: Publication/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Publication/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Publication/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Publication/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Publication/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Publication/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Publication/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
