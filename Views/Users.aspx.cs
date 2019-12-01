using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.UI;
using System.Web.UI.WebControls;
using MySql.Data.MySqlClient;
using ProjetoFaculdade2.App_Data;
using ProjetoFaculdade2.Entities;

namespace ProjetoFaculdade2.Views
{
    public partial class Users : Page
    {

        private UserContext _userContext;

        protected async void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                await LoadData();
            }
        }
        
        
        private async Task LoadData()
        {
            IEnumerable<User> users = await new UserContext().GetUsers();
            userGridView.DataSource = users;
            userGridView.DataBind();
        }
        
        protected void OnPageChangingIndex(object sender, GridViewPageEventArgs e)
        {
            throw new System.NotImplementedException();
        }

        protected void OnRowCommandEventHandler(object sender, GridViewCommandEventArgs e)
        {
            throw new System.NotImplementedException();
        }
    }
}