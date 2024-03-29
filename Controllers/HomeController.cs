using System;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ATV3__PROJETO_INTEGRADOR.Models;

namespace ATV3__PROJETO_INTEGRADOR.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            usuarioRepository uR = new usuarioRepository();
            uR.testeConexao();
            return View();
        }

        public IActionResult Noticias()
        {
            return View();
        }

        public IActionResult Trailer()
        {
            return View();
        }

        public IActionResult Resenhas()
        {
            return View();
        }

        public IActionResult Quemsomos()
        {
            return View();
        }

        public IActionResult Cadastrar()
        {
            return View();
        }
        public IActionResult login()
        {
            return View();
        }
        [HttpPost]
        public IActionResult cadastrar(usuario u)
        {
            usuarioRepository uR = new usuarioRepository();
            uR.inserir(u);

            return RedirectToAction("login");
        }
        [HttpPost]
        public IActionResult Login(usuario u)
        {
            usuarioRepository uR = new usuarioRepository();

            usuario loginUsuario = uR.validarLogin(u);

            if (loginUsuario == null)
            {
                ViewBag.Mensagem = "Ocorreu uma falha no login";
                return View();
            }
            else
            
                if (loginUsuario.idUsuario != 0)
                    HttpContext.Session.SetInt32("idUsuario", loginUsuario.idUsuario);

                if (!string.IsNullOrEmpty(loginUsuario.nome))
                    HttpContext.Session.SetString("nome", loginUsuario.nome);

                if (!string.IsNullOrEmpty(loginUsuario.email))
                    HttpContext.Session.SetString("email", loginUsuario.email);

            
                return RedirectToAction("Index", "Home"); 
            }
        




        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }

}
