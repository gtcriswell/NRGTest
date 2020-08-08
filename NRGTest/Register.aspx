<%@ Page Title="" Language="C#" MasterPageFile="~/Master_Page.Master" AutoEventWireup="true" CodeBehind="Register.aspx.cs" Inherits="NRGTest.Register" %>



<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <link href="Content/bootstrap.css" rel="stylesheet" />
    <link href="Content/Site.css" rel="stylesheet" />
    <asp:HiddenField ID="hfUID" runat="server" Value="0" />
    <div class="row">
        <div class="col-3">
        </div>
        <div class="col-6">
            <div class="form-row">
                <div class="form-group col-md-6 pad1">
                    <label>
                        First Name&nbsp;<asp:RequiredFieldValidator ID="rf_first" ValidationGroup="form" CssClass="red" Text="*" runat="server" ErrorMessage="First Name Required" ControlToValidate="txtFirstName"></asp:RequiredFieldValidator>
                    </label>
                    <asp:TextBox ID="txtFirstName" class="form-control" ValidationGroup="form" runat="server"></asp:TextBox>
                </div>
                <div class="form-group col-md-6 pad1">
                    <label>
                        Last Name&nbsp;<asp:RequiredFieldValidator ValidationGroup="form" ID="rf_last" runat="server" ErrorMessage="Last Name Required" ControlToValidate="txtLastName" CssClass="red">*</asp:RequiredFieldValidator>
                    </label>
                    <asp:TextBox ID="txtLastName" class="form-control" ValidationGroup="form" runat="server"></asp:TextBox>
                </div>
            </div>
            <div class="form-group pad1">
                <label>
                    Address&nbsp;<asp:RequiredFieldValidator ValidationGroup="form" ControlToValidate="txtAdd1" CssClass="red" ID="rf_address" runat="server" ErrorMessage="Address Required">*</asp:RequiredFieldValidator>
                </label>
                <asp:TextBox ID="txtAdd1" class="form-control" ValidationGroup="form" placeholder="1234 Main St" runat="server"></asp:TextBox>
            </div>
            <div class="form-group pad1">
                <label for="inputAddress2">Address 2</label>
                <asp:TextBox ID="txtAdd2" class="form-control" ValidationGroup="form" placeholder="Apartment, studio, or floor" runat="server"></asp:TextBox>
            </div>
            <div class="form-row">
                <div class="form-group col-md-5 pad1">
                    <label>
                        City&nbsp;<asp:RequiredFieldValidator ID="rf_city" ControlToValidate="txtCity" ValidationGroup="form" runat="server" CssClass="red" ErrorMessage="City Required">*</asp:RequiredFieldValidator>
                    </label>
                    <asp:TextBox ID="txtCity" class="form-control" ValidationGroup="form" runat="server"></asp:TextBox>
                </div>
                <div class="form-group col-md-4 pad1">
                    <label>
                        State&nbsp<asp:CustomValidator ID="cv_state" CssClass="red" Enabled="true" ValidateEmptyText="true" ValidationGroup="form" runat="server" Text="*" ControlToValidate="ddlState" ErrorMessage="State Required" OnServerValidate="cv_state_ServerValidate"></asp:CustomValidator>
                    </label>
                    <asp:DropDownList ID="ddlState" CssClass="form-control auto-size" ValidationGroup="form" runat="server">
                        <asp:ListItem Value="">--select--</asp:ListItem>
                        <asp:ListItem Value="AL">Alabama</asp:ListItem>
                        <asp:ListItem Value="AK">Alaska</asp:ListItem>
                        <asp:ListItem Value="AZ">Arizona</asp:ListItem>
                        <asp:ListItem Value="AR">Arkansas</asp:ListItem>
                        <asp:ListItem Value="CA">California</asp:ListItem>
                        <asp:ListItem Value="CO">Colorado</asp:ListItem>
                        <asp:ListItem Value="CT">Connecticut</asp:ListItem>
                        <asp:ListItem Value="DC">District of Columbia</asp:ListItem>
                        <asp:ListItem Value="DE">Delaware</asp:ListItem>
                        <asp:ListItem Value="FL">Florida</asp:ListItem>
                        <asp:ListItem Value="GA">Georgia</asp:ListItem>
                        <asp:ListItem Value="HI">Hawaii</asp:ListItem>
                        <asp:ListItem Value="ID">Idaho</asp:ListItem>
                        <asp:ListItem Value="IL">Illinois</asp:ListItem>
                        <asp:ListItem Value="IN">Indiana</asp:ListItem>
                        <asp:ListItem Value="IA">Iowa</asp:ListItem>
                        <asp:ListItem Value="KS">Kansas</asp:ListItem>
                        <asp:ListItem Value="KY">Kentucky</asp:ListItem>
                        <asp:ListItem Value="LA">Louisiana</asp:ListItem>
                        <asp:ListItem Value="ME">Maine</asp:ListItem>
                        <asp:ListItem Value="MD">Maryland</asp:ListItem>
                        <asp:ListItem Value="MA">Massachusetts</asp:ListItem>
                        <asp:ListItem Value="MI">Michigan</asp:ListItem>
                        <asp:ListItem Value="MN">Minnesota</asp:ListItem>
                        <asp:ListItem Value="MS">Mississippi</asp:ListItem>
                        <asp:ListItem Value="MO">Missouri</asp:ListItem>
                        <asp:ListItem Value="MT">Montana</asp:ListItem>
                        <asp:ListItem Value="NE">Nebraska</asp:ListItem>
                        <asp:ListItem Value="NV">Nevada</asp:ListItem>
                        <asp:ListItem Value="NH">New Hampshire</asp:ListItem>
                        <asp:ListItem Value="NJ">New Jersey</asp:ListItem>
                        <asp:ListItem Value="NM">New Mexico</asp:ListItem>
                        <asp:ListItem Value="NY">New York</asp:ListItem>
                        <asp:ListItem Value="NC">North Carolina</asp:ListItem>
                        <asp:ListItem Value="ND">North Dakota</asp:ListItem>
                        <asp:ListItem Value="OH">Ohio</asp:ListItem>
                        <asp:ListItem Value="OK">Oklahoma</asp:ListItem>
                        <asp:ListItem Value="OR">Oregon</asp:ListItem>
                        <asp:ListItem Value="PA">Pennsylvania</asp:ListItem>
                        <asp:ListItem Value="RI">Rhode Island</asp:ListItem>
                        <asp:ListItem Value="SC">South Carolina</asp:ListItem>
                        <asp:ListItem Value="SD">South Dakota</asp:ListItem>
                        <asp:ListItem Value="TN">Tennessee</asp:ListItem>
                        <asp:ListItem Value="TX">Texas</asp:ListItem>
                        <asp:ListItem Value="UT">Utah</asp:ListItem>
                        <asp:ListItem Value="VT">Vermont</asp:ListItem>
                        <asp:ListItem Value="VA">Virginia</asp:ListItem>
                        <asp:ListItem Value="WA">Washington</asp:ListItem>
                        <asp:ListItem Value="WV">West Virginia</asp:ListItem>
                        <asp:ListItem Value="WI">Wisconsin</asp:ListItem>
                        <asp:ListItem Value="WY">Wyoming</asp:ListItem>
                    </asp:DropDownList>
                </div>
                <div class="form-group col-md-3 pad1">
                    <label>
                        Zip&nbsp<asp:CustomValidator ID="cv_zip" CssClass="red" Enabled="true" ValidateEmptyText="true" ValidationGroup="form" runat="server" Text="*" ControlToValidate="txtZip" ErrorMessage="Invalid Zip Code" OnServerValidate="cv_zip_ServerValidate"></asp:CustomValidator>
                    </label>
                    &nbsp;<asp:TextBox ID="txtZip" class="form-control" ValidationGroup="form" runat="server"></asp:TextBox>
                </div>
            </div>


            <div class="form-row">
                <div class="form-group col-md-5 pad1">
                    <label>
                        Email&nbsp<asp:CustomValidator ID="cv_email" CssClass="red" Enabled="true" ValidateEmptyText="true" ValidationGroup="form" runat="server" Text="*" ControlToValidate="txtEmail" ErrorMessage="Invalid Email" OnServerValidate="cv_email_ServerValidate"></asp:CustomValidator>
                    </label>
                    <asp:TextBox ID="txtEmail" class="form-control" ValidationGroup="form" runat="server"></asp:TextBox>
                </div>
                <div class="form-group col-md-4 pad1">
                    <label>Social Security&nbsp<asp:CustomValidator CssClass="red" ID="cv_ssn" Enabled="true" ValidateEmptyText="true" ValidationGroup="form" runat="server" Text="*" ControlToValidate="txtSSN" ErrorMessage="Invalid Social Security Number" OnServerValidate="cv_ssn_ServerValidate"></asp:CustomValidator></label>
                    <asp:TextBox ID="txtSSN" class="form-control" ValidationGroup="form" placeholder="###-##-####" runat="server" TextMode="Password"></asp:TextBox>
                </div>
                <div class="form-group col-md-3 pad1">
                    <label>Birth Day&nbsp<asp:CustomValidator CssClass="red" ID="cv_birthdate" Enabled="true" ValidateEmptyText="true" ValidationGroup="form" runat="server" Text="*" ControlToValidate="txtBirthDate" ErrorMessage="Invalid Birth Date" OnServerValidate="cv_birthdate_ServerValidate"></asp:CustomValidator></label>
                    <asp:TextBox ID="txtBirthDate" class="form-control" ValidationGroup="form" placeholder="mm/dd/yyyy" runat="server"></asp:TextBox>
                </div>
            </div>
            <div class="form-row align-items-center justify-content-center">
                <div class="col-md-* col-sm-* pad1">
                    <br />
                    <asp:Button ID="btnSaveRegistration" CausesValidation="true" runat="server" ValidationGroup="form" CssClass="btn btn-primary" Text="Complete Registration" OnClick="btnSaveRegistration_Click" />
                    <asp:ValidationSummary CssClass="orange" ID="ValidationSummary1" ValidationGroup="form" runat="server" />
                </div>
            </div>
            <br />
        </div>
        <div class="col-3">
        </div>
    </div>


    <script>

        $(function () {
            $("#<%=txtBirthDate.ClientID%>").datepicker();
        });

    </script>
</asp:Content>
