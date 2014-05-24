<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Admin/adminHomeHV.master" CodeFile="admin_fund_utilization.aspx.cs" Inherits="Admin_fund_utilization" %>


<asp:Content ContentPlaceHolderID="content_body" ClientIDMode="Static" runat="server">
    <link href="css/AdminFundUtilization.css" rel="stylesheet" />
    <style>
    
    #li_9 
        {
            background-color : rgb(21,112,166); 
            color:#fff;
        }
  </style>
    <div class="container">
        <p class="text">Enter Description for fund Utilization page</p>
        <table  >
            <tr>
                <td>
                  <p class="text"> Write Description How fund will be utilized </p>

                </td>
                <td>
                      <textarea id="upper_desc" cols="70" rows="4" runat="server"></textarea>

                </td>
            </tr>
            <tr>
                <td>
                    <p class="text"><img src="../img/clinic-64.png"   height="25" width="25"/>Description How fund utilized for chop</p>

                </td>
                <td>
                      <textarea id="first_desc" cols="70" rows="4" runat="server"></textarea>
                </td>
            </tr>
            
            <tr>
                <td>
                    <p class="text"><img src="../img/tear-of-calendar-64%20(2).png"   height="25" width="25"/>Description How fund utilized on Events</p>
                </td>
                <td>
                      <textarea id="second_desc" cols="70" rows="4" runat="server"></textarea>
                </td>
            </tr>
            <tr>
                <td>
                   <p class="text"><img src="../img/screenshot-64.png"   height="25" width="25"/>Description How fund utilized for Media</p>

                </td>
                <td>
                     <textarea id="third_desc" cols="70" rows="4" runat="server"></textarea>

                </td>
            </tr>
          
            <tr>
                <td>
                    <p class="text">  <img src="../img/network-64.png"  height="25" width="25"/>Description How fund utilized for Others</p>
                </td>
                <td>
                       <textarea id="fourth_desc" cols="70" rows="4" runat="server"></textarea>

                </td>
            </tr>
            <tr>
                <td>
                    
                </td>
                <td>
                    <asp:Button ID="submit" runat="server" Height="30" Width="70" Text="Submit"  CssClass="btn" OnClick="submit_desc"/>

                </td>
            </tr>
        </table>

    </div>

</asp:Content>