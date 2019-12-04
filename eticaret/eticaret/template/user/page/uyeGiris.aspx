<%@ Page Title="" Language="C#" MasterPageFile="~/template/user/master/eticaret.Master" AutoEventWireup="true" CodeBehind="uyeGiris.aspx.cs" Inherits="eticaret.template.user.page.uyeGiris" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="../css/uyeGiris.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="row top">
       <div class="gosterge"><div class="gostergeImages"><img  src="../icon/page/homePage.png" width="20" height="20" /></div><div class="gostergeText">> &nbsp; Giriş Yap</div></div>
        <br />
        <div class="col-12 ">

            <div class="col-2" >&nbsp;</div>
            <div class="col-4">

          <div class="register">
                   <div class="registerHeader"> Bize Katıl</div>
                    <div class="text">
                        <p>Bir hesap oluşturarak daha hızlı alışveriş yapabilirsiniz, bir siparişin durumuyla ilgili güncel bilgiler edinebilir ve daha önce yaptığınız siparişleri görebilirsiniz.</p>
                    </div>
                 
                   
                
                   
                      <div class="girisYap">
                          <asp:Button ID="btnBizeKatil" CssClass="btnBizeKatil" runat="server" Text="Bize Katıl" OnClick="btnBizeKatil_Click"  /></div>
                </div>


            </div>
            <div class="col-4">
                <div class="login">
                   <div class="loginHeader"> Giriş Yap</div>
                    <div class="kullaniciAdi">Kullanıcı Adınız</div>
                    <div class="kullanici"> <asp:TextBox ID="txtKullanici" CssClass="txtKullanici" MaxLength="50"   runat="server"></asp:TextBox>
   
                    </div>
                    <div class="bos"></div>
                    <div class="sifreAd">Şifreniz</div>
                      <div class="sifre"> <asp:TextBox ID="txtSifre" MaxLength="20"  CssClass="txtSifre" runat="server" TextMode="Password"></asp:TextBox></div>
                                 <div class="hata"><asp:Label ID="lblHata" CssClass="lblHata" runat="server" visible="false"></asp:Label></div>
                    <br />
                      <div class="kayit"> 
                           <div class="beniHatirla col-6"> <asp:CheckBox ID="chcBeniHatırla"  CssClass="beniHatırla" Text="Beni Hatırla" runat="server" /></div>
                           <div class="sifreUnuttum col-6"><a href="#"> Şifremi Unuttum</a></div>
                      </div>
                      <div class="girisYap">
                          <asp:Button ID="btnGirisYap" CssClass="btnGirisYap" runat="server" Text="Giriş Yap" OnClick="btnGirisYap_Click" /></div>
                </div>


            </div>
             <div class="col-2">&nbsp;</div>
        </div>
    </div>
</asp:Content>
