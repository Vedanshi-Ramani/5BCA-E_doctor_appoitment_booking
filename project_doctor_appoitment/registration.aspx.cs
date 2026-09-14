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
        string filenm; // store the image path
        string unm; //store the user name and pass it into session
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
            else
            {
                getcon();
                cmd = new SqlCommand("update user_tbl set FirstName = '"+txtFirstName.Text+"' , LastName = '"+txtLastName.Text+"' , Age = '"+txtAge.Text+"' , Gender = '"+rdbGender.SelectedValue+"' , Mobile = '"+txtMobile.Text+"' , Email = '"+txtEmail.Text+"' where Id = '" + ViewState["id"] +"'",con);
                cmd.ExecuteNonQuery();
                clear();
                fillgrid();
                btnRegister.Text = "Save";
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

        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if(e.CommandName == "cmdedit")
            {
                int id = Convert.ToInt16(e.CommandArgument);
                ViewState["id"] = id;
                btnRegister.Text = "Update";
                filldata();
            }
            else
            {
                getcon();
                cmd = new SqlCommand("delete from user_tbl where Id = '" + e.CommandArgument + "' ", con);
                cmd.ExecuteNonQuery();
                fillgrid();
            }
        }

        void filldata()
        {
            da = new SqlDataAdapter("select*from user_tbl where id='" + ViewState["id"] + "'", con);
            ds = new DataSet();
            da.Fill(ds);

            //paring 
            txtFirstName.Text = ds.Tables[0].Rows[0]["FirstName"].ToString();
            txtLastName.Text = ds.Tables[0].Rows[0]["LastName"].ToString();
            txtAge.Text = ds.Tables[0].Rows[0]["Age"].ToString();
            txtMobile.Text = ds.Tables[0].Rows[0]["Mobile"].ToString();
            txtEmail.Text= ds.Tables[0].Rows[0]["Email"].ToString();
            txtAddress.Text = ds.Tables[0].Rows[0]["Address"].ToString();
            

            if (ds.Tables[0].Rows[0]["Gender"].ToString() == "Male")
            {
                rdbGender.SelectedValue = "Male";
            }
            else
            {
                rdbGender.SelectedValue = "Female";
            }
        }
    }
}