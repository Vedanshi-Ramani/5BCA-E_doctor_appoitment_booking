using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace project_doctor_appoitment
{
    public partial class registration : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string fname = TextBox1.Text;
            string lname = TextBox2.Text;
            string age = TextBox3.Text;
            string gen;
            string mobile = TextBox4.Text;
            string pass = TextBox5.Text;
            string con_pass = TextBox6.Text;
            string address = TextBox7.Text;
            if(RadioButtonList1.SelectedValue == "Male")
            {
                gen = "Male";
            }
            else
            {
                gen = "Female";
            }
            Label1.Text = "Your first name = " + fname + "<br>" + "Your last name = " + lname + "<br>" +
                "your age is = " + age + "<br>" + "your gender = " + gen + "<br>" + "ypur mobile number is  = " + mobile +
                "<br>" + "your password is = " + pass + "<br>" + "your confirm pass is = " + con_pass + "<br>" +
                "your address is = " + address;
        }
    }
}