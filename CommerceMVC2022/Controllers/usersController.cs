using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CommerceMVC2022.Models;
using CommerceMVC2022.Models.ViewModels;

namespace CommerceMVC2022.Controllers
{
    public class usersController : Controller
    {
        // GET: users
        public ActionResult Index()
        {
            List<UsersViewModel> listusers;
            using (commerceEntities1 db = new commerceEntities1())
            {
                listusers = (from user in db.users
                             select new UsersViewModel
                             {
                                 Id = user.id,
                                 Nombre = user.nombre,
                                 Correo = user.email
                             }
                    ).ToList();

            }
                return View(listusers);
        }

        public ActionResult CrearUser()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CrearUser(AlterUserViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    using (commerceEntities1 db = new commerceEntities1())
                    {
                        var oDataUSer = new users();
                        oDataUSer.email = model.Correo;
                        oDataUSer.fecha_nac = model.FechaNacimiento;
                        oDataUSer.nombre = model.Nombre;

                        db.users.Add(oDataUSer);
                        db.SaveChanges();
                    }
                    return Redirect("~/Users/");
                }
                return View(model);
            }
            catch(Exception e)
            {
                throw new Exception(e.Message);
            }
        }
    }
}