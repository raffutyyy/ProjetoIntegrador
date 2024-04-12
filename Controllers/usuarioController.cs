using Microsoft.AspNetCore.Mvc;
using ATV3__PROJETO_INTEGRADOR.Models;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
namespace ATV3__PROJETO_INTEGRADOR
{
    public class usuarioController : Controller
    {
        public IActionResult cadastrar()
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
        public IActionResult login()
        {
            return View();
        }
        [HttpPost]
        public IActionResult login(usuario u)
        {
            usuarioRepository uR = new usuarioRepository();

            usuario loginUsuario = uR.validarLogin(u);

            if (loginUsuario == null)
            {
                ViewBag.Mensagem = "Ocorreu uma falha no login";
                return View();
            }
            else
            { // 45:37
                HttpContext.Session.SetInt32("idUsuario", loginUsuario.idUsuario);
                HttpContext.Session.SetString("nome", loginUsuario.nome);
                HttpContext.Session.SetString("email", loginUsuario.email);
                HttpContext.Session.SetString("senha", loginUsuario.senha);
            
                return View();
            }



        }
    }
}
