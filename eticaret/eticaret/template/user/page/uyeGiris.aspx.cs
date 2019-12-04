using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Security;

namespace eticaret.template.user.page
{
    public partial class uyeGiris : System.Web.UI.Page
    {

            connect conn = new connect();
            //Bğlantı clasımızı sayfamıza dahil ettik
            string kullaniciAdi;
            //string tipinde değişken oluşturduk.
            string kullaniciSifre;
            //string tipinde değişken oluşturduk.
            protected void Page_Load(object sender, EventArgs e)
            {
                if (Request.Cookies["cerezim"] != null)
                    //Çerezimizin dolu olup olmadığını kontrol ediyoruz
                {
                    HttpCookie yakalananCerez = Request.Cookies["cerezim"];
                    //Çerez oluşturuyoruz
                    Session["kullaniciID"] = yakalananCerez.Values["kullaniciID"];
                    //KullanıcıID'mizi çereze atıyoruz
                }
                if (Session["kullaniciID"]!=null)
                    //KullanıcıID dolu olup olmadığını kontrol ediyoruz
                {
                    Response.Redirect("default.aspx");
                    //Yönlendirme işlemi yapıyoruz
                }
          

            }

        protected void btnGirisYap_Click(object sender, EventArgs e)
        {
            kullaniciAdi = txtKullanici.Text;
            // Textboxtan gelen değeri değişkene aktarıyoruz
            kullaniciSifre = txtSifre.Text;
            // Textboxtan gelen değeri değişkene aktarıyoruz

            DataRow drGiris = conn.GetDataRow("select k.kullaniciID, k.kullaniciAdi,s.sifre  from kullanici k inner join grup g on g.grupID=k.grupID inner join sifre s  on k.kullaniciID=s.kullaniciID where k.kullaniciAdi='"+kullaniciAdi+"' and s.sifre='"+kullaniciSifre+"'and g.grupID=4 and k.engel=1 and onay=1");
            //DataRow ile sorgumuzu oluşturup kullanıcı var mı yokmu diye tek satır değer döndürüyoruz.
            if (drGiris!=null)
            //DataRow dolu olup olmadığını kontrol ediyoruz
            {
                Session["kullaniciID"] = drGiris["kullaniciID"].ToString();
                //Oturum oluşturuyoruz
                if (chcBeniHatırla.Checked)
                 //Beni hatırla checkboxna tıklandı ise
                {
                    HttpCookie cerez = new HttpCookie("cerezim");
                    //Çerez oluşturuyoruz
                    cerez.Values.Add("kullaniciID",Session["kullaniciID"].ToString());
                    //Çerez kullanıcıID ekliyoruz
          
                    cerez.Expires = DateTime.Now.AddDays(10);
                    //Çerezin süresini belirliyoruz

                    Response.Cookies.Add(cerez);
                    //vede ekliyoruz
                }
                Response.Redirect("default.aspx");
                //Yönlendirme Yapıyoryz
            }
            else
            {
                lblHata.Visible = true;
                //Hata alırsak ise labelimizi görünür yapıp
                lblHata.Text = "Kullanıcı Adı veya Şifreni Yalnış";
                //Yazı yazdırıyoruz
            }
        }

        protected void btnBizeKatil_Click(object sender, EventArgs e)
        {
            Response.Redirect("bizeKatil.aspx");
            //Diğer buton ile yönlendrme yapıyoruz
        }
    }
}