using Microsoft.SqlServer.Server;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient; //for connection
using System.Data;
using System.Configuration;

namespace project_doctor_appoitment
{
    public partial class login : System.Web.UI.Page
    {

        SqlConnection con;
        SqlCommand cmd;
        SqlDataAdapter da;
        DataSet ds;
        string filenm; // store the image path
        int i; //fro store existing user means how many user are avilable in databse
        string s = ConfigurationManager.ConnectionStrings["dbcon"].ConnectionString;

        void getcon()
        {
            con = new SqlConnection(s);
            con.Open();
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            getcon();
        }
       
        protected void Unnamed3_Click(object sender, EventArgs e)
        {
             
        }

        //event of clicking login button       
        protected void Unnamed1_Click(object sender, EventArgs e)
        {
            getcon();
            if (!(string.IsNullOrEmpty(txtunm.Text)) && !(string.IsNullOrEmpty(txtpass.Text)))
            {
                cmd = new SqlCommand("select count(*) from user_tbl where Email= '" + txtunm.Text + "' and Password = '" + txtpass.Text + "'", con);
                i = Convert.ToInt16(cmd.ExecuteScalar());

                if (i > 0)
                {
                    Session["user"] = txtunm.Text;
                    Response.Redirect("home.aspx");
                }
                else
                {
                    Response.Write("Wrong username or password");
                }
            }
        }
    }
}