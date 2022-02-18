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
    public class ModelRepositoryPROD : IModelRepository
    {
        public List<Model> GetAll()
        {
            var models = new List<Model>();

            using (var cn = new SqlConnection(Settings.GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand("ModelGetAll", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                cn.Open();

                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        var row = new Model();

                        row.MakeId = (int)dr["ModelId"];
                        row.Name = dr["Name"].ToString();
                        row.DateAdded = (DateTime)dr["DateAdded"];
                        row.UserEmail = dr["UserEmail"].ToString();
                        row.Make = dr["Make"].ToString();

                        models.Add(row);
                    }
                }
            }

            return models;
        }

        public List<Model> GetByMake(int makeId)
        {
            var models = new List<Model>();

            using (var cn = new SqlConnection(Settings.GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand("ModelSelectAllByMake", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@MakeId", makeId);

                cn.Open();

                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        var row = new Model();

                        row.MakeId = (int)dr["MakeId"];
                        row.ModelId = (int)dr["ModelId"];
                        row.Name = dr["Name"].ToString();
                        row.DateAdded = (DateTime)dr["DateAdded"];
                        row.UserEmail = dr["UserEmail"].ToString();

                        models.Add(row);
                    }
                }
            }

            return models;
        }

        public void Insert(Model model)
        {
            using (var cn = new SqlConnection(Settings.GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand("ModelInsert", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                SqlParameter param = new SqlParameter("@ModelId", SqlDbType.Int);
                param.Direction = ParameterDirection.Output;
                cmd.Parameters.Add(param);

                cmd.Parameters.AddWithValue("@Name", model.Name);
                cmd.Parameters.AddWithValue("@UserEmail", model.UserEmail);
                cmd.Parameters.AddWithValue("@MakeId", model.MakeId);

                cn.Open();

                cmd.ExecuteNonQuery();

                model.ModelId = (int)param.Value;
            }
        }
    }
}
