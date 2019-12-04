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
    public partial class uyeOnay : System.Web.UI.Page
    {
        connect conn = new connect();
        string x;
        string mail;
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                x = Request.QueryString["x"];
                mail = Request.QueryString["eposta"];
            }
            catch (Exception)
            {

                throw;
            }


            DataRow drKullanici = conn.GetDataRow("select k.kullaniciID from kullanici k where k.email='"+mail+"' and k.rastgeleNumara='"+x+"'");
                if (drKullanici["kullaniciID"]!=null)
            {

                DataRow drOnay = conn.GetDataRow("select k.onay from kullanici k where k.kullaniciID='"+ drKullanici["kullaniciID"]+"'");
             
                if (drOnay["onay"].ToString()=="0")
                {
                    SqlConnection baglanti = conn.baglan();
                    SqlCommand cmd = new SqlCommand("UPDATE kullanici SET onay = 1 WHERE kullaniciID ='" + drKullanici["kullaniciID"] + "'", baglanti);

                    if (cmd.ExecuteNonQuery()==0)
                    {
                        lblDurum.Text = "Hata Oluşmuş Olabilir.";

                    }
                    else
                    {
                        lblDurum.Text = "Üyeliğiniz Aktifleştirildi";
                    }
                }
                else
                {
                    lblDurum.Text = "Üyeliğiniz Zaten Aktiftir.";
                }

                

            }
            else
	        {
                lblDurum.Text = "Böyle Bir Üye Bulunmadı.";
            }


        }

        protected void btnGirisYap_Click(object sender, EventArgs e)
        {
            Response.Redirect("UyeGiris.aspx");
        }
    }
}