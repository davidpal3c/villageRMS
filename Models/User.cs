using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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

        [Required(ErrorMessage = "Last name is required")]
        [StringLength(50, ErrorMessage = "Last name cannot exceed 50 characters")]
        public string LastName
        {
            get { return _lastName; }
            set { _lastName = value; }
        }

        [Required(ErrorMessage = "First name is required")]
        [StringLength(50, ErrorMessage = "First name cannot exceed 50 characters")]
        public string FirstName
        {
            get { return _firstName; }
            set { _firstName = value; }
        }

        [Required(ErrorMessage = "Phone number is required")]
        [RegularExpression(@"^\d+$", ErrorMessage = "Phone number must be numeric")]
        [StringLength(15, ErrorMessage = "Phone number cannot exceed 15 digits")]
        public string PhoneNumber
        {
            get { return _phoneNumber; }
            set { _phoneNumber = value; }
        }

        [Required(ErrorMessage = "Email is required")]
        [EmailAddress(ErrorMessage = "Invalid email address")]
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
