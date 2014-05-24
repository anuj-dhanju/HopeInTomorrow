<%@ Page Language="C#" AutoEventWireup="true" CodeFile="NewBlog.aspx.cs" Inherits="Admin_NewBlog" ValidateRequest="false"  MasterPageFile="~/Admin/BlogMaster.master" Title="NewBlog"%>



<asp:Content ContentPlaceHolderID="contentChildBody" ClientIDMode="Static" ID="AdminNewBlog" runat="server" >

    <link href="css/NewBlog.css" rel="stylesheet" />

    <script src="Scripts/jquery-1.10.2.js"></script>
    <script src="Scripts/NewBlog.js" type="text/javascript">  </script>


                
                    <div id="div_blog_container">           <!-- Blog container -->
                    
                            <div id="div_blog_title">
                                <input type="text" placeholder="Add blog title here" id="txtBlogTitle" name="txtBlogTitle" runat="server" /> 
                            </div> 
                            <div id="div_editting_tools"> 
                                <ul id="ul_editting_tools"> 
                                    <li> <a href="#" class="a_editting_tools" id="a_Bold"> B </a> </li>
                                    <li> <a href="#" class="a_editting_tools" id="a_Italic"> I </a> </li>
                                    <li> <a href="#" class="a_editting_tools" id="a_Underline"> U </a> </li>
                                </ul>
                            </div>

                            <div id="div_blog_body" contenteditable ="true">
                                
                            </div> 

                            <asp:HiddenField ClientIDMode="Static" ID="hid_blog_body" runat="server" />

                            <div id="div_button_bar"> 
                            
                                <div id="div_btnCancel">
                                    <asp:Button ID="btnCancel"  Text="CANCEL" runat="server" OnClick="btnCancel_Click" />
                                </div>
                                <div id="div_btnPost">
                                    <asp:Button ID="btnPost" Text="POST" runat="server" OnClientClick="return PostValue();" OnClick="btnPost_Click" />
                                </div> 
                            
                            </div> 
                    
                    </div> 

</asp:Content>