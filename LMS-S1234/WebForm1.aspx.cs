using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.Adapters;
using MySql.Data.MySqlClient;
namespace LMS_S1234
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        private string constr = @"Server=127.0.0.1;Database=lms_schema;User=root;password=";
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Unnamed_Click(object sender, EventArgs e)
        {
            string pwd=null;
            MySqlConnection con = new MySqlConnection(constr);
            con.Open();
            MySqlCommand addcmd = new MySqlCommand("GetPasswordById", con);
            addcmd.CommandType = CommandType.StoredProcedure;
            addcmd.Parameters.AddWithValue("email_in", exampleInputEmail1.Text);
            MySqlParameter returnParameter = addcmd.Parameters.Add("pwd",MySqlDbType.VarChar);
            returnParameter.Direction = ParameterDirection.ReturnValue;
            addcmd.ExecuteNonQuery();
            if(!(returnParameter.Value is DBNull)){
                pwd = (string)returnParameter.Value;
                if (pwd == exampleInputPassword1.Text)
                {
                    Response.Redirect("/WebForm2.aspx");
                }
                else
                {
                    Label1.Text = "Username/Password do not match";
                }
            }
            else
            {
                Label1.Text = "Username/Password do not match";
            }
        }
    }
}