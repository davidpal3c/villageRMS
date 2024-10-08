﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VillageRMS.Models;
using MySqlConnector;

namespace VillageRMS.Services
{
    public class RentalInformationMapper
    {
        public Rental MapFromReaderRentalInformation(MySqlDataReader reader)
        {
            try
            {
                return new Rental
                {
                    RentalId = reader.GetInt32("rental_id"),
                    CurrentDate = reader.GetDateOnly("currentdate"),
                    CustomerId = reader.GetInt32("customer_id"),
                    EquipmentId = reader.GetInt32("equipment_id"),
                    RentalDate = reader.GetDateOnly("rental_date"),
                    ReturnDate = reader.GetDateOnly("return_date"),
                    Cost = reader.GetDouble("cost")
                };
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
