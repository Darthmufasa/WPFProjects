<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Header.ascx.cs" Inherits="WebFormsProjects.UserControls.Header" %>

<div class="dropdown">
    <asp:Button ID="HeaderButton" runat="server" Text="Button" OnClick="HeaderButton_Click"/>
  <div id="myDropdown" class="dropdown-content">
    <a href="#">Top</a>
    <a href="#">Integration</a>
    <a href="#">Footer</a>
  </div>
</div>
<h2>
    Google Maps Web Forms Integration
</h2>