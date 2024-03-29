﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

namespace EmployeeRegister
{
	public partial class viewemp : System.Web.UI.Page
	{
		concls obj = new concls();
		protected void Page_Load(object sender, EventArgs e)
		{
			if(!IsPostBack)
			{
				grid_bind();
			}
		}
		public void grid_bind()
		{
			string str = "select empreg.*,dept.deptname from empreg join dept on empreg.deptid=dept.deptid";
			DataSet ds = obj.fn_dataset(str);
			GridView1.DataSource = ds;
			GridView1.DataBind();
		}

		protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)
		{
			GridView1.EditIndex = e.NewEditIndex;
			grid_bind();
		}

		protected void GridView1_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
		{
			GridView1.EditIndex = -1;
			grid_bind();
		}

		protected void GridView1_RowUpdating(object sender, GridViewUpdateEventArgs e)
		{
			int i = e.RowIndex;
			int empid = Convert.ToInt32(GridView1.DataKeys[i].Value);
			TextBox name = (TextBox)GridView1.Rows[i].Cells[0].Controls[0];
			TextBox job = (TextBox)GridView1.Rows[i].Cells[1].Controls[0];
			string str = "update empreg set empname='" + name.Text + "',empjob='" + job.Text + "' where empid="+empid+"";
			int j = obj.fn_nonquery(str);
			GridView1.EditIndex = -1;
			grid_bind();


		}

		protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
		{
			int i = e.RowIndex;
			int empid = Convert.ToInt32(GridView1.DataKeys[i].Value);
			string del = "delete from empreg where empid=" + empid + "";
			int j = obj.fn_nonquery(del);
			grid_bind();

		}

		protected void Button1_Click(object sender, EventArgs e)
		{
			Response.Redirect("home.aspx");
		}
	}
}