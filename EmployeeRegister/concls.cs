using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;

namespace EmployeeRegister
{
	public class concls
	{
		SqlConnection con;
		SqlCommand cmd;

		public concls()
		{
			con = new SqlConnection(@"server=VARSHA\SQLEXPRESS;database=empreg;Integrated Security=true");
		}

		public int fn_nonquery(string sqlquery)
		{
			if (con.State == ConnectionState.Open)
			{
				con.Close();
			}
			cmd = new SqlCommand(sqlquery, con);
			con.Open();
			int i = cmd.ExecuteNonQuery();
			con.Close();
			return i;
		}

		public string fn_scalar(string sqlquery)
		{
			if (con.State == ConnectionState.Open)
			{
				con.Close();
			}
			cmd = new SqlCommand(sqlquery, con);
			con.Open();
			string s = cmd.ExecuteScalar().ToString();
			con.Close();
			return s;
		}

		public SqlDataReader fn_reader(string sqlquery)
		{
			if (con.State == ConnectionState.Open)
			{
				con.Close();
			}
			cmd = new SqlCommand(sqlquery, con);
			con.Open();
			SqlDataReader dr = cmd.ExecuteReader();
			return dr;
		}

		public DataSet fn_dataset(string sqlquery)
		{
			if (con.State == ConnectionState.Open)
			{
				con.Close();
			}
			SqlDataAdapter da = new SqlDataAdapter(sqlquery, con);
			DataSet ds = new DataSet();
			da.Fill(ds);
			return ds;
		}

		public DataTable fn_datatable(string sqlquery)
		{
			if (con.State == ConnectionState.Open)
			{
				con.Close();
			}
			SqlDataAdapter da = new SqlDataAdapter(sqlquery, con);
			DataTable dt = new DataTable();
			da.Fill(dt);
			return dt;
		}

	}
}