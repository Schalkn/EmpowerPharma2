<%@ Page Title="Create Prescription" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="CreateP.aspx.cs" Inherits="EmpowerPharma.CreateP" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <!-- Page Title -->
    <h2>Create Prescription</h2>

    <!-- Doctor Information -->
    <asp:Label ID="lblDoctorInfo" runat="server" CssClass="doctor-info" />

    <hr />

    <!-- Products Section -->
    <h3>Products</h3>
    <asp:Panel ID="pnlProducts" runat="server" CssClass="panel-section">
        <asp:Button ID="btnNewProduct" runat="server" CssClass="aspnet-button" Text="New Product" OnClick="btnNewProduct_Click" />

        <asp:Panel ID="pnlAddProduct" runat="server" CssClass="panel-section" Visible="false">
            <label for="ddlProducts">Product:</label>
            <asp:DropDownList ID="ddlProducts" runat="server" CssClass="form-control" />

            <label for="txtProductQuantity">Quantity:</label>
            <asp:TextBox ID="txtProductQuantity" runat="server" CssClass="form-control" />

            <label>Price:</label>
            <asp:Label ID="lblProductPrice" runat="server" CssClass="form-control" />

            <label for="txtProductDescription">Description:</label>
            <asp:TextBox ID="txtProductDescription" runat="server" CssClass="form-control" TextMode="MultiLine" Rows="2" MaxLength="100" />

            <asp:Button ID="btnAddProduct" runat="server" CssClass="aspnet-button" Text="Add Product" OnClick="btnAddProduct_Click" />
        </asp:Panel>

        <asp:GridView ID="gvProducts" runat="server" CssClass="gridview" AutoGenerateColumns="false">
            <Columns>
                <asp:BoundField DataField="Name" HeaderText="Product" />
                <asp:BoundField DataField="Quantity" HeaderText="Quantity" />
                <asp:BoundField DataField="Price" HeaderText="Price" />
                <asp:BoundField DataField="Description" HeaderText="Description" />
            </Columns>
        </asp:GridView>
    </asp:Panel>

    <hr />

    <!-- Patients Section -->
    <h3>Patients</h3>
    <asp:Panel ID="pnlPatients" runat="server" CssClass="panel-section">
        <asp:Button ID="btnNewPatient" runat="server" CssClass="aspnet-button" Text="New Patient" OnClick="btnNewPatient_Click" />

        <asp:Panel ID="pnlAddPatient" runat="server" CssClass="panel-section" Visible="false">
            <label for="txtPatientName">Name:</label>
            <asp:TextBox ID="txtPatientName" runat="server" CssClass="form-control" />

            <label for="txtPatientID">ID Number:</label>
            <asp:TextBox ID="txtPatientID" runat="server" CssClass="form-control" />

            <label for="txtPatientMobile">Mobile:</label>
            <asp:TextBox ID="txtPatientMobile" runat="server" CssClass="form-control" />

            <asp:Button ID="btnAddPatient" runat="server" CssClass="aspnet-button" Text="Add Patient" OnClick="btnAddPatient_Click" />
        </asp:Panel>

        <asp:GridView ID="gvPatients" runat="server" CssClass="gridview" AutoGenerateColumns="false">
            <Columns>
                <asp:BoundField DataField="Name" HeaderText="Name" />
                <asp:BoundField DataField="IDNumber" HeaderText="ID Number" />
                <asp:BoundField DataField="Mobile" HeaderText="Mobile" />
            </Columns>
        </asp:GridView>
    </asp:Panel>

    <hr />

    <!-- Create Prescription Button -->
    <asp:Button ID="btnCreatePrescription" runat="server" CssClass="aspnet-button" Text="Create Prescription" OnClick="btnCreatePrescription_Click" />

    <!-- OTP Modal -->

    <asp:Button ID="hiddenModalTrigger" runat="server" Style="display:none" />

    <ajaxToolkit:ModalPopupExtender 
        ID="mpeOTP" 
        runat="server" 
        TargetControlID="hiddenModalTrigger" 
        PopupControlID="pnlOTP" 
        BackgroundCssClass="modal-background" />

    <asp:Panel ID="pnlOTP" runat="server" CssClass="modal-panel" Style="display:none;">
        <h3>Enter OTP</h3>
        <asp:Label ID="lblOtpInstructions" runat="server" CssClass="modal-text" />
        <br /><br />
        <asp:TextBox ID="txtOtpInput" runat="server" MaxLength="6" CssClass="form-control" />
        <br /><br />
        <asp:Button ID="btnSubmitOtp" runat="server" CssClass="aspnet-button" Text="Submit" OnClick="btnSubmitOtp_Click" />
        <asp:Button ID="btnCancelOtp" runat="server" CssClass="aspnet-button" Text="Cancel" OnClick="btnCancelOtp_Click" />
        <asp:Button ID="btnResendOtp" runat="server" CssClass="aspnet-button" Text="Resend" OnClick="btnResendOtp_Click" />
        <br /><br />
        <asp:Label ID="lblOtpCountdown" runat="server" CssClass="modal-text" />
    </asp:Panel>

</asp:Content>

