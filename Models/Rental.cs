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
        private DateTime _currentDate;
        private int _customerId;
        private int _equipmentId;
        private DateTime _rentalDate;
        private DateTime _returnDate;
        private double _cost;

        public int RentalId
        {
            get { return _rentalId; } 
            set { _rentalId = value; }
        }

        public DateTime CurrentDate
        {
            get { return _currentDate; }
            set { _currentDate = value; }
        }

        public int CustomerId
        {
            get { return _customerId; }
            set { _customerId = value; }
        }

        public int EquipmentId
        {
            get { return _equipmentId; }
            set { _equipmentId = value; }
        }

        public DateTime RentalDate
        {
            get { return _rentalDate; }
            set { _rentalDate = value; }
        }

        public DateTime ReturnDate
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

        public Rental(int rentalId, DateTime currentDate, int customerId, int equipmentId, DateTime rentalDate, DateTime returnDate, double cost)
        {
            RentalId = rentalId;
            CurrentDate = currentDate;
            CustomerId = customerId;
            EquipmentId = equipmentId;
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
