<%@ Page Title="Main" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Task2.Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1>Main</h1>
    <h1 runat="server" id="lblFeedback" visible="false">Might you have some information to let us know? <a href="Feedback.aspx">Please put it here</a></h1>
    <p runat="server" id="lblSubmitSuccess" visible="false">We have received your feedback!</p>
    <asp:Button runat="server" ID="btnEndSession" Text="End my session" />
</asp:Content>
