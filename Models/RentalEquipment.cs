using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VillageRMS.Models
{
    internal class RentalEquipment
    {
        private int _equipmentId;
        private int _category;
        private string _name;
        private string _description;
        private double _dailyRentalCost;

        public int EquipmentId
        {
            get { return _equipmentId; }
            set { _equipmentId = value; }
        }

        public int Category
        {
            get { return _category; }
            set { _category = value; }
        }

        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        public string Description
        {
            get { return _description; }
            set { _description = value; }
        }

        public double Daily_rental_cost
        {
            get { return _dailyRentalCost; }
            set { _dailyRentalCost = value; }
        }

        public RentalEquipment() { }

        public RentalEquipment(int equipmentId, int category, string name, string description, double dailyRentalCost )
        {
            _equipmentId = equipmentId;
            _category = category;
            _name = name;
            _description = description;
            _dailyRentalCost = dailyRentalCost;
        }

        public override string ToString()
        {
            return "";
        }

        
    }
}
