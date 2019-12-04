6     <%@ Page Title="" Language="C#" MasterPageFile="~/template/user/master/eticaret.Master" AutoEventWireup="true" CodeBehind="ilanGoruntule.aspx.cs" Inherits="eticaret.template.user.page.ilanGoruntule" %>

<%@ Register Assembly="DevExpress.Web.v16.2, Version=16.2.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web" TagPrefix="dx" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="../css/ilanGoruntule.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

     <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>

        <div class="row top " style="">
      <div class="gosterge"><div class="gostergeImages"><img  src="../icon/page/homePage.png" width="20" height="20" /></div><div class="gostergeText">&nbsp; &nbsp;&nbsp; &nbsp; <asp:Label ID="lblEnUstKategori" runat="server" ></asp:Label></div><div class="gostergeText">&nbsp;&nbsp;&nbsp;> &nbsp; <asp:Label ID="lblUstKategori" runat="server" ></asp:Label></div> <div class="gostergeText">&nbsp;&nbsp;> &nbsp; <asp:Label ID="lblKategori" runat="server" ></asp:Label></div></div>
        <br /><br />

        <div class="col-1  ">&nbsp;</div>
        <div class="col-10 ">
            <div class="col-7 "> 
                <div class="col-3">
                    <div class="12 sliderLeft">
                        <div class="leftImages">
                           
                            <asp:ImageButton ID="resima" width="100" height="110" CssClass="imagesLeft" runat="server" OnClick="resima_Click" />
                            
                        </div>
                    </div>

                    <div class="12 sliderLeft">
                      <div class="leftImages"><asp:ImageButton ID="resimb" width="100" height="110" CssClass="imagesLeft" runat="server" OnClick="resimb_Click" /></div>
                    </div>
                    <div class="12 sliderLeft">
                             <div class="leftImages"><asp:ImageButton ID="resimc" width="100" height="110" CssClass="imagesLeft" runat="server" OnClick="resimc_Click" /></div>
                    </div>
                </div>
                <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                        <ContentTemplate>
                <div class="col-8 sliderBig">
                    
                    <div class="bigImages"><asp:ImageButton ID="resimd" width="70%" height="280" CssClass="imagesLeft" runat="server" /></div>
                    
                    <br /><br />
                    <div class="col-12"><div class="col-4 fav">
                        <asp:Panel ID="pnlcard" runat="server">
                    <a href="ilanGoruntule.aspx?durum=fav"><img src="../icon/page/comparison.png" width="25" height="25" /></a> &nbsp;&nbsp;
                    <a href="#"> <img src="../icon/page/shoppingCart.png" width="25" height="25" /></a>
                            </asp:Panel>
                                        </div></div>

                </div>
                </ContentTemplate>
                        <Triggers>
                            <asp:AsyncPostBackTrigger ControlID="resima" EventName="Click" />
                            <asp:AsyncPostBackTrigger ControlID="resimb" EventName="Click" />
                            <asp:AsyncPostBackTrigger ControlID="resimc" EventName="Click" />
                        </Triggers>
                    </asp:UpdatePanel>
            </div>
            <div class="col-5 ">
                <asp:DataList ID="dtDefaut" runat="server">
                    <ItemTemplate>
                
                  <div class="col-12 headerText"><%#Eval("ilanAdi") %></div>  
                  
                  <div class="col-12 data color ">398 TL </div>
                  <div class="col-12 data"><%#Eval("sehirAdi") %> / <%#Eval("IlceAdi") %> / <%#Eval("mahalleAdi") %></div>
                  <div class="col-4 name ">İlan No </div><div class="col-8 data">: &nbsp;&nbsp;<%#Eval("ilanID") %></div>
                  <div class="col-4 name ">İlan Tarihi </div><div class="col-8 data">:&nbsp;&nbsp;<%#Eval("ilanTarihi") %></div>
                  <div class="col-4 name ">Kimden </div><div class="col-8 data">:&nbsp;&nbsp;<%#Eval("kimden") %></div>
                  <div class="col-4 name ">Durumu </div><div class="col-8 data">:&nbsp;&nbsp;<%#Eval("durumAdi") %></div>
                  
                 
                </ItemTemplate>
                </asp:DataList>

            </div>
             


        </div>
        <div class="col-1 ">&nbsp;</div>
       

      </div>
    <br /><br />
     <div class="row">
         
         <div class="col-2"> &nbsp;</div>
         <div class="col-8">
             
             <div class="space">&nbsp;</div>
             
            <div class="urunBilgi"> <asp:LinkButton ID="urunBilgi" runat="server" OnClick="urunBilgi_Click">Ürün Bilgisi</asp:LinkButton> &nbsp;&nbsp;&nbsp; &nbsp<asp:LinkButton ID="aciklama" runat="server" OnClick="aciklama_Click">Açıklama</asp:LinkButton>&nbsp;&nbsp;&nbsp; &nbsp;<asp:LinkButton ID="saticiBilgi" runat="server" OnClick="saticiBilgi_Click">Satıcı Bilgisi</asp:LinkButton></div>
                 
            <div class="space">&nbsp;</div>
             <br /><br /><br /><br /><br />
             <div class="col-12 ">
                 <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                     <ContentTemplate>
                 <asp:Panel ID="pnlUrunBilgi"  runat="server">
                   
       
                 <div class="col-6">
                
                     <div class="col-9 productRight"><div class="productName">İşletim Sistemi</div><div class="productData">:&nbsp; 13 MP</div></div>
                     <div class="col-9 productRight"><div class="productName">Dahili Hafıza</div><div class="productData">:&nbsp; 35 GB</div></div>
                     <div class="col-9 productRight"><div class="productName">Ekran Boyutu</div><div class="productData">:&nbsp; 4.7 İNC</div></div>
                                   
                 </div>  
                 <div class="col-6">
                     <div class="col-9 productLeft"><div class="productName">Ön Kamera</div><div class="productData">:&nbsp; 5 MP</div></div>
                     <div class="col-9 productLeft"><div class="productName">Renk</div><div class="productData">:&nbsp; Siyah</div></div>
                     <div class="col-9 productLeft"><div class="productName">Garanti</div><div class="productData">:&nbsp; Var</div></div>
             
                        </div>
                            
                     </asp:Panel>

                      <asp:Panel ID="pnlAciklama" runat="server" Visible="false">
                 <div class="col-12">
                     
                     <div class="col-9 aciklama">
                         <asp:DataList ID="dtAciklama" runat="server">
                             <ItemTemplate>
                         <div class="productData">
                            <%#Eval("aciklama") %>

                         </div>
                         </ItemTemplate>
                         </asp:DataList>
                     </div>
                     
                 </div>  
              
                     </asp:Panel>

                                   
                      <asp:Panel ID="pnlSaticiBilgi" runat="server" Visible="false">
                            <asp:DataList ID="dtsatici" Width="100%" runat="server">
                              <ItemTemplate>
                 
                
                                    
                 <div class="col-6">
                     <div  class="col-9 productRight"><div class="productName">Ad Soyad</div><div class="productData">:&nbsp;<%#Eval("adSoyad") %></div></div>
                     <div class="col-9 productRight"><div class="productName">Telefon</div><div class="productData">:&nbsp;<%#Eval("telefon") %></div></div>
            
                 </div>  
                 <div class="col-6">
                     <div class="col-9 productLeft"><div class="productName">Mail</div><div class="productData">:&nbsp<%#Eval("email") %></div></div>
                     <div class="col-9 productLeft"><div class="productName">Şehir</div><div class="productData">:&nbsp; <%#Eval("sehirAdi") %></div></div>
                        </div>
                                  
                
                          </ItemTemplate>
                          </asp:DataList> 
                                
                     </asp:Panel>
                 </ContentTemplate>
                     <Triggers>
                         <asp:AsyncPostBackTrigger ControlID="urunBilgi" EventName="Click" />
                         <asp:AsyncPostBackTrigger ControlID="aciklama" EventName="Click" />
                         <asp:AsyncPostBackTrigger ControlID="saticiBilgi" EventName="Click" />
                     </Triggers>
                 </asp:UpdatePanel>
             </div>

        
         </div>
         <div class="col-2">&nbsp;</div>
     </div>

   

   
</asp:Content>
