<%@ Page Title="Cadastrar Usuario" Language="C#" MasterPageFile="Admin.Master" Inherits="ProjetoFaculdade2.Views.NewUser" %>

<asp:Content runat="server" ContentPlaceHolderID="bodyPlaceholder">
    <div class="container">
        <div class="row mt-4">
            <div class="col-12 d-flex justify-content-between align-items-center">
                <h2>Cadastar usuario</h2>
                <a href="<%: GetRouteUrl("users", null) %>" class="btn btn-outline-dark">
                    <i class="fas fa-arrow-left"></i> &nbsp; Voltar
                </a>
            </div>
        </div>
        <hr/>
        <div class="row mt-4">
            <div class="col-12">
                <div class="row">
                    <div class="col-12 col-sm-6 col-md-6">
                        <div class="form-group">
                            <label for="userLogin">Insira o email do usuario</label>
                            <asp:TextBox runat="server" CssClass="form-control" ID="userLogin"/>
                        </div>
                    </div>
                    <div class="col-12 col-sm-6 col-md-6">
                        <div class="form-group">
                            <label for="userPassword">Insira a senha do usuario</label>
                            <asp:TextBox runat="server" type="password" CssClass="form-control" ID="userPassword"/>
                        </div>
                    </div>
                </div>
            </div>
        </div>
        <div class="row">
            <div class="col-12 col-md-6 offset-md-6">
                <div class="row">
                    <div class="col-6">
                        <a class="btn btn-outline-dark btn-block" href="#">
                            <i class="fas fa-arrow-left"></i> &nbsp; Voltar
                        </a>
                    </div>
                    <div class="col-6">
                        <asp:LinkButton runat="server" OnClick="NewUserButtonClick" class="btn btn-outline-primary btn-block">
                            <i class="fas fa-check-square"></i> &nbsp; Salvar
                        </asp:LinkButton>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>