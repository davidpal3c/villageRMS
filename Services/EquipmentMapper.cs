using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VillageRMS.Models;
using MySqlConnector;
using System.Xml.Linq;

namespace VillageRMS.Services
{
    public class EquipmentMapper
    {
        public RentalEquipment MapFromReaderRentalEquipment(MySqlDataReader reader)
        {
            try
            {
                return new RentalEquipment
                {
                    EquipmentId = reader.GetInt32("equipment_id"),
                    Category = reader.GetInt32("category"),
                    Name = reader.GetString("Name"),
                    Description = reader.GetString("description"),
                    Daily_rental_cost = reader.GetDouble("daily_rental_cost")
                };
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }
    }
}
