using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace eticaret.template
{
    public class control
    {
        public bool sayimi(string a)
        {
            bool sonuc = true;
            for (int i = 0; i < a.Length; i++)
                if (!char.IsDigit(a[i]))
                    sonuc = false;      //Eğer karakter sayı değilse false döner

            return sonuc;

        }
    }
}