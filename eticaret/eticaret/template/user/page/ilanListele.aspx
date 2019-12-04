<%@ Page Title="" Language="C#" MasterPageFile="~/template/user/master/eticaret.Master" AutoEventWireup="true" CodeBehind="ilanListele.aspx.cs" Inherits="eticaret.template.user.page.ilanListele" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
        <link href="../css/altKategori.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
     <div class="row">
        <div class="col-12 top">
              <div class="col-1">&nbsp;</div>
               <div class="col-2">
                   <br /><br />
                 <div class="col-12 ">
                        <div class="menuHeader"><p>Tüm Kategoriler</p> </div>
                 </div>
                   <div class="boyut">
                             <asp:Repeater ID="rptAltKategori" runat="server" >

                                <ItemTemplate>
                                         <div class="col-12 ">
                                            <div class="subMenu"> 
                                                <p> <%# Eval("altKategoriAdi") %></p>
                                            </div>
                                         </div>
                                 </ItemTemplate>
                             </asp:Repeater>   
                       </div>
              </div>

              <div class="col-8">



                                     
            <div class="col-1">&nbsp;</div>
                        <div class="col-11 ilanPanel">
                            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                               <ContentTemplate>    
                                
                          <div class="col-12 linkHeader">
                              <asp:LinkButton ID="lbtnSatici" CssClass="btnIlan" runat="server" OnClick="lbtnSatici_Click" ForeColor="White">Satıcı İlanları</asp:LinkButton>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                              <asp:LinkButton ID="lbtnAlici" CssClass="btnIlan" runat="server" OnClick="lbtnAlici_Click" ForeColor="White">Alıcı İlanları</asp:LinkButton>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp
                              <asp:LinkButton ID="lbtnEnYakin" CssClass="btnIlan" runat="server" Visible="false" OnClick="lbtnEnYakin_Click" ForeColor="White">Bana En Yakın İlanlar</asp:LinkButton>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                              <asp:LinkButton ID="lbtnYakin" CssClass="btnIlan" runat="server" Visible="false" OnClick="lbtnYakin_Click" ForeColor="White">Bana Yakın İlanlar</asp:LinkButton>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                              
                          </div>
                            <br /><br /><br />
                            <asp:Panel ID="pnlSatici" runat="server">
                          <div class="col-12 ilanList">
                            <div class="col-12 ilanListHeader ">
                                <div class="ilanResmi">&nbsp;</div>
                                <div class="ilanKategori">Kategori</div>
                                <div class="ilanBaslik">İlan Başlığı</div>
                                <div class="fiyat">
                                    <asp:LinkButton ID="lbFiyat" CssClass="a" runat="server" OnClick="lbFiyat_Click">Fiyat	&uml;</asp:LinkButton></div>
                                <div class="ilanTarihi">   <asp:LinkButton ID="lbIlanTarih" CssClass="a" runat="server" OnClick="lbIlanTarih_Click" >İlan Tarihi	&uml;</asp:LinkButton></div>
                                <div class="ilIlce">İl/İlçe</div>
                                <br /><br /><br />
                                <asp:Repeater ID="rptIlan" runat="server">
                                <ItemTemplate>
                                <div class="IilanResmi"><img src="../icon/ilan/<%# Eval("ilanResim1") %>" width="70%" height="66" /></div>
                                <div class="IilanKategori"><p> <%#Eval("altKategoriID").ToString()=="" ?Eval("KategoriAdi"):Eval("altKategoriAdi") %></p></div>
                                <div class="IilanBaslik"><p><a href="ilanGoruntule.aspx?ilanID=<%# Eval("ilanID") %>"> <%# Eval("ilanAdi") %></a></p></div>
                                <div class="Ifiyat"><p><%# Eval("ilanFiyat") %>&nbsp;TL</p></div>
                                <div class="IilanTarihi"><p><%# Eval("ilanTarihi") %></p></div>
                                <div class="IilIlce"><p><%# Eval("SehirAdi") %><br /><%# Eval("IlceAdi") %></p></div>
                                <br />
                                </ItemTemplate>
                                </asp:Repeater>
                                <br /><br /><br /><br /><br /><br /><br /><br /><br /><br /><br /><br /><br /><br /><br /><br /><br /><br /><br /><br /><br /><br /><br /><br /><br /><br /><br /><br /><br /><br /><br /><br /><br /><br /><br />
                                <asp:Panel ID="pnlSayfa"  runat="server">

                              </asp:Panel>
                               
                            
                                

                                 
                            </div>
                         </div>
                                </asp:Panel>
                        
                           </ContentTemplate>
                                <Triggers>
                                    <asp:AsyncPostBackTrigger ControlID="lbtnAlici" EventName="Click" />
                                    <asp:AsyncPostBackTrigger ControlID="lbtnSatici" EventName="Click" />
                                    <asp:AsyncPostBackTrigger ControlID="lbtnEnYakin" EventName="Click" />
                                    <asp:AsyncPostBackTrigger ControlID="lbtnYakin" EventName="Click" />
                                </Triggers>
                            </asp:UpdatePanel>

                      </div>
         


              </div>

              <div class="col-1">&nbsp;</div>
         </div>

    </div>
</asp:Content>
