using System;
using Shouter.App.BindingModels;
using Shouter.App.Data;
using SimpleHttpServer.Models;
using Shouter.App.Models;
using System.Linq;
using System.Collections.Generic;
using Shouter.App.ViewModels;

namespace Shouter.App.Services
{
    public class ShoutService : Service
    {
        public ShoutService(ShouterContext context) : base(context)
        {
        }

        internal FeedViewModel GetAllShouts()
        {
            FeedViewModel viewModel = new FeedViewModel()
            {
                AllShouts = this.context.Shout
                    .OrderBy(s => s.PostedOn)
                    .ToList()
            };

            foreach (var shout in viewModel.AllShouts)
            {
                var now = DateTime.Now;
                var timeSinceCreation = now - shout.PostedOn;
                if (timeSinceCreation > shout.Duration && shout.Duration.Value.Minutes != 0)
                {
                    this.context.Shout.Remove(shout);
                }
            }

            return viewModel;
        }

        internal bool IsValidAddShout(AddShoutBindingModel bindingModel)
        {
            if (string.IsNullOrEmpty(bindingModel.Content) ||
                bindingModel.Duration < 1 ||
                bindingModel.Duration > 23)
            {
                return false;
            }

            return true;
        }

        internal void AddShout(AddShoutBindingModel bindingModel, HttpSession currentSession)
        {
            User currentUser = this.context.Logins
                .First(s => s.SessionId == currentSession.Id).User;
           
            Shout shout = new Shout()
            {
                Content = bindingModel.Content,
                PostedOn = DateTime.Now,
                Author = currentUser,
                Duration =new TimeSpan(0, bindingModel.Duration, 0, 0)
            };

            this.context.Shout.Add(shout);
            this.context.SaveChanges();
        }
    }
}
