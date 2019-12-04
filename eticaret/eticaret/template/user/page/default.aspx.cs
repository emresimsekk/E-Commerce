using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI;
using System.Web.UI.WebControls;


namespace eticaret.template.user.page
{
   
    public partial class _default : System.Web.UI.Page
    {
        connect conn = new connect();
        //Bağlantı classımızı sayfaya dahil ediyoruz
  

        protected void Page_Load(object sender, EventArgs e)
        {
            
            DataTable dtEnUstMenu = conn.GetDataTable("select euk.EnUstKategoriID ,euk.EnUstKategoriAdi from EnUstKategori euk");
            //Datatable enustkategori tablomuzu çekiyoruz
            rptEnUstKategori.DataSource = dtEnUstMenu;
            //repeater datasourceyi bağlıyoruz
            rptEnUstKategori.DataBind();
            //ve yazdırıyoruz

            DataTable dtSlider = conn.GetDataTable("select s.sliderID,s.sliderUrl  from slider s");
            //Datatable slider tablomuzu çekiyoruz
            rptSlider.DataSource = dtSlider;
            //datasourceye bağlıyoruz
            rptSlider.DataBind();
            //ve yazdırıyoruz

        }
    }
}