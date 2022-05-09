using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dal;
using Dal.Entities;
using Microsoft.AspNetCore.Http;

namespace Bl
{
    public class Blc : IBlc
    {
        
        public async Task<List<CustomerAccounts>> BL_GetCustomerAccounts()
        {
            Dalc d = new();
            List<CustomerAccounts> c = d.GetCustomerAccounts();
            return c;
        }
        public async Task<CustomerAccounts> BL_GetCustomerAccountByID(Int32 id)
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

        public bool AddFile(IFormFile filess , string medialink,int orderid)
        {
            Dalc dalc = new();
            DocumentFiles doc = new();
            doc.UploadDate = DateTime.Now;
            doc.FileLink = medialink; //to do: to generate link from cloud service for the IFormFile parameter
            doc.DocumentName = filess.FileName;
            doc.FileSize = filess.Length;
            doc.FileFormat = filess.ContentType;
            doc.OrderID = orderid;
            return dalc.AddFile(doc); // to do: please note that if the file link is invalid return false
        }

        public List<DocumentFiles> GetFiles()
        {
            Dalc dalc = new();
            List<DocumentFiles> files = dalc.GetFiles();
            return files;
        }

        public bool BL_AddOrder(PrintOrders order)
        {
            Dalc dalc = new();
            order.OrderedDateTime = DateTime.Now;
            
            return dalc.AddOrder(order);
        }

        public bool UpdateOrder(PrintOrders order)
        {
            Dalc dalc = new();

            return dalc.UpdateOrder(order);
        }
        public PrintOrders GetPrintOrderById(int id)
        {
            Dalc dalc = new();
            return dalc.GetPrintOrderById(id);
        }
        public bool DeleteOrder(int id)
        {
            Dalc dalc = new();
            return (dalc.DeleteOrder(id));
        }
        public List<PrintOrders> GetPrintOrders()
        {
            Dalc dalc = new();
            return dalc.GetPrintOrders();
        }
        public DocumentFiles GetDocumentById(int id)
        {
            Dalc dalc = new();
            return dalc.GetDocumentById(id);
        }
    }
}
