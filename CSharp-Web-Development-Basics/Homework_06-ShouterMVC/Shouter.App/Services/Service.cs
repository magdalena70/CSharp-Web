using Shouter.App.Data;

namespace Shouter.App.Services
{
    public abstract class Service
    {
        protected ShouterContext context;

        public Service(ShouterContext context)
        {
            this.context = context;
        }
    }
}
