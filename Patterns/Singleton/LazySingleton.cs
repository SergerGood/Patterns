using System;


namespace Patterns.Singleton
{
    public sealed class LazySingleton
    {
        private static readonly Lazy<LazySingleton> instance
            = new Lazy<LazySingleton>(() => new LazySingleton());

        private LazySingleton()
        {
        }

        public static LazySingleton Instance => instance.Value;
    }
}
