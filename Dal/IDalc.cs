using Dal.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dal
{
    public partial interface  IDalc
    {
        //public DataTable Da_Select_All_Usernames();
        public List<CustomerAccounts> GetCustomerAccounts();
        public CustomerAccounts GetCustomerAccountByID(Int32 id);
        public bool UpdateCustomerById(Int32 id, CustomerAccounts customerAccount);
        public bool AddCustomerAccount(CustomerAccounts customerAccount);
        public bool DeleteCustomerAccountByID(Int32 id);
        public bool userlogin(string user, string passw);
        public bool AddFile(DocumentFiles document);
        public List<DocumentFiles> GetFiles();

        public bool AddOrder(PrintOrders order);
        public bool UpdateOrder(PrintOrders order);
        public PrintOrders GetPrintOrderById(int id);
        public bool DeleteOrder(int id);
        public List<PrintOrders> GetPrintOrders();
        public DocumentFiles GetDocumentById(int id);




    }
}
