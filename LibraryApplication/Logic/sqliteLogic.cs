using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;
using LibraryApplication.Connections;

namespace LibraryApplication.Logic
{
    public class sqliteLogic
    {
        Scores scores = new Scores();
        public void sendDataToUserScores(string Username, int Score, string Date_of_score, string tableName)
        {
            SQLiteConnection con = getConnectionToUserScores();
                   
            //Insert the values using commands
            SQLiteCommand command = con.CreateCommand();
            command.CommandText = $"INSERT INTO {tableName} (Username,Score,Date_of_score) values (@Username,@Score,@Date_of_score)";
            command.Parameters.AddWithValue("@Username", Username);
            command.Parameters.AddWithValue("@Score", Score);
            command.Parameters.AddWithValue("@Date_of_score", Date_of_score);
            
            //Execute the command
            command.ExecuteReader();

            //Close the connection
            con.Close();

        }
     
        public int getHighestScore(string username, string tableName)
        {

            SQLiteConnection con = getConnectionToUserScores();

            SQLiteDataReader dataReader;
            SQLiteCommand command = con.CreateCommand();

            //Gets the 10 ten scores
            command.CommandText = $"select * from {tableName} where username = @username order by score desc limit 1;";
            command.Parameters.AddWithValue("@Username", username);
            dataReader = command.ExecuteReader();

            int value = -1;

            while (dataReader.Read())
            {
                value = dataReader.GetInt32(2);
            }
         
            return value;
        }

        public Scores getTop10Scores(string tableName)
        {
            SQLiteConnection con = getConnectionToUserScores();
            
            SQLiteDataReader dataReader;
            SQLiteCommand command = con.CreateCommand();

            //Gets the 10 ten scores
            command.CommandText = $"select * from {tableName} order by score desc limit 10";
            dataReader = command.ExecuteReader();

            while (dataReader.Read())
            {
                scores.addUsername(dataReader.GetString(1));
                scores.addScore(dataReader.GetInt32(2));
                scores.addDate_of_score(dataReader.GetString(3));
            }

            return scores;
        }

        public SQLiteConnection getConnectionToUserScores()
        {
            sqliteConnectionsClass sqlCon = new sqliteConnectionsClass();
            SQLiteConnection con = sqlCon.getUserScoresConnection();

            try
            {
                con.Open();
                Console.WriteLine("Opened");
            }
            catch (Exception e)
            {
                Console.WriteLine("DB con error : " + e.Message);
            }

            return con;

        }

    }

    
}
