using ByteBank.Forum.Models;
using ByteBank.Forum.ViewModels;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ByteBank.Forum.Controllers
{
    public class ContaController : Controller
    {
        public IActionResult Registrar()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Registrar(ContaRegistrarViewModel modelo)
        {
            if (ModelState.IsValid)
            {
                //Podemos incluir o usuário

                var dbContext = new IdentityDbContext<UsuarioAplicacao>("DefaultConnection");
                var userStore = new UserStore<UsuarioAplicacao>(dbContext);
                var userManager = new UserManager<UsuarioAplicacao>(userStore);

                var novoUsuario = new UsuarioAplicacao();

                novoUsuario.Email = modelo.Email;
                novoUsuario.UserName = modelo.UserName;
                novoUsuario.NomeCompleto = modelo.NomeCompleto;

                userManager.Create(novoUsuario, modelo.Senha);

                return RedirectToAction("Index", "Home");
            }

            //Algo de errado não está certo
            return View(modelo);
        }
    }
}
