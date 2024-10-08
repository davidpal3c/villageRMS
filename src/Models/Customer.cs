﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VillageRMS.Models
{
    public class Customer : User //: DatabaseConnection
    {
        private int _customerId;
        private string _status;

        public int CustomerId
        {
            get { return _customerId; }
            set { _customerId = value; }
        }

        public string Status
        {
            get { return _status; }
            set { _status = value; }
        }

        public Customer() { }

        public Customer(int customerId, string lastName, string firstName, string phoneNumber, string emailAddress,  string status, string notes) : base(lastName, firstName, phoneNumber, emailAddress, notes)
        {
            this._customerId = customerId;
            this._status = status;            
        }


        public override string ToString()
        {
            return $"ID:{CustomerId} Name: {LastName},{FirstName} Phone:{PhoneNumber} Email:{EmailAddress} Status:{Status}";
        }

    }
}
