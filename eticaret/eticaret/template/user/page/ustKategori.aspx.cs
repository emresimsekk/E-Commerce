using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace eticaret.template.user.page
{
  
    public partial class ustKategori : System.Web.UI.Page
    {
  
        connect conn = new connect();
        //bağlantı clasımızı sayfaya dahil ediyoruz
        
        int enUstKatID;
        //integer tipinde değişken oluşturuyoruz
        int durum;
        //integer tipinde değişken oluşturuyoruz



        protected void Page_Load(object sender, EventArgs e)
        {

          
            if (Session["kullaniciID"]!=null)
             //kullanıcı varmı diye kontrol ediyoruz
            {
                lbtnEnYakin.Visible = true;
                //panelimizi gösteriyoruz
                lbtnYakin.Visible = true;
                //panelimizi gösteriyoruz
            }



            if (int.TryParse(Request.QueryString["enUstKatID"], out enUstKatID)) 
             //gelen değer string ise
            {

                DataRow drMin = conn.GetDataRow("select  min(ek.EnUstKategoriID)  as EnUstKategoriID  from EnUstKategori ek");
                //EnUstKategori tablosndan min değeri alıyoruz
                DataRow drMax = conn.GetDataRow("select  max(ek.EnUstKategoriID)  as EnUstKategoriID  from EnUstKategori ek");
                //EnUstKategori tablosndan max değeri alıyoruz


                if (enUstKatID >= Convert.ToInt32(drMin["EnUstKategoriID"]))
                    //gelen paramametre minden büyük
                {
                    if (enUstKatID <= Convert.ToInt32(drMax["EnUstKategoriID"]))
                    //gelen paramametre maxtan küçük ise büyük
                    {

                        DataTable dtUstKategori = conn.GetDataTable("select uk.UstKategoriID,uk.EnUstKategoriID,uk.UstKategoriAdi from UstKategori uk where uk.EnUstKategoriID=" + enUstKatID);
                        //gelen parametreye göre ust kategori tablomuzu çekiyoruz
                        rptUstKategori.DataSource = dtUstKategori;
                        //repeater basıyoruz
                        rptUstKategori.DataBind();
                        //ve yazdırıyoruz





                        if (int.TryParse(Request.QueryString["durum"], out durum))
                          //gelen değer string ise
                        {
                            if (durum==0)
                            {
                            //durum 0 ise
                                DataTable dtSaticiIlan = conn.GetDataTable("select i.ilanID,euk.EnUstKategoriID,euk.EnUstKategoriAdi,uk.UstKategoriID,uk.UstKategoriAdi,k.KategoriID,ak.AltKategoriID,ak.AltKategoriAdi,k.KategoriAdi,i.ilanAdi, i.ilanFiyat,i.ilanTarihi,s.SehirId,s.SehirAdi,ilce.ilceId,IlceAdi,sm.SemtMahId,sm.MahalleAdi,ir.ilanResim1,i.goruntulenme	from ilan i inner join ilanResmi ir on ir.ilanID=i.ilanID full outer join altKategori ak on ak.AltKategoriID=i.AltKategoriID inner  join Kategori k on k.KategoriID=i.kategoriID inner join UstKategori uk on uk.UstKategoriID=k.UstKategoriID inner join EnUstKategori euk on euk.EnUstKategoriID=uk.EnUstKategoriID inner  join  semtMah sm on sm.SemtMahId=i.semtMahID inner  join  iIlceler ilce on ilce.ilceId=sm.ilceId inner join sehirler s on s.SehirId=ilce.SehirId where i.ilanTipiID=1   and euk.EnUstKategoriID=" + enUstKatID + "order by i.goruntulenme desc");
                                //satıcı ilan datatable veri çekiyoruz


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
                                    hyper.NavigateUrl = "ustKategori.aspx?enUstKatID=" + enUstKatID + "&sayfa=" + i.ToString()+"&durum=0";
                                    pnlSayfa.Controls.Add(hyper);
                                    //sayfalama işlemi yapıyoruz
                                }

                                rptIlan.DataSource = pds;
                                rptIlan.DataBind();

                            }

                            else if (durum == 1)
                            //durum 1 ise
                            {

                                DataTable dtAliciIlan = conn.GetDataTable("select i.ilanID,euk.EnUstKategoriID,euk.EnUstKategoriAdi,uk.UstKategoriID,uk.UstKategoriAdi,k.KategoriID,ak.AltKategoriID,ak.AltKategoriAdi,k.KategoriAdi,i.ilanAdi, i.ilanFiyat,i.ilanTarihi,s.SehirId,s.SehirAdi,ilce.ilceId,IlceAdi,sm.SemtMahId,sm.MahalleAdi,ir.ilanResim1,i.goruntulenme	from ilan i inner join ilanResmi ir on ir.ilanID=i.ilanID full outer join altKategori ak on ak.AltKategoriID=i.AltKategoriID inner  join Kategori k on k.KategoriID=i.kategoriID inner join UstKategori uk on uk.UstKategoriID=k.UstKategoriID inner join EnUstKategori euk on euk.EnUstKategoriID=uk.EnUstKategoriID inner  join  semtMah sm on sm.SemtMahId=i.semtMahID inner  join  iIlceler ilce on ilce.ilceId=sm.ilceId inner join sehirler s on s.SehirId=ilce.SehirId where i.ilanTipiID=2   and euk.EnUstKategoriID=" + enUstKatID + "  order by i.goruntulenme desc");
                                //aalıcı ilan datatable veri çekiyoruz

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
                                    hyper.NavigateUrl = "ustKategori.aspx?enUstKatID=" + enUstKatID + "&sayfa=" + i.ToString() + "&durum=1";
                                    pnlSayfa.Controls.Add(hyper);
                                }
                                //sayfalama işlemi yapıyoruz


                                rptIlan.DataSource = pdsAlici;
                                rptIlan.DataBind();

                            }

                            else if (durum == 2)
                            //durum 2 ise
                            {
                                if (Session["kullaniciID"] != null)
                                    //kullanıcı var ise
                                {
                                    DataTable dtEnYakin = conn.GetDataTable("select i.kullaniciID, i.ilanID,euk.EnUstKategoriID,euk.EnUstKategoriAdi,uk.UstKategoriID,uk.UstKategoriAdi, k.KategoriID,ak.AltKategoriID,ak.AltKategoriAdi,k.KategoriAdi,i.ilanAdi, i.ilanFiyat,i.ilanTarihi, s.SehirId,s.SehirAdi,ilce.ilceId,IlceAdi,sm.SemtMahId,sm.MahalleAdi,ir.ilanResim1 from ilan i inner join ilanResmi ir on ir.ilanID=i.ilanID full outer join altKategori ak on ak.AltKategoriID=i.AltKategoriID  inner  join Kategori k on k.KategoriID=i.kategoriID  inner join UstKategori uk on uk.UstKategoriID=k.UstKategoriID inner join EnUstKategori euk on euk.EnUstKategoriID=uk.EnUstKategoriID inner  join  semtMah sm on sm.SemtMahId=i.semtMahID inner  join  iIlceler ilce on ilce.ilceId=sm.ilceId inner join sehirler s on s.SehirId=ilce.SehirId  inner join  kullanici kul on kul.kullaniciID=i.kullaniciID where kul.ilce=i.ilceID and euk.EnUstKategoriID=" + enUstKatID + " order by i.goruntulenme desc");
                                    //ilçesinde bulanan ilanları çekiyoruz

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
                                        hyper.NavigateUrl = "ustKategori.aspx?enUstKatID=" + enUstKatID + "&sayfa=" + i.ToString() + "&durum=2";
                                        pnlSayfa.Controls.Add(hyper);
                                    }
                                    rptIlan.DataSource = pdsEnYakin;
                                    rptIlan.DataBind();

                                }
                                //sayfalama işlemi yapıyoruz
                                else
                                {
                                    Response.Redirect("eror.aspx");
                                }




                            }
                            else if (durum == 3)
                            //durum 2 ise
                            {

                                if (Session["kullaniciID"] != null)
                                 //kullanıcı var ise
                                {

                                    DataTable dtYakin = conn.GetDataTable("select i.kullaniciID, i.ilanID,euk.EnUstKategoriID,euk.EnUstKategoriAdi,uk.UstKategoriID,uk.UstKategoriAdi, k.KategoriID,ak.AltKategoriID,ak.AltKategoriAdi,k.KategoriAdi,i.ilanAdi, i.ilanFiyat,i.ilanTarihi, s.SehirId,s.SehirAdi,ilce.ilceId,IlceAdi,sm.SemtMahId,sm.MahalleAdi,ir.ilanResim1 from ilan i inner join ilanResmi ir on ir.ilanID=i.ilanID full outer join altKategori ak on ak.AltKategoriID=i.AltKategoriID  inner  join Kategori k on k.KategoriID=i.kategoriID  inner join UstKategori uk on uk.UstKategoriID=k.UstKategoriID inner join EnUstKategori euk on euk.EnUstKategoriID=uk.EnUstKategoriID inner  join  semtMah sm on sm.SemtMahId=i.semtMahID inner  join  iIlceler ilce on ilce.ilceId=sm.ilceId inner join sehirler s on s.SehirId=ilce.SehirId  inner join  kullanici kul on kul.kullaniciID=i.kullaniciID where kul.il=i.sehirID and euk.EnUstKategoriID=" + enUstKatID + " order by i.goruntulenme desc");
                                    //kullanıcın ilindeki ilanları çekiyoruz
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
                                        hyper.NavigateUrl = "ustKategori.aspx?enUstKatID=" + enUstKatID + "&sayfa=" + i.ToString() + "&durum=3";
                                        pnlSayfa.Controls.Add(hyper);
                                    }
                                    //sayfalama yapıyoruz

                                    rptIlan.DataSource = pdsYakin;
                                    rptIlan.DataBind();


                                }
                                else
                                {
                                    Response.Redirect("eror.aspx");
                                    //yönlendirme yapıyoruz
                                }

                            }



                        }
                        else
                        {
                            Response.Redirect("errodsar.aspx");
                            //yönlendirme yapıyoruz
                        }


                    }
                        else
                        {
                            Response.Redirect("eror.aspx");
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
            Response.Redirect("ustKategori.aspx?enUstKatID=" + enUstKatID + "&durum=0");
            //yönlendirme yapıyoruz
        }

        protected void lbtnAlici_Click(object sender, EventArgs e)
        {

            Response.Redirect("ustKategori.aspx?enUstKatID=" + enUstKatID + "&durum=1");
            //yönlendirme yapıyoruz


        }


        protected void lbtnEnYakin_Click(object sender, EventArgs e)
        {

            Response.Redirect("ustKategori.aspx?enUstKatID=" + enUstKatID + "&durum=2");
            //yönlendirme yapıyoruz


        }

        protected void lbtnYakin_Click(object sender, EventArgs e)
        {

            Response.Redirect("ustKategori.aspx?enUstKatID=" + enUstKatID + "&durum=3");
        }
      
        protected void lbFiyat_Click(object sender, EventArgs e)
        {  
            DataTable dtSaticiSırali = conn.GetDataTable("select i.ilanID,euk.EnUstKategoriID,euk.EnUstKategoriAdi,uk.UstKategoriID,uk.UstKategoriAdi,k.KategoriID,ak.AltKategoriID,ak.AltKategoriAdi,k.KategoriAdi,i.ilanAdi, i.ilanFiyat,i.ilanTarihi,s.SehirId,s.SehirAdi,ilce.ilceId,IlceAdi,sm.SemtMahId,sm.MahalleAdi,ir.ilanResim1	from ilan i inner join ilanResmi ir on ir.ilanID=i.ilanID full outer join altKategori ak on ak.AltKategoriID=i.AltKategoriID inner  join Kategori k on k.KategoriID=i.kategoriID inner join UstKategori uk on uk.UstKategoriID=k.UstKategoriID inner join EnUstKategori euk on euk.EnUstKategoriID=uk.EnUstKategoriID inner  join  semtMah sm on sm.SemtMahId=i.semtMahID inner  join  iIlceler ilce on ilce.ilceId=sm.ilceId inner join sehirler s on s.SehirId=ilce.SehirId where i.ilanTipiID=1 and euk.EnUstKategoriID=" + enUstKatID + "ORDER BY i.ilanFiyat asc");
            rptIlan.DataSource = dtSaticiSırali;
            rptIlan.DataBind();
        
        }

        protected void lbIlanTarih_Click(object sender, EventArgs e)
        {
            DataTable dtSaticiSırali = conn.GetDataTable("select i.ilanID,euk.EnUstKategoriID,euk.EnUstKategoriAdi,uk.UstKategoriID,uk.UstKategoriAdi,k.KategoriID,ak.AltKategoriID,ak.AltKategoriAdi,k.KategoriAdi,i.ilanAdi, i.ilanFiyat,i.ilanTarihi,s.SehirId,s.SehirAdi,ilce.ilceId,IlceAdi,sm.SemtMahId,sm.MahalleAdi,ir.ilanResim1	from ilan i inner join ilanResmi ir on ir.ilanID=i.ilanID full outer join altKategori ak on ak.AltKategoriID=i.AltKategoriID inner  join Kategori k on k.KategoriID=i.kategoriID inner join UstKategori uk on uk.UstKategoriID=k.UstKategoriID inner join EnUstKategori euk on euk.EnUstKategoriID=uk.EnUstKategoriID inner  join  semtMah sm on sm.SemtMahId=i.semtMahID inner  join  iIlceler ilce on ilce.ilceId=sm.ilceId inner join sehirler s on s.SehirId=ilce.SehirId where i.ilanTipiID=1 and euk.EnUstKategoriID=" + enUstKatID + "ORDER BY i.ilanTarihi asc");
            rptIlan.DataSource = dtSaticiSırali;
            rptIlan.DataBind();
        }
    }
}