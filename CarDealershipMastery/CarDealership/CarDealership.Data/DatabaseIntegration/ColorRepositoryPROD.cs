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
    public class ColorRepositoryPROD : IColorRepository
    {
        public List<Color> GetAll()
        {
            var colors = new List<Color>();

            using (var cn = new SqlConnection(Settings.GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand("ColorGetAll", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                cn.Open();

                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        var row = new Color();

                        row.ColorId = (int)dr["ColorId"];
                        row.Name = dr["Name"].ToString();

                        colors.Add(row);
                    }
                }
            }

            return colors;
        }
    }
}
