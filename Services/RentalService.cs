using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VillageRMS.Models;


namespace VillageRMS.Services
{
    public class RentalService
    {
        public static async Task<RentalCategory> LoadCategoryByIdAsync(int categoryId)
        {
            try
            {
                return await DatabaseService.GetCategoryByIdAsync(categoryId);
            }
            catch (Exception ex)
            {
                throw new Exception($"An error occurred while loading the category: {ex.Message}");
            }
        }
    }
}
