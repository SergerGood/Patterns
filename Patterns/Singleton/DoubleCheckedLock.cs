using System;


namespace Patterns.Singleton
{
    public sealed class DoubleCheckedLock
    {
        private static volatile DoubleCheckedLock instance;

        private static readonly object syncRoot = new object();


        private DoubleCheckedLock()
        {
        }


        public static DoubleCheckedLock Instance
        {
            get
            {
                if (instance == null)
                {
                    lock (syncRoot)
                    {
                        if (instance == null)
                        {
                            instance = new DoubleCheckedLock();
                        }
                    }
                }

                return instance;
            }
        }
    }
}
