using PizzaMore.App.BindingModels;
using PizzaMore.App.Data;
using PizzaMore.App.Models;
using PizzaMore.App.Security;
using PizzaMore.App.Services;
using SimpleHttpServer.Models;
using SimpleMVC.Attributes.Methods;
using SimpleMVC.Controllers;
using SimpleMVC.Interfaces;

namespace PizzaMore.App.Controllers
{
    public class UsersController : Controller
    {
        private UserService userService;

        public UsersController()
        {
            this.userService = new UserService(Data.Data.Context);
        }

        [HttpGet]
        public IActionResult Signup()
        {
            return this.View();
        }

        [HttpPost]
        public IActionResult Signup(UserSignupBindingModel bindingModel, HttpResponse response)
        {
            if (string.IsNullOrEmpty(bindingModel.SignUpEmail) ||
                string.IsNullOrEmpty(bindingModel.SignUpPassword))
            {
                this.Redirect(response, "/users/signup");
                return null;
            }

            this.userService.SignupUser(bindingModel);

            this.Redirect(response, "/users/signin");
            return null;

        }

        [HttpGet]
        public IActionResult Signin()
        {
            return this.View();
        }

        [HttpPost]
        public IActionResult Signin(UserSigninBindingModel bindingModel, HttpSession session, HttpResponse response)
        {
            if (string.IsNullOrEmpty(bindingModel.SignInEmail) ||
                string.IsNullOrEmpty(bindingModel.SignInPassword))
            {
                this.Redirect(response, "/users/signin");
                return null;
            }

            User user = this.userService.GetCurrentUser(bindingModel);
            if (user == null)
            {
                this.Redirect(response, "/users/signup");
                return null;
            }

            this.userService.SigninUser(bindingModel, session, user);

            this.Redirect(response, "/home/index");
            return null;
        }

        [HttpGet]
        public IActionResult Logout(HttpSession currentSession, HttpResponse response)
        {
            this.userService.Logout(response, currentSession.Id);

            this.Redirect(response, "/home/index");
            return null;
        }
    }
}
