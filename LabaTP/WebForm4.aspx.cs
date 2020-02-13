using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LabaTP
{
    public partial class WebForm4 : System.Web.UI.Page
    {
        private SqlConnection sqlConnection = null;

        protected async void Page_Load(object sender, EventArgs e)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["DBConnection"].ConnectionString;
            sqlConnection = new SqlConnection(connectionString);
            await sqlConnection.OpenAsync();
        }

        protected async void Button3_Click(object sender, EventArgs e)
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
            /*if (TextBox3.Text == "" || TextBox4.Text == "")
            {
                string script = "alert('Empty fields!');";
                ClientScript.RegisterClientScriptBlock(this.GetType(), "MessageBox", script, true);
            }*/
            if (!db.Keys.Contains(TextBox3.Text))
            {
                SqlCommand regUser = new SqlCommand("INSERT INTO [Users] (Login, Password)VALUES(@Login,@Password)", sqlConnection);
                regUser.Parameters.AddWithValue("Login", TextBox3.Text);
                regUser.Parameters.AddWithValue("Password", TextBox4.Text);


                await regUser.ExecuteNonQueryAsync();

                Response.Redirect("WebForm1.aspx", false);
            }
            else
            {
                string script = "alert('This Login exists!');";
                ClientScript.RegisterClientScriptBlock(this.GetType(), "MessageBox", script, true);
            }
        }
        protected void Page_Unload(object sender, EventArgs e)
        {
            if (sqlConnection != null && sqlConnection.State != ConnectionState.Closed) sqlConnection.Close();
        }
    }
}