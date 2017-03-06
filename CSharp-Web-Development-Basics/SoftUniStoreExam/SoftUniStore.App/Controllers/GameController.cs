using SimpleHttpServer.Models;
using SimpleMVC.Attributes.Methods;
using SimpleMVC.Controllers;
using SimpleMVC.Interfaces;
using SimpleMVC.Interfaces.Generic;
using SoftUniStore.App.BindingModels;
using SoftUniStore.App.Security;
using SoftUniStore.App.Services;
using SoftUniStore.App.ViewModels;

namespace SoftUniStore.App.Controllers
{
    public class GameController : Controller
    {
        private LoginManager loginManager;
        private GameService gameService;


        public GameController()
        {
            this.loginManager = new LoginManager(Data.Data.Context);
            this.gameService = new GameService(Data.Data.Context);
        }

        [HttpGet]
        public IActionResult<GameDetailsViewModel> Details(int gameId, HttpSession session, HttpResponse response)
        {
            if (!this.loginManager.IsAuthenticated(session))
            {
                this.Redirect(response, "/home/login");
                return null;
            }

            GameDetailsViewModel viewModel = this.gameService.ShowDetails(gameId);
            return this.View(viewModel);
        }

        [HttpPost]
        public IActionResult Details(BuyGameBindingModel bindingModel, HttpSession session, HttpResponse response)
        {
            if (!this.loginManager.IsAuthenticated(session))
            {
                this.Redirect(response, "/home/login");
            }

            this.gameService.BuyGame(bindingModel, session);
            this.Redirect(response, "/home/owned");
            return null;
        }
    }
}
