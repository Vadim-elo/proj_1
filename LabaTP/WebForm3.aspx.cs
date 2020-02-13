using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LabaTP
{
    public partial class WebForm3 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            HttpCookie login = Request.Cookies["login"];
            HttpCookie sign = Request.Cookies["sign"];
            if (login!= null && sign!=null)
            if (sign.Value != SignGenerator.GetSign(login.Value + "bytepp"))
            {
                    //Label4.Text = login.Value;
                    if (Session["Name"] != null)
                    {
                        Label4.Text = Session["Name"].ToString();
                        Label4.Text = Label4.Text + ":" + Request.QueryString["login"];
                    }
                    else Label4.Text = "";

                    return;
            }
            Response.Redirect("WebForm1.aspx");
        }
        protected void Botton2_Clik(object sender, EventArgs e)
        {
            
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Response.Redirect("WebForm2.aspx");
        }
    }
}