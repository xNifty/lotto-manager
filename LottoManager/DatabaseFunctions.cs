using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using MySql.Data.MySqlClient;

namespace LottoManager
{
    public static class DatabaseFunctions
    {
        public static void AddLottoWinner(
            MySqlConnection connection, object winner, object rolls, object items, object date, object rollHistory)
        {
            // setup a new command
            var command = new MySqlCommand
            {
                CommandText = "call Add_Lotto_Winner(@p1, @p2, @p3, @p4, @p5)",
            };

            command.Parameters.AddWithValue("@p1", winner);
            command.Parameters.AddWithValue("@p2", rolls);
            command.Parameters.AddWithValue("@p3", items);
            command.Parameters.AddWithValue("@p4", date);
            command.Parameters.AddWithValue("@p5", rollHistory);

            command.Connection = connection;

            command.ExecuteNonQuery();
        }
        
        public static void AddLottoUser(MySqlConnection connection, object username, object ticketsToUpdate) {
            // setup a new command
            var command = new MySqlCommand
            {
                CommandText = "call Add_Lotto_user(@p1, @p2)",
            };
            
            command.Parameters.AddWithValue("@p1", username);
            command.Parameters.AddWithValue("@p2", ticketsToUpdate);
            command.Connection = connection;

            command.ExecuteNonQuery();
        }

        public static void ClearLottoUsers(MySqlConnection connection)
        {
            var command = new MySqlCommand
            {
                CommandText = "call Clear_Lotto_Users()",
                Connection = connection
            };
            
            command.ExecuteNonQuery();
        }

        public static Dictionary<string, string> ListLottoUsers(MySqlConnection connection)
        {
            var userlist = new Dictionary<string, string>();
            var command = new MySqlCommand
            {
                CommandText = "call List_Lotto_Users()",
                Connection = connection
            };

            var reader = command.ExecuteReader();

            using (reader)
            {
                while (reader.Read())
                {
                    userlist.Add(reader[0].ToString(), reader[1].ToString());
                }
            }

            return userlist;
        }
    }
    
}