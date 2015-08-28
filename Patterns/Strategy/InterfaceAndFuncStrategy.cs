using System;
using System.Collections.Generic;


namespace Patterns.Strategy
{
    public class InterfaceAndFuncStrategy
    {
        public static void SortLists()
        {
            var employees = new List<Employee>();
            var employeeByIdComparer = new EmployeeByIdComparer();
            Comparison<Employee> comparison = (x, y) => x.Id.CompareTo(x.Id);

            employees.Sort(employeeByIdComparer);

            employees.Sort(comparison);

            var set = new SortedSet<Employee>(employeeByIdComparer);

            var comparer = ComparerFactory.Create(comparison);
            var set1 = new SortedSet<Employee>(comparer);
        }


        private class Employee
        {
            public int Id { get; set; }
            public string Name { get; set; }


            public override string ToString()
            {
                return $"Id = {Id}, Name = {Name}";
            }
        }


        private class EmployeeByIdComparer : IComparer<Employee>
        {
            public int Compare(Employee x, Employee y)
            {
                return x.Id.CompareTo(y.Id);
            }
        }


        private class ComparerFactory
        {
            public static IComparer<T> Create<T>(Comparison<T> comparer)
            {
                return new DelegateComparer<T>(comparer);
            }


            private class DelegateComparer<T> : IComparer<T>
            {
                private readonly Comparison<T> comparer;


                public DelegateComparer(Comparison<T> comparer)
                {
                    this.comparer = comparer;
                }


                public int Compare(T x, T y)
                {
                    return comparer(x, y);
                }
            }
        }
    }
}
