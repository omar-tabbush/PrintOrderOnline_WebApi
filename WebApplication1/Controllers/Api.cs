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

        [HttpGet(Name = "Get-All-Customers")]
        public List<CustomerAccounts> GetCustomersAccounts()
        {
            Blc blc = new Blc();
            return blc.BL_GetCustomerAccounts();
        }



        [HttpGet(Name = "Get-Customer-By-Id")]
        public CustomerAccounts GetCustomerByID(Int32 id)
        {
            Blc blc = new Blc();
            return blc.BL_GetCustomerAccountByID(id);
        }


        [HttpPut(Name = "Update-By-Id")]
        public IActionResult UpdateById(Int32 id,CustomerAccounts customerAccount)
        {
            
            Blc blc = new Blc();
            if (blc.BL_UpdateCustomerById( id, customerAccount))
                return Ok();
            else
                return BadRequest();
        }


        [HttpPost(Name ="create-Customer-Account")]
        public IActionResult AddCustomerAccount(CustomerAccounts customerAccount)
        {
            Blc blc = new Blc();
            if (blc.BL_AddCustomerAccount(customerAccount))
                return Ok();
            else
                return BadRequest();
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

        [HttpHead(Name ="login")]
        public IActionResult Login(string username, string passw)
        {
            Blc blc = new();
            if (blc.bllog(username,passw))
                return Ok();
            else
                return BadRequest();
        }


        [HttpPost(Name = "add-file")]
        public IActionResult AddFile(IFormFile document , string filelink)
        {
            DocumentFiles documentFile = new DocumentFiles();
            documentFile.Document = document;
            documentFile.FileLink = filelink;
            Blc blc = new Blc();
            if (blc.AddFile(documentFile)) return Ok();
            else return BadRequest();
            
        }
    }
}