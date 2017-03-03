using System;

namespace Shouter.App.BindingModels
{
    public class UserRegisterBindingModel
    {
        public string Username { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }

        public string ConfirmPassword { get; set; }

        public DateTime BirthDate { get; set; }
    }
}
