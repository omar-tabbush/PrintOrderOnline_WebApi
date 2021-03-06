using Dal.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace Dal
{
    public class Dalc : IDalc
    {



        public List<CustomerAccounts> GetCustomerAccounts()
        {
            List<CustomerAccounts>? listEmployees = null;

            //Lets get the list of all employees in a datataable
            using (DataTable table = SqlDBHelper.ExecuteSelectCommand("GetCustomerAccounts", CommandType.StoredProcedure))
            {
                //check if any record exist or not
                if (table.Rows.Count > 0)
                {
                    //Lets go ahead and create the list of employees
                    listEmployees = new List<CustomerAccounts>();

                    //Now lets populate the employee details into the list of employees
                    foreach (DataRow row in table.Rows)
                    {

                        CustomerAccounts employee = new CustomerAccounts();
                        employee.AccountID = Convert.ToInt32(row["AccountID"]);
                        employee.Username = row["Username"].ToString();
                        employee.Password = row["Password"].ToString();
                        employee.Fname = row["Fname"].ToString();
                        employee.Lname = row["Lname"].ToString();
                        employee.PhoneNumber = row["PhoneNumber"].ToString();
                        employee.Email = row["Email"].ToString();
                        employee.Address1 = row["Address1"].ToString();
                        employee.Address2 = row["Address2"].ToString();
                        employee.Address3 = row["Address3"].ToString();
                        if (row.IsNull("CreatedDateTime"))
                            employee.CreatedDateTime = null;
                        else
                            employee.CreatedDateTime = Convert.ToDateTime(row["CreatedDateTime"]);

                        listEmployees.Add(employee);
                    }
                }
            }

            return listEmployees;
        }

        public CustomerAccounts GetCustomerAccountByID(int Accountid)
        {
            CustomerAccounts? customerAccount = null;
            SqlParameter[] parameter = new SqlParameter[]
            {
                new SqlParameter("@Accountid",Accountid)
            };
            using (DataTable table = SqlDBHelper.ExecuteParamerizedSelectCommand("GetCustomerAccountByID", CommandType.StoredProcedure, parameter))
            {
                if (table.Rows.Count > 0)
                {
                    customerAccount = new CustomerAccounts();
                    DataRow row = table.Rows[0];

                    customerAccount.AccountID = Convert.ToInt32(row["AccountID"]);
                    customerAccount.Username = row["Username"].ToString();
                    customerAccount.Password = row["Password"].ToString();
                    customerAccount.Fname = row["Fname"].ToString();
                    customerAccount.Lname = row["Lname"].ToString();
                    customerAccount.PhoneNumber = row["PhoneNumber"].ToString();
                    customerAccount.Email = row["Email"].ToString();
                    customerAccount.Address1 = row["Address1"].ToString();
                    customerAccount.Address2 = row["Address2"].ToString();
                    customerAccount.Address3 = row["Address3"].ToString();
                    if (row.IsNull("CreatedDateTime"))
                        customerAccount.CreatedDateTime = null;
                    else
                        customerAccount.CreatedDateTime = Convert.ToDateTime(row["CreatedDateTime"]);

                }
            }
            return customerAccount;
        }
        public bool UpdateCustomerById(int id, CustomerAccounts customerAccount)
        {
            if (customerAccount == null) return false;
            SqlParameter[] parameter = new SqlParameter[]
            {
                new SqlParameter("@AccountID",id),
                new SqlParameter("@Username", customerAccount.Username),
                new SqlParameter("@Password",customerAccount.Password),
                new SqlParameter("@Address1",customerAccount.Address1),
                new SqlParameter("@Email",customerAccount.Email),
                new SqlParameter("@Address2",customerAccount.Address2),
                new SqlParameter("@Address3",customerAccount.Address3),
                new SqlParameter("@PhoneNumber",customerAccount.PhoneNumber),
                new SqlParameter("@Fname",customerAccount.Fname),
                new SqlParameter("@Lname", customerAccount.Lname),
                //new SqlParameter("@CreatedDateTime", customerAccount.CreatedDateTime),
            };

            return SqlDBHelper.ExecuteNonQuery("UpdateCustomerAccountById", CommandType.StoredProcedure, parameter);
        }
        //not working well ya ja7ech kenet eleb bl stored procedure ben el parameters w el columns ba3d el update statement
        //w sarlak yomen
        //3am t7awel tchouf wen el mechkle

        public bool AddCustomerAccount(CustomerAccounts customerAccount)
        {


            SqlParameter[] parameter = new SqlParameter[]
            {
                //new SqlParameter("@AccountID",customerAccount.AccountID), should be added automatically in the sql
                new SqlParameter("@Username", customerAccount.Username),
                new SqlParameter("@Password",customerAccount.Password),
                new SqlParameter("@Address1",customerAccount.Address1),
                new SqlParameter("@Email",customerAccount.Email),
                new SqlParameter("@Address2",customerAccount.Address2),
                new SqlParameter("@Address3",customerAccount.Address3),
                new SqlParameter("@PhoneNumber",customerAccount.PhoneNumber),
                new SqlParameter("@Fname",customerAccount.Fname),
                new SqlParameter("@Lname", customerAccount.Lname),
                new SqlParameter("@CreatedDateTime", customerAccount.CreatedDateTime),//should be added automatically in the Bal
            };

            return SqlDBHelper.ExecuteNonQuery("AddCustomerAccount", CommandType.StoredProcedure, parameter);
        }

        public bool DeleteCustomerAccountByID(Int32 AccountID)
        {
            SqlParameter[] parameter = new SqlParameter[]
            {
                new SqlParameter("@AccountID", AccountID),
            };

            return SqlDBHelper.ExecuteNonQuery("[DeleteCustomerAccountByID]", CommandType.StoredProcedure, parameter);

        }
        /*                          ta3allam min a5ta2ak ya m3lm

         public DataTable Da_Select_All_Usernames()
            {
                using (SqlConnection con = new SqlConnection(conString))
                {
                    string query = @"
                         SELECT  [AccountID]
                          ,[Username]
                          ,[Password]
                          ,[Fname]
                          ,[Lname]
                          ,[PhoneNumber]
                          ,[Email]
                          ,[Address1]
                          ,[Address2]
                          ,[Address3]
                          ,[CreatedDateTime]
                          FROM [PrintOrderOnline].[dbo].[CustomerAccounts]";
                    DataTable table = new DataTable();
                    SqlDataReader myReader;
                    using (SqlConnection myCon = new SqlConnection(conString))
                    {
                        myCon.Open();
                        using (SqlCommand myCommand = new SqlCommand(query, myCon))
                        {
                            myReader = myCommand.ExecuteReader();
                            table.Load(myReader); ;

                            myReader.Close();
                            myCon.Close();
                        }
                    }

                    return table;
                }

            }*/

        public bool userlogin(string user, string passw)//checking the user name and password.If matched count 1 not 0.
        {
            SqlConnection con = new SqlConnection(@"Data Source =.; Initial Catalog = PrintOrderOnline; Integrated Security = true");
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("select count(*) from CustomerAccounts where Username='" + user + "'and Password='" + passw + "'", con);
                int a = Convert.ToInt32(cmd.ExecuteScalar());
                return a == 1;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                con.Close();
            }
        }


        public bool AddFile(DocumentFiles file)
        {
            SqlParameter[] param = new SqlParameter[]
            {
                new SqlParameter("@DocumentFileName" ,file.DocumentName),
                new SqlParameter("@UploadDate", file.UploadDate),
                new SqlParameter("@FileSize", file.FileSize),
                new SqlParameter("@FileFormat" , file.FileFormat),
                new SqlParameter("@FileLink" , file.FileLink),
                new SqlParameter("@OrderID" , file.OrderID),
            };
            return SqlDBHelper.ExecuteNonQuery("AddDocumentFiles", CommandType.StoredProcedure, param);

        }

        public List<DocumentFiles> GetFiles()
        {
            List<DocumentFiles>? files = null;


            using (DataTable table = SqlDBHelper.ExecuteSelectCommand("GetDocumentFiles", CommandType.StoredProcedure))
            {
                //check if any record exist or not
                if (table.Rows.Count > 0)
                {
                    //Lets go ahead and create the list of employees
                    files = new List<DocumentFiles>();

                    //Now lets populate the employee details into the list of employees
                    foreach (DataRow row in table.Rows)
                    {

                        DocumentFiles file = new();
                        file.DocumentFileID = Convert.ToInt32(row["DocumentFileID"]);
                        file.UploadDate = Convert.ToDateTime(row["UploadDate"]);
                        file.FileLink = row["FileLink"].ToString();
                        file.DocumentName = row["DocumentFileName"].ToString();
                        file.FileFormat = row["FileFormat"].ToString();
                        file.FileSize = Convert.ToInt32(row["FileSize"]);
                        file.OrderID = Convert.ToInt32(row["OrderID"]);




                        files.Add(file);
                    }
                    
                }
                return files;
            }
        }

        public bool AddOrder(PrintOrders order)
        {
            SqlParameter[] param = new SqlParameter[]
            {
                new SqlParameter("@isBlack", order.isBlack),
                new SqlParameter("@isHightQuality", order.isHighQuality),
                new SqlParameter("@isBorderless", order.isBorderless),
                new SqlParameter("@isDoubleSide", order.isDoubleSide),
                new SqlParameter("@PaperType", order.PaperType),
                new SqlParameter("@OrderStatus", order.OrderStatus),
                new SqlParameter("@WhoOrdered", order.whoOrderedID),
                new SqlParameter("@OrderedDateTime", order.OrderedDateTime),
                new SqlParameter("@price", order.Price),
                new SqlParameter("@size", order.Size),
            };
            return SqlDBHelper.ExecuteNonQuery("AddPrintOrders", CommandType.StoredProcedure, param);

        }
        public bool UpdateOrder(PrintOrders order)
        {

            if (order == null) return false;
            SqlParameter[] parameter = new SqlParameter[]
            {
                new SqlParameter("@OrderID",order.OrderID),
                new SqlParameter("@isBlack", order.isBlack),
                new SqlParameter("@isHightQuality",order.isHighQuality),
                new SqlParameter("@isBorderless",order.isBorderless),
                new SqlParameter("@size",order.Size),
                new SqlParameter("@isDoubleSide",order.isDoubleSide),
                new SqlParameter("@PaperType",order.PaperType),
                new SqlParameter("@OrderStatus",order.OrderStatus),
                new SqlParameter("@OrderDateTime",order.OrderedDateTime),
                new SqlParameter("@price", order.Price),
                new SqlParameter("@WhoOrdered" , order.whoOrderedID)
                //new SqlParameter("@CreatedDateTime", customerAccount.CreatedDateTime),
            };

            return SqlDBHelper.ExecuteNonQuery("UpdatePrinOrderById", CommandType.StoredProcedure, parameter);
        }

        public PrintOrders GetPrintOrderById(int id)
        {
            PrintOrders? order = null;
            SqlParameter[] parameter = new SqlParameter[]
            {
                new SqlParameter("@OrderID",id)
            };
            using (DataTable table = SqlDBHelper.ExecuteParamerizedSelectCommand("GetPrintOrderById", CommandType.StoredProcedure, parameter))
            {
                if (table.Rows.Count > 0)
                {
                    order = new PrintOrders();
                    DataRow row = table.Rows[0];

                    order.OrderID = Convert.ToInt32(row["OrderID"]);
                    order.isBlack= getbool(Convert.ToInt32(row["isBlack"]));
                    order.isHighQuality = getbool(Convert.ToInt32(row["isHightQuality"]));
                    order.isBorderless= getbool(Convert.ToInt32(row["isBorderless"]));
                    order.Size= row["Size"].ToString();
                    order.isDoubleSide= getbool(Convert.ToInt32(row["isDoubleSide"]));
                    order.PaperType= row["PaperType"].ToString();
                    order.OrderStatus= row["OrderStatus"].ToString();
                    order.Price= Convert.ToInt32(row["Price"]);
                    order.whoOrderedID= Convert.ToInt32(row["WhoOrdered"]);
                    order.OrderedDateTime = Convert.ToDateTime(row["OrderedDateTime"]);

                }
            }
            return order;
        }

        public List<PrintOrders> GetPrintOrders()
        {
            List<PrintOrders>? orders = null;
            
            using (DataTable table = SqlDBHelper.ExecuteSelectCommand("GetPrintOrders", CommandType.StoredProcedure))
            {
                if (table.Rows.Count > 0)
                {
                    
                    foreach (DataRow row in table.Rows)
                    {
                        PrintOrders order = new PrintOrders();

                        order.OrderID = Convert.ToInt32(row["OrderID"]);
                        order.isBlack = getbool(Convert.ToInt32(row["isBlack"]));
                        order.isHighQuality = getbool(Convert.ToInt32(row["isHightQuality"]));
                        order.isBorderless = getbool(Convert.ToInt32(row["isBorderless"]));
                        order.Size = row["Size"].ToString();
                        order.isDoubleSide = getbool(Convert.ToInt32(row["isDoubleSide"]));
                        order.PaperType = row["PaperType"].ToString();
                        order.OrderStatus = row["OrderStatus"].ToString();
                        order.Price = Convert.ToInt32(row["Price"]);
                        order.whoOrderedID = Convert.ToInt32(row["WhoOrdered"]);
                        order.OrderedDateTime = Convert.ToDateTime(row["OrderedDateTime"]);

                        orders.Add(order);
                    }
                }
            }
            return orders;
        }
        public bool DeleteOrder(int id)
        {
            SqlParameter[] sp = new SqlParameter[]
            {
                new SqlParameter("@OrderID" , id),
            };

            return SqlDBHelper.ExecuteNonQuery("DeletePrintOrderByID" , CommandType.StoredProcedure, sp);
        }

        public DocumentFiles GetDocumentById(int id)
        {
            DocumentFiles doc = null;
            SqlParameter param = new SqlParameter("@DocumentFileID", id);
            using (DataTable table = SqlDBHelper.ExecuteParamerizedSelectCommand("GetDocumentFileByID", CommandType.StoredProcedure, param))
            {
                if (table.Rows.Count > 0)
                {
                    doc = new DocumentFiles();
                    DataRow row = table.Rows[0];
                    doc.DocumentName = row["DocumentFileName"].ToString();
                    doc.FileSize = Convert.ToInt32(row["FileSize"]);
                    doc.UploadDate = Convert.ToDateTime(row["UploadDateTime"]);
                    doc.FileFormat = row["FileFormat"].ToString() ;
                    doc.FileLink = row["FileLink"].ToString().ToLower() ;
                    doc.OrderID = Convert.ToInt32(row["OrderID"]);
                    
                }
            }
            return doc;
        }
        public static bool getbool(int bit)
        {
            if (bit == 1)
                return true;
            else
                return false;
        }

    }
}
