using Dal;
using Dal.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Internal;
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
        public Task<List<CustomerAccounts>> BL_GetCustomerAccounts();
        public Task<CustomerAccounts> BL_GetCustomerAccountByID(Int32 id);
        public bool BL_UpdateCustomerById(Int32 id, CustomerAccounts customerAccount);
        public bool BL_AddCustomerAccount(CustomerAccounts customerAccount);
        public bool BL_DeleteCustomerAccountByID(Int32 id);
        public bool bllog(string userid, string pass);
        public bool AddFile(IFormFile file, string link, int orderid);
        public List<DocumentFiles> GetFiles();

        public bool BL_AddOrder(PrintOrders order);
        public bool DeleteOrder(int id);
        public DocumentFiles GetDocumentById(int id);



    }
}
