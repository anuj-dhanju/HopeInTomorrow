<%@ Page Language="C#" AutoEventWireup="true" CodeFile="BlogWriter.aspx.cs" ValidateRequest="false"  Inherits="HopeInTomorrow_BlogWriter" MasterPageFile="~/UserMasterPage.master" Title="Blog Writer" %>


<asp:Content ContentPlaceHolderID="ContentPlaceHolder1" ClientIDMode="Static" ID="userBlogWriter" runat="server" >
<script src="js/redirect.js" type="text/javascript"></script>

    <link href="css/BlogWriter.css" rel="stylesheet" type="text/css" />
    <link href="css/MessageBox.css" rel="stylesheet" type="text/css" />

    <script src="js/BlogWriter.js" type="text/javascript" ></script>



   <div id="div_message" >                                   <!-- Message box -->
        <div id="div_message_body">
            <div id="div_message_text" runat="server">
               
            </div>
             <div id="div_message_button"  >
                    <input type="button" value="OK" id="btnMessageOkButton" style="width:100px" />
             </div>
        </div>

    </div>


         <div id="div_main_contianer">            <!-- The main container--> 
           
            <div id="div_middle">               <!-- The Middle Body --> 
                
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

                            <div id="div_blog_body" contenteditable ="true" runat="server">
                                
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
                    
                    </div>                      <!-- End Of Blog container -->

                </div>                         <!-- End of middle -->
             </div>     <!-- End of main container -->

</asp:Content>