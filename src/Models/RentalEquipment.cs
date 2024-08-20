using System;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VillageRMS.Services;

namespace VillageRMS.Models
{
    public class RentalEquipment
    {
        private int _equipmentId;
        //private RentalCategory _category;
        private string _name;
        private string _description;
        private double _dailyRentalCost;
        private int _categoryId;

        public int EquipmentId
        {
            get { return _equipmentId; }
            set { _equipmentId = value; }
        }

        [Required(ErrorMessage = "CategoryID required")]
        public int CategoryId
        {
            /*
            get => _category?.CategoryId ?? 0;
            set
            {
                if (_category == null || _category.CategoryId != value)
                {
                    LoadCategoryById(value).ConfigureAwait(false);
                }
            }
            */
            get => _categoryId;
            set { _categoryId = value; }
        }

        /*
        [Required(ErrorMessage = "CategoryDescription required")]
        public string CategoryDescription
        {
            get => _category?.CategoryDescription ?? string.Empty;
        }*/

        [Required(ErrorMessage = "Equipment Name required")]
        [StringLength(50, ErrorMessage = "Name cannot exceed 50 characters")]
        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        [Required(ErrorMessage = "Description required")]
        [StringLength(100, ErrorMessage = "Description cannot exceed 100 characters")]
        public string Description
        {
            get { return _description; }
            set { _description = value; }
        }

        [Required(ErrorMessage = "Daily rental cost is required")]
        [Range(0, double.MaxValue, ErrorMessage = "Daily rental cost must be a positive number")]
        public double Daily_rental_cost
        {
            get { return _dailyRentalCost; }
            set { _dailyRentalCost = value; }
        }

        public RentalEquipment() { }

        public RentalEquipment(int equipmentId, string name, string description, double dailyRentalCost )
        {
            _equipmentId = equipmentId;            
            _name = name;
            _description = description;
            _dailyRentalCost = dailyRentalCost;
                        
        }

        public override string ToString()
        {
            return "";
        }


        /*public async Task LoadCategoryById(int categoryId)
        {
            _category = await DatabaseService.LoadCategoryByIdAsync(categoryId);
        }*/

    }
}
