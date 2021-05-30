using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Diagnostics;
using MySql.Data.MySqlClient;

namespace LMS_S1234
{
    public partial class WebForm5 : System.Web.UI.Page
    {
        private string constr = @"Server=127.0.0.1;Database=lms_schema;User=root;password=";
        protected void Page_Load(object sender, EventArgs e)
        {
           

        }

        protected void btnsign_Click(object sender, EventArgs e)
        {
            int i;
            if (ippassword.Text == ipconpassword.Text)
            {
                MySqlConnection con = new MySqlConnection(constr);
                MySqlCommand addcmd = new MySqlCommand("UserAdd", con);
                addcmd.CommandType = System.Data.CommandType.StoredProcedure;
                addcmd.Parameters.AddWithValue("fname", ipfname.Text.Trim());
                addcmd.Parameters.AddWithValue("lname", iplname.Text.Trim());
                addcmd.Parameters.AddWithValue("email", ipemail.Text.Trim());
                addcmd.Parameters.AddWithValue("pwd", ippassword.Text.Trim());
                con.Open();
                i= addcmd.ExecuteNonQuery();

                if (i == 1)
                {
                    resultlbl.Text = "Successfully Signed Up";
                    Response.Redirect("/WebForm1.aspx");
                }
                else
                {
                    resultlbl.Text = "Error Occured";
                }
            }
        }
    }
}