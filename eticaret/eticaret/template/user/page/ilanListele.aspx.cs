using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace eticaret.template.user.page
{
    public partial class ilanListele : System.Web.UI.Page
    {
        connect conn = new connect();
        int AltkatID;
        int durum;
        protected void Page_Load(object sender, EventArgs e)
        {


            if (int.TryParse(Request.QueryString["altKatID"], out AltkatID)) //gelen değer string ise

            {


               
                    DataTable dtAltKategoriBilgi = conn.GetDataTable("select * from altKategori where AltKategoriID=" + AltkatID);
                    rptAltKategori.DataSource = dtAltKategoriBilgi;
                    rptAltKategori.DataBind();



                    if (int.TryParse(Request.QueryString["durum"], out durum)) //gelen değer string ise
                    {
                        if (durum == 0)
                        {
                            DataTable dtSaticiIlan = conn.GetDataTable("select i.ilanID,euk.EnUstKategoriID,euk.EnUstKategoriAdi,uk.UstKategoriID,uk.UstKategoriAdi,k.KategoriID,ak.AltKategoriID,ak.AltKategoriAdi,k.KategoriAdi,i.ilanAdi, i.ilanFiyat,i.ilanTarihi,s.SehirId,s.SehirAdi,ilce.ilceId,IlceAdi,sm.SemtMahId,sm.MahalleAdi,ir.ilanResim1,i.goruntulenme	from ilan i inner join ilanResmi ir on ir.ilanID=i.ilanID full outer join altKategori ak on ak.AltKategoriID=i.AltKategoriID inner  join Kategori k on k.KategoriID=i.kategoriID inner join UstKategori uk on uk.UstKategoriID=k.UstKategoriID inner join EnUstKategori euk on euk.EnUstKategoriID=uk.EnUstKategoriID inner  join  semtMah sm on sm.SemtMahId=i.semtMahID inner  join  iIlceler ilce on ilce.ilceId=sm.ilceId inner join sehirler s on s.SehirId=ilce.SehirId where i.ilanTipiID=1   and  ak.altKategoriID=" + AltkatID + "order by i.goruntulenme desc");


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
                                hyper.NavigateUrl = "ilanListele.aspx?altKatID=" + AltkatID + "&sayfa=" + i.ToString() + "&durum=0";
                                pnlSayfa.Controls.Add(hyper);
                            }

                            rptIlan.DataSource = pds;
                            rptIlan.DataBind();

                        }

                        else if (durum == 1)
                        {
                            DataTable dtAliciIlan = conn.GetDataTable("select i.ilanID,euk.EnUstKategoriID,euk.EnUstKategoriAdi,uk.UstKategoriID,uk.UstKategoriAdi,k.KategoriID,ak.AltKategoriID,ak.AltKategoriAdi,k.KategoriAdi,i.ilanAdi, i.ilanFiyat,i.ilanTarihi,s.SehirId,s.SehirAdi,ilce.ilceId,IlceAdi,sm.SemtMahId,sm.MahalleAdi,ir.ilanResim1,i.goruntulenme	from ilan i inner join ilanResmi ir on ir.ilanID=i.ilanID full outer join altKategori ak on ak.AltKategoriID=i.AltKategoriID inner  join Kategori k on k.KategoriID=i.kategoriID inner join UstKategori uk on uk.UstKategoriID=k.UstKategoriID inner join EnUstKategori euk on euk.EnUstKategoriID=uk.EnUstKategoriID inner  join  semtMah sm on sm.SemtMahId=i.semtMahID inner  join  iIlceler ilce on ilce.ilceId=sm.ilceId inner join sehirler s on s.SehirId=ilce.SehirId where i.ilanTipiID=2   and  ak.altKategoriID=" + AltkatID + "  order by i.goruntulenme desc");

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
                                hyper.NavigateUrl = "ilanListele.aspx?altKatID" + AltkatID + "&sayfa=" + i.ToString() + "&durum=1";
                                pnlSayfa.Controls.Add(hyper);
                            }


                            rptIlan.DataSource = pdsAlici;
                            rptIlan.DataBind();

                        }

                        else if (durum == 2)
                        {
                            if (Session["kullaniciID"] != null)
                            {
                                DataTable dtEnYakin = conn.GetDataTable("select i.kullaniciID, i.ilanID,euk.EnUstKategoriID,euk.EnUstKategoriAdi,uk.UstKategoriID,uk.UstKategoriAdi, k.KategoriID,ak.AltKategoriID,ak.AltKategoriAdi,k.KategoriAdi,i.ilanAdi, i.ilanFiyat,i.ilanTarihi, s.SehirId,s.SehirAdi,ilce.ilceId,IlceAdi,sm.SemtMahId,sm.MahalleAdi,ir.ilanResim1 from ilan i inner join ilanResmi ir on ir.ilanID=i.ilanID full outer join altKategori ak on ak.AltKategoriID=i.AltKategoriID  inner  join Kategori k on k.KategoriID=i.kategoriID  inner join UstKategori uk on uk.UstKategoriID=k.UstKategoriID inner join EnUstKategori euk on euk.EnUstKategoriID=uk.EnUstKategoriID inner  join  semtMah sm on sm.SemtMahId=i.semtMahID inner  join  iIlceler ilce on ilce.ilceId=sm.ilceId inner join sehirler s on s.SehirId=ilce.SehirId  inner join  kullanici kul on kul.kullaniciID=i.kullaniciID where kul.ilce=i.ilceID and  ak.altKategoriID=" + AltkatID + " order by i.goruntulenme desc");

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
                                    hyper.NavigateUrl = "ilanListele.aspx?altKatID=" + AltkatID + "&sayfa=" + i.ToString() + "&durum=2";
                                    pnlSayfa.Controls.Add(hyper);
                                }
                                rptIlan.DataSource = pdsEnYakin;
                                rptIlan.DataBind();

                            }
                            else
                            {
                                Response.Redirect("eror.aspx");
                            }




                        }
                        else if (durum == 3)
                        {

                            if (Session["kullaniciID"] != null)
                            {

                                DataTable dtYakin = conn.GetDataTable("select i.kullaniciID, i.ilanID,euk.EnUstKategoriID,euk.EnUstKategoriAdi,uk.UstKategoriID,uk.UstKategoriAdi, k.KategoriID,ak.AltKategoriID,ak.AltKategoriAdi,k.KategoriAdi,i.ilanAdi, i.ilanFiyat,i.ilanTarihi, s.SehirId,s.SehirAdi,ilce.ilceId,IlceAdi,sm.SemtMahId,sm.MahalleAdi,ir.ilanResim1 from ilan i inner join ilanResmi ir on ir.ilanID=i.ilanID full outer join altKategori ak on ak.AltKategoriID=i.AltKategoriID  inner  join Kategori k on k.KategoriID=i.kategoriID  inner join UstKategori uk on uk.UstKategoriID=k.UstKategoriID inner join EnUstKategori euk on euk.EnUstKategoriID=uk.EnUstKategoriID inner  join  semtMah sm on sm.SemtMahId=i.semtMahID inner  join  iIlceler ilce on ilce.ilceId=sm.ilceId inner join sehirler s on s.SehirId=ilce.SehirId  inner join  kullanici kul on kul.kullaniciID=i.kullaniciID where kul.il=i.sehirID and  ak.altKategoriID=" + AltkatID + " order by i.goruntulenme desc");
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
                                    hyper.NavigateUrl = "ilanListele.aspx?altKatID=" + AltkatID + "&sayfa=" + i.ToString() + "&durum=3";
                                    pnlSayfa.Controls.Add(hyper);
                                }

                                rptIlan.DataSource = pdsYakin;
                                rptIlan.DataBind();


                            }
                            else
                            {
                               // Response.Redirect("eror.aspx");
                            }

                        }
                        else
                        {
                          // Response.Redirect("eror.aspx");
                        }

                    }









               
            }
            else
            {
                Response.Redirect("eror.aspx");
            }





        }
        protected void lbtnEnYakin_Click(object sender, EventArgs e)
        {

            Response.Redirect("ilanListele.aspx?altKatID=" + AltkatID + "&durum=2");


        }

        protected void lbtnYakin_Click(object sender, EventArgs e)
        {

            Response.Redirect("ilanListele.aspx?altKatID=" + AltkatID + "&durum=3");
        }

        protected void lbFiyat_Click(object sender, EventArgs e)
        {
            DataTable dtSaticiSırali = conn.GetDataTable("select i.ilanID,euk.EnUstKategoriID,euk.EnUstKategoriAdi,uk.UstKategoriID,uk.UstKategoriAdi,k.KategoriID,ak.AltKategoriID,ak.AltKategoriAdi,k.KategoriAdi,i.ilanAdi, i.ilanFiyat,i.ilanTarihi,s.SehirId,s.SehirAdi,ilce.ilceId,IlceAdi,sm.SemtMahId,sm.MahalleAdi,ir.ilanResim1	from ilan i inner join ilanResmi ir on ir.ilanID=i.ilanID full outer join altKategori ak on ak.AltKategoriID=i.AltKategoriID inner  join Kategori k on k.KategoriID=i.kategoriID inner join UstKategori uk on uk.UstKategoriID=k.UstKategoriID inner join EnUstKategori euk on euk.EnUstKategoriID=uk.EnUstKategoriID inner  join  semtMah sm on sm.SemtMahId=i.semtMahID inner  join  iIlceler ilce on ilce.ilceId=sm.ilceId inner join sehirler s on s.SehirId=ilce.SehirId where i.ilanTipiID=1 and a.altKategoriID=" + AltkatID + "ORDER BY i.ilanFiyat asc");
            rptIlan.DataSource = dtSaticiSırali;
            rptIlan.DataBind();

        }

        protected void lbIlanTarih_Click(object sender, EventArgs e)
        {
            DataTable dtSaticiSırali = conn.GetDataTable("select i.ilanID,euk.EnUstKategoriID,euk.EnUstKategoriAdi,uk.UstKategoriID,uk.UstKategoriAdi,k.KategoriID,ak.AltKategoriID,ak.AltKategoriAdi,k.KategoriAdi,i.ilanAdi, i.ilanFiyat,i.ilanTarihi,s.SehirId,s.SehirAdi,ilce.ilceId,IlceAdi,sm.SemtMahId,sm.MahalleAdi,ir.ilanResim1	from ilan i inner join ilanResmi ir on ir.ilanID=i.ilanID full outer join altKategori ak on ak.AltKategoriID=i.AltKategoriID inner  join Kategori k on k.KategoriID=i.kategoriID inner join UstKategori uk on uk.UstKategoriID=k.UstKategoriID inner join EnUstKategori euk on euk.EnUstKategoriID=uk.EnUstKategoriID inner  join  semtMah sm on sm.SemtMahId=i.semtMahID inner  join  iIlceler ilce on ilce.ilceId=sm.ilceId inner join sehirler s on s.SehirId=ilce.SehirId where i.ilanTipiID=1 and ak.altKategoriID=" + AltkatID + "ORDER BY i.ilanTarihi asc");
            rptIlan.DataSource = dtSaticiSırali;
            rptIlan.DataBind();
        }
        protected void lbtnSatici_Click(object sender, EventArgs e)
        {
            Response.Redirect("ilanListele.aspx?altKatID=" + AltkatID + "&durum=0");
        }

        protected void lbtnAlici_Click(object sender, EventArgs e)
        {

            Response.Redirect("ilanListele.aspx?altKatID=" + AltkatID + "&durum=1");


        }
    }
}