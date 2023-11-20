using FirstMVCApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FirstMVCApp.Controllers
{
    public class CustomerController : Controller
    {
        static List<CustomerModel> modelList = new List<CustomerModel>();

        public ActionResult Contact()
        { 
        
        return View();      
        }



        public ActionResult InsertCustomer()
        {
            return View();
        
        }
        [HttpPost]
        public ActionResult InsertCustomer(CustomerModel obj) 
        {
            modelList.Add(obj);

            //return Content("Received Data ");

            return RedirectToAction("ShowListOfCustomers");
        }

        public ActionResult Edit(int id)
        {
            CustomerModel customer=modelList.Find(c => c.Custid == id);
            return View(customer);
        }
        [HttpPost]
        public ActionResult Edit(int id,CustomerModel editeddata)
        {
            CustomerModel customer = modelList.Find(c => c.Custid == id);
            customer.CustName = editeddata.CustName;
            customer.City = editeddata.City;
            return RedirectToAction("ShowListOfCustomers");
        }



        public ActionResult ShowListOfCustomers()
        {
            return View(modelList);

        }


        // GET: Customer
        public ActionResult Index()
        {
            return View();
        }
    }
}