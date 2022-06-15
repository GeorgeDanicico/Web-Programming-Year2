using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using FinalExamASP.Models;

namespace FinalExamASP.DataAbstractionLayer
{
    public class DAL
    {
        /*public void UpdatePost(int postId, string text, string user, DateTime date)
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
                cmd.CommandText = "update posts set user='" + user + "', text='" + text + "', date='" + date.ToString("yyyy-MM-dd H:mm:ss") + "' where id=" + postId;

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

                }
                else
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
        */
        public void AddEntry(string key, string value)
        {
            MySql.Data.MySqlClient.MySqlConnection conn;
            string myConnectionString;

            myConnectionString = "server=localhost;uid=root;pwd=;database=finalexam;";

            try
            {
                conn = new MySql.Data.MySqlClient.MySqlConnection();
                conn.ConnectionString = myConnectionString;
                conn.Open();

                MySqlCommand cmd = new MySqlCommand();
                cmd.Connection = conn;
                cmd.CommandText = "insert into keyword(keyy, value) values ('" + key + "', '" + value + "')";

                cmd.ExecuteNonQuery();
            }
            catch (MySql.Data.MySqlClient.MySqlException ex)
            {
                Console.Write(ex.Message);
            }
        }

        public List<Document> GetDocuments(string title)
        {
                MySql.Data.MySqlClient.MySqlConnection conn;
                string myConnectionString;

                myConnectionString = "server=localhost;uid=root;pwd=;database=finalexam;";
                List<Document> dlist = new List<Document>();

                try
                {
                    conn = new MySql.Data.MySqlClient.MySqlConnection();
                    conn.ConnectionString = myConnectionString;
                    conn.Open();

                    MySqlCommand cmd = new MySqlCommand();
                    cmd.Connection = conn;
                    cmd.CommandText = "select * from document where title like '%" + title + "%'";
                    MySqlDataReader myreader = cmd.ExecuteReader();

                    while (myreader.Read())
                    {
                        Document dest = new Document();
                        dest.Id = myreader.GetInt32("id");
                        dest.Title = myreader.GetString("title");
                        dest.ListOfTemplates = myreader.GetString("listoftemplates");
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

        public string GetTemplates(int docId)
        {
            string result = "";

            MySql.Data.MySqlClient.MySqlConnection conn;
            string myConnectionString;

            myConnectionString = "server=localhost;uid=root;pwd=;database=finalexam;";

            try
            {
                conn = new MySql.Data.MySqlClient.MySqlConnection();
                conn.ConnectionString = myConnectionString;
                conn.Open();

                MySqlCommand cmd = new MySqlCommand();
                cmd.Connection = conn;
                cmd.CommandText = "select * from document where id =" + docId + "";
                MySqlDataReader myreader = cmd.ExecuteReader();
                Document dest = new Document();
                if (myreader.Read())
                {
                    dest.Id = myreader.GetInt32("id");
                    dest.Title = myreader.GetString("title");
                    dest.ListOfTemplates = myreader.GetString("listoftemplates");
                }
                myreader.Close();
                string[] templates = dest.ListOfTemplates.Split(";");

                cmd = new MySqlCommand();
                cmd.Connection = conn;
                cmd.CommandText = "select * from keyword";
                myreader = cmd.ExecuteReader();
                List<Keyword> keywords = new List<Keyword>();
                while (myreader.Read())
                {
                    Keyword keyword = new Keyword();
                    keyword.Id = myreader.GetInt32("id");
                    keyword.Key = myreader.GetString("keyy");
                    keyword.Value = myreader.GetString("value");
                    keywords.Add(keyword);
                }
                myreader.Close();

                foreach (var template in templates)
                {
                    cmd = new MySqlCommand();
                    cmd.Connection = conn;
                    cmd.CommandText = "select * from template where name ='" + template + "'";
                    myreader = cmd.ExecuteReader();
                    if (myreader.Read())
                    {
                        string content = myreader.GetString("textContent");

                        foreach (var keyw in keywords)
                        {
                            string seachkey = "{{" + keyw.Key + "}}";
                            if (content.Contains(seachkey))
                            {
                                content = content.Replace(seachkey, keyw.Value);
                            }
                        }

                        result += content;
                        result += "<br><br>";
                    }
                    myreader.Close();
                }
            }
            catch (MySql.Data.MySqlClient.MySqlException ex)
            {
                Console.Write(ex.Message);
            }

            return result;
        }

    }
}
