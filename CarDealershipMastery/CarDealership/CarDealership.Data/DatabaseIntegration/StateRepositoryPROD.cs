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
    public class StateRepositoryPROD : IStateRepository
    {
        public List<State> GetAll()
        {
            var states = new List<State>();

            using (var cn = new SqlConnection(Settings.GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand("StateGetAll", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                cn.Open();

                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        var row = new State();

                        row.StateId = dr["StateId"].ToString();
                        row.Name = dr["Name"].ToString();

                        states.Add(row);
                    }
                }
            }

            return states;
        }
    }
}
