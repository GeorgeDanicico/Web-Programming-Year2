using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace ExamASP_TopicPost.DataAbstractionLayer
{
    public class DAL
    {
        private int GetNextPostId()
        {
            MySql.Data.MySqlClient.MySqlConnection conn;
            string myConnectionString;
            int id = 1;
            myConnectionString = "server=localhost;uid=root;pwd=;database=exam;";

            try
            {
                conn = new MySql.Data.MySqlClient.MySqlConnection();
                conn.ConnectionString = myConnectionString;
                conn.Open();

                MySqlCommand cmd = new MySqlCommand();

                cmd = new MySqlCommand();
                cmd.Connection = conn;
                cmd.CommandText = "select count(*) from posts";

                MySqlDataReader myreader = cmd.ExecuteReader();

                if (myreader.Read())
                {
                    id = myreader.GetInt32(0) + 1;
                }
            }
            catch (MySql.Data.MySqlClient.MySqlException ex)
            {
                Console.Write(ex.Message);
            }

            return id;
        }

        private int GetNextTopicId()
        {
            MySql.Data.MySqlClient.MySqlConnection conn;
            string myConnectionString;
            int id = 1;
            myConnectionString = "server=localhost;uid=root;pwd=;database=exam;";

            try
            {
                conn = new MySql.Data.MySqlClient.MySqlConnection();
                conn.ConnectionString = myConnectionString;
                conn.Open();

                MySqlCommand cmd = new MySqlCommand();

                cmd = new MySqlCommand();
                cmd.Connection = conn;
                cmd.CommandText = "select count(*) from topics";

                MySqlDataReader myreader = cmd.ExecuteReader();

                if (myreader.Read())
                {
                    id = myreader.GetInt32(0) + 1;
                }
            }
            catch (MySql.Data.MySqlClient.MySqlException ex)
            {
                Console.Write(ex.Message);
            }

            return id;
        }

        public void UpdatePost(int postId, string text, string user, DateTime date)
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

                cmd.Connection = conn;
                cmd.CommandText = "update posts set user='" + user + "', text='" + text + "', date='" + date + "' where id=" + postId;

                cmd.ExecuteNonQuery();
            }
            catch (MySql.Data.MySqlClient.MySqlException ex)
            {
                Console.Write(ex.Message);
            }
        }

        public int GetTopicId(string topicName)
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
                cmd.CommandText = "select * from topics where topicname='" + topicName + "'";
                MySqlDataReader myreader = cmd.ExecuteReader();
                if (myreader.Read())
                {
                    id = myreader.GetInt32("id");
               
                } else
                {
                    myreader.Close();
                    id = GetNextTopicId();
                    cmd = new MySqlCommand();
                    cmd.Connection = conn;
                    cmd.CommandText = "insert into topics(id, topicname) values (" + id + ", '" + topicName + "')";

                    cmd.ExecuteNonQuery();
                }
            }
            catch (MySql.Data.MySqlClient.MySqlException ex)
            {
                Console.Write(ex.Message);
            }
            return id;
        }

        public String GetAllPosts(string user)
        {
            MySql.Data.MySqlClient.MySqlConnection conn;
            string myConnectionString;
            string p = "";
            myConnectionString = "server=localhost;uid=root;pwd=;database=exam;convert zero datetime=True";

            try
            {
                conn = new MySql.Data.MySqlClient.MySqlConnection();
                conn.ConnectionString = myConnectionString;
                conn.Open();

                MySqlCommand cmd = new MySqlCommand();
               
                cmd = new MySqlCommand();
                cmd.Connection = conn;
                cmd.CommandText = "select * from posts where user<>'" + user + "'";

                MySqlDataReader myreader = cmd.ExecuteReader();

                while (myreader.Read())
                {
                    if (p != "") p += "/";
                    p += myreader.GetInt32("id") + ";" + myreader.GetString("user") + ";" + myreader.GetInt32("topicid") + ";" + myreader.GetString("text");
                }
            }
            catch (MySql.Data.MySqlClient.MySqlException ex)
            {
                Console.Write(ex.Message);
            }

            return p;
        }

        public void AddPost(int topicId, string text, string user, DateTime date)
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
                cmd.Connection = conn;
                int postId = GetNextPostId();
                Console.WriteLine("Post id: " + postId);
                cmd.CommandText = "insert into posts(id, topicid, user, text, date) values (" + postId + ", " + topicId + ", '" +
                    user + "', '" + text + "', '" + date.ToString() + "')";

                cmd.ExecuteNonQuery();
            }
            catch (MySql.Data.MySqlClient.MySqlException ex)
            {
                Console.Write(ex.Message);
            }
        }

 
    }
}
