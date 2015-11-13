using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Configuration;
using System.IO;
using System.Web.Configuration;

namespace SupportPage
{
    public partial class Server : System.Web.UI.Page
    {
        static string prevPage = String.Empty;

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Unnamed_Click(object sender, EventArgs e)
        {

            //string main = ServerText.Text;
            //string user = UserId.Text;
            //string pass = Password.Text;
            //var configuration = WebConfigurationManager.OpenWebConfiguration("~");
            //var section = (ConnectionStringsSection)configuration.GetSection("connectionStrings");
            //Response.Write(section.ConnectionStrings["Support"]);
            //section.ConnectionStrings["Support"].ConnectionString = "Data Source=tcp:" + main + ";Initial Catalog=Support;Integrated Security=false" + ";user id=" + user + ";password=" + pass +";";
            //section.ConnectionStrings["SupportConnectionStringAdmin"].ConnectionString = "Data Source=tcp:" + main + ";Initial Catalog=Support;Integrated Security=false"+ ";user id=" + user + ";password=" + pass +";";;
            //section.ConnectionStrings["SupportConnectionStringUser"].ConnectionString = "Data Source=tcp:" + main + ";Initial Catalog=Support;Integrated Security=false" + ";user id=" + user + ";password=" + pass + ";"; 
            //section.ConnectionStrings["SupportConnectionString"].ConnectionString = "Data Source=tcp:" + main + ";Initial Catalog=Support;Integrated Security=false" + ";user id=" + user + ";password=" + pass + ";";
            //Response.Write(section.ConnectionStrings["Support"]);
            //configuration.Save();
        }
    }
}