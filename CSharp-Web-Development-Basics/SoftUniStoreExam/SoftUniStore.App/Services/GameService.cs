using SoftUniStore.App.Data;
using SoftUniStore.App.ViewModels;
using System.Linq;
using SoftUniStore.App.Models;
using SimpleHttpServer.Models;
using System.Collections.Generic;
using SoftUniStore.App.BindingModels;
using System;

namespace SoftUniStore.App.Services
{
    public class GameService : Service
    {
        public GameService(SoftUniContext context) : base(context)
        {
        }

        internal HomeGamesViewModel GetAll()
        {
            var games = this.context.Games.Select(g => new GameViewModel()
            {
                Id = g.Id,
                Title = g.Title,
                ImageThumbnail = g.ImageThumbnail,
                Description = g.Description,
                Price = g.Price,
                Size = g.Size
            }).ToList();

            HomeGamesViewModel viewModel = new HomeGamesViewModel()
            {
                AllGames = games
            };

            return viewModel;
        }

        internal GameDetailsViewModel ShowDetails(int gameId)
        {
            Game game = this.context.Games.Find(gameId);
            GameDetailsViewModel viewModel = new GameDetailsViewModel()
            {
                GameId = game.Id,
                Title = game.Title,
                Description = game.Description,
                Price = game.Price,
                Trailer = game.Trailer,
                Size = game.Size,
                ReleaseDate = game.ReleaseDate
            };

            return viewModel;
        }

        internal HomeGamesViewModel GetOwned(HttpSession session)
        {
            ICollection<GameViewModel> games = this.context.Logins
                .First(l => l.SessionId == session.Id && l.IsActive == true)
                .User.Games.Select(ug => new GameViewModel()
                {
                    Id = ug.Id,
                    Title = ug.Title,
                    ImageThumbnail = ug.ImageThumbnail,
                    Description = ug.Description,
                    Price = ug.Price,
                    Size = ug.Size
                }).ToList();

            HomeGamesViewModel viewModel = new HomeGamesViewModel()
            {
                AllGames = games
            };

            return viewModel;
        }

        internal void BuyGame(BuyGameBindingModel bindingModel, HttpSession session)
        {
            User user = this.context.Logins
                .First(l => l.SessionId == session.Id && l.IsActive == true)
                .User;
            Game game = this.context.Games.Find(bindingModel.GameId);
            user.Games.Add(game);
            this.context.SaveChanges();
        }
    }
}
