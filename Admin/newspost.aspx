<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/NewsMaster.master" AutoEventWireup="true" CodeFile="newspost.aspx.cs" Inherits="Admin_Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="contentChildBody" Runat="Server" ClientIDMode="Static">
     <link href="css/ViewAllEvents.css" rel="stylesheet" />
    <script src="Scripts/jquery-1.10.2.js" type="text/javascript"></script>
    <script src="Scripts/NewEvent.js"></script>
    

  
                
                
                <div id="div_newevent_container">           <!-- User list container -->
                    
                     <div style="margin-left:40px; float:left;"> 

                         <br/>
                        <br/>
                        <br/>

                         
                       


                        <table style="height: 131px; width: 631px"> 
                            <tr >
                                <th colspan="2" style="text-align:center;font-size:18px;">
                                    Post Latest News
                                </th>

                            </tr>
                            <td colspan="2"></td>
                             <tr>
                                <td style="width: 143px" >
                                    <asp:Label ID="lblnewsheading" runat="server" > News Headline </asp:Label>
                                </td>
                                 <td style="width: 404px">
                                     <asp:TextBox ID="txtnewsheading" runat="server" placeholder="News Headline" style="margin-left: 0px" Width="391px"></asp:TextBox> 
                                 </td>
                            </tr>
                             <tr>
                                <td style="width:143px;">
                                    Upload Image 
                                </td>
                                <td style="width:404px;">
                                    <asp:FileUpload runat="server" ID="news_pic_uploader" />
                                </td>
                            </tr>                                       
                                        
                             
                                                
                            <tr>
                                <td style="width: 143px" >
                                    <asp:Label ID="Label3" runat="server"> Description </asp:Label>
                                </td>
                                 <td style="width: 404px">                                   
                                     <asp:TextBox ID="txtNewsDesc" runat="server" TextMode="MultiLine" Rows="8" Columns="47"></asp:TextBox>
                                 </td>
                            </tr>

                             <tr>
                                <td style="width: 143px" >
                                    
                                </td>
                                 <td style="width: 404px"> 
                                     &emsp; &emsp;   
                                     <asp:Button ID="btnPostnews" runat="server" OnClientClick="return postvalcheck();"  Text="Post News" Height="30px" OnClick="btnPostnews_Click" />  &emsp; &emsp;   &emsp; &emsp;                                  
                                     <input type="reset" value="Reset" style="height: 30px" />
                                  </td>
                            </tr>
                            

                        </table>


                    </div>
             </div> 
</asp:Content>

