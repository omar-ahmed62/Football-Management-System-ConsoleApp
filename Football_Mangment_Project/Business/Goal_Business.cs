using Football_Mangment_Project.Data_Access;
using Football_Mangment_Project.Models;
using Football_Mangment_Project.Data_Access;
using Football_Mangment_Project.Models;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Text;

namespace Football_Mangment_Project.Business
{
    internal class Goal_Business
    {
        public static int AddGoal(int matchId, int playerId, TeamGoal teamGoal)
        {
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@MatchId", matchId),
                new SqlParameter("@PlayerId", playerId),
                new SqlParameter("@TeamGoal", teamGoal.ToString())
            };

            return DB_Layer.DML(
                "INSERT INTO Goal (MatchID, PlayerID, TeamGoal) VALUES (@MatchId, @PlayerId, @TeamGoal)", parameters);
        }
    }
}