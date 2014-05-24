<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/EventMaster.master" AutoEventWireup="true" CodeFile="ViewAllSubscribers.aspx.cs" Inherits="ViewAllSubscribers" %>

<asp:Content ID="Content1" ContentPlaceHolderID="contentChildBody" Runat="Server">
    <link href="css/ViewAllEvents.css" rel="stylesheet" />
    <script src="Scripts/jquery-1.10.2.js" type="text/javascript"></script>
    <script src="Scripts/NewEvent.js"></script>
    <script>
        $(document).ready(function () {

            $("#a_menu_subcribes").css("color", "rgb(255,255,255)");
            $("#li_5").css("background", "rgb(21,112,166)");

        });
    </script>

    <%--<div>
    
        <div id="div_main_contianer">            <!-- The main container--> 
           
            
            <div id="div_middle">                <!-- The Middle Body --> 
                
                       --%>
    <%--<div id="div_event_list_container">           <!-- Event List container -->--%>
                    
                
                
                
                <div id="div_event_list_container" style="float:left;margin-top:17px;margin-left:90px; ">           <!-- User list container -->
                    <asp:ScriptManager ID="userview" runat="server"></asp:ScriptManager>
                    <asp:UpdatePanel ID="aluserview" runat="server"><ContentTemplate>
                      
                        <asp:GridView ID="GridView1" runat="server" AllowPaging="True" PageSize="6" Height="393px" CellPadding="4" CssClass="auto-style1"  Width="766px" ForeColor="#333333" GridLines="None"  OnRowDataBound="GridView1_RowDataBound" OnPageIndexChanging="GridView1_PageIndexChanging" CellSpacing="2" ShowHeaderWhenEmpty="True">
                          <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                          <EditRowStyle BackColor="#999999" />
               <FooterStyle BackColor="#5D7B9D" ForeColor="White" Font-Bold="True" />
                <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
                <RowStyle ForeColor="#333333" BackColor="#F7F6F3" />
                <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                <SortedAscendingCellStyle BackColor="#E9E7E2" />
                <SortedAscendingHeaderStyle BackColor="#506C8C" />
                <SortedDescendingCellStyle BackColor="#FFFDF8" />
                <SortedDescendingHeaderStyle BackColor="#6F8DAE" />
                            <pagersettings mode="NumericFirstLast" position="Bottom"   pagebuttoncount="3"  />
                           <pagerstyle backcolor="RoyalBlue" height="25px"     verticalalign="Bottom"   horizontalalign="Center"/>
            </asp:GridView>

                     </ContentTemplate></asp:UpdatePanel>
                    


                    </div>                   <!-- End of user list container --> 
                


                
                


                                          <!-- End OF The Middle Body --> 
            

    
   
 </asp:Content>


