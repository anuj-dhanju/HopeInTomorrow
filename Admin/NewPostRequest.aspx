<%@ Page Language="C#" AutoEventWireup="true" CodeFile="NewPostRequest.aspx.cs" Inherits="Admin_NewPostRequest" MasterPageFile="~/Admin/BlogMaster.master" Title="New Posts"%>

<asp:Content ContentPlaceHolderID="contentChildBody" ID="newpostrequest" runat="server">


     <link href="css/BlogList.css" rel="stylesheet" />

    <script src="Scripts/jquery-1.10.2.js" type="text/javascript"></script>
    <script src="Scripts/NewPostList.js" type="text/javascript"></script>

                
                <div id="div_bloglist_container">           <!-- Blog container -->
                    
                      
                        <asp:DataList ID="dlBlog" runat="server" Height="88px" Width="980px" style="margin-left:10px;" >
                        
                            <ItemTemplate>
                        
                                   <div class="div_blog_body">
                                   
                                       <div class="div_blog_title">
                                            <asp:Label ID="lblBlogTitle" runat="server"  CssClass="blog_title" Text='<%# ChangeStringFormat(DataBinder.Eval(Container.DataItem,"blog_title").ToString()) %>'> </asp:Label>
                                            <br/>
                                            <div class="div_blog_options">
                                                <asp:LinkButton ID="lbtnView" runat="server" OnCommand="lbtnView_Command"  CommandArgument='<%# DataBinder.Eval(Container.DataItem,"blog_id") %>' > View</asp:LinkButton> &emsp;
                                             
                                                <asp:LinkButton ID="lbtnDelete" runat="server" OnCommand="lbtnDelete_Command" CommandArgument='<%# DataBinder.Eval(Container.DataItem,"blog_id") %>'>Delete</asp:LinkButton>
                                            </div>
                                       </div>

                                       <div class="div_blog_views">
                                           <div class="div_blog_post_time">
                                           
                                                <asp:label ID="lblBlogPostTime" runat="server" CssClass="lblBlogDateTime" Text='<%# DateTimeFormatting((DateTime)DataBinder.Eval(Container.DataItem,"date_time_of_post")) %>'> </asp:label>
                                           </div>
                                       </div>
                            
                                    </div>
                            
                                
                        
                            </ItemTemplate>
                   
                         </asp:DataList>

                    </div>                   <!-- End of blog list container --> 


</asp:Content>
 