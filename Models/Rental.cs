using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VillageRMS.Models
{
    public class Rental
    {
        public int RentalId {  get; set; }
        public DateOnly RecordDate { get; set; }
        public int CustomerId { get; set; }
        public int EquipmentId { get; set; }
        public DateOnly RentalDate { get; set; }
        public DateOnly ReturnDate { get; set; }

        public double Cost { get; set; }

        public Rental() { }

        public Rental(int rentalId, DateOnly recordDate, int customerId, int equipmentId, DateOnly rentalDate, DateOnly returnDate, double cost)
        {
            RentalId = rentalId;
            RecordDate = recordDate;
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
