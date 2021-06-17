<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Matheus_Almeida___Menu_Dinamico.Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="Style.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <asp:Menu ID="Menu1" runat="server" Orientation="Horizontal" >

        <LevelMenuItemStyles>
    <asp:MenuItemStyle CssClass="level1"/>
    <asp:MenuItemStyle CssClass="level2"/>
    <asp:MenuItemStyle CssClass="level3" />
    <asp:MenuItemStyle CssClass="level4" />
  </LevelMenuItemStyles>
  
  <StaticHoverStyle CssClass="hoverstyle"/>

        </asp:Menu>
    
    </div>
    </form>
</body>
</html>
