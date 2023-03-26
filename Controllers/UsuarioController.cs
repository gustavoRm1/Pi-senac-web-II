
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Http;
using mvc.Models;
using MySqlConnector;

namespace mvc.Controllers
{

    public class UsuarioController : Controller
    {
        public IActionResult Login()
        {
            return View();
        }

        public IActionResult Inserir()
        {
            return View();
        }
        
        public IActionResult Perfil()
        {
            if (HttpContext.Session.GetInt32("idUsuario") == null)
            {
                return RedirectToAction("Login", "Usuario");
            }
            return View();
        }
        [HttpPost]

        public IActionResult Login(Usuario u){
            Usuario usuarioEncontrado = UsuarioBD.ValidarLogin(u);
            if(usuarioEncontrado != null)
            {
                HttpContext.Session.SetInt32("idUsuario", usuarioEncontrado.id);
                HttpContext.Session.SetString("nomeUsuario", usuarioEncontrado.nome);
                HttpContext.Session.SetInt32("tipoUsuario", usuarioEncontrado.tipo);
                return RedirectToAction("Index", "Home");
            }else{
                ViewBag.Mensagem = "Falha ao fazer o login!";
                return View();
            }

        }
            public IActionResult Logout(){
            HttpContext.Session.Clear();
            return RedirectToAction("Login", "Usuario");   
        }

   
}}