using ArtistAssignment.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ArtistAssignment.Controllers
{
    public class CustomRoleManagementController : Controller
    {
        private ApplicationDbContext _db;
        private RoleManager<IdentityRole> roleManager;
        public CustomRoleManagementController()
        {
            _db = new ApplicationDbContext();
            roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(_db));
        }
        public ActionResult Index()
        {
            return View(roleManager.Roles.ToList());
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(IdentityRole role)
        {
            roleManager.Create(role);
            return RedirectToAction("Index", "CustomRoleManagement");
        }

        public ActionResult IdentityUsers()
        {
            var users = _db.Users.ToList();
            return View(users);
        }

        protected override void Dispose(bool disposing)
        {
            _db.Dispose();
        }
    }
}