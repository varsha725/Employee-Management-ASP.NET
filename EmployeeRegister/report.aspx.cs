using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

namespace EmployeeRegister
{
	public partial class report : System.Web.UI.Page
	{
		concls obj = new concls();
		protected void Page_Load(object sender, EventArgs e)
		{
			if(!IsPostBack)
			{
				string str = "select deptid,deptname from dept";
				DataSet ds = obj.fn_dataset(str);
				DropDownList1.DataTextField = "deptname";
				DropDownList1.DataValueField = "deptid";
				DropDownList1.DataSource = ds;
				DropDownList1.DataBind();
				DropDownList1.Items.Insert(0, "_select_");

			}
		}

		protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
		{
			string s = "select empname from empreg where deptid='" + DropDownList1.SelectedItem.Value + "'";
			DataSet ds = obj.fn_dataset(s);
			GridView1.DataSource = ds;
			GridView1.DataBind();
			string n = "select count(empid) from empreg where deptid='" + DropDownList1.SelectedItem.Value + "'";
			string emp = obj.fn_scalar(n);
			Label3.Visible = true;
			Label3.Text = emp;
		}

		protected void Button1_Click(object sender, EventArgs e)
		{
			Response.Redirect("home.aspx");
		}
	}
}