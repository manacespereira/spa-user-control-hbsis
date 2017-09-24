

namespace HBSIS.SpaUserControl.Data.Context
{
    public sealed class SpaContextSingleton
    {
        private SpaContextSingleton() { }

        static SpaContextSingleton() { }

        public static SpaContext Instance { get; } = new SpaContext();
    }
}
