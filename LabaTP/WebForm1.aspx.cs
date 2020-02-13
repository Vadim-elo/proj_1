using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Data.SqlClient;
using System.Configuration; 
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LabaTP
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        int count = 1;
        private SqlConnection sqlConnection = null;

        protected async void Page_Load(object sender, EventArgs e)
        {
            RadioButton1.Checked = false;
            if (!IsPostBack)
            {
                Label5.Text = "0";
            }
            string connectionString = ConfigurationManager.ConnectionStrings["DBConnection"].ConnectionString;
            sqlConnection = new SqlConnection(connectionString);
            await sqlConnection.OpenAsync();
        }

        protected void TextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        protected async void Button1_Click(object sender, EventArgs e)
        {
            
            Dictionary<string, string> db = new Dictionary<string, string>();
            SqlCommand getUsersCredCmd = new SqlCommand("SELECT [Login], [Password] FROM [Users]", sqlConnection);

            SqlDataReader sqlReader = null;// считать всю таблицу
            try
            {
                sqlReader = await getUsersCredCmd.ExecuteReaderAsync();

                while (await sqlReader.ReadAsync())
                {
                    db.Add(Convert.ToString(sqlReader["Login"]), Convert.ToString(sqlReader["Password"])); 
                }
            }
            catch 
            { 
            
            }
            finally
            {
                if (sqlReader != null) 
                    sqlReader.Close();

            }

            if (RadioButton1.Checked == false)
            {
                Label6.Text = "<<<<<<<<<<<<<<<<";
                string script = "Use required field of agreement!');";
                ClientScript.RegisterClientScriptBlock(this.GetType(), "MessageBox", script, true);
            }
            else
            {
                try
                {
                    if (TextBox2.Text == db[TextBox1.Text])
                    {
                        HttpCookie login = new HttpCookie("login", TextBox1.Text);
                        HttpCookie sign = new HttpCookie("sign", SignGenerator.GetSign(TextBox1 + "bytepp"));
                        Response.Cookies.Add(login);
                        Response.Cookies.Add(sign);

                        Session["Name"] = Label1.Text;
                        Response.Redirect("~/WebForm3.aspx?login=" + TextBox1.Text, false);
                    }
                    else
                    {
                        TextBox2.Text = "";
                        TextBox1.Text = "";
                    }
                }
                catch
                {
                    TextBox2.Text = "";
                    TextBox1.Text = "";

                }
            }

            if(ViewState["Clicks"]!=null)
            {
                count = (int)ViewState["Clicks"] + 1;
            }
            Label5.Text = count.ToString();
            ViewState["Clicks"] = count;

            

        }

        protected void Button2_Click(object sender, EventArgs e)
        {

        }

        protected void Button2_Click1(object sender, EventArgs e)
        {
            
            Response.Redirect("~/WebForm4.aspx",false);
        }
        protected void Page_Unload(object sender, EventArgs e)
        {
            if (sqlConnection != null && sqlConnection.State != ConnectionState.Closed) sqlConnection.Close();
        }

        protected void RadioButton1_CheckedChanged(object sender, EventArgs e)
        {
            RadioButton1.Checked = true;
        }
    }
}
