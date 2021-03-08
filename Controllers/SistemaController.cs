using klturismo.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace klturismo.Controllers
{
    public class SistemaController : Controller
    {
        public IActionResult Login()
        {

            return View();
        }
        [HttpPost]
        public IActionResult Login(Usuario user)
        {

            UsuarioRepository userbd = new UsuarioRepository();
            Usuario userEncontrado = userbd.FazerLogin(user);

            if (userEncontrado != null)
            {
                HttpContext.Session.SetInt32("IdUsuario", userEncontrado.Id);
                HttpContext.Session.SetString("NomeUsuario", userEncontrado.Nome);

                return RedirectToAction("Index", "Home");
            }
            else
            {

                ViewBag.Mensagem = "FALHA NO LOGIN";
                return View();
            }


        }


        public IActionResult CadastroPacotes()
        {

            return View();
        }

        [HttpPost]
        public IActionResult CadastroPacotes(PacoteTuristico pacote)
        {

            PacoteRepository pacotebd = new PacoteRepository();

            pacotebd.Inserir(pacote);

            return RedirectToAction("Pacote", "Home");
        }


        public IActionResult EditarPacotes(int Id)
        {

            PacoteRepository pr = new PacoteRepository();
            PacoteTuristico pacote = pr.BuscarPorId(Id);
            return View(pacote);
        }


        [HttpPost]
        public IActionResult EditarPacotes(PacoteTuristico pacote)
        {

            PacoteRepository pacotebd = new PacoteRepository();


            pacotebd.Editar(pacote);


            return RedirectToAction("Pacote", "Home");
        }


        public IActionResult CadastroUsuario()
        {
            return View();
        }


        [HttpPost]
        public IActionResult CadastroUsuario(Usuario user)
        {

            UsuarioRepository userbd = new UsuarioRepository();
            userbd.CadastrarUsuario(user);

            return RedirectToAction("Login", "Sistema");
        }

        
        public IActionResult RemoverPacote(int Id)
        {
            PacoteRepository pr = new PacoteRepository();
            pr.Remover(Id);
            return RedirectToAction("Pacote", "Home");

        }

        public IActionResult Logout()
        {

            HttpContext.Session.Clear();
            return RedirectToAction("Index", "Home");
        }





    }
}