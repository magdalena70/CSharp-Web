using PizzaMore.App.Data;
using PizzaMore.App.Models;
using SimpleHttpServer.Models;
using SimpleHttpServer.Utilities;
using System.Linq;

namespace PizzaMore.App.Security
{
    public class SignInManager
    {
        private PizzaMoreContext context;

        public SignInManager(PizzaMoreContext context)
        {
            this.context = context;
        }

        public bool IsAuthenticated(HttpSession session)
        {
            bool isAuthenticated = this.context.Sessions.Any(s => s.SessionId == session.Id && s.IsActive);

            return isAuthenticated;
        }
    }
}
