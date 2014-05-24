<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Blog.aspx.cs" Inherits="HopeInTomorrow_Blog" MasterPageFile="~/UserMasterPage.master" Title="Blog"%>

<asp:Content ContentPlaceHolderID="ContentPlaceHolder1" ID="BlogBody" runat="server">
<script src="js/redirect.js" type="text/javascript"></script>
    <script src="js/redirect.js" type="text/javascript"></script>
    <link href="css/BlogListView.css" rel="stylesheet" type="text/css"/>
    <div id="lower_middle_main">
    	<div id="lower_middle_cont">
            <div id="div_main_contianer">            <!-- The main container--> 
           
            <div id="div_middle" class="div_middle"> 
                              <!-- The Middle Body --> 
                 
                <asp:DataList ID="dlBlog" runat="server" OnItemDataBound="dlBlog_ItemDataBound" CssClass="datalistblog">
                    <ItemTemplate>
                        <div class="blog_cont">
                            <div class="div_v_spacer">

                        </div>
                        <div class="div_img_cont" runat="server" >
                            <asp:Image ID="img_pp"  CssClass="img_pp" runat="server" />
                        </div>
                        <div class="div_v_spacer">

                        </div>
                            
                          
                        <div id="div_blog_container" class="div_blog_container">           <!-- Blog container -->

                                <div id="div_blog_title" runat="server" contenteditable ="false" class="div_blog_title">
                                    <%# DataBinder.Eval(Container.DataItem,"blog_title").ToString() %>
                                </div> 

                                <div id="div_blog_date_time" runat="server" contenteditable ="false" class="div_blog_date_time">
                                    <%# GetLongDateFormat((DateTime)DataBinder.Eval(Container.DataItem,"date_time_of_post")) %>
                                </div> 

                                <div id="div_blog_body" contenteditable ="false" runat="server" class="div_blog_body">
                                    <%# Server.HtmlDecode(DataBinder.Eval(Container.DataItem,"blog_content").ToString()) %>
                                </div>   
                            
                            <div id="div_blog_options" runat="server" class="div_blog_options">
                                <asp:Label runat="server" id="lblPosterNameText" CssClass="lblPosterNameText" Text="Posted By " ></asp:Label>
                                <asp:Label runat="server" ID="lblPosterName" CssClass="lblPosterName" Text='<%# GetPosterName(Convert.ToInt32(DataBinder.Eval(Container.DataItem,"poster_id")),Convert.ToInt16(DataBinder.Eval(Container.DataItem,"is_admin"))) %>' > </asp:Label>
                                <asp:Label runat="server" id="lblCommentCountText" CssClass="lblCommentCountText" Text="Comments" ></asp:Label>
                                <asp:Label runat="server" ID="lblCommentCount" CssClass="lblCommentCount" Text='<%# GetCommentCount(Convert.ToInt32(DataBinder.Eval(Container.DataItem,"blog_id"))) %>' > </asp:Label>
                                <asp:Label runat="server" id="lblViewCountText" CssClass="lblViewCountText" Text="Views" ></asp:Label>
                                <asp:Label runat="server" ID="lblViewCount" CssClass="lblViewCount" Text='<%# GetViewCount(Convert.ToInt32(DataBinder.Eval(Container.DataItem,"blog_id"))) %>' ></asp:Label>
                                
                                <asp:LinkButton ID="lnkbtnReadMore" runat="server" CssClass="lnkbtn_blog_readmore"  OnCommand="lnkbtnReadMore_Command" CommandArgument='<%# DataBinder.Eval(Container.DataItem,"blog_id") %>' > Read More</asp:LinkButton>
                            </div>
                        </div>
                                </div>
                        </div> 

                        

                    </ItemTemplate>

                 </asp:DataList> 
                
            </div>                               <!-- End OF The Middle Body --> 

            
        </div>                                  <!-- End Of The main container-->

        </div>
    </div>
</asp:Content>