using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace eticaret.template.user.page
{
    public partial class kategori : System.Web.UI.Page
    {
        connect conn = new connect();
        //Bğlantı classımızı sayfaya dahil ediyoruz
        
        int UstKatID;
        //integer tipinde değişken oluşturuyoruz
        int durum;
        //integer tipinde değişken oluşturuyoruz

        protected void Page_Load(object sender, EventArgs e)
        {
            
            if (int.TryParse(Request.QueryString["UstKatID"], out UstKatID))
                //gelen değer string ise
            {
                DataRow drMin = conn.GetDataRow("select min(uk.UstKategoriID) as UstKategoriID from UstKategori uk ");
                // veritabanından ustkategori tablosunun min değerini alıyoruz
                DataRow drMax = conn.GetDataRow("select max(uk.UstKategoriID) as UstKategoriID from UstKategori uk");
                // veritabanından ustkategori tablosunun max değerini alıyoruz




                if (UstKatID >= Convert.ToInt32(drMin["UstKategoriID"]))
                    //min değerden büyük ise
                {
                    if (UstKatID <= Convert.ToInt32(drMax["UstKategoriID"]))
                    //max değerden küçük ise
                    {
                        DataTable dtKategori = conn.GetDataTable("select k.KategoriID,k.UstKategoriID,k.KategoriAdi from kategori k where k.UstKategoriID="+ UstKatID);
                        //ustkategoriID sine göre  kategori çekiyoruz
                            rptKategori.DataSource = dtKategori;
                        //datasourceye bağlıyoruz
                            rptKategori.DataBind();
                        //repeater yazdırıyoruz





                        if (int.TryParse(Request.QueryString["durum"], out durum))
                            //gelen değer string ise
                        {
                            if (durum == 0)
                            {
                                DataTable dtSaticiIlan = conn.GetDataTable("select i.ilanID,euk.EnUstKategoriID,euk.EnUstKategoriAdi,uk.UstKategoriID,uk.UstKategoriAdi,k.KategoriID,ak.AltKategoriID,ak.AltKategoriAdi,k.KategoriAdi,i.ilanAdi, i.ilanFiyat,i.ilanTarihi,s.SehirId,s.SehirAdi,ilce.ilceId,IlceAdi,sm.SemtMahId,sm.MahalleAdi,ir.ilanResim1,i.goruntulenme	from ilan i inner join ilanResmi ir on ir.ilanID=i.ilanID full outer join altKategori ak on ak.AltKategoriID=i.AltKategoriID inner  join Kategori k on k.KategoriID=i.kategoriID inner join UstKategori uk on uk.UstKategoriID=k.UstKategoriID inner join EnUstKategori euk on euk.EnUstKategoriID=uk.EnUstKategoriID inner  join  semtMah sm on sm.SemtMahId=i.semtMahID inner  join  iIlceler ilce on ilce.ilceId=sm.ilceId inner join sehirler s on s.SehirId=ilce.SehirId where i.ilanTipiID=1   and uk.UstKategoriID=" + UstKatID + "order by i.goruntulenme desc");
                                //satıcı ilanı çekip datatable atıyoruz


                                PagedDataSource pds = new PagedDataSource();
                                pds.DataSource = dtSaticiIlan.DefaultView;
                                pds.AllowPaging = true;
                                pds.PageSize = 8;
                                int sayfa;

                                if (Request.QueryString["sayfa"] != null)
                                {
                                    sayfa = Convert.ToInt32(Request.QueryString["sayfa"]);
                                }
                                else
                                {
                                    sayfa = 1;
                                }
                                pds.CurrentPageIndex = sayfa - 1;

                                for (int i = 1; i <= pds.PageCount; i++)
                                {
                                    HyperLink hyper = new HyperLink();
                                    hyper.ForeColor = System.Drawing.ColorTranslator.FromHtml("white");
                                    hyper.Style.Add("text-decoration", "none");
                                    hyper.Style.Add("background-color", "#62bfc4");
                                    hyper.Style.Add("padding-top", "5px");
                                    hyper.Style.Add("padding-bottom", "5px");
                                    hyper.Style.Add("padding-left", "10px");
                                    hyper.Style.Add("padding-right", "10px");
                                    hyper.Text = i.ToString() + "&nbsp;";
                                    hyper.NavigateUrl = "kategori.aspx?UstKatID=" + UstKatID + "&sayfa=" + i.ToString();
                                    pnlSayfa.Controls.Add(hyper);
                                }

                                rptIlan.DataSource = pds;
                                rptIlan.DataBind();
                                //sayfalama işlemlerini yapıyoruz

                            }

                            else if (durum == 1)
                            {
                                DataTable dtAliciIlan = conn.GetDataTable("select i.ilanID,euk.EnUstKategoriID,euk.EnUstKategoriAdi,uk.UstKategoriID,uk.UstKategoriAdi,k.KategoriID,ak.AltKategoriID,ak.AltKategoriAdi,k.KategoriAdi,i.ilanAdi, i.ilanFiyat,i.ilanTarihi,s.SehirId,s.SehirAdi,ilce.ilceId,IlceAdi,sm.SemtMahId,sm.MahalleAdi,ir.ilanResim1,i.goruntulenme	from ilan i inner join ilanResmi ir on ir.ilanID=i.ilanID full outer join altKategori ak on ak.AltKategoriID=i.AltKategoriID inner  join Kategori k on k.KategoriID=i.kategoriID inner join UstKategori uk on uk.UstKategoriID=k.UstKategoriID inner join EnUstKategori euk on euk.EnUstKategoriID=uk.EnUstKategoriID inner  join  semtMah sm on sm.SemtMahId=i.semtMahID inner  join  iIlceler ilce on ilce.ilceId=sm.ilceId inner join sehirler s on s.SehirId=ilce.SehirId where i.ilanTipiID=2   and uk.UstKategoriID=" + UstKatID + "  order by i.goruntulenme desc");
                                //alıcı ilanlarını parametreye göre çekiyoruz 

                                PagedDataSource pdsAlici = new PagedDataSource();
                                pdsAlici.DataSource = dtAliciIlan.DefaultView;
                                pdsAlici.AllowPaging = true;
                                pdsAlici.PageSize = 8;
                                int sayfaAlici;

                                if (Request.QueryString["sayfa"] != null)
                                {
                                    sayfaAlici = Convert.ToInt32(Request.QueryString["sayfa"]);
                                }
                                else
                                {
                                    sayfaAlici = 1;
                                }
                                pdsAlici.CurrentPageIndex = sayfaAlici - 1;

                                for (int i = 1; i <= pdsAlici.PageCount; i++)
                                {
                                    HyperLink hyper = new HyperLink();
                                    hyper.ForeColor = System.Drawing.ColorTranslator.FromHtml("white");
                                    hyper.Style.Add("text-decoration", "none");
                                    hyper.Style.Add("background-color", "#62bfc4");
                                    hyper.Style.Add("padding-top", "5px");
                                    hyper.Style.Add("padding-bottom", "5px");
                                    hyper.Style.Add("padding-left", "10px");
                                    hyper.Style.Add("padding-right", "10px");
                                    hyper.Text = i.ToString() + "&nbsp;";
                                    hyper.NavigateUrl = "kategori.aspx?UstKatID=" + UstKatID + "&sayfa=" + i.ToString() + "&durum=1";
                                    pnlSayfa.Controls.Add(hyper);
                                }


                                rptIlan.DataSource = pdsAlici;
                                rptIlan.DataBind();
                               // sayfalama işlemlerini yapıyoruz

                            }

                            else if (durum == 2)
                            {
                                if (Session["kullaniciID"] != null)
                                   //kullanıcı adı boş değil ise
                                {
                                    DataTable dtEnYakin = conn.GetDataTable("select i.kullaniciID, i.ilanID,euk.EnUstKategoriID,euk.EnUstKategoriAdi,uk.UstKategoriID,uk.UstKategoriAdi, k.KategoriID,ak.AltKategoriID,ak.AltKategoriAdi,k.KategoriAdi,i.ilanAdi, i.ilanFiyat,i.ilanTarihi, s.SehirId,s.SehirAdi,ilce.ilceId,IlceAdi,sm.SemtMahId,sm.MahalleAdi,ir.ilanResim1 from ilan i inner join ilanResmi ir on ir.ilanID=i.ilanID full outer join altKategori ak on ak.AltKategoriID=i.AltKategoriID  inner  join Kategori k on k.KategoriID=i.kategoriID  inner join UstKategori uk on uk.UstKategoriID=k.UstKategoriID inner join EnUstKategori euk on euk.EnUstKategoriID=uk.EnUstKategoriID inner  join  semtMah sm on sm.SemtMahId=i.semtMahID inner  join  iIlceler ilce on ilce.ilceId=sm.ilceId inner join sehirler s on s.SehirId=ilce.SehirId  inner join  kullanici kul on kul.kullaniciID=i.kullaniciID where kul.ilce=i.ilceID and uk.UstKategoriID=" + UstKatID + " order by i.goruntulenme desc");
                                   //kullanıncın ilçesinde bulunan ilanları datatable atıyoruz

                                    PagedDataSource pdsEnYakin = new PagedDataSource();
                                    pdsEnYakin.DataSource = dtEnYakin.DefaultView;
                                    pdsEnYakin.AllowPaging = true;
                                    pdsEnYakin.PageSize = 8;
                                    int sayfaEnYakin;

                                    if (Request.QueryString["sayfa"] != null)
                                    {
                                        sayfaEnYakin = Convert.ToInt32(Request.QueryString["sayfa"]);
                                    }
                                    else
                                    {
                                        sayfaEnYakin = 1;
                                    }
                                    pdsEnYakin.CurrentPageIndex = sayfaEnYakin - 1;

                                    for (int i = 1; i <= pdsEnYakin.PageCount; i++)
                                    {
                                        HyperLink hyper = new HyperLink();
                                        hyper.ForeColor = System.Drawing.ColorTranslator.FromHtml("white");
                                        hyper.Style.Add("text-decoration", "none");
                                        hyper.Style.Add("background-color", "#62bfc4");
                                        hyper.Style.Add("padding-top", "5px");
                                        hyper.Style.Add("padding-bottom", "5px");
                                        hyper.Style.Add("padding-left", "10px");
                                        hyper.Style.Add("padding-right", "10px");
                                        hyper.Text = i.ToString() + "&nbsp;";
                                        hyper.NavigateUrl = "kategori.aspx?UstKatID=" + UstKatID + "&sayfa=" + i.ToString() + "&durum=2";
                                        pnlSayfa.Controls.Add(hyper);
                                    }
                                    rptIlan.DataSource = pdsEnYakin;
                                    rptIlan.DataBind();

                                }
                                else
                                {
                                    Response.Redirect("eror.aspx");
                                }
                                //sayfalama işlemlerini yapıyoruz




                            }
                            else if (durum == 3)
                            {

                                if (Session["kullaniciID"] != null)
                                    //kullanıcıID boşdeğil ise
                                {

                                    DataTable dtYakin = conn.GetDataTable("select i.kullaniciID, i.ilanID,euk.EnUstKategoriID,euk.EnUstKategoriAdi,uk.UstKategoriID,uk.UstKategoriAdi, k.KategoriID,ak.AltKategoriID,ak.AltKategoriAdi,k.KategoriAdi,i.ilanAdi, i.ilanFiyat,i.ilanTarihi, s.SehirId,s.SehirAdi,ilce.ilceId,IlceAdi,sm.SemtMahId,sm.MahalleAdi,ir.ilanResim1 from ilan i inner join ilanResmi ir on ir.ilanID=i.ilanID full outer join altKategori ak on ak.AltKategoriID=i.AltKategoriID  inner  join Kategori k on k.KategoriID=i.kategoriID  inner join UstKategori uk on uk.UstKategoriID=k.UstKategoriID inner join EnUstKategori euk on euk.EnUstKategoriID=uk.EnUstKategoriID inner  join  semtMah sm on sm.SemtMahId=i.semtMahID inner  join  iIlceler ilce on ilce.ilceId=sm.ilceId inner join sehirler s on s.SehirId=ilce.SehirId  inner join  kullanici kul on kul.kullaniciID=i.kullaniciID where kul.il=i.sehirID and uk.UstKategoriID=" + UstKatID + " order by i.goruntulenme desc");
                                    PagedDataSource pdsYakin = new PagedDataSource();
                                    pdsYakin.DataSource = dtYakin.DefaultView;
                                    pdsYakin.AllowPaging = true;
                                    pdsYakin.PageSize = 8;
                                    int sayfaYakin;

                                    if (Request.QueryString["sayfa"] != null)
                                    {
                                        sayfaYakin = Convert.ToInt32(Request.QueryString["sayfa"]);
                                    }
                                    else
                                    {
                                        sayfaYakin = 1;
                                    }
                                    pdsYakin.CurrentPageIndex = sayfaYakin - 1;

                                    for (int i = 1; i <= pdsYakin.PageCount; i++)
                                    {
                                        HyperLink hyper = new HyperLink();
                                        hyper.ForeColor = System.Drawing.ColorTranslator.FromHtml("white");
                                        hyper.Style.Add("text-decoration", "none");
                                        hyper.Style.Add("background-color", "#62bfc4");
                                        hyper.Style.Add("padding-top", "5px");
                                        hyper.Style.Add("padding-bottom", "5px");
                                        hyper.Style.Add("padding-left", "10px");
                                        hyper.Style.Add("padding-right", "10px");
                                        hyper.Text = i.ToString() + "&nbsp;";
                                        hyper.NavigateUrl = "kategori.aspx?UstKatID=" + UstKatID + "&sayfa=" + i.ToString() + "&durum=3";
                                        pnlSayfa.Controls.Add(hyper);
                                    }

                                    rptIlan.DataSource = pdsYakin;
                                    rptIlan.DataBind();


                                }
                                else
                                {
                                    Response.Redirect("eror.aspx");
                                    //yönlendirme yapıyoruz
                                }

                            }
                            //sayfalama işlemlrini yapıyoruz



                        }
                        else
                        {
                            Response.Redirect("error.aspx");
                            //yönlendirme yapıyoruz
                        }


                    }
                    else
                    {
                        Response.Redirect("error.aspx");
                        //yönlendirme yapıyoruz
                    }
                }
                else
                {
                    Response.Redirect("error.aspx");
                    //yönlendirme yapıyoruz
                }
            }
            else
            {
                Response.Redirect("error.aspx");
                //yönlendirme yapıyoruz
            }



        }



        protected void lbtnSatici_Click(object sender, EventArgs e)
        {
            Response.Redirect("kategori.aspx?UstKatID=" + UstKatID + "&durum=0");
            //yönlendirme yapıyoruz
        }

        protected void lbtnAlici_Click(object sender, EventArgs e)
        {

            Response.Redirect("kategori.aspx?UstKatID = " + UstKatID + " &durum=1");
            //yönlendirme yapıyoruz


        }


        protected void lbtnEnYakin_Click(object sender, EventArgs e)
        {

            Response.Redirect("kategori.aspx?UstKatID=" + UstKatID + "&durum=2");
            //yönlendirme yapıyoruz


        }

        protected void lbtnYakin_Click(object sender, EventArgs e)
        {

            Response.Redirect("kategori.aspx?UstKatID=" + UstKatID + "&durum=3");
            //yönlendirme yapıyoruz
        }

        protected void lbFiyat_Click(object sender, EventArgs e)
        {
            DataTable dtSaticiSırali = conn.GetDataTable("select i.ilanID,euk.EnUstKategoriID,euk.EnUstKategoriAdi,uk.UstKategoriID,uk.UstKategoriAdi,k.KategoriID,ak.AltKategoriID,ak.AltKategoriAdi,k.KategoriAdi,i.ilanAdi, i.ilanFiyat,i.ilanTarihi,s.SehirId,s.SehirAdi,ilce.ilceId,IlceAdi,sm.SemtMahId,sm.MahalleAdi,ir.ilanResim1	from ilan i inner join ilanResmi ir on ir.ilanID=i.ilanID full outer join altKategori ak on ak.AltKategoriID=i.AltKategoriID inner  join Kategori k on k.KategoriID=i.kategoriID inner join UstKategori uk on uk.UstKategoriID=k.UstKategoriID inner join EnUstKategori euk on euk.EnUstKategoriID=uk.EnUstKategoriID inner  join  semtMah sm on sm.SemtMahId=i.semtMahID inner  join  iIlceler ilce on ilce.ilceId=sm.ilceId inner join sehirler s on s.SehirId=ilce.SehirId where i.ilanTipiID=1 and uk.UstKategoriID=" + UstKatID + "ORDER BY i.ilanFiyat asc");
            //satıcı ilanlarını fiyata göre sıralıyoruz
            rptIlan.DataSource = dtSaticiSırali;
            //repeater datasourcesine bağlıyoruz
            rptIlan.DataBind();
            //ve yazdırıyoruz

        }

        protected void lbIlanTarih_Click(object sender, EventArgs e)
        {
            DataTable dtSaticiSırali = conn.GetDataTable("select i.ilanID,euk.EnUstKategoriID,euk.EnUstKategoriAdi,uk.UstKategoriID,uk.UstKategoriAdi,k.KategoriID,ak.AltKategoriID,ak.AltKategoriAdi,k.KategoriAdi,i.ilanAdi, i.ilanFiyat,i.ilanTarihi,s.SehirId,s.SehirAdi,ilce.ilceId,IlceAdi,sm.SemtMahId,sm.MahalleAdi,ir.ilanResim1	from ilan i inner join ilanResmi ir on ir.ilanID=i.ilanID full outer join altKategori ak on ak.AltKategoriID=i.AltKategoriID inner  join Kategori k on k.KategoriID=i.kategoriID inner join UstKategori uk on uk.UstKategoriID=k.UstKategoriID inner join EnUstKategori euk on euk.EnUstKategoriID=uk.EnUstKategoriID inner  join  semtMah sm on sm.SemtMahId=i.semtMahID inner  join  iIlceler ilce on ilce.ilceId=sm.ilceId inner join sehirler s on s.SehirId=ilce.SehirId where i.ilanTipiID=1 and uk.UstKategoriID=" + UstKatID + "ORDER BY i.ilanTarihi asc");
            //satıcı ilanlarını tarihine göre sıralıyoruz
            rptIlan.DataSource = dtSaticiSırali;
            //repeater datasourcesine bağlıyoruz
            rptIlan.DataBind();
            //ve yazdırıyoruz
        }
    }
}