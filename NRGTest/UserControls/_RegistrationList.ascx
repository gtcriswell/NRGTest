<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="_RegistrationList.ascx.cs" Inherits="NRGTest.UserControls._RegistrationList" %>
<asp:GridView ID="gvRegistrations" runat="server" AutoGenerateColumns="False" CssClass="table">
    <Columns>
        <asp:TemplateField HeaderText="Name">
            <ItemTemplate>
                <asp:Label ID="lblName" Text='<%#Bind("FullName")%>' runat="server"></asp:Label>
            </ItemTemplate>
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Email">
            <ItemTemplate>
                <asp:Label ID="lblEmail" Text='<%#Bind("Email")%>' runat="server"></asp:Label>
            </ItemTemplate>
        </asp:TemplateField>
        <asp:TemplateField>
            <ItemTemplate>

                <a href='Register.aspx?Action=Edit&amp;UID=<%#Eval("UID")%>'>edit</a>

            </ItemTemplate>
        </asp:TemplateField>
    </Columns>
</asp:GridView>
