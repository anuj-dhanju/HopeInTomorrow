<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/ProfileMasterPage.master" CodeFile="UserProfileEdit.aspx.cs" Inherits="UserProfileEdit" %>

<asp:Content runat="server" ClientIDMode="Static"  ContentPlaceHolderID="ContentPlaceHolder1">

    <link href="css/UserProfileEdit.css" rel="stylesheet" />
    <div class="div_user_profile_edit_container">
        <div class="div_user_profile_edit_row">
            <span style="font-size:25px;  margin-left:18px;vertical-align:central; ">
                Edit Profile
            </span>
                <asp:Button ID="Button2" runat="server" OnClick="UpdateData_Click"   style="float:right;" Text="Update" CssClass="bt_size btn" />
        </div>
        <div class="div_user_profile_edit_row">
              <span class="user_profile_edit_label">
               First Name
             </span>
             <div class="div_text_box">
                <input  id="tbUserFirstName" class="text_box" runat="server" placeholder=""/>
             </div>

        </div>
         <div class="div_user_profile_edit_row">
             <span class="user_profile_edit_label">
               Last Name

            </span>
             <div class="div_text_box">
                <input id="tbUserLastName"  runat="server" class="text_box" placeholder=""/>
             </div>

        </div>
         <div class="div_user_profile_edit_row">
             <span class="user_profile_edit_label">
                Password
            </span>
             <div class="div_text_box">
                  <span class="user_profile_edit_label_password">
                      old
                </span>
               <input  class="password_text_box" id="tbUserPassword"   runat="server"  type="password"  />
                 <span class="user_profile_edit_label_password">
                      New
                </span>
                 
                
                  <input  class="password_text_box"  id="tbNewPassword"   runat="server" type="password"  />
             </div>
        </div>
        <div class="div_user_profile_edit_row">
             <span class="user_profile_edit_label">
                Country

            </span>
            <div class="div_text_box">
                <input  id="tbUserCountry" runat="server" class="text_box" placeholder=""/>
             </div>

        </div>
        <div class="div_user_profile_edit_row">
             <span class="user_profile_edit_label">
                City

            </span>
            <div class="div_text_box">
                <input  id="tbUserCity" runat="server" class="text_box" placeholder=""/>
             </div>

        </div>
        <div class="div_user_profile_edit_row">
             <span class="user_profile_edit_label">
                Profile Picture

            </span>

           <!-- <div class="div_text_box">
                <input  id="pic" runat="server" class="text_box" placeholder="
               "/>
             </div>-->
            <!--<div  style="float:right; margin-top:-5px" class="bt_size btn">-->
            <div class="div_text_box">
            <asp:FileUpload ID="PicUpload" runat="server" style="float:left; margin-top:-5px; "  class="text_box"  />
           </div>
           
               
               
            <!--</div>-->


        </div>
   
    <asp:Label ID="StatusLabel"  runat="server"  style="float:left; margin-left:20px; color:#cf5151"></asp:Label>
         </div>
</asp:Content>