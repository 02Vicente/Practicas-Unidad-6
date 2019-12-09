using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Practica_VI_IV_Model.Models
{
    public class SessionData
    {
        private string session;
        public string getSession(string name)
        {
            this.session = Convert.ToString(HttpContext.Current.Session[name]);
            return session;
        }

        public void setSession(string name, string data)
        {
            HttpContext.Current.Session[name] = data;
        }

        public void destroySession()
        {
            HttpContext.Current.Session.Clear();
            HttpContext.Current.Session.Abandon();
            HttpContext.Current.Session.RemoveAll();
        }
    }
}
