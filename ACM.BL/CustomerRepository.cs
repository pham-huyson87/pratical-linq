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

            // Function Delagate
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
    }
}
