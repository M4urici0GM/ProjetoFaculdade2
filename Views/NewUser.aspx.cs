using System;
using System.Web.UI;

namespace ProjetoFaculdade2.Views
{
    public partial class NewUser : Page
    {
        protected void NewUserButtonClick(object sender, EventArgs e)
        {
            if (userLogin.Text.Length == 0 || userPassword.Text.Length == 0)
            {
                ClientScript.RegisterStartupScript(this.GetType(), "missingFields", "<script> Swal.fire({type: 'error', title: 'Ops, algo deu errado', text: 'Insira o usuario e a senha!'}); </script>");
            }
            
            
        }
    }
}