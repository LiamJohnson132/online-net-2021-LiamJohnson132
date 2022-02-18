using CarDealership.Models.Interfaces;
using CarDealership.Models.Tables;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarDealership.Data.DatabaseIntegration
{
    public class PurchaseTypeRepositoryPROD : IPurchaseTypeRepository
    {
        public List<PurchaseType> GetAll()
        {
            var purchaseTypes = new List<PurchaseType>();

            using (var cn = new SqlConnection(Settings.GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand("PurchaseTypeGetAll", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                cn.Open();

                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        var row = new PurchaseType();

                        row.PurchaseTypeId = (int)dr["PurchaseTypeId"];
                        row.Name = dr["Name"].ToString();

                        purchaseTypes.Add(row);
                    }
                }
            }

            return purchaseTypes;
        }
    }
}
