using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace EmployeeRegister
{
	public partial class deptreg : System.Web.UI.Page
	{
		concls obj = new concls();
		protected void Page_Load(object sender, EventArgs e)
		{

		}

		protected void Button1_Click(object sender, EventArgs e)
		{
			string str = "insert into dept values('" + TextBox1.Text + "','" + TextBox2.Text + "')";
			int i = obj.fn_nonquery(str);
			if (i != 0)
			{
				Label3.Visible = true;
;				Label3.Text = "Inserted";
			}
		}

		protected void Button3_Click(object sender, EventArgs e)
		{
			Response.Redirect("home.aspx");
		}
	}
}