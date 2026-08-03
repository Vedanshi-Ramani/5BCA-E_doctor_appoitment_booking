using Microsoft.SqlServer.Server;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace project_doctor_appoitment
{
    public partial class login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Unnamed3_Click(object sender, EventArgs e)
        {
             
        }

        protected void Unnamed1_Click(object sender, EventArgs e)
        {
            string user_name =  TextBox1.Text;
            string password = TextBox2.Text;
            Label1.Text = "user name = " + user_name + "<br>" + "password = " + password;
        }
    }
}