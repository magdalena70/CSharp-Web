using SimpleHttpServer.Models;
using SimpleMVC.Attributes.Methods;
using SimpleMVC.Controllers;
using SimpleMVC.Interfaces;
using SoftUniStore.App.BindingModels;
using SoftUniStore.App.Services;
using SoftUniStore.App.Security;
using SoftUniStore.App.ViewModels;
using SimpleMVC.Interfaces.Generic;
using System.Linq;

namespace SoftUniStore.App.Controllers
{
    public class HomeController : Controller
    {
        private LoginManager loginManager;
        private HomeService homeService;
        private GameService gameService;

        public HomeController()
        {
            this.loginManager = new LoginManager(Data.Data.Context);
            this.homeService = new HomeService(Data.Data.Context);
            this.gameService = new GameService(Data.Data.Context);
        }

        [HttpGet]
        public IActionResult Register(HttpSession session, HttpResponse response)
        {
            if (this.loginManager.IsAuthenticated(session))
            {
                this.Redirect(response, "/home/index");
                return null;
            }

            return this.View();
        }

        [HttpPost]
        public IActionResult Register(HttpResponse response, RegisterBindingModel bindingModel, HttpSession session)
        {
            if (this.loginManager.IsAuthenticated(session))
            {
                this.Redirect(response, "/home/index");
                return null;
            }

            if (!this.homeService.IsRegisterModelValid(bindingModel))
            {
                this.Redirect(response, "/home/register");
                return null;
            }

            this.homeService.RegisterUser(bindingModel);
            this.Redirect(response, "/home/login");
            return null;
        }

        [HttpGet]
        public IActionResult Login(HttpSession session, HttpResponse response)
        {
            if (this.loginManager.IsAuthenticated(session))
            {
                this.Redirect(response, "/home/index");
                return null;
            }

            return this.View();
        }

        [HttpPost]
        public IActionResult Login(HttpResponse response, HttpSession session, LoginBindingModel bindingModel)
        {
            if (this.loginManager.IsAuthenticated(session))
            {
                this.Redirect(response, "/home/index");
                return null;
            }

            if (!this.homeService.IsLoginModelValid(bindingModel))
            {
                this.Redirect(response, "/home/login");
                return null;
            }

            this.homeService.LoginUser(bindingModel, session.Id);
            this.Redirect(response, "/home/index");
            return null;
        }

        [HttpGet]
        public IActionResult Logout(HttpSession session, HttpResponse response)
        {
            if (!this.loginManager.IsAuthenticated(session))
            {
                this.Redirect(response, "/home/login");
                return null;
            }

            this.homeService.Logout(response, session.Id);
            this.Redirect(response, "/home/login");
            return null;
        }

        [HttpGet]
        public IActionResult<HomeGamesViewModel> Index(HttpSession session, HttpResponse response)
        {
            if (!this.loginManager.IsAuthenticated(session))
            {
                this.Redirect(response, "/home/login");
                return null;
            }

            HomeGamesViewModel viewModel = this.gameService.GetAll();
            return this.View(viewModel);
        }

        [HttpGet]
        public IActionResult<HomeGamesViewModel> Owned(HttpSession session, HttpResponse response)
        {
            if (!this.loginManager.IsAuthenticated(session))
            {
                this.Redirect(response, "/home/login");
                return null;
            }

            HomeGamesViewModel viewModel = this.gameService.GetOwned(session);
            return this.View(viewModel);
        }
    }
}
