<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/AdminMaster.Master" AutoEventWireup="true" CodeBehind="NewJob.aspx.cs" Inherits="JobPortal.Admin.NewJob" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div style="background-image: url('../Images/bg.jpg'); width: 100%; height: 720px; background-repeat: no-repeat; background-size: cover; background-attachment: fixed;">
        <div class="container pt-4 pb-4">
            <div>
                <asp:Label ID="lblMsg" runat="server"></asp:Label>
            </div>
            <h3 class="text-center">Add Job</h3>
            <div class="row mr-lg-5 ml-lg-5 mb-3">
                <div class="col-md-6 pt-3">
                    <asp:Label for="txtJobTitle" style="font-weight: 600;">Job Title</asp:Label>
                    <asp:TextBox ID="txtJobTitle" runat="server" CssClass="form-control" placeholder="Ex. Web Developer, App Developer" required></asp:TextBox>
                </div>
            </div>
            <div class="row mr-lg-5 ml-lg-5 mb-3">
                <div class="col-md-6 pt-3">
                    <asp:Label for="txtNoOfPost" style="font-weight: 600;">Numbeer Of Post</asp:Label>
                    <asp:TextBox ID="txtNoOfPost" runat="server" CssClass="form-control" placeholder="Enter Number of Position" TextMode="Number" required></asp:TextBox>
                </div>
            </div>
            <div class="row mr-lg-5 ml-lg-5 mb-3">
                <div class="col-md-12 pt-3">
                    <asp:Label for="txtDescription" style="font-weight: 600;">Description</asp:Label>
                    <asp:TextBox ID="txtDescription" runat="server" CssClass="form-control" placeholder="Enter Description" TextMode="Multiline" required></asp:TextBox>
                </div>
            </div>
            <div class="row mr-lg-5 ml-lg-5 mb-3">
                <div class="col-md-6 pt-3">
                    <asp:Label for="txtQualification" style="font-weight: 600;">Qualification/Education Required</asp:Label>
                    <asp:TextBox ID="txtQualification" runat="server" CssClass="form-control" placeholder="Ex. MCA, BTech, MBA" required></asp:TextBox>
                </div>
                <div class="col-md-6 pt-3">
                    <asp:Label for="txtExperience" style="font-weight: 600;">Experience Required</asp:Label>
                    <asp:TextBox ID="txtExperience" runat="server" CssClass="form-control" placeholder="Ex. 1Years, 5Years" required></asp:TextBox>
                </div>
            </div>
            <div class="row mr-lg-5 ml-lg-5 mb-3">
                <div class="col-md-6 pt-3">
                    <asp:Label for="txtSpecialization" style="font-weight: 600;">Specialization Required</asp:Label>
                    <asp:TextBox ID="txtSpecialization" runat="server" CssClass="form-control" placeholder="Enter Specialization" TextMode="Multiline" required></asp:TextBox>
                </div>
                <div class="col-md-6 pt-3">
                    <asp:Label for="txtLastDate" style="font-weight: 600;">Last Date To Apply</asp:Label>
                    <asp:TextBox ID="txtLastDate" runat="server" CssClass="form-control" placeholder="Enter Last Date to Apply" TextMode="Date" required></asp:TextBox>
                </div>
            </div>

            <div class="row mr-lg-5 ml-lg-5 mb-3">
                <div class="col-md-6 pt-3">
                    <asp:Label for="txtSalary" style="font-weight: 600;">Salary</asp:Label>
                    <asp:TextBox ID="txtSalary" runat="server" CssClass="form-control" placeholder="Ex. 500/Month, 300/Month" TextMode="Multiline" required></asp:TextBox>
                </div>
                <div class="col-md-6 pt-3">
                    <asp:Label for="ddlJobType" style="font-weight: 600;">Type Job</asp:Label>
                    <asp:DropDownList ID="ddlJobType" runat="server" CssClass="form-control">
                        <asp:ListItem Value="0">Type Job</asp:ListItem>
                        <asp:ListItem>Full Time</asp:ListItem>
                        <asp:ListItem>Part Time</asp:ListItem>
                        <asp:ListItem>Freelance</asp:ListItem>
                    </asp:DropDownList>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Job Type Is Required" ForeColor="Red"
                        ControlToValidate="ddlJobType" InitialValue="0" Display="Dynamic" SetFocusOnError="True">
                    </asp:RequiredFieldValidator>
                </div>
            </div>

            <div class="row mr-lg-5 ml-lg-5 mb-3">
                <div class="col-md-6 pt-3">
                    <asp:Label for="txtCompany" style="font-weight: 600;">Company/Organisation Name</asp:Label>
                    <asp:TextBox ID="txtCompany" runat="server" CssClass="form-control" placeholder="Enter Name" required></asp:TextBox>
                </div>
                <div class="col-md-6 pt-3">
                    <asp:Label for="ddlJobType" style="font-weight: 600;">Company/Organisation Logo</asp:Label>
                    <asp:FileUpload ID="fuCompanyLogo" runat="server" CssClass="form-control" ToolTip=".jpg, .jpeg, .png extension only"></asp:FileUpload>
                </div>
            </div>

            <div class="row mr-lg-5 ml-lg-5 mb-3">
                <div class="col-md-6 pt-3">
                    <asp:Label for="txtWebsite" style="font-weight: 600;">Website</asp:Label>
                    <asp:TextBox ID="txtWebsite" runat="server" CssClass="form-control" placeholder="Enter Website" TextMode="Url"></asp:TextBox>
                </div>
                <div class="col-md-6 pt-3">
                    <asp:Label for="txtEmail" style="font-weight: 600;">Email</asp:Label>
                    <asp:TextBox ID="txtEmail" runat="server" CssClass="form-control" placeholder="Enter Email" TextMode="Email"></asp:TextBox>
                </div>
            </div>

            <div class="row mr-lg-5 ml-lg-5 mb-3">
                <div class="col-md-12 pt-3">
                    <asp:Label for="txtAddress" style="font-weight: 600;">Address</asp:Label>
                    <asp:TextBox ID="txtAddress" runat="server" CssClass="form-control" placeholder="Enter Work Location" TextMode="Multiline" required></asp:TextBox>
                </div>
            </div>

            <div class="row mr-lg-5 ml-lg-5 mb-3">
                <div class="col-md-6 pt-3">
                    <asp:Label for="txtCountry" style="font-weight: 600;">Country</asp:Label>
                    <asp:DropDownList ID="ddlCountry" runat="server" DataSourceID="sqlDataSource1" CssClass="form-control w-100" AppenDataBoundItems="true"
                        DataTextField="CountryName" DataValueField="CountryName">
                    </asp:DropDownList>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="Country is Required" Display="Dynamic" SetFocusOnError="true"
                        Font-Size="Small" InitialValue="0" ControlToValidate="ddlCountry">
                    </asp:RequiredFieldValidator>
                    <asp:SqlDataSource ID="sqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:cs %>" SelectCommand="SELECT [CountryName] FROM [Country]"></asp:SqlDataSource>
                </div>
                <div class="col-md-6 pt-3">
                    <asp:Label for="txtState" style="font-weight: 600;">State</asp:Label>
                    <asp:TextBox ID="txtState" runat="server" CssClass="form-control" placeholder="Enter State" required></asp:TextBox>
                </div>
            </div>

            <div class="row mr-lg-5 ml-lg-5 mb-3">
                <div class="col-md-3 col-md-offset-2 mb-2">
                    <asp:Button ID="btnAdd" runat="server" CssClass="btn btn-primary btn-block" BackColor="#7200cf" Text="Add job" OnClick="btnAdd_Click" />
                </div>
            </div>
        </div>
    </div>
</asp:Content>