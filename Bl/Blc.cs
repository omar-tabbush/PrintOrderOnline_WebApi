using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dal;
using Dal.Entities;

namespace Bl
{
    public class Blc : IBlc
    {
        public List<CustomerAccounts> BL_GetCustomerAccounts()
        {
            Dalc d = new();
            return d.GetCustomerAccounts();
        }
        public CustomerAccounts BL_GetCustomerAccountByID(Int32 id)
        {
            Dalc dalc = new();
            return dalc.GetCustomerAccountByID(id);
        }

        public bool BL_UpdateCustomerById(Int32 id, CustomerAccounts customerAccount)
        {
            Dalc dalc = new();
            return dalc.UpdateCustomerById(id, customerAccount);
        }

        public bool BL_AddCustomerAccount(CustomerAccounts customerAccount)
        {
            Dalc dalc = new();
            customerAccount.CreatedDateTime = DateTime.Now;
            return dalc.AddCustomerAccount(customerAccount);
        }
        //why to use events?
        // we use event to not to be able to invoke the methode(event) outside the class!
        public bool BL_DeleteCustomerAccountByID(Int32 id)
        {
            Dalc dalc = new();
            return dalc.DeleteCustomerAccountByID((Int32)id);
        }


        public bool bllog(string userid, string pass)//checking the usename and password
        {
            Dalc dallogin = new();
            bool a = dallogin.userlogin(userid, pass);
            return a;
        }

        public bool AddFile(DocumentFiles file)
        {
            Dalc dalc = new();
            file.UploadDate = DateTime.Now;
            return dalc.AddFile(file);
        }
    }
}
