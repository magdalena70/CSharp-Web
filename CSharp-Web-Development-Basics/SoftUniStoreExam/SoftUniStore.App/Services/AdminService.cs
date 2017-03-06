using SoftUniStore.App.Data;
using SoftUniStore.App.ViewModels;
using System.Linq;
using System.Collections.Generic;
using SoftUniStore.App.BindingModels;
using System;
using SoftUniStore.App.Models;

namespace SoftUniStore.App.Services
{
    public class AdminService : Service
    {
        public AdminService(SoftUniContext context) : base(context)
        {
        }

        internal ICollection<AdminGamesViewModel> GetAll()
        {
            ICollection<AdminGamesViewModel> viewModel = this.context.Games.Select(g => new AdminGamesViewModel()
            {
                Id = g.Id,
                Title = g.Title,
                Price = g.Price,
                Size = g.Size
            }).ToList();

            return viewModel;
        }

        internal bool IsValidAdd(AddGameBindingModel bindingModel)
        {
            if (string.IsNullOrEmpty(bindingModel.Title) ||
                string.IsNullOrEmpty(bindingModel.Description) ||
                string.IsNullOrEmpty(bindingModel.ImageThumbnail) ||
                string.IsNullOrEmpty(bindingModel.Trailer) ||
                bindingModel.ReleaseDate == null ||
                bindingModel.Size < 0 || bindingModel.Price < 0)
            {
                return false;
            }

            if (bindingModel.Title.Length < 3 ||
                bindingModel.Title.Length > 100)
            {
                return false;
            }

            if (bindingModel.Trailer.Length != 11 ||
                bindingModel.Description.Length < 20)
            {
                return false;
            }

            if (bindingModel.ImageThumbnail.Substring(0, 7) == "http://" ||
                bindingModel.ImageThumbnail.Substring(0, 8) == "https://")
            {
                return true;
            }
            else
            {
                return false;
            }

            return true;
        }

        internal void AddGame(AddGameBindingModel bindingModel)
        {
            Game game = new Game()
            {
                Title = bindingModel.Title
                            .Substring(0, 1)
                            .ToUpper() + bindingModel.Title
                                    .Substring(1, bindingModel.Title.Length - 1),
                Description = bindingModel.Description,
                ImageThumbnail = bindingModel.ImageThumbnail,
                Trailer = bindingModel.Trailer,
                Price = bindingModel.Price,
                Size = bindingModel.Size,
                ReleaseDate = bindingModel.ReleaseDate
            };

            this.context.Games.Add(game);
            this.context.SaveChanges();
        }

        internal bool IsValidDelete(DeleteGameBindingModel bindingModel)
        {
            Game game = this.context.Games.Find(bindingModel.GameId);
            if (game == null)
            {
                return false;
            }

            return true;
        }

        internal void DeleteGame(DeleteGameBindingModel bindingModel)
        {
            Game game = this.context.Games.Find(bindingModel.GameId);
            this.context.Games.Remove(game);
            this.context.SaveChanges();
        }

        internal DeleteGameViewModel GetGameToDelete(int gameId)
        {
            Game game = this.context.Games.Find(gameId);
            DeleteGameViewModel viewModel = new DeleteGameViewModel()
            {
                GameId = game.Id,
                Title = game.Title
            };

            return viewModel;
        }
    }
}
