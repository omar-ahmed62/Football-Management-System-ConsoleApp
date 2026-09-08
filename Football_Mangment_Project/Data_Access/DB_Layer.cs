using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using Microsoft.Data.SqlClient;


namespace Football_Mangment_Project.Data_Access
{
    internal class DB_Layer
    {
        public static DataTable select(string cmd, SqlParameter[] parameters = null)
        {
            SqlConnection con = new SqlConnection("Data Source=.;Initial Catalog=FootballConsoleDB;Integrated Security=True;Trust Server Certificate=True");
            SqlCommand cmdd = new SqlCommand(cmd, con);

            if (parameters != null)
            {
                cmdd.Parameters.AddRange(parameters);
            }

            SqlDataAdapter adapter = new SqlDataAdapter(cmdd);

            DataTable dataTable = new DataTable();
            adapter.Fill(dataTable);
            return dataTable;
        }

        public static int DML(string cmd, SqlParameter[] parameters = null)
        {
            SqlConnection con = new SqlConnection("Data Source=.;Initial Catalog=FootballConsoleDB;Integrated Security=True;Trust Server Certificate=True");
            SqlCommand cmdd = new SqlCommand(cmd, con);

            if (parameters != null)
            {
                cmdd.Parameters.AddRange(parameters);
            }
            con.Open();
            int roweffect = cmdd.ExecuteNonQuery();
            con.Close();

            return roweffect;
        }

    }
}
