using Shouter.App.BindingModels;
using Shouter.App.Models;
using Shouter.App.Security;
using Shouter.App.Services;
using Shouter.App.ViewModels;
using SimpleHttpServer.Models;
using SimpleMVC.Attributes.Methods;
using SimpleMVC.Controllers;
using SimpleMVC.Interfaces;
using SimpleMVC.Interfaces.Generic;

namespace Shouter.App.Controllers
{
    public class UsersController : Controller
    {
        private LoginManager loginManager;
        private UserService userService;
        private ShoutService shoutService;

        public UsersController()
        {
            this.loginManager = new LoginManager(Data.Data.Context);
            this.userService = new UserService(Data.Data.Context);
            this.shoutService = new ShoutService(Data.Data.Context);
        }

        [HttpGet]
        public IActionResult Register(HttpResponse response, HttpSession currentSession)
        {
            if (this.loginManager.IsAuthenticated(currentSession))
            {
                this.Redirect(response, "/users/feed");
                return null;
            }

            return this.View();
        }

        [HttpPost]
        public IActionResult Register(UserRegisterBindingModel bindingModel, HttpResponse response, HttpSession currentSession)
        {
            if (this.loginManager.IsAuthenticated(currentSession))
            {
                this.Redirect(response, "/users/feed");
                return null;
            }

            if (!this.userService.IsValidRegisterInput(bindingModel))
            {
                this.Redirect(response, "/users/register");
                return null;
            }

            this.userService.RegisterUser(bindingModel);
            this.Redirect(response, "/users/login");
            return null;
        }

        [HttpGet]
        public IActionResult Login(HttpResponse response, HttpSession currentSession)
        {
            if (this.loginManager.IsAuthenticated(currentSession))
            {
                this.Redirect(response, "/users/feed");
                return null;
            }

            return this.View();
        }

        [HttpPost]
        public IActionResult Login(UserLoginBindingModel bindingModel, HttpResponse response, HttpSession currentSession)
        {
            if (this.loginManager.IsAuthenticated(currentSession))
            {
                this.Redirect(response, "/users/feed");
                return null;
            }

            if (!this.userService.IsValidLoginInput(bindingModel))
            {
                this.Redirect(response, "/users/login");
                return null;
            }

            User currentUser = this.userService.GetCurrentUser(bindingModel);
            this.userService.LoginUser(bindingModel, currentUser, currentSession);
            this.Redirect(response, "/users/feed");
            return null;
        }

        [HttpGet]
        public IActionResult Logout(HttpSession currentSession, HttpResponse response)
        {
            this.userService.Logout(response, currentSession.Id);

            this.Redirect(response, "/home/feed");
            return null;
        }

        [HttpGet]
        public IActionResult<FeedViewModel> Feed(HttpSession currentSession, HttpResponse response)
        {
            if (!this.loginManager.IsAuthenticated(currentSession))
            {
                this.Redirect(response, "/home/feed");
                return null;
            }

            FeedViewModel viewModel = this.shoutService.GetAllShouts();
            return this.View(viewModel);
        }

        [HttpPost]
        public IActionResult Feed(AddShoutBindingModel bindingModel, HttpSession currentSession, HttpResponse response)
        {
            if (!this.loginManager.IsAuthenticated(currentSession))
            {
                this.Redirect(response, "/home/feed");
                return null;
            }

            if (!this.shoutService.IsValidAddShout(bindingModel))
            {
                this.Redirect(response, "/users/feed");
                return null;
            }

            this.shoutService.AddShout(bindingModel, currentSession);
            this.Redirect(response, "/users/feed");
            return null;
        }
    }
}
