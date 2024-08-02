using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VillageRMS.Models
{
    public abstract class User
    {
        private string _lastName;
        private string _firstName;
        private string _phoneNumber;
        private string _emailAddress;
        private string _status;

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

        public User() { }

        public User(string lastName, string firstName, string phoneNumber, string emailAddress)
        {
            _lastName = lastName;
            _firstName = firstName;
            _phoneNumber = phoneNumber;
            _emailAddress = emailAddress;
        }

        public abstract override string ToString();
    }

}
