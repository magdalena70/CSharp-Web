using SimpleMVC.App.BindingModels;
using SimpleMVC.App.Data;
using SimpleMVC.App.Models;
using SimpleMVC.App.MVC.Attributes.Methods;
using SimpleMVC.App.MVC.Controllers;
using SimpleMVC.App.MVC.Interfaces;
using SimpleMVC.App.MVC.Interfaces.Generic;
using SimpleMVC.App.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SimpleMVC.App.Controllers
{
    public class UsersController : Controller
    {
        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Register(RegisterUserBindingModel model)
        {
            if (model.Username == null && model.Password == null)
            {
                Console.WriteLine("Error - Username or password can not be empty.");
                //throw new Exception("Error - Username or password can not be empty.");
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
        public IActionResult<IEnumerable<AllUsernamesViewModel>> All()
        {
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
        public IActionResult<UserProfileViewModel> Profile(int id)
        {
            if (id <= 0)
            {
                Console.WriteLine("Error - invalid id.");
                //throw new Exception("Error - invalid id.");
            }

            var viewModel = new UserProfileViewModel();

            using (NotesAppContext context = new NotesAppContext())
            {
                var user = context.Users.Find(id);
                if (user != null)
                {
                    viewModel = new UserProfileViewModel()
                    {
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
        public IActionResult<UserProfileViewModel> Profile(AddNoteBindingModel model)
        {
            if (model.Title == null || model.Content == null)
            {
                Console.WriteLine("Error - Title or Content can not be empty.");
                //throw new Exception("Error - invalid id or empty input field.");
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

                return Profile(model.UserId);
            }
        }
    }
}
