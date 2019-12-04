<%@ Page Title="" Language="C#" MasterPageFile="~/template/user/master/eticaret.Master" AutoEventWireup="true" CodeBehind="sendeSat.aspx.cs" Inherits="eticaret.template.user.page.sendeSat" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
       <link href="../css/sendeSat.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <br /><br /><br /><br>
<div class="row">
    <div class="ilan">
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
        <div class="selected">&nbsp;</div>
        <div class="selected"><asp:DropDownList ID="EnustKategori" CssClass="txt" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ustKategori_SelectedIndexChanged"></asp:DropDownList></div>
        <div class="selected"><asp:DropDownList ID="ustKategori" CssClass="txt" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ustKategori_SelectedIndexChanged1"></asp:DropDownList></div>
        <div class="selected"><asp:DropDownList ID="kategori" CssClass="txt" runat="server" AutoPostBack="True" OnSelectedIndexChanged="kategori_SelectedIndexChanged"></asp:DropDownList></div>
        <div class="selected"><asp:DropDownList ID="altKat" CssClass="txt" runat="server" AutoPostBack="True" OnSelectedIndexChanged="altKat_SelectedIndexChanged"></asp:DropDownList></div>
        <div class="selected">&nbsp;</div>
                <br /><br />    <br /><br />
                <asp:Panel ID="pnlBolge" Visible="false" runat="server">
                    <div class="selected">&nbsp;</div>

                      <div class="selected"> <asp:DropDownList ID="drpSehir"  runat="server"  CssClass="txt" AutoPostBack="True" OnSelectedIndexChanged="drpSehir_SelectedIndexChanged"></asp:DropDownList></div>
                    
                       <div class="selected"> <asp:DropDownList ID="drpIlce" runat="server"  CssClass="txt" AutoPostBack="True" OnSelectedIndexChanged="drpIlce_SelectedIndexChanged"></asp:DropDownList></div>
                   
                        <div class="selected"><asp:DropDownList ID="drpSemt" runat="server"  CssClass="txt" AutoPostBack="True" OnSelectedIndexChanged="drpSemt_SelectedIndexChanged"></asp:DropDownList></div>
                    <div class="selected">&nbsp;</div>
                      <div class="selected">&nbsp;</div>

                </asp:Panel>
                <br /><br />    <br /><br />
                 <asp:Panel runat="server" Visible="false" ID="pnlselected">
                       <div class="selected">&nbsp;</div>
                     <div class="selected"> <asp:RadioButtonList ID="RadioButtonList1" runat="server" AutoPostBack="True" OnSelectedIndexChanged="RadioButtonList1_SelectedIndexChanged">
                         <asp:ListItem Value="2">Alıcı İlanı</asp:ListItem>
                         <asp:ListItem Value="1" Selected="True">Satıcı İlanı</asp:ListItem>
                     </asp:RadioButtonList></div>

                    <div class="selected"> <asp:DropDownList ID="drKimden" runat="server"  CssClass="txt" OnSelectedIndexChanged="drKimden_SelectedIndexChanged" AutoPostBack="True"></asp:DropDownList></div>
                 
                     
                     <div class="selected"><asp:DropDownList ID="drDurum" runat="server"  CssClass="txt" AutoPostBack="True" OnSelectedIndexChanged="drDurum_SelectedIndexChanged"></asp:DropDownList></div>
                      <div class="selected">&nbsp;</div> <div class="selected">&nbsp;</div>
            
            </asp:Panel>
                <br /><br />    <br /><br />
                <asp:Panel ID="pnlIlan" Visible="false" runat="server">


                 <div class="selected">&nbsp;</div>
                      İLAN BAŞLIĞI :  <asp:TextBox ID="txtIlanBasligi" runat="server"></asp:TextBox><br /><br />
                       <div class="selected">&nbsp;</div>
                   İLAN FİYATI :&nbsp;&nbsp;&nbsp;&nbsp; <asp:TextBox ID="IlanFiyat" runat="server"></asp:TextBox></div><br /><br />
                    <div class="selected">&nbsp;</div>
                      AÇIKLAMA :&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; <asp:TextBox ID="txtAciklama" runat="server" TextMode="MultiLine"></asp:TextBox><br /><br />
                    <div class="selected">&nbsp;</div>
                     <div class="selected">   <asp:Button CssClass="btn" ID="btnIlanEkle" runat="server" Text="İlan Ekle" OnClick="btnIlanEkle_Click" />
                         <br /><br /><asp:Label ID="lblHata" runat="server" Text=""></asp:Label>
                     </div>
                        <div class="selected">&nbsp;</div>

                </asp:Panel>
                 <br /><br />    <br /><br />
                <asp:Panel ID="pnlImages" Visible="false" runat="server">
                      <div class="selected">&nbsp;</div>  
                 

                     <div class="selected"> <asp:FileUpload ID="flImages1" runat="server" /></div>
                     <div class="selected">  <asp:FileUpload ID="flImages2" runat="server" /></div>
                      <div class="selected"> <asp:FileUpload ID="flImages3" runat="server" /></div>
                     <div class="selected"> <asp:Button ID="btnResimEkle" CssClass="btn" runat="server" Text="Resim Ekle" OnClick="btnResimEkle_Click" /></div>
                       <div class="selected">&nbsp;</div>

                </asp:Panel>
                </ContentTemplate>
           
         </asp:UpdatePanel>
       
    </div>

</div>
</asp:Content>
