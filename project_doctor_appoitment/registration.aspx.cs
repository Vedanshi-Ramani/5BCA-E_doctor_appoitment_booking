using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
//new name space 
using System.Data.SqlClient; //for connection
using System.Data;
using System.Configuration;

namespace project_doctor_appoitment
{
    public partial class registration : System.Web.UI.Page
    {
        SqlConnection con;
        SqlCommand cmd;
        SqlDataAdapter da;
        DataSet ds;
        string filenm;
        string s = ConfigurationManager.ConnectionStrings["dbcon"].ConnectionString;

        protected void Page_Load(object sender, EventArgs e)
        {
            getcon();
            fillgrid();
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            if(btnRegister.Text == "Register")
            {
                getcon();
                imgupload();
                cmd = new SqlCommand("insert into user_tbl(FirstName , LastName , Age, Gender , Mobile , Email ,Password , Address , ProfilePhoto) values ('"+ txtFirstName.Text+ "' , '"+ txtLastName.Text+ "' , '"+ txtAge.Text+ "' , '"+ rdbGender.SelectedValue+ "' , '"+ txtMobile.Text+ "' , '"+ txtEmail.Text+ "' , '"+ txtPassword.Text+ "' , '"+ txtAddress.Text+ "','"+filenm+"' )",con);
                cmd.ExecuteNonQuery();
                clear();
                fillgrid();
            }
        }
        void getcon()
        {
            con = new SqlConnection(s);
            con.Open();
        }
        void imgupload()
        {
            filenm = "user_profile/" + fileProfilePhoto.FileName;
            fileProfilePhoto.SaveAs(Server.MapPath(filenm));
        }

        void clear()
        {
            txtFirstName.Text = "";
            txtLastName.Text = "";
            rdbGender.ClearSelection();
            txtAge.Text = "";
            txtPassword.Text = "";
            txtConfirmPassword.Text = "";
            txtAddress.Text = "";
            txtMobile.Text = "";
            txtEmail.Text = "";
        }
        void fillgrid()
        {
            da = new SqlDataAdapter("select*from user_tbl", con);
            ds = new DataSet();
            da.Fill(ds);
            GridView1.DataSource = ds;
            GridView1.DataBind();
        }
    }
}