using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace project_doctor_appoitment
{
    public partial class contact : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string name = TextBox1.Text;
            string email = TextBox2.Text;
            string mobile = TextBox3.Text;
            string subject = TextBox4.Text;
            string message = TextBox5.Text;

            Label1.Text = "your name is = " + name + "<br>" + "your email is = " + email + "<br>" +
                "your mobile number is = " + mobile + "<br>" + "yout subject is = " + subject + "<br>" +
                "your message is = " + message;
        }
    }
}