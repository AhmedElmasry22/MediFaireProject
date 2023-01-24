using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MediaFaire.Helper
{
    public interface IMailHelper
    {
        public void SendMail(InputEmail inputEmail);
    }
}
