using System;
using Shouter.App.BindingModels;
using Shouter.App.Data;
using Shouter.App.Models;
using System.Linq;
using SimpleHttpServer.Models;
using SimpleHttpServer.Utilities;

namespace Shouter.App.Services
{
    public class UserService : Service
    {
        public UserService(ShouterContext context) : base(context)
        {
        }

        internal void RegisterUser(UserRegisterBindingModel bindingModel)
        {
            User user = new User()
            {
                Username = bindingModel.Username,
                Email = bindingModel.Email,
                Password = bindingModel.Password,
                BirthDate = bindingModel.BirthDate
            };

            this.context.Users.Add(user);
            this.context.SaveChanges();
        }

        internal bool IsValidRegisterInput(UserRegisterBindingModel bindingModel)
        {
            if (string.IsNullOrEmpty(bindingModel.Username) ||
                string.IsNullOrEmpty(bindingModel.Email) ||
                string.IsNullOrEmpty(bindingModel.Password) ||
                string.IsNullOrEmpty(bindingModel.ConfirmPassword))
            {
                if (bindingModel.Password == bindingModel.ConfirmPassword)
                {
                    return false;
                }
            }

            return true;
        }

        internal User GetCurrentUser(UserLoginBindingModel bindingModel)
        {
            User user = this.context.Users
                .FirstOrDefault(u => u.Email == bindingModel.LoginEmail &&
                                    u.Password == bindingModel.LoginPassword);

            return user;
        }

        internal void LoginUser(UserLoginBindingModel bindingModel, User currentUser, HttpSession currentSession)
        {
            Login login = new Login()
            {
                SessionId = currentSession.Id,
                User = currentUser,
                IsActive = true
            };

            this.context.Logins.Add(login);
            this.context.SaveChanges();
        }

        internal bool IsValidLoginInput(UserLoginBindingModel bindingModel)
        {
            if (string.IsNullOrEmpty(bindingModel.LoginEmail) ||
                string.IsNullOrEmpty(bindingModel.LoginPassword))
            {
                return false;
            }

            return true;
        }

        internal void Logout(HttpResponse response, string sessionId)
        {
            Login currentLogin = this.context.Logins.FirstOrDefault(s => s.SessionId == sessionId);
            currentLogin.IsActive = false;
            this.context.SaveChanges();

            var session = SessionCreator.Create();
            var sessionCookie = new Cookie("sessionId", session.Id + "; HttpOnly; path=/");
            response.Header.AddCookie(sessionCookie);
        }
    }
}
