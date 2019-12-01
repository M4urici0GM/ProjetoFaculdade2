using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ProjetoFaculdade2.App_Data;
using ProjetoFaculdade2.App_Data.Exceptions;
using ProjetoFaculdade2.Entities;

namespace ProjetoFaculdade2.Views
{
    public partial class Login : System.Web.UI.Page
    {

        private readonly UserContext _userContext;

        public Login()
        {
            _userContext = new UserContext();
        }

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected async void DoLoginEvent(object sender, EventArgs e)
        {
            if (userMail.Text.Length == 0 || userPassword.Text.Length == 0)
            {
                ClientScript.RegisterStartupScript(this.GetType(), "missingFields", "<script> Swal.fire({type: 'error', title: 'Ops, algo deu errado', text: 'Insira o usuario e a senha!'}); </script>");
            }

            try
            {
                User user = await _userContext.DoLogin(new User
                {
                    Login = userMail.Text,
                    Password = userPassword.Text
                });

                Session["userSession"] = user;
                Response.RedirectToRoute("home");
            }
            catch (Exception ex)
            {
                ClientScript.RegisterStartupScript(this.GetType(), "missingFields", "<script> Swal.fire({type: 'error', title: 'Ops, algo deu errado', text: 'Usuario ou senha invalidos!'}); </script>");
            } 
        }
    }
}