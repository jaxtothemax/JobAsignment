using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;
using MVC.Models;

namespace MVC.Controllers
{
    public class ProductController : Controller
    {
        // GET: Product
        public ActionResult Index()
        {
            IEnumerable<mvcProductModel> prodList;
            HttpResponseMessage response = GlobalVariables.WebApiClient.GetAsync("Product").Result;
            prodList = response.Content.ReadAsAsync<IEnumerable<mvcProductModel>>().Result;
            return View(prodList);
        }

        public ActionResult AddOrEdit(int id = 0)
        {
            if (id == 0)
            return View(new mvcProductModel());
            else
            {
                HttpResponseMessage response = GlobalVariables.WebApiClient.GetAsync("Product/"+id.ToString()).Result;
                return View(response.Content.ReadAsAsync<mvcProductModel>().Result);
            }
        }
        [HttpPost]
        public ActionResult AddOrEdit(mvcProductModel prod)
        {
            if (prod.ProductID == 0) 
            {
                HttpResponseMessage response = GlobalVariables.WebApiClient.PostAsJsonAsync("Product", prod).Result;
                TempData["SuccessMessage"] = "Saved Successfully";
            }
            else
            {
                HttpResponseMessage response = GlobalVariables.WebApiClient.PutAsJsonAsync("Product/"+prod.ProductID, prod).Result;
                TempData["SuccessMessage"] = "Updated Successfully";
            }
            return RedirectToAction("Index");
        }

        public ActionResult Delete(int id)
        {
            HttpResponseMessage response = GlobalVariables.WebApiClient.DeleteAsync("Product/" + id.ToString()).Result;
            TempData["SuccessMessage"] = "Deleted Successfully";
            return RedirectToAction("Index");
        }
    }
}