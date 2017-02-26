using SimpleHttpServer.Models;
using SimpleMVC.App.BindingModels;
using SimpleMVC.App.Data;
using SimpleMVC.App.Models;
using SimpleMVC.App.MVC.Attributes.Methods;
using SimpleMVC.App.MVC.Controllers;
using SimpleMVC.App.MVC.Interfaces;
using SimpleMVC.App.MVC.Interfaces.Generic;
using SimpleMVC.App.MVC.Security;
using SimpleMVC.App.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SimpleMVC.App.Controllers
{
    public class UsersController : Controller
    {
        private SignInManager signInManager;

        public UsersController()
        {
            signInManager = new SignInManager(new NotesAppContext());
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Register(RegisterUserBindingModel model, HttpResponse response)
        {
            if (model.Username == null && model.Password == null)
            {
                Redirect(response, "/home/index");
                return null;
            }

            User user = new User()
            {
                Username = model.Username,
                Password = model.Password
            };

            using (NotesAppContext context = new NotesAppContext())
            {
                context.Users.Add(user);
                context.SaveChanges();
            }

            return View();
        }

        [HttpGet]
        public IActionResult<IEnumerable<AllUsernamesViewModel>> All(HttpSession session, HttpResponse response)
        {
            if (!signInManager.IsAuthenticated(session))
            {
                Redirect(response, "/users/login");
                return null;
            }

            using (NotesAppContext context = new NotesAppContext())
            {
                var users = context.Users.Select(u => new { UserId = u.Id, u.Username }).ToList();
                var viewModel = new List<AllUsernamesViewModel>();

                foreach (var user in users)
                {
                    viewModel.Add(new AllUsernamesViewModel()
                    {
                        UserId = user.UserId,
                        Username = user.Username
                    });
                }

                return View(viewModel.AsEnumerable());
            }
        }

        [HttpGet]
        public IActionResult<UserProfileViewModel> Profile(int id, HttpSession session, HttpResponse response)
        {
            if (id <= 0)
            {
                Redirect(response, "/users/login");
                return null;
            }

            if (!signInManager.IsAuthenticated(session))
            {
                Redirect(response, "/users/login");
                return null;
            }

            var viewModel = new UserProfileViewModel();

            using (NotesAppContext context = new NotesAppContext())
            {
                var user = context.Users.Find(id);
                if (user != null)
                {
                    viewModel = new UserProfileViewModel()
                    {
                        SessionId = session.Id,
                        UserId = user.Id,
                        Username = user.Username,
                        Notes = user.Notes
                            .Select(un => new NoteViewModel()
                            {
                                Title = un.Title,
                                Content = un.Content
                            })
                    };
                }

                return View(viewModel);
            }
        }

        [HttpPost]
        public IActionResult<UserProfileViewModel> Profile(AddNoteBindingModel model, HttpSession session, HttpResponse response)
        {
            if (model.Title == null || model.Content == null)
            {
                Redirect(response, "/users/login");
                return null;
            }

            using (NotesAppContext context = new NotesAppContext())
            {
                var user = context.Users.Find(model.UserId);

                var note = new Note()
                {
                    Title = model.Title,
                    Content = model.Content
                };

                user.Notes.Add(note);
                context.SaveChanges();

                return Profile(model.UserId, session, response);
            }
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(LoginUserBindingModel model, HttpSession session, HttpResponse response)
        {
            string username = model.Username;
            string password = model.Password;
            string sessionId = session.Id;

            using (NotesAppContext context = new NotesAppContext())
            {
                User user = context.Users.FirstOrDefault(u => u.Username == username && u.Password == password);
                if (user != null)
                {
                    Login login = new Login()
                    {
                        User = user,
                        SessionId = sessionId,
                        IsActive = true
                    };

                    context.Logins.Add(login);
                    context.SaveChanges();
                    Redirect(response, "/home/index");
                    return null;
                }
            }

            return View();
        }

        [HttpGet]
        public IActionResult Logout()
        {
            return View();
        }

        //to do
        //[HttpPost]
        //public IActionResult Logout(HttpSession session)
        //{
        //    signInManager.Logout(session);          
        //    return View("Home", "Index");
        //}
    }
}
