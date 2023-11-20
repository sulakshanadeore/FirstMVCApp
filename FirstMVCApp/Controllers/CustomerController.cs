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


        public ActionResult Details(int id)
        {
            CustomerModel customer = modelList.Find(c => c.Custid == id);
            return View(customer);

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

        public ActionResult Delete(int id)
        {
            CustomerModel customer = modelList.Find(c => c.Custid == id);
            modelList.Remove(customer);
            return RedirectToAction("ShowListOfCustomers");
        }


        public ActionResult ShowListOfCustomers()
        {
            //if (modelList.Count <=0)
            //{
            //    string s = "There are no customers to show now!!!";
            //    //Pass the data(string) Controller(ShowListOfCustomers) Action to the view(ShowListOfCustomers)

            //    ViewBag.message = s;

            //}
            int noOfRows=modelList.Count;
            ViewBag.rowCount = noOfRows;

            
                return View(modelList);
            
            

        }


        // GET: Customer
        public ActionResult Index()
        {
            return View();
        }
    }
}