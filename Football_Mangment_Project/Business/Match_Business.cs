using Football_Mangment_Project.Data_Access;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace Football_Mangment_Project.Business
{
    internal class Match_Business
    {
        public static int AddMatch(int homeTeamId, int awayTeamId)
        {
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@HomeTeamId", homeTeamId),
                new SqlParameter("@AwayTeamId", awayTeamId)
            };

            return DB_Layer.InsertAndGetId("INSERT INTO Match (HomeTeamID, AwayTeamID) OUTPUT INSERTED.MatchID VALUES (@HomeTeamId, @AwayTeamId)", parameters);
        }

        public static DataTable GetAllMatches()
        {
            return DB_Layer.select("SELECT * FROM Match");
        }

    }
        
}
