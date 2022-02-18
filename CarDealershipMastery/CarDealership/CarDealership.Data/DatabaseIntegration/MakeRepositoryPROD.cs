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
    public class MakeRepositoryPROD : IMakeRepository
    {
        public List<Make> GetAll()
        {
            var makes = new List<Make>();

            using (var cn = new SqlConnection(Settings.GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand("MakeGetAll", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                cn.Open();

                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        var row = new Make();

                        row.MakeId = (int)dr["MakeId"];
                        row.Name = dr["Name"].ToString();
                        row.DateAdded = (DateTime)dr["DateAdded"];
                        row.UserEmail = dr["UserEmail"].ToString();

                        makes.Add(row);
                    }
                }
            }

            return makes;
        }

        public void Insert(Make make)
        {
            using (var cn = new SqlConnection(Settings.GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand("MakeInsert", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                SqlParameter param = new SqlParameter("@MakeId", SqlDbType.Int);
                param.Direction = ParameterDirection.Output;
                cmd.Parameters.Add(param);

                cmd.Parameters.AddWithValue("@Name", make.Name);
                cmd.Parameters.AddWithValue("@UserEmail", make.UserEmail);

                cn.Open();

                cmd.ExecuteNonQuery();

                make.MakeId = (int)param.Value;
            }
        }
    }
}
