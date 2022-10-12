using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace FITNESS__
{
     class Functions
    {

        private SqlConnection Con;
        private SqlCommand Cmd;
        private string Constr;
        private DataTable dt;
        private SqlDataAdapter sda;
        public Functions()
        {
            Constr = @"Data Source=LAPTOP-NCEDVHBS;Initial Catalog=defense_project;Integrated Security=True";
            Con = new SqlConnection(Constr);
            Cmd = new SqlCommand();
            Cmd.Connection = Con;
        }
      public int SetData(string Query)
            {
            int cnt = 0;
            if (Con.State == ConnectionState.Closed )
            {
                Con.Open();
            }

            Cmd.CommandText = Query;
            cnt = Cmd.ExecuteNonQuery();
            Con.Close();
            return cnt;
        }

        public DataTable GetData(string Query)
        {
            dt = new DataTable();
            sda = new SqlDataAdapter(Query,Constr);
            sda.Fill(dt);
            return dt;
        }


 }



}




