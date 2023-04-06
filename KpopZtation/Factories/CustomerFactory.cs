using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using KpopZtation.Model;

namespace KpopZtation.Factories
{
    public class CustomerFactory
    {
        public static Customer createCustomer(string CustomerName, string CustomerEmail, string CustomerPassword, string CustomerGender, string CustomerAddress, string CustomerRole)
        {
            Customer c = new Customer();
            c.CustomerName = CustomerName;
            c.CustomerEmail = CustomerEmail;
            c.CustomerPassword = CustomerPassword;
            c.CustomerGender = CustomerGender;
            c.CustomerAddress = CustomerAddress;
            c.CustomerRole = CustomerRole;
            return c;
        }
    }
}