<%@ Page Title="Feedback" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="Feedback.aspx.cs" Inherits="Task2.Feedback" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1>Feedback</h1>

    <asp:TextBox runat="server" ID="tbxFeedback"></asp:TextBox>
    <asp:Button runat="server" ID="btnSubmitFeedback" Text="Submit feedback" />
</asp:Content>
