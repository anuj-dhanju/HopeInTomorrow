<%@ Page Language="C#" AutoEventWireup="true" CodeFile="AdminInbox.aspx.cs" MasterPageFile="~/Admin/InboxMaster.master"  Inherits="Admin_AdminInbox" %>

<asp:Content ContentPlaceHolderID="contentChildBody" runat="server" ClientIDMode="Static">
     <link href="css/BlogList.css" rel="stylesheet" />

    <script src="Scripts/jquery-1.10.2.js" type="text/javascript"></script>
    <script src="Scripts/Admininbox.js" type="text/javascript"></script>

     <style>
        #a_vertical_menu8
        {
            background-color : rgb(21,112,166); 
            color : rgb(255,255,255);
        }

    </style>
                
                <div id="div_bloglist_container">           <!-- Blog container -->
                    
                      
                        <asp:DataList ID="dlBlog" runat="server" Height="88px" Width="980px" style="margin-left:10px;" >
                        
                            <ItemTemplate>
                        
                                   <div class="div_blog_body" >
                                   
                                       <div class="div_blog_title" >
                                           <div style=" overflow:hidden;height:38px">
                                            <asp:Label ID="lblBlogTitle" runat="server"  CssClass="blog_title" Text='<%#DataBinder.Eval(Container.DataItem,"subject").ToString()%>' ForeColor="#FF6600"> </asp:Label>
                                            <asp:Label ID="Label1" runat="server"   CssClass="blog_title" Text='<%#"     "+DataBinder.Eval(Container.DataItem,"suggestion_msg").ToString()%>'> </asp:Label>
                                        
                                               </div>
                                               
                                           <div class="div_blog_options">
                                                <asp:LinkButton ID="lbtnView" runat="server" OnCommand="lbtnView_Click"  CommandArgument='<%# DataBinder.Eval(Container.DataItem,"suggestion_id") %>' > View</asp:LinkButton> &emsp;
                                                  <asp:LinkButton ID="lbtnDelete" runat="server" OnCommand="lbtnDelete_Click" CommandArgument='<%# DataBinder.Eval(Container.DataItem,"suggestion_id") %>'>Delete</asp:LinkButton>
                                            </div>
                                       </div>
                                      
                                       <div class="div_blog_views">
                                           <div style="color:white; margin-top:20px;">
                                                <asp:label ID="Label2" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"userName").ToString() %>'> </asp:label>
                                           
                                                <asp:label ID="lblBlogPostTime" runat="server"  Text='<%# DateTimeFormatting((DateTime)DataBinder.Eval(Container.DataItem,"date_time")) %>'> </asp:label>
                                           </div>
                                       </div>
                            
                                    </div>
                            
                                
                        
                            </ItemTemplate>
                   
                         </asp:DataList>

                    </div>                   <!-- End of blog list container --> 
</asp:Content>
