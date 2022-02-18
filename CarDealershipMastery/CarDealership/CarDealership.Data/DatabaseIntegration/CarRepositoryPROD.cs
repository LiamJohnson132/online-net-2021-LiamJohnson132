using CarDealership.Models;
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
    public class CarRepositoryPROD : ICarRepository
    {
        public void Delete(int carId)
        {
            using (var cn = new SqlConnection(Settings.GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand("CarDelete", cn);
                cmd.CommandType = CommandType.StoredProcedure;


                cmd.Parameters.AddWithValue("@CarId", carId);

                cn.Open();

                cmd.ExecuteNonQuery();
            }
        }

        public Car GetById(int carId)
        {
            var car = new Car();

            using (var cn = new SqlConnection(Settings.GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand("CarGetById", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@CarId", carId);

                cn.Open();

                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    if (dr.Read())
                    {
                        car.CarId = (int)dr["CarId"];
                        car.MakeId = (int)dr["MakeId"];
                        car.ModelId = (int)dr["ModelId"];
                        car.TypeId = (int)dr["TypeId"];
                        car.BodyStyleId = (int)dr["BodyStyleId"];
                        car.Year = (int)dr["Year"];
                        car.TransmissionId = (int)dr["TransmissionId"];
                        car.ColorId = (int)dr["ColorId"];
                        car.InteriorId = (int)dr["InteriorId"];
                        car.Price = (decimal)dr["Price"];
                        car.Mileage = (int)dr["Mileage"];
                        car.MSRP = (decimal)dr["MSRP"];
                        car.VIN = dr["VIN"].ToString();
                        car.Description = dr["Description"].ToString();
                        car.ImgFileName = dr["ImgFileName"].ToString();
                        car.IsSold = (bool)dr["IsSold"];
                        car.IsFeatured = (bool)dr["IsFeatured"];
                    }
                }
            }

            return car;
        }

        public Car GetDetails(int carId)
        {
            var car = new Car();

            using (var cn = new SqlConnection(Settings.GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand("CarGetDetails", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@CarId", carId);

                cn.Open();

                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    if (dr.Read())
                    {
                        car.CarId = (int)dr["CarId"];
                        car.Year = (int)dr["Year"];
                        car.Make = dr["Make"].ToString();
                        car.Model = dr["Model"].ToString();
                        car.BodyStyle = dr["BodyStyle"].ToString();
                        car.Interior = dr["Interior"].ToString();
                        car.Price = (decimal)dr["Price"];
                        car.Transmission = dr["Transmission"].ToString();
                        car.Mileage = (int)dr["Mileage"];
                        car.MSRP = (decimal)dr["MSRP"];
                        car.Color = dr["Color"].ToString();
                        car.VIN = dr["VIN"].ToString();
                        car.Description = dr["Description"].ToString();
                        car.ImgFileName = dr["ImgFileName"].ToString();
                        car.IsSold = (bool)dr["IsSold"];
                    }
                }
            }

            return car;
        }

        public List<Car> GetFeatured()
        {
            var cars = new List<Car>();

            using (var cn = new SqlConnection(Settings.GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand("CarSelectFeatured", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                cn.Open();

                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        var row = new Car();

                        row.CarId = (int)dr["CarId"];
                        row.VIN = dr["VIN"].ToString();
                        row.Year = (int)dr["Year"];
                        row.Make = dr["Make"].ToString();
                        row.Model = dr["Model"].ToString();
                        row.ImgFileName = dr["ImgFileName"].ToString();
                        row.Price = (decimal)dr["Price"];

                        cars.Add(row);
                    }
                }
            }

            return cars;
        }

        public void Insert(Car car)
        {
            using (var cn = new SqlConnection(Settings.GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand("CarInsert", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                SqlParameter param = new SqlParameter("@CarId", SqlDbType.Int);
                param.Direction = ParameterDirection.Output;
                cmd.Parameters.Add(param);

                cmd.Parameters.AddWithValue("@ModelId", car.ModelId);
                cmd.Parameters.AddWithValue("@TypeId", car.TypeId);
                cmd.Parameters.AddWithValue("@BodyStyleId", car.BodyStyleId);
                cmd.Parameters.AddWithValue("@Year", car.Year);
                cmd.Parameters.AddWithValue("@TransmissionId", car.TransmissionId);
                cmd.Parameters.AddWithValue("@ColorId", car.ColorId);
                cmd.Parameters.AddWithValue("@InteriorId", car.InteriorId);
                cmd.Parameters.AddWithValue("@Mileage", car.Mileage);
                cmd.Parameters.AddWithValue("@VIN", car.VIN);
                cmd.Parameters.AddWithValue("@MSRP", car.MSRP);
                cmd.Parameters.AddWithValue("@Price", car.Price);
                cmd.Parameters.AddWithValue("@Description", car.Description);
                cmd.Parameters.AddWithValue("@ImgFileName", car.ImgFileName);

                cn.Open();

                cmd.ExecuteNonQuery();

                car.CarId = (int)param.Value;
            }
        }

        public List<Car> SearchAll(SearchParameters parameters)
        {
            var cars = new List<Car>();

            using (var cn = new SqlConnection(Settings.GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand("CarAllSearch", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@Parameter", parameters.Parameter);
                cmd.Parameters.AddWithValue("@YearParameter", parameters.YearParameter);
                cmd.Parameters.AddWithValue("@PriceMin", parameters.PriceMin);
                cmd.Parameters.AddWithValue("@PriceMax", parameters.PriceMax);
                cmd.Parameters.AddWithValue("@YearMin", parameters.YearMin);
                cmd.Parameters.AddWithValue("@YearMax", parameters.YearMax);

                cn.Open();

                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        var row = new Car();

                        row.CarId = (int)dr["CarId"];
                        row.Year = (int)dr["Year"];
                        row.Make = dr["Make"].ToString();
                        row.Model = dr["Model"].ToString();
                        row.ImgFileName = dr["ImgFileName"].ToString();
                        row.BodyStyle = dr["BodyStyle"].ToString();
                        row.Interior = dr["Interior"].ToString();
                        row.Price = (decimal)dr["Price"];
                        row.Transmission = dr["Transmission"].ToString();
                        row.Mileage = (int)dr["Mileage"];
                        row.MSRP = (decimal)dr["MSRP"];
                        row.Color = dr["Color"].ToString();
                        row.VIN = dr["VIN"].ToString();

                        cars.Add(row);
                    }
                }
            }

            return cars;
        }

        public List<Car> SearchNew(SearchParameters parameters)
        {
            var cars = new List<Car>();

            using (var cn = new SqlConnection(Settings.GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand("CarNewSearch", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@Parameter", parameters.Parameter);
                cmd.Parameters.AddWithValue("@YearParameter", parameters.YearParameter);
                cmd.Parameters.AddWithValue("@PriceMin", parameters.PriceMin);
                cmd.Parameters.AddWithValue("@PriceMax", parameters.PriceMax);
                cmd.Parameters.AddWithValue("@YearMin", parameters.YearMin);
                cmd.Parameters.AddWithValue("@YearMax", parameters.YearMax);

                cn.Open();

                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        var row = new Car();

                        row.CarId = (int)dr["CarId"];
                        row.Year = (int)dr["Year"];
                        row.Make = dr["Make"].ToString();
                        row.Model = dr["Model"].ToString();
                        row.ImgFileName = dr["ImgFileName"].ToString();
                        row.BodyStyle = dr["BodyStyle"].ToString();
                        row.Interior = dr["Interior"].ToString();
                        row.Price = (decimal)dr["Price"];
                        row.Transmission = dr["Transmission"].ToString();
                        row.Mileage = (int)dr["Mileage"];
                        row.MSRP = (decimal)dr["MSRP"];
                        row.Color = dr["Color"].ToString();
                        row.VIN = dr["VIN"].ToString();

                        cars.Add(row);
                    }
                }
            }

            return cars;
        }

        public List<Car> SearchUsed(SearchParameters parameters)
        {
            var cars = new List<Car>();

            using (var cn = new SqlConnection(Settings.GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand("CarUsedSearch", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@Parameter", parameters.Parameter);
                cmd.Parameters.AddWithValue("@YearParameter", parameters.YearParameter);
                cmd.Parameters.AddWithValue("@PriceMin", parameters.PriceMin);
                cmd.Parameters.AddWithValue("@PriceMax", parameters.PriceMax);
                cmd.Parameters.AddWithValue("@YearMin", parameters.YearMin);
                cmd.Parameters.AddWithValue("@YearMax", parameters.YearMax);

                cn.Open();

                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        var row = new Car();

                        row.CarId = (int)dr["CarId"];
                        row.Year = (int)dr["Year"];
                        row.Make = dr["Make"].ToString();
                        row.Model = dr["Model"].ToString();
                        row.ImgFileName = dr["ImgFileName"].ToString();
                        row.BodyStyle = dr["BodyStyle"].ToString();
                        row.Interior = dr["Interior"].ToString();
                        row.Price = (decimal)dr["Price"];
                        row.Transmission = dr["Transmission"].ToString();
                        row.Mileage = (int)dr["Mileage"];
                        row.MSRP = (decimal)dr["MSRP"];
                        row.Color = dr["Color"].ToString();
                        row.VIN = dr["VIN"].ToString();

                        cars.Add(row);
                    }
                }
            }

            return cars;
        }

        public void Update(Car car)
        {
            using (var cn = new SqlConnection(Settings.GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand("CarUpdate", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@CarId", car.CarId);
                cmd.Parameters.AddWithValue("@ModelId", car.ModelId);
                cmd.Parameters.AddWithValue("@TypeId", car.TypeId);
                cmd.Parameters.AddWithValue("@BodyStyleId", car.BodyStyleId);
                cmd.Parameters.AddWithValue("@Year", car.Year);
                cmd.Parameters.AddWithValue("@TransmissionId", car.TransmissionId);
                cmd.Parameters.AddWithValue("@ColorId", car.ColorId);
                cmd.Parameters.AddWithValue("@InteriorId", car.InteriorId);
                cmd.Parameters.AddWithValue("@Mileage", car.Mileage);
                cmd.Parameters.AddWithValue("@VIN", car.VIN);
                cmd.Parameters.AddWithValue("@MSRP", car.MSRP);
                cmd.Parameters.AddWithValue("@Price", car.Price);
                cmd.Parameters.AddWithValue("@Description", car.Description);
                cmd.Parameters.AddWithValue("@ImgFileName", car.ImgFileName);

                if (car.IsSold == true)
                {
                    cmd.Parameters.AddWithValue("@IsSold", 1);
                } else
                {
                    cmd.Parameters.AddWithValue("@IsSold", 0);
                }
                if (car.IsFeatured == true)
                {
                    cmd.Parameters.AddWithValue("@IsFeatured", 1);
                }
                else
                {
                    cmd.Parameters.AddWithValue("@IsFeatured", 0);
                }

                cn.Open();

                cmd.ExecuteNonQuery();
            }
        }

        public int GetNextCarId()
        {
            int result = 0;

            using (var cn = new SqlConnection(Settings.GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand("CarGetNextId", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                cn.Open();

                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    if (dr.Read())
                    {
                        result = (int)dr["Result"];
                    }
                }
            }

            return result;
        }
    }
}
