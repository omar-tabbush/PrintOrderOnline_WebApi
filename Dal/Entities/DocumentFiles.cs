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
        public string DocumentName { get; set; }
        public long FileSize { get; set; }
        public string FileFormat { get; set; }

        public DateTime UploadDate { get; set; }
        public string FileLink{ get; set; }
        public int OrderID { get; set; }
    }

}
