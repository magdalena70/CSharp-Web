using SoftUniStore.App.Data;

namespace SoftUniStore.App.Services
{
    public abstract class Service
    {
        protected SoftUniContext context;

        public Service(SoftUniContext context)
        {
            this.context = context;
        }
    }
}
