using SimpleHttpServer.Models;
using SoftUniStore.App.Data;
using System.Linq;
using System;
using SoftUniStore.App.Models;

namespace SoftUniStore.App.Security
{
    public class LoginManager
    {
        private SoftUniContext context;

        public LoginManager(SoftUniContext context)
        {
            this.context = context;
        }

        public bool IsAuthenticated(HttpSession session)
        {
            bool isAuthenticated = this.context.Logins.Any(s => s.SessionId == session.Id && s.IsActive);

            return isAuthenticated;
        }

        internal bool IfUserIsAdmin(HttpSession session)
        {
            User user = this.context.Logins
                .First(l => l.SessionId == session.Id && l.IsActive == true)
                .User;
            return user.IsAdmin;
        }
    }
}
