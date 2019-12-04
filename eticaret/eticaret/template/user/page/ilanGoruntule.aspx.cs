using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace eticaret.template.user.page
{
  
    public partial class ilanGoruntule : System.Web.UI.Page
    {

        connect conn =new connect();
        //bağlantı clasımızı çekiyoruz
        int ilanID;
        //integer dğer oluşturuyoruz
        string resim1 = "~/template/user/icon/ilan/";
        //string tipinde değişken tanımlıyoruz
        string resim2 = "~/template/user/icon/ilan/";
        //string tipinde değişken tanımlıyoruz
        string resim3 = "~/template/user/icon/ilan/";
        //string tipinde değişken tanımlıyoruz
        protected void Page_Load(object sender, EventArgs e)
        {
            

            if (int.TryParse(Request.QueryString["ilanID"], out ilanID)) 
                //gelen değer string ise
            {
                DataRow dtMax = conn.GetDataRow("select max(i.ilanID) as ilanID from ilan i");
                //veritabanında ilanların max değerini alıyoruz
                DataRow dtMin = conn.GetDataRow("select min(i.ilanID) as ilanID from ilan i");
                //veritabanında ilanların in değerini alıyoruz
                if (ilanID <= Convert.ToInt32(dtMax["ilanID"]))
                    //gelendeğerden küçük
                {
                    if (ilanID >= Convert.ToInt32(dtMin["ilanID"]))
                        //gelen değerden büyük ise
                    {
                        DataTable dtDefault = conn.GetDataTable("select i.ilanID,i.ilanAdi,i.ilanFiyat,i.ilanTarihi,i.aciklama, d.durumAdi,k.kimden,s.SehirAdi,ilce.IlceAdi,sm.MahalleAdi  from ilan i inner join durum d on i.durumID=d.durumID inner join kimden k on i.kimdenID=k.kimdenID  inner join sehirler s on i.sehirID=s.SehirId inner join iIlceler ilce on i.ilceID=ilce.ilceId inner join semtMah sm on i.semtMahID=sm.SemtMahId where i.ilanID=" + ilanID);
                        //ilan ID sine göre ilanı çekiyoruz
                        dtDefaut.DataSource = dtDefault;
                        //datalistin datasourcesine bağlıyoruz
                        dtDefaut.DataBind();
                        //ekrana basıyoruz

                        DataRow drResim = conn.GetDataRow("select ir.ResimID,ir.ilanID,ir.ilanResim1,ir.ilanResim2,ir.ilanResim3 from ilanResmi ir where ir.ilanID=" + ilanID);
                        //ilanIDsine göre resimleri çekiyoruz
                        resim1 = resim1 + drResim["ilanResim1"].ToString();
                        //resimleri değişkene atıyoruz
                        resim2 = resim2 + drResim["ilanResim2"].ToString();
                        //resimleri değişkene atıyoruz
                        resim3 = resim3 + drResim["ilanResim3"].ToString();
                        //resimleri değişkene atıyoruz

                        dtAciklama.DataSource = dtDefault;
                        //datalistin datasourcesine bağlıyoruz
                        dtAciklama.DataBind();
                        //ekrana basıyoruz

                        DataTable dtSaticiBilgi = conn.GetDataTable("select i.ilanID, i.kullaniciID,k.ad+' '+soyad as adSoyad,k.email,k.telefon,s.SehirAdi from ilan i inner join kullanici k on i.kullaniciID=k.kullaniciID inner join sehirler s on i.sehirID=s.SehirId where i.ilanID=" + ilanID);
                        //datatableye satıcının bilgilerini çekiyoruz
                        dtsatici.DataSource = dtSaticiBilgi;
                        //datalistin datasourcesine bağlıyoruz
                        dtsatici.DataBind();
                        //ekrana basıyoruz

                        DataRow drGosterge = conn.GetDataRow("select i.ilanID,k.KategoriAdi,uk.UstKategoriAdi,euk.EnUstKategoriAdi from ilan i inner join Kategori k on i.kategoriID=k.KategoriID inner join UstKategori uk on k.UstKategoriID=uk.UstKategoriID inner join EnUstKategori euk on uk.EnUstKategoriID=euk.EnUstKategoriID where i.ilanID=" + ilanID);
                        //kategori altkategori ustkategori bilgilerini çekiyoruz
                        lblEnUstKategori.Text = drGosterge["EnUstKategoriAdi"].ToString();
                        //textboxa yazdırıyoruz
                        lblUstKategori.Text = drGosterge["UstKategoriAdi"].ToString();
                        //textboxa yazdırıyoruz
                        lblKategori.Text = drGosterge["KategoriAdi"].ToString();
                        //textboxa yazdırıyoruz

                    }
                    else
                    {
                           Response.Redirect("eror.aspx");
                        //hata yönledirmesi yapıyoruz
                    }

                }
                else
                {
                    Response.Redirect("eror.aspx");
                    //hata yönledirmesi yapıyoruz
                }


            }
            else
            {
                Response.Redirect("eror.aspx");
                //hata yönledirmesi yapıyoruz
            }



            if (Session["kullaniciID"]==null)
                //kullanıcıyı varmı diye kontrol ediyoruz
            {
                pnlcard.Visible = false;
                //pnlkartı gizliyoruz yok ise
            }
            else
            {
                pnlcard.Visible = true;
                //gösteriyoruz bursa
            }
                
            if (IsPostBack==false)
            {

                resima.ImageUrl = resim1;
                //resimleri basıyoruz ekrana
                resimb.ImageUrl = resim2;
                //resimleri basıyoruz ekrana
                resimc.ImageUrl = resim3;
                //resimleri basıyoruz ekrana
                resimd.ImageUrl = resim1;
                //resimleri basıyoruz ekrana
            }

        }

        protected void resima_Click(object sender, ImageClickEventArgs e)
        {


            resimd.ImageUrl = resim1;
            //resimleri basıyoruz ekrana


        }

        protected void resimb_Click(object sender, ImageClickEventArgs e)
        {
            resimd.ImageUrl = resim2;
            //resimleri basıyoruz ekrana
        }

        protected void resimc_Click(object sender, ImageClickEventArgs e)
        {
            resimd.ImageUrl = resim3;
            //resimleri basıyoruz ekrana
        }

        protected void urunBilgi_Click(object sender, EventArgs e)
        {

            pnlUrunBilgi.Visible = true;
            pnlAciklama.Visible = false;
            pnlSaticiBilgi.Visible = false;
        }

        protected void aciklama_Click(object sender, EventArgs e)
        {

            pnlUrunBilgi.Visible = false;
            pnlAciklama.Visible = true;
            pnlSaticiBilgi.Visible = false;
        }

        protected void saticiBilgi_Click(object sender, EventArgs e)
        {


            pnlUrunBilgi.Visible = false;
            pnlAciklama.Visible = false;
            pnlSaticiBilgi.Visible = true;
        }
    }
}