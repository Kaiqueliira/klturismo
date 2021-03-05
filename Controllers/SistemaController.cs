using Microsoft.AspNetCore.Mvc;

namespace klturismo.Controllers
{
    public class SistemaController : Controller
    {
        public IActionResult Login()
        {

            return View();
        }

        public IActionResult Cadastro()
        {

            return View();
        }

    public IActionResult CadastroUsuario()
            {

                return View();
            }

        }
}