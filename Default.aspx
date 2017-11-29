<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml" lang="en">
<head runat="server">
    <title>Play Tic Tac Toe</title>

    <meta charset="utf-8"/>
    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/css/bootstrap.min.css" />
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.2.1/jquery.min.js"></script>
    <script src="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/js/bootstrap.min.js"></script>
    <link href="StyleSheet.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <nav class="navbar navbar-inverse">
      <div class="container-fluid">
        <div class="navbar-header">
          <a class="navbar-brand" href="/">Tic Tac Toe</a>
        </div>
      </div>
    </nav>
    <div class="mainContent">
    <form id="form1" runat="server">
    <div class="content">
       <asp:ScriptManager ID="ScriptManager1" runat="server" />
        <asp:UpdatePanel ID="My_Items_Ajax" runat="server">
         <ContentTemplate>
        <div class="gameContent">
            <div class="gameStartText">
                <asp:Label CssClass="text-danger" ID="gameStartTextLabel" runat="server" Text="">To start playing, Select a difficulty level!</asp:Label>
            </div>
            <div class="table">
                <div class="Row Row-1">
                    <div class="Col Col-1">
                          <asp:Button CssClass="ImgButton" ID="A1" Style="border:none" runat="server" OnClick="Button_Click" Enabled="false" Text="" />
                    </div>
                    <div class="Col Col-2">
                          <asp:Button CssClass="ImgButton" ID="A2" Style="border:none" runat="server" OnClick="Button_Click" Enabled="false" Text="" />
                    </div>
                    <div class="Col Col-3">
                          <asp:Button CssClass="ImgButton" ID="A3" Style="border:none" runat="server" OnClick="Button_Click" Enabled="false" Text="" />
                    </div>
                </div>
                <div class="Row Row-2">
                    <div class="Col Col-1">
                          <asp:Button CssClass="ImgButton" ID="B1" Style="border:none" runat="server" OnClick="Button_Click" Text=""  />
                    </div>
                    <div class="Col Col-2">
                          <asp:Button CssClass="ImgButton" ID="B2" Style="border:none" runat="server" OnClick="Button_Click" Text=""  />
                    </div>
                    <div class="Col Col-3">
                          <asp:Button CssClass="ImgButton" ID="B3" Style="border:none" runat="server" OnClick="Button_Click" Text=""  />
                    </div>
                </div>
                <div class="Row Row-3">
                    <div class="Col Col-1">
                          <asp:Button CssClass="ImgButton" ID="C1" Style="border:none" runat="server" OnClick="Button_Click" Text=""  />
                    </div>
                    <div class="Col Col-2">
                          <asp:Button CssClass="ImgButton" ID="C2" Style="border:none" runat="server" OnClick="Button_Click" Text=""  />
                    </div>
                    <div class="Col Col-3">
                          <asp:Button CssClass="ImgButton" ID="C3" Style="border:none" runat="server" OnClick="Button_Click" Text=""  />
                    </div>
                </div>
            </div>
            <div class="buttonContainer">
                <div class="table2">
                    
                <div class="table2Row difficultyButtonsRow">
                    <br />
                        <asp:Label CssClass="Label" ID="difficultyLabel" runat="server" Text="">Difficulty Level: </asp:Label>&nbsp;
                        <asp:Button CssClass="btn btn-default" ID="changeDifficulty" runat="server" Text="Change"  Enabled="true" OnClick="changeDifficulty_Click"/>
                        <div class="btn-group">
                            <asp:Button CssClass="btn btn-default" ID="hard" runat="server" Text="Hard" OnClick="hard_Click" />
                            <asp:Button CssClass="btn btn-default" ID="impossible" runat="server" Text="Very Hard" OnClick="impossible_Click" />
                        </div>
                </div>
                <div class="table2Row resetButtonDiv">
                    <br />
                       <asp:Button CssClass="btn btn-primary" ID="Reset_Button" runat="server" Text="Reset Game" OnClick="Reset_Button_Click"/>
                </div>
                <div class="table2Row winnerLabelContainer">
                    <br /><asp:Label CssClass="Label" ID="labelWinner" runat="server" Text="" ></asp:Label>
                 </div>
                <div class="table2Row winnerLabelContainer">
                        <br /><br /><asp:Label CssClass="Label" ID="winsInARow" runat="server" Text=""></asp:Label>
                        <br /><br /><asp:Label ID="highscoreLabel" runat="server" Text=""></asp:Label>
                </div>
                </div>
            </div>
        </div>
    
             </ContentTemplate>
             </asp:UpdatePanel>
        </div>
    </form>
    </div>
</body>
</html>
