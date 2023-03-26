using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using mvc.Models;
using Microsoft.AspNetCore.Http;

namespace mvc.Controllers
{
    public class Chamados : Controller
    {
        public IActionResult TestarConexao(){
            ViewBag.mensagem = ContatosBD.TestarConexao();
            return View();
        }
        
        public IActionResult RegistrarContatos()
        {
            if (HttpContext.Session.GetInt32("idUsuario") == null)
            {
                return RedirectToAction("Login", "Usuario");
            }
            if(HttpContext.Session.GetInt32("tipoUsuario") != 1)
                return RedirectToAction("AcessoNegado", "Home");
            return View();
        }  

        [HttpPost]
        public IActionResult RegistrarContatos(Contatos novoContato)
        {
            ContatosBD.Inserir(novoContato);
            ViewBag.Mensagem = "Sua reclamação foi recebida com sucesso! Aguarde um de nossos atendentes entrar em contato.";
            return View();
        }
        
        public IActionResult Contato()
        {
            List<Contatos> listaCompleta = ContatosBD.Listar();
            return View (listaCompleta);
        }
        
        
    }
}