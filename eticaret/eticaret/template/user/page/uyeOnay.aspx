<%@ Page Title="" Language="C#" MasterPageFile="~/template/user/master/eticaret.Master" AutoEventWireup="true" CodeBehind="uyeOnay.aspx.cs" Inherits="eticaret.template.user.page.uyeOnay" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="../css/uyeOnay.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    
         <div class="row top">
        <br />
             <div class="col-2">&nbsp;</div>
        <div class="col-8 popup">
            <div class="popHeader">
            <div class="popupHeader">Üyelik Onay Sistemi</div><div class="close"></div>
            </div>
           <div class="uyeTamam"> <asp:Label ID="lblDurum" runat="server" ></asp:Label></div>
            <div class="login">
                <asp:Button ID="btnGirisYap" CssClass="btnBizeKatil" runat="server" Text="Giriş Yap" OnClick="btnGirisYap_Click" /></div>
            </div>
             <div class="col-2">&nbsp;</div>
         </div>
    
    

</asp:Content>
