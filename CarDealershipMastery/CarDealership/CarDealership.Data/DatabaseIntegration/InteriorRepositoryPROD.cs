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
    public class InteriorRepositoryPROD : IInteriorRepository
    {
        public List<Interior> GetAll()
        {
            var interiors = new List<Interior>();

            using (var cn = new SqlConnection(Settings.GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand("InteriorGetAll", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                cn.Open();

                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        var row = new Interior();

                        row.InteriorId = (int)dr["InteriorId"];
                        row.Name = dr["Name"].ToString();

                        interiors.Add(row);
                    }
                }
            }

            return interiors;
        }
    }
}
