using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using KpopZtation.Repositories;
using KpopZtation.Model;

namespace KpopZtation.Handlers
{
    public class CustomerHandler
    {
        CustomerRepository cr;

        public CustomerHandler()
        {
            cr = new CustomerRepository(); 
        }

        public void insertCustomer(string CustomerName, string CustomerEmail, string CustomerPassword, string CustomerGender, string CustomerAddress, string CustomerRole)
        {
            cr.insertCustomer(CustomerName, CustomerEmail, CustomerPassword, CustomerGender, CustomerAddress, CustomerRole);
        }

        public void deleteCustomer(int CustomerID)
        {
            cr.deleteCustomer(CustomerID);
        }

        public void updateCustomer(int CustomerID, string CustomerName, string CustomerEmail, string CustomerPassword, string CustomerGender, string CustomerAddress)
        {
            cr.updateCustomer(CustomerID, CustomerName, CustomerEmail, CustomerPassword, CustomerGender, CustomerAddress);
        }

        public Customer getCustomerByID(int CustomerID)
        {
            return cr.getCustomerByID(CustomerID);
        }

        public Customer getCustomerByLogin(string CustomerEmail, string CustomerPassword)
        {
            return cr.getCustomerByLogin(CustomerEmail, CustomerPassword);
        }

        public Boolean isEmailTrue(string CustomerEmail)
        {
            return cr.isEmailTrue(CustomerEmail);
        }

        public Boolean isPasswordTrue(string CustomerPassword)
        {
            return cr.isPasswordTrue(CustomerPassword);
        }
    }
}