using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HERBProject.Presentation.WebUI.Models.User;
using HERBProject.Presentation.WebUI.MapFactories.DataModelToApplicationDTO;
using HERBProject.Contracts.ServiceLibrary.DTO;
using HERBProject.Contracts.ServiceLibrary.Contracts;

namespace HERBProject.Presentation.WebUI.Controllers.User
{
    public class UserController : Controller
    {
        //
        // GET: /User/
        private IMannageUser _mannageUser;

        public UserController(IMannageUser mannageUser)
        {
            _mannageUser = mannageUser;
        }
      
        public ActionResult Index()
        {
            return View();
        }

        //
        // GET: /User/Details/5

        public ActionResult Details(int id)
        {
            return View();
        }

        //
        // GET: /User/Create
        [HttpPost]
        public ActionResult Create(UserDataModel user)
        {
            if (user != null)
            {
                try
                {

                    MapDataModelToApplicationDTOFactoryBase factory = SwictherDataModelToApplicationDTO.GetFactoryFor(EnumApplicationDTO.UserDataModel);
                    UserEntityDTO userEntityDTO = factory.GetApplicationDTOFromDataModelDTO<UserDataModel, UserEntityDTO>(user);
                    _mannageUser.Create(userEntityDTO);
                    
                }
                catch (Exception)
                {

                    throw;
                }
            }
            return View();
        }

        //
        // POST: /User/Create

        //[HttpPost]
        //public ActionResult Create(FormCollection collection)
        //{
        //    try
        //    {
        //        // TODO: Add insert logic here

        //        return RedirectToAction("Index");
        //    }
        //    catch
        //    {
        //        return View();
        //    }
        //}

        //
        // GET: /User/Edit/5

        public ActionResult Edit(int id)
        {
            return View();
        }

        //
        // POST: /User/Edit/5

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

        //
        // GET: /User/Delete/5

        public ActionResult Delete(int id)
        {
            return View();
        }

        //
        // POST: /User/Delete/5

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
