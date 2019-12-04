using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace eticaret.template.user.page
{
    public partial class sendeSat : System.Web.UI.Page
    {
        connect conn = new connect();
        protected void Page_Load(object sender, EventArgs e)
        {

            if (Session["kullaniciID"] == null)
                //kullanıcı giriş yaptımı diye kontrol ediyoruz
            {

                Response.Redirect("eror.aspx");
                //hata sayfasına yöneldiriyoruz
            }
            else
            {

                if (Page.IsPostBack == false)
                {

                    enust();
                    //enust voidmizi çağırıyoruz
                    EnustKategori.Items.Insert(0, new ListItem("Seçiniz", "0"));
                    //dropdownlist ilk indisin seçiniz yazıyoruz
                    drpIlce.Items.Insert(0, new ListItem("Seçiniz", "0"));
                    //dropdownlist ilk indisin seçiniz yazıyoruz
                    drpSemt.Items.Insert(0, new ListItem("Seçiniz", "0"));
                    ustKategori.Visible = false;
                    kategori.Visible = false;
                    altKat.Visible = false;
                    pnlselected.Visible = false;
                    drDurum.Visible = false;

                }
             


            }

        }

        protected void enust()
        {

            DataTable mah = conn.GetDataTable("select * from enUstKategori");
            EnustKategori.DataSource = mah;

            EnustKategori.DataTextField = "EnUstKategoriAdi";
            EnustKategori.DataValueField = "EnUstKategoriID";
            EnustKategori.DataBind();

        }
        protected void kate()
        {

            DataTable kategoridrp = conn.GetDataTable("select * from UstKategori  where EnUstKategoriID='" + EnustKategori.SelectedValue+"'");
            ustKategori.DataSource = kategoridrp;

            ustKategori.DataTextField = "UstkategoriAdi";
            ustKategori.DataValueField = "UstkategoriID";
            ustKategori.DataBind();
        }
        protected void kategor()
        {

            DataTable kate = conn.GetDataTable("select * from kategori where UstKategoriID='" + ustKategori.SelectedValue + "'");
            kategori.DataSource = kate;

            kategori.DataTextField = "kategoriAdi";
            kategori.DataValueField = "kategoriID";
            kategori.DataBind();
        }
        protected void altKategori()
        {

            DataTable altKate = conn.GetDataTable("select * from altKategori where KategoriID='" + kategori.SelectedValue + "'");
            altKat.DataSource = altKate;
            altKat.DataTextField = "AltKategoriAdi";
            altKat.DataValueField = "AltKategoriID";
            altKat.DataBind();
        }
        protected void kimdenn()
        {

            DataTable kimden = conn.GetDataTable("select * from kimden");
            drKimden.DataSource = kimden;
            drKimden.DataTextField = "kimden";
            drKimden.DataValueField = "kimdenID";
            drKimden.DataBind();
        }
        protected void durum()
        {

            DataTable durum = conn.GetDataTable("select * from durum");
            drDurum.DataSource = durum;
            drDurum.DataTextField = "durumAdi";
            drDurum.DataValueField = "durumID";
            drDurum.DataBind();
        }



        protected void ustKategori_SelectedIndexChanged(object sender, EventArgs e)
        {
            kate();
            ustKategori.Visible = true;
            ustKategori.Items.Insert(0, new ListItem("Seçiniz", "0"));

        }

        protected void ustKategori_SelectedIndexChanged1(object sender, EventArgs e)
        {
            kategor();
            ustKategori.Visible = true;
            kategori.Visible = true;
            kategori.Items.Insert(0, new ListItem("Seçiniz", "0"));

        }

        protected void kategori_SelectedIndexChanged(object sender, EventArgs e)
        {
            altKategori();
            ustKategori.Visible = true;
            kategori.Visible = true;
            altKat.Visible = true;
          
            altKat.Items.Insert(0, new ListItem("Seçiniz", "0"));
            
        }

        protected void altKat_SelectedIndexChanged(object sender, EventArgs e)
        {
           
            pnlBolge.Visible = true;
           
            kimdenn();
            drKimden.Items.Insert(0, new ListItem("Seçiniz", "0"));
            sehir();
            drpSehir.Items.Insert(0, new ListItem("Seçiniz", "0"));


        }

        protected void drKimden_SelectedIndexChanged(object sender, EventArgs e)
        {
            
            drDurum.Visible = true;
            
            durum();
            drDurum.Items.Insert(0, new ListItem("Seçiniz", "0"));
        }

        protected void RadioButtonList1_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }



        protected void drpIlce_SelectedIndexChanged(object sender, EventArgs e)
        {
            semt();
            drpSemt.Items.Insert(0, new ListItem("Seçiniz", "0"));
        }

        protected void drpSemt_SelectedIndexChanged(object sender, EventArgs e)
        {
            pnlselected.Visible = true;
        }

       
        protected void drpSehir_SelectedIndexChanged(object sender, EventArgs e)
        {
            Ilce();
            drpIlce.Items.Insert(0, new ListItem("Seçiniz", "0"));

        }
        protected void sehir()
        {

            DataTable seh = conn.GetDataTable("select * from sehirler order by SehirAdi");
            drpSehir.DataSource = seh;
            drpSehir.DataTextField = "SehirAdi";
            drpSehir.DataValueField = "SehirID";
            drpSehir.DataBind();
        }
        protected void Ilce()
        {

            DataTable ılce = conn.GetDataTable("select * from iIlceler where SehirId='"+drpSehir.SelectedValue+"'");
            drpIlce.DataSource = ılce;
            drpIlce.DataTextField = "IlceAdi";
            drpIlce.DataValueField = "IlceID";
            drpIlce.DataBind();
        }
        protected void semt()
        {

            DataTable semtMah = conn.GetDataTable("select * from semtMah where ilceId='" + drpIlce.SelectedValue + "' order by MahalleAdi");
            drpSemt.DataSource = semtMah;
            drpSemt.DataTextField = "MahalleAdi";
            drpSemt.DataValueField = "semtMahID";
            drpSemt.DataBind();
        }

        protected void drDurum_SelectedIndexChanged(object sender, EventArgs e)
        {
            pnlIlan.Visible = true;
        }

        protected void btnResimEkle_Click(object sender, EventArgs e)
        {

            Response.Redirect("default.aspx");

                      
            
                      
            
        }

        protected void btnIlanEkle_Click(object sender, EventArgs e)
        {

            if (txtIlanBasligi.Text!="")
                //boş olup olmadığını kontrol ediyoruz
            {
                if (txtAciklama.Text != "")
                //boş olup olmadığını kontrol ediyoruz
                {
                    if (IlanFiyat.Text!="")
                    //boş olup olmadığını kontrol ediyoruz
                    {
                        SqlConnection baglanti = conn.baglan();
                        //sql bağlantı kuruyoruz
                        SqlCommand cmd = new SqlCommand("insert into ilan (kullaniciID,kategoriID,altKategoriID,ilanTipiID,durumID,kimdenID,ilanAdi,ilanFiyat,ilanTarihi,aciklama,sehirID,ilceID,semtMahID) values (@kullaniciID,@kategoriID,@altKategoriID,@ilanTipiID,@durumID,@kimdenID,@ilanAdi,@ilanFiyat,@ilanTarihi,@aciklama,@sehirID,@ilceID,@semtMahID)", baglanti);
                        //insert cümlemizi kuruyoruz


                        cmd.Parameters.Add("@kullaniciID", Session["kullaniciID"]);
                        cmd.Parameters.Add("@kategoriID", kategori.SelectedValue);
                        cmd.Parameters.Add("@altKategoriID", altKat.SelectedValue);
                        cmd.Parameters.Add("@ilanTipiID", RadioButtonList1.SelectedValue);
                        cmd.Parameters.Add("@durumID", drDurum.SelectedValue);
                        cmd.Parameters.Add("@kimdenID", drKimden.SelectedValue);
                        cmd.Parameters.Add("@ilanAdi", txtIlanBasligi.Text);
                        cmd.Parameters.Add("@ilanFiyat", IlanFiyat.Text);
                        cmd.Parameters.Add("@ilanTarihi", DateTime.Now.ToShortDateString());
                        cmd.Parameters.Add("@aciklama", txtAciklama.Text);
                        cmd.Parameters.Add("@sehirID", drpSehir.SelectedValue);
                        cmd.Parameters.Add("@ilceID", drpIlce.SelectedValue);
                        cmd.Parameters.Add("@semtMahID", drpSemt.SelectedValue);
                        cmd.ExecuteNonQuery();
                        //parametreler belirleyiz ekliyoruz
                        pnlImages.Visible = true;
                    }
                    else
                    {
                        lblHata.Text = "Lütfen Boş Alanları Doldurunuz.";
                    }

                }
                else
                {
                    lblHata.Text = "Lütfen Boş Alanları Doldurunuz.";
                }
            }
            else
            {
                lblHata.Text = "Lütfen Boş Alanları Doldurunuz.";
            }


        }
    }

}