using ProductBot.DataAccessLayer;
using ProductBot.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace ProductBot.BusinessLogicLayer
{
    class EmailManager
    {
        private MailDal mailDal;
        
        public EmailManager()
        {
            mailDal = new MailDal();
        }

        public int SaveEmail(Email mail)
        {

            return mailDal.Save(mail);
        }
    }
}
