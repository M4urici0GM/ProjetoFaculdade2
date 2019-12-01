<%@ Page Title="Title" Async="true" Language="C#" MasterPageFile="Admin.Master" CodeBehind="Users.aspx.cs" Inherits="ProjetoFaculdade2.Views.Users" %>

<asp:Content runat="server" ContentPlaceHolderID="bodyPlaceholder">
    <div class="container">
            <div class="row mt-4">
               <div class="col-12 d-flex justify-content-between align-items-center">
                   <h2>Usuarios</h2>
                   <a href="<%: GetRouteUrl("newUser", null) %>" class="btn btn-outline-dark">
                       <i class="fas fa-user-plus"></i> &nbsp; Novo
                   </a>
               </div>
            </div>
            <hr />
            <div class="row">
                <div class="table-responsive">
                    <asp:GridView ID="userGridView" runat="server"  
                                  ShowHeaderWhenEmpty="true" 
                                  EmptyDataText="Sem registros no sistema!" 
                                  AutoGenerateColumns="false" 
                                  DataKeyNames="Id"
                                  CssClass="table table-borderless table-hover text-center border-0" 
                                  AllowPaging="true" 
                                  OnPageIndexChanging="OnPageChangingIndex"
                                  OnRowCommand="OnRowCommandEventHandler">
                        <Columns>
                            <asp:BoundField DataField="Login" HeaderStyle-CssClass="text-center"  HeaderText="Usuario" />
                            <asp:TemplateField HeaderText="Ações" HeaderStyle-CssClass="text-center" >
                                <ItemTemplate>
                                    <asp:LinkButton ID="editButton" runat="server" CommandName="editUser" CssClass="btn btn-outline-primary">
                                        <i class="fas fa-user-cog"></i> Editar
                                    </asp:LinkButton>
                                    <asp:LinkButton ID="delButton" runat="server" CommandName="editUser" CssClass="btn btn-outline-danger">
                                        <i class="fas fa-user-minus"></i> Excluir
                                    </asp:LinkButton>
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                    </asp:GridView>
                </div>
            </div>
        </div>
</asp:Content>