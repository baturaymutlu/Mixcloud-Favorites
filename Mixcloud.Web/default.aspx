<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="default.aspx.cs" Inherits="Mixcloud.Web._default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Mixcloud Favorites</title>
</head>
<body>
    <form id="form1" runat="server">
    <asp:ScriptManager runat="server" ID="scrManager">
    </asp:ScriptManager>
    <asp:UpdatePanel runat="server" ID="upMain">
        <ContentTemplate>
            <table>
                <tr>
                    <td>
                        Username :
                    </td>
                    <td>
                        <asp:TextBox runat="server" ID="txtUsername" Text="baturaymutlu">
                        </asp:TextBox>
                    </td>
                    <td>
                        <asp:Button runat="server" ID="btnSubmit" Text="Get Favorites" OnClick="btnSubmit_Click" />
                    </td>
                </tr>
            </table>
            <div id="divFavorites" runat="server">
                <table>
                    <tr>
                        <asp:Repeater runat="server" ID="rptFavorites">
                            <ItemTemplate>
                                <td>
                                    <a href='<%#Eval("url") %>'>
                                        <img src='<%#Eval("pictures.thumbnail") %>' /></a>
                                </td>
                                <td>
                                    <a href='<%#Eval("url") %>'>
                                        <%#Eval("name") %></a>
                                </td>
                            </ItemTemplate>
                        </asp:Repeater>
                    </tr>
                </table>
            </div>
            <div id="divMessage" runat="server" visible="False">
                There are no favorites.
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
    </form>
</body>
</html>
