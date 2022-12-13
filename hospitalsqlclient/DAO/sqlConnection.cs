using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using testefcore.models;

namespace testefcore.DAO
{
    public class sqlConnection
    {
        private SqlConnection con = new SqlConnection("Server=DESKTOP-O64BAV4;DataBase= test;Integrated Security=true");
        public SqlConnection OpenConnection()
        {
            if (con.State == ConnectionState.Closed)
                con.Open();
            return con;
        }
        public SqlConnection CloseConnection()
        {
            if (con.State == ConnectionState.Open)
                con.Close();
            return con;
        }
    }
}
