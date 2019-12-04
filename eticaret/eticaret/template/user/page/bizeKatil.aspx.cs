using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace eticaret.template.user.page
{
    public partial class bizeKatil : System.Web.UI.Page
    {
        connect conn = new connect();
        //Bağlantı dosyamızı sayfaya dahil ediyoruz
        string sehirID;
        //String tipinde değişken oluşturuyoruz.


        protected void Page_Load(object sender, EventArgs e)
        {
            if (Page.IsPostBack==false)
            
            {
               
                sehir();
                //Şehir voidimizi çağırıyoruz
                drpIl.Items.Insert(0, new ListItem("Seçiniz", "0"));
                //dropDownList  değer giriyoruz
                drpIlce.Items.Insert(0, new ListItem("Önce İl Seçiniz", "0"));
                //dropDownList  değer giriyoruz
                drpMah.Items.Insert(0, new ListItem("Önce İlçe Seçiniz", "0"));
                //dropDownList  değer giriyoruz

            }


        }

        protected void  sehir()
        {

            DataTable sehir = conn.GetDataTable("select s.SehirAdi,s.SehirId from sehirler s order by s.SehirAdi");
            //DataTable şehirler tablomuzu çekiyoruz
            drpIl.DataSource = sehir;
            //DataSource ile bağlıyoruz
            drpIl.DataTextField = "SehirAdi";
            //Textine Sehir Adı
            drpIl.DataValueField = "SehirId";
            //Valuesine SehirID yazdırıyoruz
            drpIl.DataBind();
            //Ve dropdown listimize yazdırıyoruz
        }

        protected void ilce()
        {

            DataTable ilce = conn.GetDataTable("select i.ilceId,i.SehirId,i.IlceAdi  from iIlceler i where i.SehirId='" + drpIl.SelectedItem.Value+"'");
            //DataTable ilçeler tablomuzu çekiyoruz
            drpIlce.DataSource = ilce;
            //DataSource ile bağlıyoruz
            drpIlce.DataTextField = "IlceAdi";
            //Textine Sehir Adı
            drpIlce.DataValueField = "ilceId";
            //Valuesine SehirID yazdırıyoruz
            drpIlce.DataBind();
            //Ve dropdown listimize yazdırıyoruz
        }
        protected void mah()
        {

            DataTable mah = conn.GetDataTable("select  sm.SemtMahId,sm.MahalleAdi from semtMah sm where ilceId='"+drpIlce.SelectedItem.Value+"'");
            //DataTable ilçeler tablomuzu çekiyoruz
            drpMah.DataSource = mah;
            //DataSource ile bağlıyoruz
            drpMah.DataTextField = "MahalleAdi";
            //Textine Sehir Adı
            drpMah.DataValueField = "SemtMahId";
            //Valuesine SehirID yazdırıyoruz
            drpMah.DataBind();
            //Ve dropdown listimize yazdırıyoruz
        }


        protected void drpIl_SelectedIndexChanged(object sender, EventArgs e)
        {
            ilce();
            //ilce voidimizi çağırıyoruz
            drpIlce.Items.Insert(0, new ListItem("Seçiniz", "0"));
            //dropDownList box değer giriyoruz

        }

        protected void drpIlce_SelectedIndexChanged(object sender, EventArgs e)
        {
            mah();
            //mah voidimizi çağırıyoruz
            drpMah.Items.Insert(0, new ListItem("Seçiniz", "0"));
            //dropDownList box değer giriyoruz
        }

        protected void btnUyeOl_Click(object sender, EventArgs e)
        {
            DataRow drKullaniciAdi = conn.GetDataRow("select k.kullaniciAdi from kullanici k where k.kullaniciAdi='"+txtKullaniciAdi.Text+"'");
            //Kullanıcı adının cvalrığını kontrol ediyoruz

            if (drKullaniciAdi==null)
            {
                DataRow drEmail = conn.GetDataRow("select k.email from kullanici k where k.email='" + txtEposta.Text + "'");
                //Email varmı diye kontrol ediyoruuz
                if (drEmail == null)
                {
                    if (drpIl.SelectedValue!="0")
                     //dropdownlistler boşmu diye kontrol ediyoruz
                    {
                        if (drpIlce.SelectedValue!="0")
                        //dropdownlistler boşmu diye kontrol ediyoruz
                        {
                            if (drpMah.SelectedValue!="0")
                            //dropdownlistler boşmu diye kontrol ediyoruz
                            {
                                DataRow drTel = conn.GetDataRow("select k.telefon from kullanici k where k.telefon='" + txtTel.Text + "'");
                                //Telefonun varlığını kontrol ediyoruz

                                if (drTel == null)
                                {
                                    if (chcOnay.Checked==true)
                                    {

                                        int randomNumber; int sayi;
                                        //random sayı oluşturduk
                                        Random rastgeleSayi = new Random();
                                        sayi = rastgeleSayi.Next();
                                        //Değişkene aktardık

                                        DataRow drPostaKodu = conn.GetDataRow("select sm.PostaKodu from semtMah sm where sm.SemtMahId='" + drpMah.SelectedItem.Value + "'");
                                        //Seçili olan mahallenin posta kodunu aldık


                                        SqlConnection baglanti = conn.baglan();
                                        //sql bağlantımızı oluşturduk
                                        SqlCommand cmd = new SqlCommand("insert into  kullanici (grupID,kullaniciAdi,ad,soyad,email,telefon,il,ilce,mah,postaKodu,uyelikTarihi,rastgeleNumara,onay,engel) values (@grupID,@kullaniciAdi,@ad,@soyad,@email,@telefon,@il,@ilce,@mah,@postaKodu,@UyelikTarihi,@rastgeleNumara,@onay,@engel)", baglanti);
                                        //insert cümlemizi kurduk


                                        cmd.Parameters.Add("@grupID", "4");
                                        cmd.Parameters.Add("@kullaniciAdi", txtKullaniciAdi.Text);
                                        cmd.Parameters.Add("@ad", txtAdi.Text);
                                        cmd.Parameters.Add("@soyad", txtSoyadi.Text);
                                        cmd.Parameters.Add("@email", txtEposta.Text);
                                        cmd.Parameters.Add("@telefon", txtTel.Text);
                                        cmd.Parameters.Add("@il", drpIl.SelectedItem.Value);
                                        cmd.Parameters.Add("@ilce", drpIlce.SelectedItem.Value);
                                        cmd.Parameters.Add("@mah", drpMah.SelectedItem.Value);
                                        cmd.Parameters.Add("@postaKodu", drPostaKodu["PostaKodu"]);
                                        cmd.Parameters.Add("@UyelikTarihi", DateTime.Now.ToShortDateString());
                                        cmd.Parameters.Add("@rastgeleNumara", sayi);
                                        cmd.Parameters.Add("@onay", "0");
                                        cmd.Parameters.Add("@engel", "1");
                                        //parametrelerimi ekledik
                                        if (cmd.ExecuteNonQuery() == 0)
                                         //eğer değer üye oldu ise
                                        {
                                            lblHata.Visible = true;
                                            //labelımızı gösteriyoruz
                                            lblHata.Text = "Üyelik Başarısız.";
                                            //text yazdırıyoruz
                                        }
                                        else
                                        {
                                            DataRow drSifreSor = conn.GetDataRow("select k.kullaniciID from kullanici k where k.email='"+ txtEposta.Text + "' and k.kullaniciAdi='"+ txtKullaniciAdi.Text + "' and k.rastgeleNumara='"+ sayi+"'");
                                            //gelen eposta kullanıcı adı ve  sayıyı sorguluyoruz
                                            if (drSifreSor["kullaniciID"]!=null)
                                            {
                                                SqlCommand sifreCmd = new SqlCommand("insert into sifre (kullaniciID,sifre) values (@kullaniciID,@sifre)", baglanti);
                                                //şifremizi inset ediyoruz
                                                sifreCmd.Parameters.Add("@kullaniciID", drSifreSor["kullaniciID"]);
                                                sifreCmd.Parameters.Add("@sifre", txtSifre.Text);
                                                //parametreleri giriyoruz
                                                if (sifreCmd.ExecuteNonQuery() == 0)
                                                 //eğer boş satır döner ise
                                                {
                                                    lblHata.Visible = true;
                                                    //labelımızı gösteriyoruz
                                                    lblHata.Text = "Üyelik Başarısız.";
                                                    //text yazdırıyoruz

                                                }
                                                else
                                                {
                                                    MailMessage msg = new MailMessage();
                                                    msg.IsBodyHtml = true;
                                                    msg.To.Add(txtEposta.Text);
                                                    msg.From = new MailAddress("emresimsek801@gmail.com", "Emre Şimşek", System.Text.Encoding.UTF8);
                                                    msg.Subject = "Sende Sat Kullanıcı Onay Maili";
                                                    msg.Body = "<a href='http://localhost:62271/template/user/page/uyeOnay.aspx?x=" + sayi + "&eposta=" + txtEposta.Text + "'> Üyeliğinizi Tamamlamak İçin Tıklayınız </a>";
                                                    SmtpClient smp = new SmtpClient();
                                                    smp.Credentials = new NetworkCredential("emresimsek801@gmail.com", "123456789emre");
                                                    smp.Port = 587;
                                                    smp.Host = "smtp.gmail.com";
                                                    smp.EnableSsl = true;
                                                    smp.Send(msg);
                                                    pnlRegister.Visible = false;
                                                    pnlOnay.Visible = true;
                                                    //mail fonksiyonlarımızı yazdık
                                                }


                                            }
                                            else
                                            {
                                                lblHata.Visible = true;
                                                //labelımızı gösteriyoruz
                                                lblHata.Text = "Üyelik Başarısız.";
                                                //text yazdırıyoruz
                                            }



                                        }

                                        baglanti.Close();//sql bağlantısını kapatıyoruz
                                        baglanti.Dispose();

                                    }
                                    else
                                    {
                                        lblHata.Visible = true;
                                        //labelımızı gösteriyoruz
                                        lblHata.Text = "Lütfen Sözleşmeyi Onaylayın";
                                        //text yazdırıyoruz
                                    }

                                }
                                else
                                {
                                    lblHata.Visible = true;
                                    //labelımızı gösteriyoruz
                                    lblHata.Text = "Böyle Bir Telefon Numarası Sistemimizde Mevcuttur";
                                    //text yazdırıyoruz
                                }




                            }
                            else
                            {
                                lblHata.Visible = true;
                                //labelımızı gösteriyoruz
                                lblHata.Text = "Lütfen Yaşadığınız Mahalleyi Seçiniz";
                                //text yazdırıyoruz
                            }
                        }
                        else
                        {
                            lblHata.Visible = true;
                            //labelımızı gösteriyoruz
                            lblHata.Text = "Lütfen Yaşadığınız İlçeyi Seçiniz";
                            //text yazdırıyoruz
                        }
                    }
                    else
                    {
                        lblHata.Visible = true;
                        //labelımızı gösteriyoruz
                        lblHata.Text = "Lütfen Yaşadığınız Şehiri Seçiniz";
                        //text yazdırıyoruz
                    }
                }
                else
                {
                    lblHata.Visible = true;
                    //labelımızı gösteriyoruz
                    lblHata.Text = "Daha Önce Kullanılmış Mail Adresi.";
                    //text yazdırıyoruz
                }
            }
            else
            {
                lblHata.Visible = true;
                //labelımızı gösteriyoruz
                lblHata.Text = "Daha Önce Kullanılmış Kullanıcı Adı.";
                //text yazdırıyoruz
            }







        }

        protected void btnclose_Click(object sender, EventArgs e)
        {
            pnlOnay.Visible = false;
            //paneli gösteriyoruz
            Response.Redirect("default.aspx");
            //yönlendirme yapıyoruz
        }

        protected void btnGirisYap_Click(object sender, EventArgs e)
        {
            Response.Redirect("uyeGiris.aspx");
            //yönlendirme yapıyoruz 
        }
    }
}