﻿using CargaAcademica.BL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace CargaAcademica.WebAdmin.Controllers
{
    public class LoginController : Controller
    {
        SeguridadBL _seguridadBl;
        public LoginController()
        {
            _seguridadBl = new SeguridadBL();
        }
        // GET: Login
        public ActionResult Index()
        {
            FormsAuthentication.SignOut();
            return View();

           }
        
         [HttpPost]
         public ActionResult Index(FormCollection data)
        {
            var nombreUsuario = data["username"];

            var contrasena = data["password"];

            var usuarioValido = _seguridadBl
                .Autorizar(nombreUsuario,contrasena);


            if (usuarioValido)
            {
                FormsAuthentication.SetAuthCookie(nombreUsuario, true);

                return RedirectToAction("Index", "Home");

            }

            ModelState.AddModelError("","Usuario o Contraseña no encontrados");

            return View();
        }

      
    }
}