<%@ Page Title="Donate" Language="C#" MasterPageFile="~/UserMasterPage.master" AutoEventWireup="true" CodeFile="donate.aspx.cs" Inherits="donate" %>

<asp:Content ID="Content1" runat="server" contentplaceholderid="ContentPlaceHolder1">  

<script src="js/redirect.js" type="text/javascript"></script>
    <script>

        $(function () {

            $("body").css("background-image", "url('img/s3.jpg')");
            $("body").css("background-attachment", "fixed");
            $("body").css("background-repeat", "no-repeat");
            $("body").css("background-repeat", "no-repeat");
            $("#header_main").css("background", "rgba(255,255,255,0.9)");
            

        });
    </script>
    <div id="lower_middle_main">
    	    <div id="lower_middle_cont">
                 <div id="slide">
         <div id="slide_inner">
          <div id="slide_inner1">
                  <div id="slide_content" align="justify">
                  <span style="color:#262466; font-size:40px;">Donate for children</span>
                 Hope today, Invest In Tomorrow 
                    <a href="donate_form.aspx" class="btn_donate_join" style="margin-top:10px;" > Donate now </a>
 
            </div>
         </div>
        
        
        <div id="buttons">
           <div id="button_outer">
             <div class="buttons_inner">
                  
                  <div class="btn_image">
                      <div class="icon_image_inner" >
                       <img style="border-radius:50px" class="donate_radius" src="img/Infinity-Loop@2x.png" />
                       </div>
                     
                   </div>
                          <div class="buttons_content">
                            <center> 
                               DONATE NOW
                                <br />
                                  <h5>
                                        Make a tax-deductible donation help find a cure for pediatric cancer
                                  </h5>
                                <br />
                            </center>
                           </div>
                                    
                                       <div class="buttons_btn">
                                           <center>
                                               <a href="donate_form.aspx" class="button white" > Donate now </a>
                                           </center>
                           </div>
                   </div>
              
               <div class="buttons_inner">
                    <div class="btn_image">
                        <div class="icon_image_inner">
                       <img src="img/img2.ico"  />
                       </div>
                    </div>
                     <div class="buttons_content">
                         <center>
                             Funds Utilization
                             <br />
                                 <h5>
                                      Click here to see how your donation will be utilized
                                  </h5>
                             <br />
                         </center>
                    </div>
       
                        <div class="buttons_btn">
                            <center>
                                    <a href="fundUtilization.aspx" class="button white" > Funds Utilization </a>
                            </center>
                       </div>
                </div>
       
       
       
        <div class="buttons_inner">
                    <div class="btn_image">
                         <div class="icon_image_inner">
                       <img src="img/img3.png"  />
                       </div>
                    </div>
                          <div class="buttons_content">
                             <center>
                                  OTHER HELP
                                <br />
                              <h5>
                                 Learn how you can help today 
                              </h5>
                                 <br /><br /> 
                            </center>
                          </div>
       
                        <div class="buttons_btn">
                            <center>
                                   <a href="join_us.aspx" class="button white" > Other Help </a>
                            </center>
                       </div>
                </div>
          </div>
        
        <div id="team">
        </div>
   </div>     
         </div>
    </div>


            </div>
    </div>
</asp:Content>