using System;
using System.Collections.Generic;
using System.Linq;

namespace ACM.BL
{
    public class InvoiceRepository
    {
        public List<Invoice> Retrieve()
        {
            List<Invoice> invoiceList = new List<Invoice>
                    {new Invoice()
                          { InvoiceId = 1,
                            CustomerId = 1,
                            InvoiceDate=new DateTime(2013, 6, 20),
                            DueDate=new DateTime(2013, 7,29),
                            IsPaid=null,
                            Amount=199.99M,
                            NumberOfUnits=20,
                            DiscountPercent=0M},
                    new Invoice()
                          { InvoiceId = 2,
                            CustomerId = 1,
                            InvoiceDate=new DateTime(2013, 7, 20),
                            DueDate=new DateTime(2013, 8,20),
                            IsPaid=null,
                            Amount=98.50M,
                            NumberOfUnits=10,
                            DiscountPercent=10M},
                    new Invoice()
                          { InvoiceId = 3,
                            CustomerId = 2,
                            InvoiceDate=new DateTime(2013, 7, 25),
                            DueDate=new DateTime(2013, 8,25),
                            IsPaid=null,
                            Amount=250M,
                            NumberOfUnits=25,
                            DiscountPercent=10M},
                    new Invoice()
                          { InvoiceId = 4,
                            CustomerId = 3,
                            InvoiceDate=new DateTime(2013, 7, 1),
                            DueDate=new DateTime(2013, 8,1),
                            IsPaid=true,
                            Amount=20M,
                            NumberOfUnits=2,
                            DiscountPercent=15M},
                    new Invoice()
                          { InvoiceId = 5,
                            CustomerId = 1,
                            InvoiceDate=new DateTime(2013, 8, 20),
                            DueDate=new DateTime(2013, 9,29),
                            IsPaid=true,
                            Amount=225M,
                            NumberOfUnits=22,
                            DiscountPercent=10M},
                    new Invoice()
                          { InvoiceId = 6,
                            CustomerId = 2,
                            InvoiceDate=new DateTime(2013, 8, 20),
                            DueDate=new DateTime(2013, 8,20),
                            IsPaid=false,
                            Amount=75M,
                            NumberOfUnits=8,
                            DiscountPercent=0M},
                    new Invoice()
                          { InvoiceId = 7,
                            CustomerId = 3,
                            InvoiceDate=new DateTime(2013,8, 25),
                            DueDate=new DateTime(2013, 9,25),
                            IsPaid=null,
                            Amount=500M,
                            NumberOfUnits=42,
                            DiscountPercent=10M},
                    new Invoice()
                          { InvoiceId = 8,
                            CustomerId = 4,
                            InvoiceDate=new DateTime(2013, 8, 1),
                            DueDate=new DateTime(2013, 9,1),
                            IsPaid=true,
                            Amount=75M,
                            NumberOfUnits=7,
                            DiscountPercent=0M}};

            return invoiceList;
        }

        public IEnumerable<Invoice> Retrieve(int customerId)
        {
            var invoiceList = this.Retrieve();
            List<Invoice> filteredList = invoiceList
                                            .Where(i => i.CustomerId == customerId)
                                            .ToList();
            return filteredList;
        }

        public decimal CalculateTotalAmountInvoiced(List<Invoice> invoiceList)
        {
            return invoiceList.Sum(i => i.TotalAmount);
        }

        public int CalculateTotalUnitsSold(List<Invoice> invoiceList)
        {
            return invoiceList.Sum(i => i.NumberOfUnits);
        }

        public dynamic GetInvoiceTotalByIsPaid(List<Invoice> invoiceList)
        {
            var query = invoiceList
                            .GroupBy(i => i.IsPaid ?? false,                     // keySelector :        key for grouping
                                     i => i.TotalAmount,                         // elementSelector :    value to select
                                     (groupKey, invoiceTotal) => new             // resultSelector :     shape of the result
                                     {
                                        Key = groupKey,
                                        InvoicedAmount = invoiceTotal.Sum()
                                     });
            foreach (var item in query)
            {
                Console.WriteLine(item.Key + ": " + item.InvoicedAmount);
            }

            return query;
        }

        public dynamic GetInvoiceTotalByIsPaidAndMonth(List<Invoice> invoiceList)
        {
            var query = invoiceList
                            .GroupBy(inv => new                                     // keySelectors
                            {
                                IsPaid = inv.IsPaid ?? false,
                                InvoiceMonth = inv.InvoiceDate.ToString("MMMM")
                            },
                            inv => inv.TotalAmount,                                 // elementSelector
                            (groupKey, invTotal) => new                             // resultSelector
                            {
                                Key = groupKey,
                                InvoiceAmount = invTotal.Sum()
                            });

            foreach (var item in query)
            {
                Console.WriteLine(item.Key.IsPaid + "/" + item.Key.InvoiceMonth + ": " + item.InvoiceAmount);
            }

            return query;
        }
    }
}