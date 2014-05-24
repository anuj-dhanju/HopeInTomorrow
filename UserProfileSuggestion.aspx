<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/ProfileMasterPage.master" CodeFile="UserProfileSuggestion.aspx.cs" Inherits="UserProfileSuggestion" %>

<asp:Content ClientIDMode="AutoID" runat="server" ContentPlaceHolderID="ContentPlaceHolder1">
<script src="js/redirect.js" type="text/javascript"></script>
    <link href="css/sugesstion.css" rel="stylesheet" />
    <div class="div_user_profile_suggestion_container">
        <div class="div_user_profile_suggestion_row">
             <span style="font-size:25px;  margin-left:18px;vertical-align:central; ">
                               Suggestion To Admin

                        </span>

        </div>
        
            <asp:DropDownList id="DDLEmailSubject" class="class_txt_area_sub" runat="server">
                <asp:ListItem Text="Events">
                </asp:ListItem>
                <asp:ListItem Text="Complain">
                </asp:ListItem>
                <asp:ListItem Text="Other"></asp:ListItem>
            </asp:DropDownList>
             
        <div class="div_user_profile_suggestion_row">
            <textarea class="class_txt_area_msg" id="writeEmail" runat="server"  placeholder="type your suggestion here...."></textarea>
           
              <asp:Button ID="suggestion_btn" runat="server" Text="Send" CssClass="bt_size btn" OnClick="suggestion_btn_click"  /> 

    </div>
</asp:Content>