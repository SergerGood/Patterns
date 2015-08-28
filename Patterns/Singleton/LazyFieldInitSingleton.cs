using System;


namespace Patterns.Singleton
{
    public sealed class LazyFieldInitSingleton
    {
        private LazyFieldInitSingleton()
        {
        }


        public static LazyFieldInitSingleton Instance => SingeltonHolder.instance;


        private static class SingeltonHolder
        {
            public static readonly LazyFieldInitSingleton instance = new LazyFieldInitSingleton();
        }
    }
}
