using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dal.Entities
{
    public class DocumentFiles
    {
        public int DocumentFileID { get; set; }
        public IFormFile Document { get; set; }
        public DateTime UploadDate { get; set; }
        public string FileLink{ get; set; }
    }
}
