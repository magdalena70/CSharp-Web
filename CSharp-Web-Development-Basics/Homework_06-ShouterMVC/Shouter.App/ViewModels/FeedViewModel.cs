using Shouter.App.Models;
using System.Collections.Generic;

namespace Shouter.App.ViewModels
{
    public class FeedViewModel
    {
        public ICollection<Shout> AllShouts { get; set; }
    }
}
