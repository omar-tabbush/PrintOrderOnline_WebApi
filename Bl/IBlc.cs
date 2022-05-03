using Dal;
using Dal.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bl
{
    internal interface IBlc
    {
        public List<CustomerAccounts> BL_GetCustomerAccounts();
        public CustomerAccounts BL_GetCustomerAccountByID(Int32 id);
        public bool BL_UpdateCustomerById(Int32 id, CustomerAccounts customerAccount);
        public bool BL_AddCustomerAccount(CustomerAccounts customerAccount);
        public bool BL_DeleteCustomerAccountByID(Int32 id);
        public bool bllog(string userid, string pass);
        public bool AddFile(DocumentFiles file);


    }
}
