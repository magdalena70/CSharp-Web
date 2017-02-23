using System;
using SimpleMVC.App.MVC.Interfaces.Generic;

namespace SimpleMVC.App.MVC.ViewEngine.Generic
{
    public class ActionResult<T> : IActionResult<T>
    {
        public ActionResult(string viewFullQualifedName, T model)
        {
            this.Action = (IRenderable<T>)Activator
                            .CreateInstance(Type.GetType(viewFullQualifedName));
            this.Action.Model = model;
        }

        public IRenderable<T> Action { get; set; }
      
        public string Invoke()
        {
            return this.Action.Render();
        }
    }
}
