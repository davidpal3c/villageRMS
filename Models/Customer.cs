using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VillageRMS.Models
{
    internal class Customer : DatabaseConnection
    {
        private int _customerId;
        private string _lastName;
        private string _firstName;
        private string _phoneNumber;
        private string _emailAddress;

        public int CustomerId
        {
            get { return _customerId; }
            set { _customerId = value; }
        }

        public string LastName
        {
            get { return _lastName; }
            set { _lastName = value; }
        }

        public string FirstName
        {
            get { return _firstName; }
            set { _firstName = value; }
        }

        public string PhoneNumber
        {
            get { return _phoneNumber; }
            set { _phoneNumber = value; }
        }

        public string EmailAddress
        {
            get { return _emailAddress; }
            set { _emailAddress = value; }
        }

        public Customer() { }

        public Customer(int customerId, string lastName, string firstName, string phoneNumber, string emailAddress)
        {
            _customerId = customerId;
            _lastName = lastName;
            _firstName = firstName;
            _phoneNumber = phoneNumber;
            _emailAddress = emailAddress;
        
        }

        public override string ToString()
        {
            return "";
        }

    }
}
