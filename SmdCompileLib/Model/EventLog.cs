using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmdCompileLib.Model
{
    public class EventLog
    {
        public Action<string> ErrorLog = null;
        public Action<string> MessageLog = null;
        public Action UpdateLog = null;

        public void f_UpdateLog(string err)
        {
            if (UpdateLog != null)
            {
                UpdateLog();
            }
        }

        public void f_ErrorLog(string err)
        {
            if(ErrorLog != null)
            {
                ErrorLog(err);
            }
        }
        public void m_MessageLog(string msg)
        {
            if (MessageLog != null)
                MessageLog(msg);
        }
    }
}
