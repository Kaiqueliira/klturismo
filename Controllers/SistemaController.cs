using klturismo.Models;
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





    }
}