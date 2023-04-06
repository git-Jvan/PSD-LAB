using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using KpopZtation.Model;
using KpopZtation.Factories;

namespace KpopZtation.Repositories
{
    public class CustomerRepository
    {
        private Database1Entities1 db;
        Customer c;

        public CustomerRepository()
        {
            db = Database.getDB();
            c = new Customer();
        }

        public void insertCustomer(string CustomerName, string CustomerEmail, string CustomerPassword, string CustomerGender, string CustomerAddress, string CustomerRole)
        {
            c = CustomerFactory.createCustomer(CustomerName, CustomerEmail, CustomerPassword, CustomerGender, CustomerAddress, CustomerRole);
            db.Customers.Add(c);
            db.SaveChanges();
        }

        public void deleteCustomer(int CustomerID)
        {
            c = db.Customers.Find(CustomerID);
            db.Customers.Remove(c);
            db.SaveChanges();
        }

        public void updateCustomer(int CustomerID, string CustomerName, string CustomerEmail, string CustomerPassword, string CustomerGender, string CustomerAddress)
        {
            c = db.Customers.Find(CustomerID);
            c.CustomerName = CustomerName;
            c.CustomerEmail = CustomerEmail;
            c.CustomerPassword = CustomerPassword;
            c.CustomerGender = CustomerGender;
            c.CustomerAddress = CustomerAddress;
            db.SaveChanges();
        }

        public Customer getCustomerByID(int CustomerID)
        {
            c = db.Customers.Find(CustomerID);
            return c;
        }

        public Customer getCustomerByLogin(string CustomerEmail, string CustomerPassword)
        {
            c = (from login in db.Customers where login.CustomerEmail.Equals(CustomerEmail) && login.CustomerPassword.Equals(CustomerPassword) select login).FirstOrDefault();
            return c;
        }

        public Boolean isEmailTrue(string CustomerEmail)
        {
            c = (from emailTrue in db.Customers where emailTrue.CustomerEmail.Equals(CustomerEmail) select emailTrue).FirstOrDefault();
            if(c == null)
            {
                return false;
            }
            return true;
        }

        public Boolean isPasswordTrue(string CustomerPassword)
        {
            c = (from passwordTrue in db.Customers where passwordTrue.CustomerPassword.Equals(CustomerPassword) select passwordTrue).FirstOrDefault();
            if(c == null)
            {
                return false;
            }
            return true;
        }
    }
}