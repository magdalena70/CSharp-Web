using PizzaMore.App.BindingModels;
using PizzaMore.App.Data;
using PizzaMore.App.Models;
using PizzaMore.App.ViewModels;
using SimpleHttpServer.Models;
using System.Linq;
using System;

namespace PizzaMore.App.Services
{
    public class PizzasService : Service
    {
        public PizzasService(PizzaMoreContext context) : base(context)
        {
        }

        internal void AddPizza(AddPizzaBindingModel bindingModel, HttpSession currentSession)
        {
            User currentUser = this.context.Sessions
                    .First(s => s.SessionId == currentSession.Id).User;
            currentUser.PizzaSuggestions.Add( new Pizza()
            {
                Title = bindingModel.Title,
                ImageUrl = bindingModel.Url,
                Recipe = bindingModel.Recipe
            });
            
            this.context.SaveChanges();
        }

        internal PizzaDetailsViewModel ShowDetails(int pizzaId)
        {
            Pizza pizza = this.context.Pizzas.Find(pizzaId);
            PizzaDetailsViewModel viewModel = new PizzaDetailsViewModel()
            {
                Title = pizza.Title,
                Recipe = pizza.Recipe,
                ImageUrl = pizza.ImageUrl,
                UpVotes = pizza.UpVotes,
                DownVotes = pizza.DownVotes
            };

            return viewModel;
        }

        internal MenuPizzasViewModel ShowAllPizzas()
        {
            MenuPizzasViewModel viewModel = new MenuPizzasViewModel()
            {
                PizzaSuggestions = this.context.Pizzas.ToList()
            };

            return viewModel;
        }

        internal void AddVote(VotePizzaBindingModel bindingModel)
        {
            Pizza currentPizza = this.context.Pizzas.Find(bindingModel.PizzaId);
            if (bindingModel.Vote == "Up")
            {
                currentPizza.UpVotes++;
            }

            if (bindingModel.Vote == "Down")
            {
                currentPizza.DownVotes++;
            }

            this.context.SaveChanges();
        }

        internal UserSuggestionsViewModel ShowUserSuggestions(HttpSession currentSession)
        {
            UserSuggestionsViewModel viewModel = new UserSuggestionsViewModel()
            {
                UserSuggestions = this.context.Sessions
                    .First(s => s.SessionId == currentSession.Id)
                    .User.PizzaSuggestions
                    .ToList()
            };

            return viewModel;
        }

        internal void DeletePizza(int id)
        {
            Pizza pizza = this.context.Pizzas.Find(id);
            this.context.Pizzas.Remove(pizza);
            this.context.SaveChanges();
        }
    }
}
