using PizzaMore.App.BindingModels;
using PizzaMore.App.Data;
using PizzaMore.App.Security;
using SimpleHttpServer.Models;
using SimpleMVC.Attributes.Methods;
using SimpleMVC.Controllers;
using SimpleMVC.Interfaces;

namespace PizzaMore.App.Controllers
{
    public class HomeController : Controller
    {
        private SignInManager signInManger;

        public HomeController()
        {
            this.signInManger = new SignInManager(new PizzaMoreContext());
        }

        [HttpGet]
        public IActionResult Index(HttpSession currentSession, HttpResponse response)
        {
            if (this.signInManger.IsAuthenticated(currentSession))
            {
                this.Redirect(response, "/home/indexlogged");
                return null;
            }

            return this.View();
        }

        [HttpPost]
        public IActionResult Index(ChangeLanguageBindingModel bindingModel, HttpSession currentSession, HttpResponse response)
        {
            if (this.signInManger.IsAuthenticated(currentSession))
            {
                this.Redirect(response, "/home/indexlogged");
                return null;
            }

            if (bindingModel.Language == "EN")
            {
                this.Redirect(response, "/home/index");
                return null;
            }

            if (bindingModel.Language == "DE")
            {
                this.Redirect(response, "/home/indexDE");
                return null;
            }

            this.Redirect(response, "/home/index");
            return null;
        }

        [HttpGet]
        public IActionResult Indexlogged(HttpSession currentSession, HttpResponse response)
        {
            if (!this.signInManger.IsAuthenticated(currentSession))
            {
                this.Redirect(response, "/home/index");
            }

            return this.View();
        }

        [HttpGet]
        public IActionResult IndexDE(HttpSession currentSession, HttpResponse response)
        {
            if (this.signInManger.IsAuthenticated(currentSession))
            {
                this.Redirect(response, "/home/indexlogged");
                return null;
            }

            return this.View();
        }
    }
}
