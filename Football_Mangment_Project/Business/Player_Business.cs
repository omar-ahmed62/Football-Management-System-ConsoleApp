using Football_Mangment_Project.Data_Access;
using Football_Mangment_Project.Models;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace Football_Mangment_Project.Business
{
    internal class Player_Business
    {
        public static int AddPlayer(string PlayerName, int ShirtNumber, Position Position, int TeamID)
        {

            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@name", PlayerName),
                new SqlParameter("@sh_number", ShirtNumber),
                new SqlParameter("@pos", Position.ToString()),
                new SqlParameter("@T_Id", TeamID)

            };

            return DB_Layer.DML("Insert into Player (PlayerName,ShirtNumber,Position,TeamID) values (@name, @sh_number, @pos, @T_Id) ",parameters);

        }
        public static DataTable GetAllPlayers()
        {
            return DB_Layer.select("SELECT * FROM Player");
        }

        public static int GetID(string PlayerName, int TeamID)
        {
            SqlParameter[] parameters = new SqlParameter[]
            {
                 new SqlParameter("@PlayerName", PlayerName),
                  new SqlParameter("@TeamID", TeamID)
            };
            DataTable dt = DB_Layer.select("SELECT PlayerID FROM Player WHERE PlayerName = @PlayerName AND TeamID = @TeamID", parameters);

            if (dt.Rows.Count > 0)
                return Convert.ToInt32(dt.Rows[0]["PlayerID"]);

            return 0;
        }
    }
}
