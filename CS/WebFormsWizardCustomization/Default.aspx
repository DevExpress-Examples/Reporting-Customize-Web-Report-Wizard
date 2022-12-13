<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.master" CodeBehind="Default.aspx.cs" Inherits="WebFormsWizardCustomization.Default" %>

<asp:Content ID="Content" ContentPlaceHolderID="MainContent" runat="server">
    <ul>
        <li/><a href="PredefinedSettings.aspx">Change the Predefined Page Size and Orientation</a>
        <li/><a href="RemovePage.aspx">Remove the 'Select Data Source' Page</a>
        <li/><a href="RemovePageSection.aspx">Hide Available Data Sources</a>
        <li/><a href="HideReportTypes.aspx">Hide the 'Label Report' and 'Empty Report' Types</a>
        <li/><a href="HideNoDataItem.aspx">Hide the 'No Data' Item</a>
        <li/><a href="ProhibitNewDataSourceCreation.aspx">Prohibit New Data Source Creation</a>
        <li/><a href="CustomizeColorSchemes.aspx">Customize Color Schemes</a>
        <li/><a href="SelectDataFields.aspx">Select Data Fields</a>
        <li/><a href="CustomizeWizardResult.aspx">Customize the Wizard Result</a>
    </ul>
</asp:Content>