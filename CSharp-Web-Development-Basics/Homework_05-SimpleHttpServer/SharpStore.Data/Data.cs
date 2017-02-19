namespace SharpStore.Data
{
    public class Data
    {
        private static SharpStoreContext context;

        public static SharpStoreContext Context
        {
            get
            {
                return context == null ? new SharpStoreContext() : context;
            }
        }
    }
}
