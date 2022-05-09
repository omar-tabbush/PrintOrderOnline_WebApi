using Microsoft.AspNetCore.Mvc;
using Bl;
using Dal;
using Dal.Entities;
using Azure.Storage.Blobs;

namespace WebApplication1.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class Api : ControllerBase
    {
        //private readonly BlobServiceClient _blobServiceClient;
        private readonly ILogger<Api> _logger;
        private readonly IConfiguration _configuration;

        public Api(ILogger<Api> logger, IConfiguration configuration/* ,BlobServiceClient  blobServiceClient*/)
        {
            _logger = logger;
            _configuration = configuration;
            //_blobServiceClient = blobServiceClient;
        }

        #region customers accounts CRUD

        [HttpGet(Name = "Get-All-Customers")]
        public async Task<List<CustomerAccounts>> GetCustomersAccounts()
        {
            Blc blc = new Blc();
            return await blc.BL_GetCustomerAccounts();
        }


        [HttpGet(Name = "Get-Customer-By-Id")]
        public async Task<CustomerAccounts>GetCustomerByID(Int32 id)
        {
            Blc blc = new Blc();
            return await blc.BL_GetCustomerAccountByID(id);
        }


        [HttpPut(Name = "Update-customer-By-Id")]
        public IActionResult UpdateById(Int32 id,CustomerAccounts customerAccount)
        {
            
            Blc blc = new Blc();
            return Ok(blc.BL_UpdateCustomerById(id, customerAccount));
        }


        [HttpPost(Name ="create-Customer-Account")]
        public IActionResult AddCustomerAccount(CustomerAccounts customerAccount)
        {
            Blc blc = new Blc();
            
            return Ok(blc.BL_AddCustomerAccount(customerAccount));
        }


        [HttpDelete(Name = "Delete-Customer-Account-By-Id")]
        public IActionResult DeleteCustomerAccountByID(Int32 id)
        {
            Blc blc = new Blc();
            if (blc.BL_DeleteCustomerAccountByID(id))
                return Ok();
            else
                return BadRequest();
        }

        #endregion
        
        #region login?
        [HttpHead(Name ="login")]
        public IActionResult Login(string username, string passw)
        {
            Blc blc = new();
            if (blc.bllog(username,passw))
                return Ok();
            else
                return BadRequest();
        }
        #endregion
        
        #region document files CRD (please add Delete action
        [HttpPost(Name = "add-file")]
        public IActionResult AddFile(IFormFile filse , string medialink , int orderid)
        {
            
            Blc blc = new Blc();
            if (blc.AddFile(filse,medialink, orderid)) return Ok();
            else return BadRequest();
            
        }
        
        

        [HttpGet(Name ="get-files")]
        public List<DocumentFiles> GetFiles()
        {
            Blc blc = new Blc();
            List<DocumentFiles> files = blc.GetFiles();
            return files;
        }


        [HttpGet(Name ="get-file-by-id")]
        public DocumentFiles GetFileByid(Int32 id)
        {
            Blc blc = new();
            return blc.GetDocumentById(id);
        }

        #endregion please add delete action
        
        #region orders CRUD
        [HttpPost(Name = "add-Order")]
        public IActionResult AddOrder(PrintOrders order)
        {
            Blc blc = new();
            if (blc.BL_AddOrder(order))
                return Ok();
            else
                return BadRequest();
        }
        
        
        [HttpGet(Name ="get-order-by-id")]
        public PrintOrders getOrderById(Int32 id)
        {
            Blc blc = new();
            return blc.GetPrintOrderById(id);
        }


        [HttpPut(Name ="update-order-by-id")]
        public IActionResult UpdateOrderById(PrintOrders order)
        {
            Blc blc = new();
            return Ok(blc.UpdateOrder(order));
        }
        

        [HttpDelete(Name ="delete-order-by-id")]
        public IActionResult DeleteOrderById(Int32 id)
        {
            Blc blc = new();
            if (blc.DeleteOrder(id))
                return Ok();
            else
                return NotFound();
        }


        [HttpGet(Name = "get-orders")]
        public List<PrintOrders> GetOrders()
        {
            Blc blc = new();
            return blc.GetPrintOrders();
        }
        #endregion



    }
}