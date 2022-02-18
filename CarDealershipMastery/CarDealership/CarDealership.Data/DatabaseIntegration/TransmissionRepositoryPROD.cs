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
    public class TransmissionRepositoryPROD : ITransmissionRepository
    {
        public List<Transmission> GetAll()
        {
            var transmissions = new List<Transmission>();

            using (var cn = new SqlConnection(Settings.GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand("TransmissionGetAll", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                cn.Open();

                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        var row = new Transmission();

                        row.TransmissionId = (int)dr["TransmissionId"];
                        row.Name = dr["Name"].ToString();

                        transmissions.Add(row);
                    }
                }
            }

            return transmissions;
        }
    }
}
