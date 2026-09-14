using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient; //for connection
using System.Linq;
using System.Reflection.Emit;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace project_doctor_appoitment
{
    public partial class book_appoitment : System.Web.UI.Page
    {

        SqlConnection con; //for connection
        SqlCommand cmd; // for insert , update , delete
        SqlDataAdapter da; // container
        DataSet ds; // selecet
        string nm; //for store username 
        string s = ConfigurationManager.ConnectionStrings["dobcon"].ConnectionString;
        void getcon()
        {
            con = new SqlConnection(s);
            con.Open();
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            getcon();
            

            if (Session["user"] != null)
            {
                da = new SqlDataAdapter("select*from user_tbl where Email = '" + Session["user"] + "' ", con);
                ds = new DataSet();
                da.Fill(ds);
                nm = ds.Tables[0].Rows[0]["FirstName"].ToString();

                txtunm.Text = nm;
            }
            else
            {
                Response.Redirect("login.aspx");
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {

        }
    }
}