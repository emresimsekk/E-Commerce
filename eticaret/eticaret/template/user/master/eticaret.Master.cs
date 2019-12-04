using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace eticaret.template.user.master
{
    public partial class eticaret : System.Web.UI.MasterPage
    {
        connect conn = new connect();
        string urunAdet;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.Cookies["cerezim"] != null)
            {
                HttpCookie yakalananCerez = Request.Cookies["cerezim"];
                Session["kullaniciID"] = yakalananCerez.Values["kullaniciID"];
            }

            DataRow drAdi = conn.GetDataRow("select (k.ad+' '+k.soyad) as adSoyad  from kullanici k where k.kullaniciID='"+ Session["kullaniciID"] + "'");

   
            if (Session["kullaniciID"]==null)
             
            {
                pnlGiris.Visible = true;
                pnlHosgeldiniz.Visible = false;
                pnlSat.Visible = false;
                pnlUser.Visible = false;
                pnlFavori.Visible = false;
            }
            else
            {
                pnlGiris.Visible = false;
                pnlHosgeldiniz.Visible = true;
                pnlSat.Visible = true;
                pnlFavori.Visible = true;
                pnlUser.Visible = true;
                lblAdi.Text = drAdi["adSoyad"].ToString();
            }



        }
    }
}