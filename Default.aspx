<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Proyecto3BD._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <main>
        
        <asp:Panel ID="pnlMenuPrincipal" runat="server" Visible="true">
            <div> 

                <br/>
                SISTEMA DE FACTURACIÓN DE SERVICIOS TELEFÓNICOS
                <br />
                <br />
                <!-- Sección de entrada de texto para buscar -->
                <asp:TextBox ID="TextBoxSearch" runat="server" placeholder="Número telefónico"></asp:TextBox>
                <!-- Botón para buscar -->
                <asp:Button ID="btnSearch" runat="server" Text="Buscar" OnClick="btnSearch_Click" />
                <br />
                <br />
                <!-- Lista de los empleados + boton que sale junto a cada uno -->
                <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="false" OnRowCommand="GridView1_RowCommand">
                    <Columns>
                        <asp:BoundField DataField="Id" HeaderText="ID Factura" />
                        <asp:BoundField DataField="Total" HeaderText="Total" />
                        <asp:BoundField DataField="TotalMasIVA" HeaderText="+ I.V.A." />
                        <asp:BoundField DataField="Estado" HeaderText="Estado" />
                        <asp:ButtonField ButtonType="Button" Text="Ver Detalle" CommandName="Accion" />

     
                    </Columns>
                </asp:GridView>

                <br />
                <br />
                
                ESTADOS DE CUENTA
                <br />
                <asp:Button ID="Button1" runat="server" Text="Empresa X" OnClick="btnSearch_Click" />
                <asp:Button ID="Button2" runat="server" Text="Empresa Y" OnClick="btnSearch_Click" />

            <div> 
        </asp:Panel>

    


        <asp:Panel ID="pnlSeleccionEmpleado" runat="server" Visible="false">

            Factura seleccionado: 
            <asp:Label ID="lblIdFactura" runat="server"></asp:Label> <br />
            <br />
            <asp:GridView ID="GridView2" runat="server" AutoGenerateColumns="false">
                <Columns>
                    <asp:TemplateField HeaderText="Desglose de Factura">
                        <ItemTemplate>
                            <table>
                                <tr class="grid-row-spacing"><td colspan="2"></td></tr>
                                <tr>
                                    <td>Fecha de Cierre:</td>
                                    <td><%# Eval("FechaCierre") %></td>
                                </tr>
                                <tr class="grid-row-spacing"><td colspan="2"></td></tr>
                                <tr>
                                    <td>Total:</td>
                                    <td><%# Eval("Total") %></td>
                                </tr>
                                <tr class="grid-row-spacing"><td colspan="2"></td></tr>
                                <tr>
                                    <td>Total + I.V.A.:</td>
                                    <td><%# Eval("TotalMasIVA") %></td>
                                </tr>
                                <tr class="grid-row-spacing"><td colspan="2"></td></tr>
                                <tr>
                                    <td>Multa:</td>
                                    <td><%# Eval("Multa") %></td>
                                </tr>
                                <tr class="grid-row-spacing"><td colspan="2"></td></tr>
                                <tr>
                                    <td>Total + Multa:</td>
                                    <td><%# Eval("TotalMasMulta") %></td>
                                </tr>
                                <tr class="grid-row-spacing"><td colspan="2"></td></tr>
                                <tr>
                                    <td>Fecha de Pago:</td>
                                    <td><%# Eval("FechaPago") %></td>
                                </tr>
                            </table>
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
            <br />
            <br />
            <!-- Botón para regresar -->
            <asp:Button ID="BtnRegresarSelec" runat="server" Text="Regresar" OnClick="btnRegresar_Click" />

        </asp:Panel>


    </main>

</asp:Content>
