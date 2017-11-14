using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace ACM.BL
{
    public class CustomerRepository
    {
        public Customer Find(List<Customer> customerList, int customerId)
        {
            Customer foundCustomer = null;

            // Original
            //foreach (var c in customerList)
            //{
            //    if (c.CustomerId == customerId)
            //    {
            //        foundCustomer = c;
            //        break;
            //    }
            //}


            // LINQ 
            //      - use Deferred Execution
            //      - have 2 syntax : Query Syntax and Method Syntax
            //      - the CLR use Query Syntax
            //      - LINQ is the extension methods of IEnumerable

            // Function Delegate
            //      - Func<X, Y> : Function that take X Type as parameter and return Y Type

            // Lambda Expression
            //      - Inline anonymous function (define directly and have no name)
            //          + No parameter :            () => true
            //          + Multiple parameters :     (x, y) => true


            // LINQ Query Syntax

            // 1. The query is defined here
            //var query = from c in customerList
            //            where c.CustomerId == customerId
            //            select c;

            // 2. The query executed here
            //foundCustomer = query.First(); 


            // LINQ Method Syntax

            // Single line expression
            //foundCustomer = customerList.FirstOrDefault(c =>                     // Parameter
            //                                c.CustomerId == customerId);         // Body of the function

            // Multiple line expression
            foundCustomer = customerList.FirstOrDefault(c => {
                Debug.Write(c.LastName);
                return c.CustomerId == customerId;
            });

            return foundCustomer;
        }

        public List<Customer> Retrieve()
        {
            List<Customer> custList = new List<Customer>
                    {new Customer() 
                          { CustomerId = 1, 
                            FirstName="Frodo",
                            LastName = "Baggins",
                            EmailAddress = "fb@hob.me",
                            CustomerTypeId=1},
                    new Customer() 
                          { CustomerId = 2, 
                            FirstName="Bilbo",
                            LastName = "Baggins",
                            EmailAddress = "bb@hob.me",
                            CustomerTypeId=null},
                    new Customer() 
                          { CustomerId = 3, 
                            FirstName="Samwise",
                            LastName = "Gamgee",
                            EmailAddress = "sg@hob.me",
                            CustomerTypeId=1},
                    new Customer() 
                          { CustomerId = 4, 
                            FirstName="Rosie",
                            LastName = "Cotton",
                            EmailAddress = "rc@hob.me",
                            CustomerTypeId=2}};
            return custList;
        }

        public IEnumerable<Customer> RetrieveEmptyList()
        {
            return Enumerable.Repeat(new Customer(), 5);
        }

        public IEnumerable<Customer> SortByName(List<Customer> customerList)
        {
            return customerList
                        .OrderBy(c => c.LastName)
                        .ThenBy(c => c.FirstName);
        }

        public IEnumerable<Customer> SortByNameInReverse(List<Customer> customerList)
        {
            return customerList
                        .OrderByDescending(c => c.LastName)
                        .ThenByDescending(c => c.FirstName);
        }

        public IEnumerable<Customer> SortByNameInReverse2(List<Customer> customerList)
        {
            return SortByName(customerList).Reverse();
        }

        public IEnumerable<Customer> SortByType(List<Customer> customerList)
        {
            return customerList.OrderBy(c => c.CustomerTypeId); // The property CustomerTypeId have null values.
                                                                // The null will be at the top by default from a sort.

        }

        public IEnumerable<Customer> SortByTypeNullAtBottom(List<Customer> customerList)
        {
            // Put null values at the bottom.
            return customerList
                        .OrderByDescending(c => c.CustomerTypeId.HasValue)      // Put the null values at the bottom
                        .ThenBy(c => c.CustomerTypeId);                         // Sort the rest in ASC order

            // So the null is the lowest value.
        }

        public IEnumerable<string> GetNames(List<Customer> customerList)
        {
            var query = customerList.Select(c => c.LastName + ", " + c.FirstName);
            return query;
        }

        public dynamic GetNamesAndEmails(List<Customer> customerList)   // dynamic bypass type checking
        {
            var query = customerList.Select(c => new {                  // Anonymous Type declaration
                Name = c.LastName + ", " + c.FirstName,
                c.EmailAddress                                          // equivalent to
                                                                        //      EmailAddress = c.EmailAddress
            });

            foreach (var item in query)
            {
                Console.WriteLine(item.Name + ":" + item.EmailAddress);
            }

            return query;
        }

        public dynamic GetNamesAndTypes(List<Customer> customerList, List<CustomerType> customerTypeList)
        {
            var query = customerList                                                        // Outer List
                                .Join(customerTypeList,                                     // Inner List
                                            c => c.CustomerTypeId,                          // Outer key selector
                                            ct => ct.CustomerTypeId,                        // Inner key selector
                                            (c, ct) => new                                  
                                            {                                               // Projection
                                                Name = c.LastName + ", " + c.FirstName,
                                                CustomerTypeName = ct.TypeName
                                            });

            foreach (var item in query)
            {
                Console.WriteLine(item.Name + " " + item.CustomerTypeName);
            }

            return query;
        }
    }
}
