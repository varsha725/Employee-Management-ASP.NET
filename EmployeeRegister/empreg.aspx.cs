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
	public partial class empreg : System.Web.UI.Page
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

		protected void Button1_Click(object sender, EventArgs e)
		{
			string str = "insert into empreg values(" + DropDownList1.SelectedItem.Value + ",'" + TextBox1.Text + "','" + TextBox2.Text + "')";
			int i = obj.fn_nonquery(str);
			if(i!=0)
			{
				Label4.Visible = true;
				Label4.Text = "Inserted";
			}
		}

		protected void Button2_Click(object sender, EventArgs e)
		{
			Response.Redirect("home.aspx");
		}
	}
}