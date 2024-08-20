using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
//using Windows.Networking;

namespace VillageRMS.Models
{
    internal class Employee : User
    {
        private int _employeeId;
        private bool _isAdmin;

        public int EmployeeId
        {
            get { return _employeeId; }
            set { _employeeId = value; }
        }


        public bool IsAdmin
        {
            get { return _isAdmin; }
            set { _isAdmin = value; }
        }

        public Employee(string lastName, string firstName, string phoneNumber, string emailAddress, int employeeId, bool isAdmin, string notes) : base(lastName, firstName, phoneNumber, emailAddress, notes)
        {
            this._employeeId = _employeeId;
            this._isAdmin = _isAdmin;
        }
        public override string ToString()
        {
            return $"ID:{EmployeeId} Name: {LastName},{FirstName} Phone:{PhoneNumber} Email:{EmailAddress}";
        }


    }
}
