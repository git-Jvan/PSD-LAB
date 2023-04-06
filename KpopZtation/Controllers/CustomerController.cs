using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using KpopZtation.Handlers;
using KpopZtation.Model;

namespace KpopZtation.Controllers
{
    public class CustomerController
    {
        CustomerHandler ch;

        public CustomerController()
        {
            ch = new CustomerHandler();
        }

        public string insertCustomer(string CustomerName, string CustomerEmail, string CustomerPassword, string CustomerGender, string CustomerAddress, string CustomerRole)
        {
            string validate = validateRegisterCustomer(CustomerName, CustomerEmail, CustomerPassword, CustomerGender, CustomerAddress);
            if(validate.Equals("Customer Registered!"))
            {
                ch.insertCustomer(CustomerName, CustomerEmail, CustomerPassword, CustomerGender, CustomerAddress, CustomerRole);
                return validate;
            }
            else
            {
                return validate;
            }
        }

        public string updateCustomer(int CustomerID, string CustomerName, string CustomerEmail, string CustomerPassword, string CustomerGender, string CustomerAddress, int CustomerEmailTaken)
        {
            string validate = validateUpdateCustomer(CustomerName, CustomerEmail, CustomerPassword, CustomerGender, CustomerAddress, CustomerEmailTaken);
            if(validate.Equals("Customer Updated!"))
            {
                ch.updateCustomer(CustomerID, CustomerName, CustomerEmail, CustomerPassword, CustomerGender, CustomerAddress);
                return validate;
            }
            else
            {
                return validate;
            }
        }

        public void deleteCustomer(int CustomerID)
        {
            ch.deleteCustomer(CustomerID);
        }

        public string loginCustomer(string CustomerEmail, string CustomerPassword)
        {
            return validateLoginCustomer(CustomerEmail, CustomerPassword);
        }
        
        public Customer getCustomerByID(int CustomerID)
        {
            return ch.getCustomerByID(CustomerID);
        }

        public Customer getCustomerByLogin(string CustomerEmail, string CustomerPassword)
        {
            return ch.getCustomerByLogin(CustomerEmail, CustomerPassword);
        }

        public string validateRegisterCustomer(string CustomerName, string CustomerEmail, string CustomerPassword, string CustomerGender, string CustomerAddress)
        {
            if(CustomerName.Length == 0 || (CustomerName.Length <= 5 || CustomerName.Length >= 50))
            {
                if(CustomerName.Length == 0)
                {
                    return "Customer's Name Must be Filled!";
                }
                else if(CustomerName.Length <= 5 || CustomerName.Length >= 50)
                {
                    return "Customer's Name Must Between 5 and 50 Characters!";
                }
            }

            if(CustomerEmail.Length == 0 || ch.isEmailTrue(CustomerEmail) == true)
            {
                if(CustomerEmail.Length == 0)
                {
                    return "Customer's Email Must be Filled!";
                }
                else if(ch.isEmailTrue(CustomerEmail) == true)
                {
                    return "Customer's Email Address is Already Taken!";
                }   
            }

            if (CustomerPassword.Length == 0 || isPasswordTrue(CustomerPassword) == false)
            {
                if (CustomerPassword.Length == 0)
                {
                    return "Customer's Password Must be Filled!";
                }
                else if (isPasswordTrue(CustomerPassword) == false)
                {
                    return "Customer's Password Must be Alphanumeric!";
                }
            }

            if (CustomerGender.Length == 0)
            {
                return "Customer's Gender Must be Selected!";
            }


            if(CustomerAddress.Length == 0 || CustomerAddress.EndsWith("Street") == false)
            {
                if(CustomerAddress.Length == 0)
                {
                    return "Customer's Address Must be Filled!";
                }
                else if(CustomerAddress.EndsWith("Street") == false)
                {
                    return "Customer's Address Must Ends with 'Street'!";
                }
            }

            return "Customer Registered!";
        }

        public string validateUpdateCustomer(string CustomerName, string CustomerEmail, string CustomerPassword, string CustomerGender, string CustomerAddress, int CustomerEmailTaken)
        {
            if (CustomerName.Length == 0 || (CustomerName.Length <= 5 || CustomerName.Length >= 50))
            {
                if (CustomerName.Length == 0)
                {
                    return "Customer's Name Must be Filled!";
                }
                else if (CustomerName.Length <= 5 || CustomerName.Length >= 50)
                {
                    return "Customer's Name Must Between 5 and 50 Characters!";
                }
            }

            if (CustomerEmail.Length == 0 || (ch.isEmailTrue(CustomerEmail) == true && CustomerEmailTaken == -1))
            {
                if (CustomerEmail.Length == 0)
                {
                    return "Customer's Email Must be Filled!";
                }
                else if (ch.isEmailTrue(CustomerEmail) == true && CustomerEmailTaken == -1)
                {
                    return "Customer's Email Address is Already Taken!";
                }
            }

            if (CustomerPassword.Length == 0 || isPasswordTrue(CustomerPassword) == false)
            {
                if (CustomerPassword.Length == 0)
                {
                    return "Customer's Password Must be Filled!";
                }
                else if (isPasswordTrue(CustomerPassword) == false)
                {
                    return "Customer's Password Must be Alphanumeric!";
                }
            }

            if (CustomerGender.Length == 0)
            {
                return "Customer's Gender Must be Selected!";
            }


            if (CustomerAddress.Length == 0 || CustomerAddress.EndsWith("Street") == false)
            {
                if (CustomerAddress.Length == 0)
                {
                    return "Customer's Address Must be Filled!";
                }
                else if (CustomerAddress.EndsWith("Street") == false)
                {
                    return "Customer's Address Must Ends with 'Street'!";
                }
            }

            return "Customer Updated!";
        }

        public bool isPasswordTrue(string CustomerPassword)
        {
            Boolean hasAlphabet1 = false;
            Boolean hasAlphabet2 = false;
            Boolean hasDigit = false;
            Boolean hasAll = false;

            foreach(char p in CustomerPassword)
            {
                if (p >= 'a' && p <= 'z')
                {
                    hasAlphabet1 = true;
                }
                else if(p >= 'A' && p <= 'Z')
                {
                    hasAlphabet2 = true;
                }
                else if (p >= '0' && p <= '9')
                {
                    hasDigit = true;
                }
            }

            if(hasAlphabet1 == true && hasAlphabet2 == true && hasDigit == true)
            {
                hasAll = true;
            }

            return hasAll;
        }

        public string validateLoginCustomer(string CustomerEmail, string CustomerPassword)
        {
            if(CustomerEmail.Length == 0 || ch.isEmailTrue(CustomerEmail) == false)
            {
                if(CustomerEmail.Length == 0)
                {
                    return "Email Must be Filled!";
                }
                else if(ch.isEmailTrue(CustomerEmail) == false)
                {
                    return "Email Address Does Not Register!";
                }
            }

            if(CustomerPassword.Length == 0 || ch.isPasswordTrue(CustomerPassword) == false)
            {
                if(CustomerPassword.Length == 0)
                {
                    return "Password Must be Filled!";
                }
                else if(ch.isPasswordTrue(CustomerPassword) == false)
                {
                    return "Wrong Password!";
                }
            }

            return "Login Successfully!";
        }
    }
}