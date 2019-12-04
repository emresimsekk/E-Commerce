<%@ Page Title="" Language="C#" MasterPageFile="~/template/user/master/eticaret.Master" AutoEventWireup="true" CodeBehind="bizeKatil.aspx.cs" Inherits="eticaret.template.user.page.bizeKatil" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="../css/bizeKatil.css" rel="stylesheet" />

   
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <asp:Panel ID="pnlRegister" runat="server" >
    <div class="row top">
 <div class="gosterge"><div class="gostergeImages"><img  src="../icon/page/homePage.png" width="20" height="20" /></div><div class="gostergeText">> &nbsp; Bize Katıl</div></div>
        <br />
        
        <div class="col-2">&nbsp;</div>
        <div class="col-8">
            <div class="registerBaslik">Bize Katıl</div>
            <div class="information">Personel Bilgisi</div><br /><br />
             <div class="adi"><div class="renk">*&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</div><div class="ad">Kullanıcı Adı</div></div><div class="icerik"><asp:TextBox ID="txtKullaniciAdi"  MaxLength="20" placeHolder="Kullanıcı Adı"  CssClass="txt" runat="server" ValidationGroup="vg"></asp:TextBox>&nbsp;&nbsp;
                 <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ErrorMessage="6 ile 18 Arası Karakter Girilmeli. (Tükçe Karakter Girilemez)" ValidationExpression="^[a-zA-Z0-9'@&#.\s]{6,18}$" ControlToValidate="txtKullaniciAdi" CssClass="hata" ></asp:RegularExpressionValidator>
                                                                                                                                    </div>
            <br /><br />
            <div class="adi"><div class="renk">*&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</div><div class="ad">Adı</div></div><div class="icerik"><asp:TextBox ID="txtAdi" CssClass="txt" MaxLength="40"  placeHolder="Adı"  runat="server"></asp:TextBox>&nbsp;&nbsp;
                 <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ErrorMessage="3 ve 40 Karakter Arası Veri Girilebilir" ControlToValidate="txtAdi" ValidationExpression=".{3,40}$"  CssClass="hata"  ></asp:RegularExpressionValidator></div>
            <br /><br />
            <div class="adi"><div class="renk">*&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</div><div class="ad">Soyadı</div></div><div class="icerik"><asp:TextBox ID="txtSoyadi"  placeHolder="Soyadı" MaxLength="40" CssClass="txt" runat="server"></asp:TextBox>
                &nbsp;&nbsp;
                 <asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server" ErrorMessage="3 ve 40 Karakter Arası Veri Girilebilir" ValidationExpression=".{3,40}$"  ControlToValidate="txtSoyadi" CssClass="hata" ></asp:RegularExpressionValidator>
                                                                                                                            </div>

            <br /><br />
            <div class="adi"><div class="renk">*&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</div><div class="ad">E-Mail</div></div><div class="icerik"><asp:TextBox ID="txtEposta"  placeHolder="Mail" MaxLength="100" CssClass="txt" runat="server" TextMode="Email"></asp:TextBox> &nbsp;&nbsp;
                <asp:RegularExpressionValidator ID="revEposta" runat="server" ControlToValidate="txtEposta" ErrorMessage="Mail Adresinizi Kontrol Ediniz" CssClass="hata" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator></div>
            <br /><br />
            <div class="adi"><div class="renk">*&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</div><div class="ad">Telefon</div></div><div class="icerik"><asp:TextBox ID="txtTel"  MaxLength="10"  placeHolder="Telefon (5xxxxxxxxx)"  CssClass="txt" runat="server" TextMode="Phone"></asp:TextBox>
                   &nbsp;&nbsp;
                 <asp:RegularExpressionValidator ID="RegularExpressionValidator4" runat="server" ErrorMessage="10 Haneli Telefon Numarası Girilmeli" ValidationExpression="^[0-9'@&#.\s]{10}$" ControlToValidate="txtTel" CssClass="hata" ></asp:RegularExpressionValidator>
               
                                                                                                                             </div>
            <br /><br /><br />
            <div class="information">Adres Bilgisi</div>
            <br /><br />
            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                <ContentTemplate>
             <div class="adi"><div class="renk">*&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</div><div class="ad">Şehir</div></div><div class="icerik">
                 <asp:DropDownList ID="drpIl" runat="server" CssClass="txt" OnSelectedIndexChanged="drpIl_SelectedIndexChanged" AutoPostBack="True"></asp:DropDownList>
                 &nbsp;&nbsp;</div>
            <br /><br />
            <div class="adi"><div class="renk">*&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</div><div class="ad">İlçe</div></div><div class="icerik"><asp:DropDownList ID="drpIlce" runat="server" CssClass="txt" AutoPostBack="True" OnSelectedIndexChanged="drpIlce_SelectedIndexChanged"></asp:DropDownList>
                &nbsp;&nbsp;</div>
            <br /><br />
            <div class="adi"><div class="renk">*&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</div><div class="ad">Mahalle</div></div><div class="icerik"><asp:DropDownList ID="drpMah" runat="server" CssClass="txt" AutoPostBack="True"></asp:DropDownList>
                           &nbsp;&nbsp;</div>
            <br /><br />
                    
                    </ContentTemplate>
                </asp:UpdatePanel>
        
             <br /><br /><br />
            <div class="information">Şifre Bilgisi</div>
            <br /><br />
            <div class="adi"><div class="renk">*&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</div><div class="ad">Şifre</div></div><div class="icerik"><asp:TextBox ID="txtSifre" MaxLength="20"  placeHolder="Şifre"  CssClass="txt" runat="server" TextMode="Password"></asp:TextBox>&nbsp;&nbsp;
           <asp:RegularExpressionValidator ID="RegularExpressionValidator5" runat="server" ErrorMessage="8 ve 16 Karakter Arası Şifre Girilebilir" ValidationExpression=".{8,16}$"  ControlToValidate="txtSifre" CssClass="hata" ></asp:RegularExpressionValidator>
            </div>
            <br /><br />
            <div class="adi"><div class="renk">*&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</div><div class="ad">Şifre Onay</div></div><div class="icerik"><asp:TextBox ID="txtSifreOnay"  MaxLength="20" placeHolder="Şifre Onay"  CssClass="txt" runat="server" TextMode="Password"></asp:TextBox>
              &nbsp;&nbsp;  <asp:CompareValidator ID="CompareValidator1" runat="server" CssClass="hata" ErrorMessage="Şifreniz Uyuşmuyor" ControlToCompare="txtSifre" ControlToValidate="txtSifreOnay"></asp:CompareValidator>
                                                                                                                                </div>
            <br /><br /><br />
 <div class="adi"><div class="renk">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</div><div class="ad"></div></div><div class="icerik">
           
     <asp:Label ID="lblHata" CssClass="hata" runat="server" Visible="false" ></asp:Label>

                   </div>
            <br /><br /><br /><br />
           <div class="onay"><asp:CheckBox ID="chcOnay" Text="Okudum ve Gizlilik Politikası'nı Kabul Ediyorum." runat="server" /></div><div class="uye"><asp:Button ID="btnUyeOl" CssClass="btnBizeKatil" runat="server" Text="Bize Katıl" OnClick="btnUyeOl_Click" /></div>
        </div>
        <div class="col-2"></div>

    </div>
        </asp:Panel>

    <asp:Panel ID="pnlOnay" runat="server" Visible="false" >

         <div class="row top">
        <br />
             <div class="col-2">&nbsp;</div>
        <div class="col-8 popup">
            <div class="popHeader">
            <div class="popupHeader">Üyelik Bilgi Sistemi</div><div class="close"> <asp:Button ID="btnclose" CssClass="btnClose" runat="server" Text="X" OnClick="btnclose_Click" /></div>
            </div>
           <div class="uyeTamam"> Üyelik İşleminizi Tamamlamak İçin Mail Onayı Yapmanız Gerekmektedir</div>
            <div class="login">
                <asp:Button ID="btnGirisYap" CssClass="btnBizeKatil" runat="server" Text="Giriş Yap" OnClick="btnGirisYap_Click" /></div>
            </div>
             <div class="col-2">&nbsp;</div>
         </div>
        
    </asp:Panel>


</asp:Content>
