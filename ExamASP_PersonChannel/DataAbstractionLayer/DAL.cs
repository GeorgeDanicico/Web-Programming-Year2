using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using MySql.Data.MySqlClient;
using ExamASP_PersonChannel.Models;

namespace ExamASP_PersonChannel.DataAbstractionLayer
{
    public class DAL
    {
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

        public int GetUserId(string user)
        {
            MySql.Data.MySqlClient.MySqlConnection conn;
            string myConnectionString;
            int id = 0;
            myConnectionString = "server=localhost;uid=root;pwd=;database=exam;";

            try
            {
                conn = new MySql.Data.MySqlClient.MySqlConnection();
                conn.ConnectionString = myConnectionString;
                conn.Open();

                MySqlCommand cmd = new MySqlCommand();
                cmd.Connection = conn;
                cmd.CommandText = "select * from persons where name='" + user + "'";
                MySqlDataReader myreader = cmd.ExecuteReader();
                if (myreader.Read())
                {
                    id = myreader.GetInt32("id");
                }
                myreader.Close();
            }
            catch (MySql.Data.MySqlClient.MySqlException ex)
            {
                Console.Write(ex.Message);
            }
            return id;
        }

        public List<Channel> GetChannels(string user)
        {
            MySql.Data.MySqlClient.MySqlConnection conn;
            string myConnectionString;

            myConnectionString = "server=localhost;uid=root;pwd=;database=exam;";
            List<Channel> dlist = new List<Channel>();

            try
            {
                conn = new MySql.Data.MySqlClient.MySqlConnection();
                conn.ConnectionString = myConnectionString;
                conn.Open();
                int userId = GetUserId(user);
                MySqlCommand cmd = new MySqlCommand();
                cmd.Connection = conn;
                cmd.CommandText = "select * from channels where ownerId=" + userId;
                MySqlDataReader myreader = cmd.ExecuteReader();

                while (myreader.Read())
                {
                    Channel ch = new Channel();
                    ch.Id = myreader.GetInt32("id");
                    ch.OwnerId = myreader.GetInt32("ownerid");
                    ch.Name = myreader.GetString("name");
                    ch.Description = myreader.GetString("description");
                    ch.subscribers = myreader.GetString("subscribers");
                    dlist.Add(ch);
                }
                myreader.Close();
            }
            catch (MySql.Data.MySqlClient.MySqlException ex)
            {
                Console.Write(ex.Message);
            }
            return dlist;
        }

        public List<Channel> GetAllChannels()
        {
            MySql.Data.MySqlClient.MySqlConnection conn;
            string myConnectionString;

            myConnectionString = "server=localhost;uid=root;pwd=;database=exam;";
            List<Channel> dlist = new List<Channel>();

            try
            {
                conn = new MySql.Data.MySqlClient.MySqlConnection();
                conn.ConnectionString = myConnectionString;
                conn.Open();
                MySqlCommand cmd = new MySqlCommand();
                cmd.Connection = conn;
                cmd.CommandText = "select * from channels";
                MySqlDataReader myreader = cmd.ExecuteReader();

                while (myreader.Read())
                {
                    Channel ch = new Channel();
                    ch.Id = myreader.GetInt32("id");
                    ch.OwnerId = myreader.GetInt32("ownerid");
                    ch.Name = myreader.GetString("name");
                    ch.Description = myreader.GetString("description");
                    ch.subscribers = myreader.GetString("subscribers");
                    dlist.Add(ch);
                }
                myreader.Close();
            }
            catch (MySql.Data.MySqlClient.MySqlException ex)
            {
                Console.Write(ex.Message);
            }
            return dlist;
        }

        public Channel GetChannel(string name)
        {
            MySql.Data.MySqlClient.MySqlConnection conn;
            string myConnectionString;

            myConnectionString = "server=localhost;uid=root;pwd=;database=exam;";
            Channel ch = new Channel();
            try
            {
                conn = new MySql.Data.MySqlClient.MySqlConnection();
                conn.ConnectionString = myConnectionString;
                conn.Open();
                MySqlCommand cmd = new MySqlCommand();
                cmd.Connection = conn;
                cmd.CommandText = "select * from channels where name='" + name + "'";
                MySqlDataReader myreader = cmd.ExecuteReader();

                if (myreader.Read())
                {
                    ch.Id = myreader.GetInt32("id");
                    ch.OwnerId = myreader.GetInt32("ownerid");
                    ch.Name = myreader.GetString("name");
                    ch.Description = myreader.GetString("description");
                    ch.subscribers = myreader.GetString("subscribers");
                }
                myreader.Close();
            }
            catch (MySql.Data.MySqlClient.MySqlException ex)
            {
                Console.Write(ex.Message);
            }
            return ch;
        }

        public string GetPerson(string name)
        {
            MySql.Data.MySqlClient.MySqlConnection conn;
            string myConnectionString;

            myConnectionString = "server=localhost;uid=root;pwd=;database=exam;";
            string p = "";
            try
            {
                conn = new MySql.Data.MySqlClient.MySqlConnection();
                conn.ConnectionString = myConnectionString;
                conn.Open();
                MySqlCommand cmd = new MySqlCommand();
                cmd.Connection = conn;
                cmd.CommandText = "select * from persons where name='" + name + "'";
                MySqlDataReader myreader = cmd.ExecuteReader();

                if (myreader.Read())
                {

                    p = myreader.GetInt32("id") + ";" + myreader.GetString("name") + ";" + myreader.GetInt32("age") + ";";
                }
                myreader.Close();
            }
            catch (MySql.Data.MySqlClient.MySqlException ex)
            {
                Console.Write(ex.Message);
            }
            return p;
        }

        public void UpdateChannel(string channelName, string subscribers)
        {
            MySql.Data.MySqlClient.MySqlConnection conn;
            string myConnectionString;

            myConnectionString = "server=localhost;uid=root;pwd=;database=exam;";

            try
            {
                conn = new MySql.Data.MySqlClient.MySqlConnection();
                conn.ConnectionString = myConnectionString;
                conn.Open();

                MySqlCommand cmd = new MySqlCommand();

                cmd = new MySqlCommand();
                cmd.Connection = conn;
                cmd.CommandText = "update channels set subscribers='" + subscribers + "' where name='" + channelName + "'";

                cmd.ExecuteNonQuery();
            }
            catch (MySql.Data.MySqlClient.MySqlException ex)
            {
                Console.Write(ex.Message);
            }
        }
    }
}

