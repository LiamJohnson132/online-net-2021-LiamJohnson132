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
    public class ContactRepositoryPROD : IContactRepository
    {
        public Contact GetById(int id)
        {
            var contact = new Contact();

            using (var cn = new SqlConnection(Settings.GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand("ContactGetById", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@ContactId", id);

                cn.Open();

                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    if (dr.Read())
                    {
                        contact.ContactId = (int)dr["ContactId"];
                        contact.Name = dr["Name"].ToString();
                    }
                }
            }

            return contact;
        }

        public void Insert(Contact contact)
        {
            using (var cn = new SqlConnection(Settings.GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand("ContactInsert", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@Name", contact.Name);

                if (contact.Email == null)
                {
                    cmd.Parameters.AddWithValue("@Email", DBNull.Value);
                } else
                {
                    cmd.Parameters.AddWithValue("@Email", contact.Email);
                }
                
                if (contact.Phone == null)
                {
                    cmd.Parameters.AddWithValue("@Phone", DBNull.Value);
                } else
                {
                    cmd.Parameters.AddWithValue("@Phone", contact.Phone);
                }

                cmd.Parameters.AddWithValue("@Message", contact.Message);

                cn.Open();

                cmd.ExecuteNonQuery();
            }
        }
    }
}
