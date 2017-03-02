using PizzaMore.App.BindingModels;
using PizzaMore.App.Data;
using PizzaMore.App.Models;
using PizzaMore.App.Security;
using PizzaMore.App.Services;
using PizzaMore.App.ViewModels;
using SimpleHttpServer.Models;
using SimpleMVC.Attributes.Methods;
using SimpleMVC.Controllers;
using SimpleMVC.Interfaces;
using SimpleMVC.Interfaces.Generic;
using System.Collections.Generic;
using System.Linq;

namespace PizzaMore.App.Controllers
{
    public class MenuController : Controller
    {
        private SignInManager signInManger;
        private PizzasService pizzasService;

        public MenuController()
        {
            this.signInManger = new SignInManager(Data.Data.Context);
            this.pizzasService = new PizzasService(Data.Data.Context);
        }

        [HttpGet]
        public IActionResult<MenuPizzasViewModel> Index(HttpSession currentSession, HttpResponse response)
        {
            if (!this.signInManger.IsAuthenticated(currentSession))
            {
                this.Redirect(response, "/home/index");
                return null;
            }

            MenuPizzasViewModel viewModel = this.pizzasService.ShowAllPizzas();
            return this.View(viewModel);
        }

        [HttpPost]
        public IActionResult<MenuPizzasViewModel> Index(VotePizzaBindingModel bindingModel, HttpSession currentSession, HttpResponse response)
        {
            if (!this.signInManger.IsAuthenticated(currentSession))
            {
                this.Redirect(response, "/home/index");
                return null;
            }

            this.pizzasService.AddVote(bindingModel);
            this.Redirect(response, "/menu/index");
            return null;
        }

        [HttpGet]
        public IActionResult Add(HttpSession currentSession, HttpResponse response)
        {
            if (!this.signInManger.IsAuthenticated(currentSession))
            {
                this.Redirect(response, "/users/signin");
            }

            return this.View();
        }

        [HttpPost]
        public IActionResult Add(AddPizzaBindingModel bindingModel, HttpSession currentSession, HttpResponse response)
        {
            if (!this.signInManger.IsAuthenticated(currentSession))
            {
                this.Redirect(response, "/users/signin");
                return null;
            }

            this.pizzasService.AddPizza(bindingModel, currentSession);
            this.Redirect(response, "/menu/index");
            return null;
        }

        [HttpGet]
        public IActionResult<PizzaDetailsViewModel> Details(int pizzaId, HttpSession currentSesion, HttpResponse response)
        {
            if (!this.signInManger.IsAuthenticated(currentSesion))
            {
                this.Redirect(response, "/users/signin");
            }

            PizzaDetailsViewModel viewModel = this.pizzasService.ShowDetails(pizzaId);
            return this.View(viewModel);
        }

        [HttpGet]
        public IActionResult<UserSuggestionsViewModel> Suggestions(HttpSession currentSession, HttpResponse response)
        {
            if (!this.signInManger.IsAuthenticated(currentSession))
            {
                this.Redirect(response, "/users/signin");
            }

            UserSuggestionsViewModel viewModel = this.pizzasService.ShowUserSuggestions(currentSession);
            return this.View(viewModel);
        }

        [HttpPost]
        public IActionResult<UserSuggestionsViewModel> Suggestions(DeletePizzaBindingModel bindingModel, HttpSession currentSession, HttpResponse response)
        {
            if (!this.signInManger.IsAuthenticated(currentSession))
            {
                this.Redirect(response, "/users/signin");
            }

            this.pizzasService.DeletePizza(bindingModel.PizzaId);

            this.Redirect(response, "/menu/suggestions");
            return null;
        }
    }
}
