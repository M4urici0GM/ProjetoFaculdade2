using System;
using System.Web.UI;
using ProjetoFaculdade2.App_Data;
using ProjetoFaculdade2.App_Data.Exceptions;
using ProjetoFaculdade2.Entities;

namespace ProjetoFaculdade2.Views
{
    public partial class NewUser : Page
    {
        private UserContext userContext;

        protected void Page_Load(object sender, EventArgs e)
        {
            userContext = new UserContext();
        }
        
        protected async void NewUserButtonClick(object sender, EventArgs e)
        {
            if (userLogin.Text.Length == 0 || userPassword.Text.Length == 0)
            {
                ClientScript.RegisterStartupScript(this.GetType(), "missingFields", "<script> Swal.fire({type: 'error', title: 'Ops, algo deu errado', text: 'Insira o usuario e a senha!'}); </script>");
            }

            try
            {
                User user = await userContext.CreateUser(new User
                {
                    Login = userLogin.Text,
                    Password = userPassword.Text
                });
                if (user.Id.HasValue)
                    ClientScript.RegisterStartupScript(this.GetType(), "missingFields", "<script> Swal.fire({type: 'success', title: 'Cadastrar usuario', text: 'Usuario cadastrado com sucesso!'}).then(() => location.href = '"+ GetRouteUrl("users")  +"'); </script>");
            }
            catch (EntityAlreadyExists ex)
            {
                ClientScript.RegisterStartupScript(this.GetType(), "missingFields", "<script> Swal.fire({type: 'error', title: 'Ops, algo deu errado', text: 'Um usuario com esse login ja existe!'}); </script>");
            }
        }
    }
}