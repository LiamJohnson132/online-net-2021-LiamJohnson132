using CarDealership.Models.Interfaces;
using CarDealership.Models.Queries;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarDealership.Data.DatabaseIntegration
{
    public class UserRepositoryPROD : IUserRepository
    {

        public List<InventoryReportModel> GetNewInventoryReports()
        {
            var reports = new List<InventoryReportModel>();

            using (var cn = new SqlConnection(Settings.GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand("InventoryReportNewGet", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                cn.Open();

                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        var row = new InventoryReportModel();

                        row.Year = (int)dr["Year"];
                        row.Make = dr["Make"].ToString();
                        row.Model = dr["Model"].ToString();
                        row.Count = (int)dr["Count"];
                        row.StockValue = (decimal)dr["StockValue"];

                        reports.Add(row);
                    }
                }
            }

            return reports;
        }

        public List<RoleModel> GetRoles()
        {
            var roles = new List<RoleModel>();

            using (var cn = new SqlConnection(Settings.GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand("RoleGetAll", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                cn.Open();

                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        var row = new RoleModel();

                        row.RoleId = dr["RoleId"].ToString();
                        row.Name = dr["Name"].ToString();

                        roles.Add(row);
                    }
                }
            }

            return roles;
        }

        public List<SalesReportModel> GetSalesReports(SalesReportParameters parameters)
        {
            var reports = new List<SalesReportModel>();

            using (var cn = new SqlConnection(Settings.GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand("SalesReportGet", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@DateMin", parameters.DateMin);
                cmd.Parameters.AddWithValue("@DateMax", parameters.DateMax);

                cn.Open();

                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        var row = new SalesReportModel();

                        row.FullName = dr["FullName"].ToString();
                        row.TotalVehicles = (int)dr["TotalVehicles"];
                        row.TotalSales = (decimal)dr["TotalSales"];

                        reports.Add(row);
                    }
                }
            }

            return reports;
        }

        public List<SalesReportModel> GetSalesReportsByUser(SalesReportParameters parameters)
        {
            var reports = new List<SalesReportModel>();

            using (var cn = new SqlConnection(Settings.GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand("SalesReportGet", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@UserId", parameters.UserId);
                cmd.Parameters.AddWithValue("@DateMin", parameters.DateMin);
                cmd.Parameters.AddWithValue("@DateMax", parameters.DateMax);

                cn.Open();

                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        var row = new SalesReportModel();

                        row.FullName = dr["FullName"].ToString();
                        row.TotalVehicles = (int)dr["TotalVehicles"];
                        row.TotalSales = (decimal)dr["TotalSales"];

                        reports.Add(row);
                    }
                }
            }

            return reports;
        }

        public List<InventoryReportModel> GetUsedInventoryReports()
        {
            var reports = new List<InventoryReportModel>();

            using (var cn = new SqlConnection(Settings.GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand("InventoryReportUsedGet", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                cn.Open();

                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        var row = new InventoryReportModel();

                        row.Year = (int)dr["Year"];
                        row.Make = dr["Make"].ToString();
                        row.Model = dr["Model"].ToString();
                        row.Count = (int)dr["Count"];
                        row.StockValue = (decimal)dr["StockValue"];

                        reports.Add(row);
                    }
                }
            }

            return reports;
        }

        public List<UserModel> GetUsers()
        {
            var users = new List<UserModel>();

            using (var cn = new SqlConnection(Settings.GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand("UserGetAll", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                cn.Open();

                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        var row = new UserModel();

                        row.UserId = dr["UserId"].ToString();
                        row.LastName = dr["LastName"].ToString();
                        row.FirstName = dr["FirstName"].ToString();
                        row.Email = dr["Email"].ToString();
                        row.Role = dr["Role"].ToString();
                        row.FullName = dr["FullName"].ToString();

                        users.Add(row);
                    }
                }
            }

            return users;
        }
    }
}
