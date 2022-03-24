using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Data;
using WebApplication1.Models;
//using Xceed.Wpf.Toolkit;

namespace WebApplication1.Controllers
{
    public class ClientsController : Controller
    {
        ApplicationDbContext applicationDbContext = new ApplicationDbContext();
        public ActionResult display()
        {
            //instead of string , use action result so here we can return view
            return View("details");
        }
//________________________________________________________________________________________________________________________

        public ActionResult details(int id)
        {


            // List<Client> Clients = new List<Client>
            //{
            //              new Client{
            //               Id = 2001,
            //               fullname = "hamza",
            //               rooms = 3,
            //                place = "10th of Ramadan",
            //                job= "engineer"  },

            //              new Client{
            //                Id = 2002,
            //               fullname = "karrem",
            //               rooms = 6,
            //                place = "Cairo",
            //                job= "Plumber" } };

            ////return View(Clients);
            ////
            Client client = applicationDbContext.Clients.Include(e => e.Room_Type).Include(e => e.payment).FirstOrDefault(e => e.Id == id);
            if (client == null)
           {

                return NotFound();
            }
            return View(client);
        }

        //________________________________________________________________________________________________________________
        public IActionResult Index(string searchText, int room_TypeId, string sortType, int pageSize, int pageNumber)
        {



            ViewBag.AllDepartments = applicationDbContext.Room_Type;
            //ViewBag.currentSearch = searchText.Trim();     //remain the name in the input layout while searching  




            //الدقيقه 34 فيديو 3 يوم 20 تعلم كيف تعم 
            //pagination
            if (pageSize > 0 && pageNumber > 0)
            {
                ViewBag.PageSize = pageSize;
                ViewBag.PageNumber = pageNumber;
                return View(applicationDbContext.Clients.Skip(pageSize * (pageNumber - 1)).Take(pageSize));


            }





            //?????????????????????????????????????????????????????????????
            //الدقيقه 13 فيديو 3 يوم 20 تعلم كيف تعمل debugging
            //*******************************************************
            //sort/order
            if (string.IsNullOrWhiteSpace(sortType) == false && sortType.Trim() == "asc")
            {
                return View(applicationDbContext.Clients.OrderBy(e => e.fullname).ToList());


            }
            else if (string.IsNullOrWhiteSpace(sortType) == false && sortType.Trim() == "desc")
            {
                return View(applicationDbContext.Clients.OrderByDescending(e => e.fullname).ToList());


            }





            if (string.IsNullOrWhiteSpace(searchText) == true && room_TypeId == 0)
            {
                return View(applicationDbContext.Clients);

            }
            ViewBag.currentSearch = searchText;
            ViewBag.SelectedDepartmentId = room_TypeId;

            List<Client> clients = new List<Client>();
            //return View(applicationDbContext.Employees.Where(e => e.fullname.Contains(searchText)));


            if (room_TypeId > 0 && string.IsNullOrWhiteSpace(searchText) == true)
            {
                clients = applicationDbContext.Clients.Where(e => e.Room_TypeId == room_TypeId).ToList();


            }
            else if (room_TypeId > 0 && string.IsNullOrWhiteSpace(searchText) == false)
            {
                //return View(applicationDbContext.Employees.Where(e => e.fullname.Contains(searchText)));
                //empoyees = applicationDbContext.Employees.Where(e => e.DepartmentId == depatmentId).ToList();


               clients = applicationDbContext.Clients.Where(e => e.Room_TypeId == room_TypeId && e.fullname.Contains(searchText.Trim())).ToList();
            }
            else
            {
                clients = applicationDbContext.Clients.Where(e => e.fullname.Contains(searchText.Trim())).ToList();



            }




            return View(clients);
        }



        //____________________________________________________________________________________________________________________
        public string dispalyservices()    
        {

            return "our services: \n web development, and \n-Mobile apps .";
        }

        //_______________________________________________________________________________________________________________

        [HttpGet] 
        public ActionResult create()
        {

            //var vm = new payment();
            //var items = new List<string> { "Monday", "Tuesday", "Wednesday" };
            //vm.PaymentMethoed = new SelectList(items);
            ViewBag.AllDepartments = applicationDbContext.Room_Type.ToList();
            ViewBag.ALLPayments = applicationDbContext.payment.ToList();
            return View();

        }

        [ValidateAntiForgeryToken]
        [HttpPost]
        public ActionResult create(Client cl)
        {
           
                if (ModelState.IsValid == true)
                {

               
                cl.creationDateTime = DateTime.Now;


                applicationDbContext.Clients.Add(cl);
                    applicationDbContext.SaveChanges();  // must be used

                    return RedirectToAction("Index");
                }
            //return RedirectToAction("Index");
            ViewBag.AllDepartments = applicationDbContext.Room_Type.ToList();
            ViewBag.ALLPayments = applicationDbContext.payment.ToList();
            return View(cl);

        }



       

        //____________________________________________________________________________________________________________________________________
        [HttpGet]
        public ActionResult Edit(int id)
        {
           Client client = applicationDbContext.Clients.Find(id);

            if (client == null)
            {
                return NotFound();

            }
            ViewBag.AllDepartments = applicationDbContext.Room_Type.ToList();
            ViewBag.ALLPayments = applicationDbContext.payment.ToList();
            return View(client);
        }


        [ValidateAntiForgeryToken]
        [HttpPost]      //so u can save and edit so u must use post
        public ActionResult Edit(int id, Client client)
        {
            // we just make it like a protect but u can not use id as u want and it is hidden already so just for ensure
            if (id != client.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid == true)
            {
                client.updateDateTime = DateTime.Now;
                applicationDbContext.Clients.Update(client);   //Edit or update
                applicationDbContext.SaveChanges();


                return RedirectToAction("Index");  //return to index(table)
            }

            ViewBag.AllDepartments = applicationDbContext.Room_Type.ToList();
            ViewBag.ALLPayments = applicationDbContext.payment.ToList();
            return View(client);
        }
        //____________________________________________________________________________________________________________________________________________________________________________

        [HttpGet]
        public ActionResult Delete(int id)
        {
            Client client = applicationDbContext.Clients.Include(e => e.Room_Type).FirstOrDefault(e => e.Id == id);
            if (client == null)
            {
                return NotFound();

            }

            return View(client);
        }



        [ValidateAntiForgeryToken]
        [ActionName("Delete")]
        [HttpPost]
        public ActionResult DeleteConfirmed(int id)
        {
            Client client = applicationDbContext.Clients.Find(id);
            if (client == null)                                              
            {
                return NotFound();

            }

            applicationDbContext.Clients.Remove(client);   //delete
            applicationDbContext.SaveChanges();

            return RedirectToAction("Index");
        }




















































































































    }
}
