using System;
using PizzaMore.App.BindingModels;
using PizzaMore.App.Data;
using PizzaMore.App.Models;
using System.Linq;
using SimpleHttpServer.Models;
using SimpleHttpServer.Utilities;

namespace PizzaMore.App.Services
{
    public class UserService : Service
    {
        public UserService(PizzaMoreContext context) : base(context)
        {
        }

        public void SignupUser(UserSignupBindingModel bindingModel)
        {
                User user = new User()
                {
                    Email = bindingModel.SignUpEmail,
                    Password = bindingModel.SignUpPassword
                };

            this.context.Users.Add(user);
            this.context.SaveChanges();
        }

        public User GetCurrentUser(UserSigninBindingModel bindingModel)
        {
            User user = this.context.Users
                .FirstOrDefault(u => u.Email == bindingModel.SignInEmail &&
                                    u.Password == bindingModel.SignInPassword);

            return user;
        }

        public void SigninUser(UserSigninBindingModel bindingModel, HttpSession currentSession, User currentUser)
        {
            Session session = new Session()
            {
                SessionId = currentSession.Id,
                User = currentUser,
                IsActive = true
            };

            this.context.Sessions.Add(session);
            this.context.SaveChanges();
        }

        public void Logout(HttpResponse response, string sessionId)
        {
            Session currentSession = this.context.Sessions.FirstOrDefault(s => s.SessionId == sessionId);
            currentSession.IsActive = false;
            this.context.SaveChanges();

            var session = SessionCreator.Create();
            var sessionCookie = new Cookie("sessionId", session.Id + "; HttpOnly; path=/");
            response.Header.AddCookie(sessionCookie);
        }
    }
}
