using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VillageRMS.Models
{
    public class Customer //: DatabaseConnection
    {
        private int _customerId;
        private string _lastName;
        private string _firstName;
        private string _phoneNumber;
        private string _emailAddress;
        private string _status;

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

        public string Status
        {
            get { return _status; }
            set { _status = value; }
        }

        public Customer() { }

        public Customer(int customerId, string lastName, string firstName, string phoneNumber, string emailAddress, string status)
        {
            _customerId = customerId;
            _lastName = lastName;
            _firstName = firstName;
            _phoneNumber = phoneNumber;
            _emailAddress = emailAddress;
            _status = status;
        }

        public override string ToString()
        {
            return $"ID:{CustomerId} Name: {LastName},{FirstName} Phone:{PhoneNumber} Status:{Status}";
        }

    }
}
