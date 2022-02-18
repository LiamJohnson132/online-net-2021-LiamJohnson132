using CarDealership.Models;
using CarDealership.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarDealership.Data.DatabaseIntegration
{
    public class BodyStyleRepositoryPROD : IBodyStyleRepository
    {
        public List<BodyStyle> GetAll()
        {
            var bodyStyles = new List<BodyStyle>();

            using (var cn = new SqlConnection(Settings.GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand("BodyStyleGetAll", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                cn.Open();

                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        var row = new BodyStyle();

                        row.BodyStyleId = (int)dr["BodyStyleId"];
                        row.Name = dr["Name"].ToString();

                        bodyStyles.Add(row);
                    }
                }
            }

            return bodyStyles;
        }
    }
}
