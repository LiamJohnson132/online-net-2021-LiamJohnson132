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
    public class OrderRepositoryPROD : IOrderRepository
    {
        public Order GetById(int id)
        {
            var order = new Order();

            using (var cn = new SqlConnection(Settings.GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand("OrderGetById", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@OrderId", id);

                cn.Open();

                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    if (dr.Read())
                    {
                        order.OrderId = (int)dr["OrderId"];
                        order.Name = dr["Name"].ToString();
                    }
                }
            }

            return order;
        }

        public void Insert(Order order)
        {
            using (var cn = new SqlConnection(Settings.GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand("OrderInsert", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                SqlParameter param = new SqlParameter("@OrderId", SqlDbType.Int);
                param.Direction = ParameterDirection.Output;
                cmd.Parameters.Add(param);

                cmd.Parameters.AddWithValue("@Name", order.Name);

                if (string.IsNullOrEmpty(order.Email))
                {
                    cmd.Parameters.AddWithValue("@Email", DBNull.Value);
                } else
                {
                    cmd.Parameters.AddWithValue("@Email", order.Email);
                }

                if (string.IsNullOrEmpty(order.Phone))
                {
                    cmd.Parameters.AddWithValue("@Phone", DBNull.Value);
                } else
                {
                    cmd.Parameters.AddWithValue("@Phone", order.Phone);
                }
                
                cmd.Parameters.AddWithValue("@StreetOne", order.StreetOne);

                if (string.IsNullOrEmpty(order.StreetTwo))
                {
                    cmd.Parameters.AddWithValue("@StreetTwo", DBNull.Value);
                } else
                {
                    cmd.Parameters.AddWithValue("@StreetTwo", order.StreetTwo);
                }
                
                cmd.Parameters.AddWithValue("@City", order.City);
                cmd.Parameters.AddWithValue("@Zipcode", order.Zipcode);

                if (string.IsNullOrEmpty(order.ZipcodeExtension))
                {
                    cmd.Parameters.AddWithValue("@ZipcodeExtension", DBNull.Value);
                } else
                {
                    cmd.Parameters.AddWithValue("@ZipcodeExtension", order.ZipcodeExtension);
                }
                
                cmd.Parameters.AddWithValue("@PurchasePrice", order.PurchasePrice);
                cmd.Parameters.AddWithValue("@UserEmail", order.UserEmail);
                cmd.Parameters.AddWithValue("@CarId", order.CarId);
                cmd.Parameters.AddWithValue("@PurchaseTypeId", order.PurchaseTypeId);
                cmd.Parameters.AddWithValue("@StateId", order.StateId);

                cn.Open();

                cmd.ExecuteNonQuery();

                order.OrderId = (int)param.Value;
            }
        }
    }
}
