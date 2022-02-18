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
    public class TypeRepositoryPROD : ITypeRepository
    {
        public List<VehicleType> GetAll()
        {
            var types = new List<VehicleType>();

            using (var cn = new SqlConnection(Settings.GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand("TypeGetAll", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                cn.Open();

                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        var row = new VehicleType();

                        row.TypeId = (int)dr["TypeId"];
                        row.Name = dr["Name"].ToString();

                        types.Add(row);
                    }
                }
            }

            return types;
        }
    }
}
