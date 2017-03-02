using System;
using SimpleMVC.Interfaces;
using PizzaMore.App.Utillities;
using System.Text;
using PizzaMore.App.ViewModels;
using SimpleMVC.Interfaces.Generic;

namespace PizzaMore.App.Views.Menu
{
    public class Suggestions : IRenderable<UserSuggestionsViewModel>
    {
        public UserSuggestionsViewModel Model { get; set; }

        public string Render()
        {
            StringBuilder bd = new StringBuilder();

            bd.Append(WebUtil.RetrieveFileContent("../../Content/yoursuggestions-top.html"));
            bd.Append(this.Model.ToString());
            bd.Append(WebUtil.RetrieveFileContent("../../Content/yoursuggestions-bottom.html"));

            return bd.ToString();
        }
    }
}
