using System;
using System.Runtime.ExceptionServices;


namespace Patterns.FactoryMethod
{
    public class GenericFactory
    {
        public abstract class Product
        {
            protected internal abstract void PostConstruction();
        }


        public class ConcreteProduct : Product
        {
            internal ConcreteProduct()
            {
            }


            protected internal override void PostConstruction()
            {
                Console.WriteLine("ConcreteProduct: post construction");
            }
        }


        public static class ProductFactory
        {
            public static T Create<T>()
                where T : Product, new()
            {
                try
                {
                    var product = new T();
                    product.PostConstruction();

                    return product;
                }
                catch (Exception exception)
                {
                    var exceptionDispatchInfo = ExceptionDispatchInfo.Capture(exception.InnerException);
                    exceptionDispatchInfo.Throw();

                    return default(T);
                }
            }
        }
    }
}
