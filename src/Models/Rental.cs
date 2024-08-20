using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VillageRMS.Models
{
    public class Rental
    {
        private int _rentalId;
        private DateOnly _currentDate;
        private int _customerId;
        private string _customerName;
        private int _equipmentId;
        private string _equipmentName;
        private DateOnly _rentalDate;
        private DateOnly _returnDate;
        private double _cost;

        public int RentalId
        {
            get { return _rentalId; } 
            set { _rentalId = value; }
        }

        public DateOnly CurrentDate
        {
            get { return _currentDate; }
            set { _currentDate = value; }
        }

        public int CustomerId
        {
            get { return _customerId; }
            set { _customerId = value; }
        }

        public string CustomerName
        {
            get { return _customerName; }
            set { _customerName = value; }
        }

        public int EquipmentId
        {
            get { return _equipmentId; }
            set { _equipmentId = value; }
        }

        public string EquipmentName
        {
            get { return _equipmentName; }
            set { _equipmentName = value; }
        }

        public DateOnly RentalDate
        {
            get { return _rentalDate; }
            set { _rentalDate = value; }
        }

        public DateOnly ReturnDate
        {
            get { return _returnDate; }
            set { _returnDate = value; }
        }

        public double Cost
        {
            get { return _cost; }
            set { _cost = value; }
        }

        public Rental() { }

        public Rental(int rentalId, DateOnly currentDate, int customerId, string customerName, int equipmentId, string equipmentName, DateOnly rentalDate, DateOnly returnDate, double cost)
        {
            RentalId = rentalId;
            CurrentDate = currentDate;
            CustomerId = customerId;
            CustomerName = customerName;
            EquipmentId = equipmentId;
            EquipmentName = equipmentName;
            RentalDate = rentalDate;
            ReturnDate = returnDate;
            Cost = cost;
        
        }

        public override string ToString() 
        {
            return $"";
        }
    }
}
