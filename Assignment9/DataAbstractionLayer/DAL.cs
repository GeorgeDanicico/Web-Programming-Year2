using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using MySql.Data.MySqlClient;
using Assignment9.Models;


namespace Assignment9.DataAbstractionLayer
{
    public class DAL
    {
        public int Login(string username, string password)
        {
            MySql.Data.MySqlClient.MySqlConnection conn;
            string myConnectionString;

            myConnectionString = "server=localhost;uid=root;pwd=;database=vacations;";

            try
            {
                conn = new MySql.Data.MySqlClient.MySqlConnection();
                conn.ConnectionString = myConnectionString;
                conn.Open();

                MySqlCommand cmd = new MySqlCommand();
                cmd.Connection = conn;
                cmd.CommandText = "select * from users where username='" + username + "' and password='" + password + "'";
                MySqlDataReader myreader = cmd.ExecuteReader();

                if (myreader.Read())
                {
                    int userId = myreader.GetInt32("id");
                    myreader.Close();
                    return userId;
                }

                myreader.Close();
                return -1;
            }
            catch (MySql.Data.MySqlClient.MySqlException ex)
            {
                Console.Write(ex.Message);
            }

            return -1;
        }

        public void DeleteDestination(int destId)
        {
            MySql.Data.MySqlClient.MySqlConnection conn;
            string myConnectionString;

            myConnectionString = "server=localhost;uid=root;pwd=;database=vacations;";

            try
            {
                conn = new MySql.Data.MySqlClient.MySqlConnection();
                conn.ConnectionString = myConnectionString;
                conn.Open();

                MySqlCommand cmd = new MySqlCommand();
                cmd.Connection = conn;
                cmd.CommandText = "delete from destinations where id=" + destId;
                cmd.ExecuteNonQuery();
            }
            catch (MySql.Data.MySqlClient.MySqlException ex)
            {
                Console.Write(ex.Message);
            }
        }

        public void UpdateDestination(int itemId, string city, string country, string description,
                string tourists, string estimated_cost)
        {
            MySql.Data.MySqlClient.MySqlConnection conn;
            string myConnectionString;

            myConnectionString = "server=localhost;uid=root;pwd=;database=vacations;";

            try
            {
                conn = new MySql.Data.MySqlClient.MySqlConnection();
                conn.ConnectionString = myConnectionString;
                conn.Open();

                MySqlCommand cmd = new MySqlCommand();
 
                cmd = new MySqlCommand();
                cmd.Connection = conn;
                cmd.CommandText = "update destinations set city='" + city + "', country='" + country + "', descriptions='" + description + 
                    "', tourists_target='" + tourists + "', estimated_cost=" + estimated_cost + " where id=" + itemId;

                cmd.ExecuteNonQuery();
            }
            catch (MySql.Data.MySqlClient.MySqlException ex)
            {
                Console.Write(ex.Message);
            }
        }

        public void InsertDestination(string city, string country, string description,
                string tourists, string estimated_cost, int userId)
        {
            MySql.Data.MySqlClient.MySqlConnection conn;
            string myConnectionString;

            myConnectionString = "server=localhost;uid=root;pwd=;database=vacations;";

            try
            {
                conn = new MySql.Data.MySqlClient.MySqlConnection();
                conn.ConnectionString = myConnectionString;
                conn.Open();

                MySqlCommand cmd = new MySqlCommand();
                cmd.Connection = conn;
                cmd.CommandText = "select max(id) as maxId from destinations";
                MySqlDataReader myreader = cmd.ExecuteReader();

                int itemId = 1;
                if (myreader.Read())
                {
                    itemId = myreader.GetInt32("maxId") + 1;
                }
                Console.WriteLine(itemId);
                myreader.Close();

                cmd = new MySqlCommand();
                cmd.Connection = conn;
                cmd.CommandText = "insert into destinations(id, city, country, descriptions, tourists_target, estimated_cost, userId) values (" + itemId + ", '" + city + "', '" +
                    country + "', '" + description + "', '" + tourists + "', " + 
                    estimated_cost + ", " + userId +
                    ")";

                cmd.ExecuteNonQuery();
            }
            catch (MySql.Data.MySqlClient.MySqlException ex)
            {
                Console.Write(ex.Message);
            }
        }
        public List<Destination> GetDestinations(int userId)
        {
            MySql.Data.MySqlClient.MySqlConnection conn;
            string myConnectionString;

            myConnectionString = "server=localhost;uid=root;pwd=;database=vacations;";
            List<Destination> dlist = new List<Destination>();

            try
            {
                conn = new MySql.Data.MySqlClient.MySqlConnection();
                conn.ConnectionString = myConnectionString;
                conn.Open();

                MySqlCommand cmd = new MySqlCommand();
                cmd.Connection = conn;
                cmd.CommandText = "select * from destinations where userId=" + userId;
                MySqlDataReader myreader = cmd.ExecuteReader();

                while (myreader.Read())
                {
                    Destination dest = new Destination();
                    dest.Id = myreader.GetInt32("id");
                    dest.Description = myreader.GetString("descriptions");
                    dest.City = myreader.GetString("city");
                    dest.Country = myreader.GetString("country");
                    dest.TouristTarget = myreader.GetString("tourists_target");
                    dest.EstimatedCost = myreader.GetInt32("estimated_cost");
                    dlist.Add(dest);
                }
                myreader.Close();
            }
            catch (MySql.Data.MySqlClient.MySqlException ex)
            {
                Console.Write(ex.Message);
            }
            return dlist;
        }

        public Destination GetDestination(int itemId)
        {
            MySql.Data.MySqlClient.MySqlConnection conn;
            string myConnectionString;

            myConnectionString = "server=localhost;uid=root;pwd=;database=vacations;";
            List<Destination> dlist = new List<Destination>();
            Destination dest = new Destination();

            try
                {
                    conn = new MySql.Data.MySqlClient.MySqlConnection();
                    conn.ConnectionString = myConnectionString;
                    conn.Open();

                    MySqlCommand cmd = new MySqlCommand();
                    cmd.Connection = conn;
                    cmd.CommandText = "select * from destinations where id=" + itemId;
                    MySqlDataReader myreader = cmd.ExecuteReader();

                    if (myreader.Read())
                    {
                        dest.Id = myreader.GetInt32("id");
                        dest.Description = myreader.GetString("descriptions");
                        dest.City = myreader.GetString("city");
                        dest.Country = myreader.GetString("country");
                        dest.TouristTarget = myreader.GetString("tourists_target");
                        dest.EstimatedCost = myreader.GetInt32("estimated_cost");
                        dlist.Add(dest);
                    }
                    myreader.Close();
                }
                catch (MySql.Data.MySqlClient.MySqlException ex)
                {
                    Console.Write(ex.Message);
                }
                return dest;
            }
        }
}
