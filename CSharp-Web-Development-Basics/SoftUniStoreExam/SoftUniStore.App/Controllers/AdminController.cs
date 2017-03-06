using SimpleHttpServer.Models;
using SimpleMVC.Attributes.Methods;
using SimpleMVC.Controllers;
using SimpleMVC.Interfaces;
using SimpleMVC.Interfaces.Generic;
using SoftUniStore.App.BindingModels;
using SoftUniStore.App.Security;
using SoftUniStore.App.Services;
using SoftUniStore.App.ViewModels;
using System.Collections.Generic;

namespace SoftUniStore.App.Controllers
{
    public class AdminController : Controller
    {
        private LoginManager loginManager;
        private AdminService adminService;

        public AdminController()
        {
            this.loginManager = new LoginManager(Data.Data.Context);
            this.adminService = new AdminService(Data.Data.Context);
        }

        [HttpGet]
        public IActionResult<ICollection<AdminGamesViewModel>> Games(HttpSession session, HttpResponse response)
        {
            if (!this.loginManager.IsAuthenticated(session))
            {
                this.Redirect(response, "/home/login");
                return null;
            }

            if (!this.loginManager.IfUserIsAdmin(session))
            {
                this.Redirect(response, "/home/index");
                return null;
            }

            ICollection<AdminGamesViewModel> viewModel = this.adminService.GetAll();
            return this.View(viewModel);
        }

        [HttpGet]
        public IActionResult Add(HttpSession session, HttpResponse response)
        {
            if (!this.loginManager.IsAuthenticated(session))
            {
                this.Redirect(response, "/home/login");
                return null;
            }

            if (!this.loginManager.IfUserIsAdmin(session))
            {
                this.Redirect(response, "/home/index");
                return null;
            }

            return this.View();
        }

        [HttpPost]
        public IActionResult Add(AddGameBindingModel bindingModel, HttpSession session, HttpResponse response)
        {
            if (!this.loginManager.IsAuthenticated(session))
            {
                this.Redirect(response, "/home/login");
                return null;
            }

            if (!this.loginManager.IfUserIsAdmin(session))
            {
                this.Redirect(response, "/home/index");
                return null;
            }

            if (!this.adminService.IsValidAdd(bindingModel))
            {
                this.Redirect(response, "/admin/add");
                return null;
            }

            this.adminService.AddGame(bindingModel);
            this.Redirect(response, "/admin/games");
            return null;
        }

        [HttpGet]
        public IActionResult Edit( int gameId, HttpSession session, HttpResponse response)
        {
            if (!this.loginManager.IsAuthenticated(session))
            {
                this.Redirect(response, "/home/login");
                return null;
            }

            if (!this.loginManager.IfUserIsAdmin(session))
            {
                this.Redirect(response, "/home/index");
                return null;
            }

            //to do viewModel and post
            return this.View();
        }

        [HttpGet]
        public IActionResult<DeleteGameViewModel> Delete(int gameId, HttpSession session, HttpResponse response)
        {
            if (!this.loginManager.IsAuthenticated(session))
            {
                this.Redirect(response, "/home/login");
                return null;
            }

            if (!this.loginManager.IfUserIsAdmin(session))
            {
                this.Redirect(response, "/home/index");
                return null;
            }

            DeleteGameViewModel viewModel = this.adminService.GetGameToDelete(gameId);
            return this.View(viewModel);
        }

        [HttpPost]
        public IActionResult Delete(DeleteGameBindingModel bindingModel, HttpSession session, HttpResponse response)
        {
            if (!this.loginManager.IsAuthenticated(session))
            {
                this.Redirect(response, "/home/login");
                return null;
            }

            if (!this.loginManager.IfUserIsAdmin(session))
            {
                this.Redirect(response, "/home/index");
                return null;
            }

            if (!this.adminService.IsValidDelete(bindingModel))
            {
                this.Redirect(response, "/admin/add");
                return null;
            }

            this.adminService.DeleteGame(bindingModel);
            this.Redirect(response, "/admin/games");
            return null;
        }
    }
}
