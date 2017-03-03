using Shouter.App.Data;
using SimpleHttpServer.Models;
using System.Linq;

namespace Shouter.App.Security
{
    public class LoginManager
    {
        private ShouterContext context;

        public LoginManager(ShouterContext context)
        {
            this.context = context;
        }

        public bool IsAuthenticated(HttpSession session)
        {
            bool isAuthenticated = this.context.Logins.Any(s => s.SessionId == session.Id && s.IsActive);

            return isAuthenticated;
        }
    }
}
