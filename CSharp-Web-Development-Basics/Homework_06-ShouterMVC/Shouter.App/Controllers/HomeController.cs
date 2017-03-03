using Shouter.App.Services;
using Shouter.App.ViewModels;
using SimpleMVC.Attributes.Methods;
using SimpleMVC.Controllers;
using SimpleMVC.Interfaces.Generic;

namespace Shouter.App.Controllers
{
    public class HomeController: Controller
    {
        private ShoutService shoutService;

        public HomeController()
        {
            this.shoutService = new ShoutService(Data.Data.Context);
        }

        [HttpGet]
        public IActionResult<FeedViewModel> Feed()
        {
            FeedViewModel viewModel = this.shoutService.GetAllShouts();
            return this.View(viewModel);
        }
    }
}
