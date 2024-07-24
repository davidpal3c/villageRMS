using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VillageRMS.Models
{
    internal class RentalCategory
    {
        private int _categoryId;
        private string _categoryDescription;

        public int CategoryId
        {
            get { return _categoryId; }
            set { _categoryId = value; }
        }

        public string CategoryDescription
        {
            get { return _categoryDescription; }
            set { _categoryDescription = value; }
        }

        public RentalCategory() { }

        public RentalCategory(int categoryId, string categoryDescription)
        {
            _categoryId = categoryId;
            _categoryDescription = categoryDescription;
        }

        public override string ToString()
        {
            return "";
        }
    
    }
}
