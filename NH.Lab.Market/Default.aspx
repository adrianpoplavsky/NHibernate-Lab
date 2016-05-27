<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="NH.Lab.Market._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div class="jumbotron">
        <h1>NHibernate lab</h1>
        <p class="lead">Basic usage of NHibernate using just the NHibernate nuget package.</p>
    </div>
    <div class="container">
        <div id="generalExceptionMessage" role="alert" class="alert alert-danger alert-dismissable collapse">
            <span id="spanGeneralError"></span>
        </div>

        <div class="row">
            <div class="col-md-3">
                <div class="panel panel-primary">
                    <div class="panel-heading">
                        <h3 class="panel-title">Schema</h3>
                    </div>

                    <div class="panel-body">
                        <p>
                            Create from the mappings
                        <asp:Button runat="server" ID="btnCreateSchema" class="btn btn-primary" role="button" Text="Create" OnClientClick="createSchema(); return false;"  />
                        </p>
                        <p>
                            Check mappings
                        <asp:Button runat="server" ID="btnCheckMapping" class="btn btn-primary" role="button" Text="Check" OnClientClick="checkSchema(); return false;" />
                        </p>
                    </div>
                </div>
            </div>
            <div class="col-md-3">
                <div class="panel panel-primary">
                    <div class="panel-heading">
                        <h3 class="panel-title">Market</h3>
                    </div>

                    <div class="panel-body">
                        <p>
                            <asp:DropDownList class="form-control" runat="server" ID="ddlMarkets" DataTextField="Name" DataValueField="Id" />
                        </p>

                    </div>
                </div>
            </div>
            <div class="col-md-3">
                <div class="panel panel-primary">
                    <div class="panel-heading">
                        <h3 class="panel-title">Product</h3>
                    </div>

                    <div class="panel-body">
                        <p>
                            <asp:DropDownList class="form-control" runat="server" ID="ddlProducts" DataTextField="Name" DataValueField="Id" />
                        </p>
                    </div>
                </div>
            </div>
            <div class="col-md-3">
                <div class="panel panel-primary">
                    <div class="panel-heading">
                        <h3 class="panel-title">New Market</h3>
                    </div>

                    <div class="panel-body">
                        <p>
                            <label>Nombre</label><asp:TextBox ID="txtNombre" class="form-control" runat="server"></asp:TextBox>
                        </p>
                        <p>
                            <label>Direccion</label><asp:TextBox ID="txtAddress" class="form-control" runat="server"></asp:TextBox>
                        </p>
                        <p>
                            <asp:Button runat="server" ID="btnNuevoMarket" class="btn btn-primary" role="button" Text="Crear" OnClientClick="addMarket();return false;" />
                        </p>
                    </div>
                </div>
            </div>
            <div class="col-md-3">
                <div class="panel panel-primary">
                    <div class="panel-heading">
                        <h3 class="panel-title">New Product</h3>
                    </div>

                    <div class="panel-body">
                        <p>
                            <label>Nombre</label><asp:TextBox class="form-control" ID="txtProductName" runat="server"></asp:TextBox>
                        </p>
                        <p>
                            <label>Market</label><asp:DropDownList class="form-control" runat="server" ID="ddlMarketForProduct" DataTextField="Name" DataValueField="Id" />
                        </p>
                        <asp:Button runat="server" ID="btnNewProduct" class="btn btn-primary" role="button" Text="Crear" OnClientClick="addProduct(txtProductName, ddlMarketForProduct);return false;" />

                    </div>
                </div>
            </div>
            <div class="col-md-3">
                <div class="panel panel-primary">
                    <div class="panel-heading">
                        <h3 class="panel-title">Search Market</h3>
                    </div>

                    <div class="panel-body">
                        <p>
                            <label>Nombre a buscar</label><asp:TextBox ID="txtNameSearch" class="form-control" runat="server"></asp:TextBox>
                        </p>
                        <p>
                            <asp:LinkButton ID="LinkButton1" runat="server" CssClass="btn btn-primary" ><i class="glyphicon glyphicon-search"></i> Search</asp:LinkButton>
                        </p>
                        <p>
                            <asp:GridView class="form-control" ID="grdMarkets" runat="server"></asp:GridView>
                        </p>

                    </div>
                </div>
            </div>
            <div class="col-md-3">
                <div class="panel panel-primary">
                    <div class="panel-heading">
                        <h3 class="panel-title">Buscar Product</h3>
                    </div>

                    <div class="panel-body">
                        <p>
                            <label>Nombre a buscar</label><asp:TextBox ID="txtProductSearch" class="form-control" runat="server"></asp:TextBox>
                        </p>
                        <p>
                            With MARKET being a Lazy member (only fetched when needed), the Databind tries to get the value from Product.MarketDescrip, so this must happen inside a session otherwise an error will occur saying that the
                        </p>
                        <p>
                            <asp:Button runat="server" ID="btnProductSearch" class="btn btn-primary" role="button" Text="Search inside session" OnClientClick="getByProductName(txtproductName);return false;" />
                        </p>
                        <p>
                            <asp:GridView ID="grdProductResults" runat="server"></asp:GridView>
                        </p>
                        <p>
                            <asp:Button runat="server" ID="btnProductSearchNoSession" class="btn btn-primary" role="button" Text="Search with no session" OnClientClick="getByProductName(txtproductName);return false;" />
                        </p>


                    </div>
                </div>
            </div>
            <div class="col-md-3">
                <div class="panel panel-primary">
                    <div class="panel-heading">
                        <h3 class="panel-title">Product List</h3>
                    </div>

                    <div class="panel-body">
                        <table style="width: 100%;" id="products">
                        </table>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <script>
            var ddlMarkets = $("#<%=ddlMarkets.ClientID %>");
        var ddlMarketsForProducts = $("#<%=ddlMarketForProduct.ClientID %>");
        var txtProductName = $("#<%=txtProductName.ClientID %>");
        var ddlMarketForProduct = $("#<%=ddlMarketForProduct.ClientID %>");
        var txtNombre = $("#<%=txtNombre.ClientID %>");
        var txtAddress = $("#<%=txtAddress.ClientID %>");
        var ddlProducts = $("#<%=ddlProducts.ClientID %>");

        $(document).ready(function () { getProducts(ddlProducts); });
        $(document).ready(function () { getMarkets(ddlMarkets, ddlMarketsForProducts); });
    </script>
</asp:Content>
