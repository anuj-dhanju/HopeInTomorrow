<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ViewPost.aspx.cs" Inherits="HopeInTomorrow_ViewPost" MasterPageFile="~/UserMasterPage.master"  %>

<asp:Content ContentPlaceHolderID="ContentPlaceHolder1" ID="BlogViewPost" runat="server" ClientIDMode="Static" >
<script src="js/redirect.js" type="text/javascript"></script>
    
    <link href="css/BlogPostView.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript" >

        function CheckStat()
        {
            if (document.GetElementById("textcomment").value.trim() == "")
            {
                alert("Please do not leave any blank comments");
            }
        }



    </script> 

     <div id="div_main_contianer">            <!-- The main container--> 
           
            <div id="div_middle">               <!-- The Middle Body --> 
                
                
                <div id="div_blog_container">           <!-- Blog container -->
                    
                        <div id="div_blog_title" runat="server" contenteditable ="false">
                          
                        </div> 

                        <div id="div_blog_date_time" runat="server" contenteditable ="false">

                        </div> 

                        <div id="div_blog_body" contenteditable ="false" runat="server">

                        </div> 
                        

                        <div id="div_blog_info_bar"> 
                           <div id="div_poster_name_time" runat="server">
                                Posted by <span id="spn_posterName" runat="server"> </span> at <span id="spn_timeOfPost" runat="server"></span>
                            </div>
 
                        </div> 
                    
                    
                    
                <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>

                <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                   
                     <ContentTemplate>
                         

                         <div id="div_spacer" style="height:20px"> </div>
                                <div id="div_comment_main" >                <!-- Comments main div -->

                                <label id="lbl_postcomments_text" > Post Comments </label>
                                <br/> 
                                <textarea rows="5" cols="70" id="txtcomment" runat="server" required="required" maxlength="1000" ></textarea>
                    
                                <div id="div_button_bar">
                                    <asp:Button ID="btnPostComment" runat="server" Text="Post" OnClick="btnPostComment_Click" OnClientClick="return CheckStat();" />
                                </div>



                                    <asp:DataList ID="dlBlogComments"  OnItemDataBound="dlBlogComments_ItemDataBound" runat="server" CssClass="datalistblog">
                                        <ItemTemplate>

                                            <div id="div_blog_comment_container" class="div_blog_comment_container">           <!-- Blog container -->

                                                <div id="div_blog_commenter_info" runat="server" class="div_blog_commenter_info">

                                                    <div id="div_commenter_pic" runat="server" class="div_commenter_pic">
                                                        <asp:Image ID="img_commenter_pic" runat="server" class="img_commenter_pic"/> 
                                                    </div>

                                                    <div id="div_commenter_name_date" runat="server" class="div_commenter_name_date">
                                                        <asp:Label runat="server" ID="lblCommenterName" CssClass="lblCommenterName" Text='<%# commenter_name(Convert.ToInt32(DataBinder.Eval(Container.DataItem,"poster_id")),Convert.ToInt32(DataBinder.Eval(Container.DataItem,"is_admin"))) %>' > </asp:Label>
                                                        <br/>
                                                        <asp:Label runat="server" ID="lblCommentDate" CssClass ="lblCommentDate" Text='<%# Convert.ToDateTime(DataBinder.Eval(Container.DataItem,"date_time_of_comment")).ToShortDateString() %>' > </asp:Label>
                                                     </div>
                                                    

                                                </div>

                                                <div id="div_blog_comment_body" runat="server" class="div_blog_comment_body">
                                                    <div id="div_blog_comment_text" runat="server" class="div_blog_comment_text">
                                                        <%# LnToBr(DataBinder.Eval(Container.DataItem,"comment").ToString()) %>
                                                    </div>
                                                    
                                                </div>

                                                <div id="div_blog_comment_options" runat="server" class="div_blog_comment_options" >
                                                        
                                                    </div>
                                            </div> 

                        

                                        </ItemTemplate>

                                 </asp:DataList> 


                          </div>                                     <!-- END OF Comments main Div --> 


                         
               


                    </ContentTemplate>

                </asp:UpdatePanel>
               

               
                    



                </div>             <!-- END OF BLOG CONTAINER -->
                
                




            </div>                               <!-- End OF The Middle Body --> 

            
        </div>                                  <!-- End Of The main container-->

</asp:Content>