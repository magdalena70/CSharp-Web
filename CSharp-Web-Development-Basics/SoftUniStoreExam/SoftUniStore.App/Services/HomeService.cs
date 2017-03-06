using System;
using SoftUniStore.App.BindingModels;
using SoftUniStore.App.Data;
using System.Text.RegularExpressions;
using System.Linq;
using SoftUniStore.App.Models;
using SimpleHttpServer.Models;
using SimpleHttpServer.Utilities;

namespace SoftUniStore.App.Services
{
    public class HomeService : Service
    {
        public HomeService(SoftUniContext context) : base(context)
        {
        }

        internal bool IsRegisterModelValid(RegisterBindingModel bindingModel)
        {
            if (string.IsNullOrEmpty(bindingModel.FullName) ||
                string.IsNullOrEmpty(bindingModel.Email) ||
                string.IsNullOrEmpty(bindingModel.Password) ||
                string.IsNullOrEmpty(bindingModel.ConfirmPassword))
            {
                return false;
            }
                

            Regex regex = new Regex("^[A-Za-z0-9]+$");
            if (!regex.IsMatch(bindingModel.Password) || bindingModel.Password.Length < 6)
            {
                return false;
            }

            if (!bindingModel.Email.Contains("@") && !bindingModel.Email.Contains("."))
            {
                return false;
            }

            if (bindingModel.Password != bindingModel.ConfirmPassword)
            {
                return false;
            }


            if (this.context.Users.Any(u => u.Email == bindingModel.Email))
            {
                return false;
            }

            return true;
        }

        internal void RegisterUser(RegisterBindingModel bindingModel)
        {
            User user = new User()
            {
                FullName = bindingModel.FullName,
                Email = bindingModel.Email,
                Password = bindingModel.Password
            };

            if (this.context.Users.Count() == 0)
            {
                user.IsAdmin = true;
            }

            this.context.Users.Add(user);
            this.context.SaveChanges();
        }

        internal void LoginUser(LoginBindingModel bindingModel, string sessionId)
        {
            User user = this.context.Users.First(u => 
                            u.Email == bindingModel.Email &&
                            u.Password == bindingModel.Password);
            Login login = new Login()
            {
                User = user,
                SessionId = sessionId,
                IsActive = true
            };

            this.context.Logins.Add(login);
            this.context.SaveChanges();
        }

        internal bool IsLoginModelValid(LoginBindingModel bindingModel)
        {
            if (string.IsNullOrEmpty(bindingModel.Email) ||
                string.IsNullOrEmpty(bindingModel.Password))
            {
                return false;
            }

            if (!this.context.Users.Any(u => 
                    u.Email == bindingModel.Email &&
                    u.Password == bindingModel.Password))
            {
                return false;
            }

            return true;
        }

        internal void Logout(HttpResponse response, string sessionId)
        {
            Login currentLogin = this.context.Logins.First(s => s.SessionId == sessionId);
            currentLogin.IsActive = false;
            this.context.SaveChanges();

            var session = SessionCreator.Create();
            var sessionCookie = new Cookie("sessionId", session.Id + "; HttpOnly; path=/");
            response.Header.AddCookie(sessionCookie);
        }
    }
}
