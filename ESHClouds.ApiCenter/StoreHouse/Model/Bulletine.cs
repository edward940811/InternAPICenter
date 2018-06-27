using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace ESHClouds.ApiCenter.StoreHouse.Model
{
    public class Bulletine
    {
        public string Id { get; set; }
        public string CompanyId { get; set; }
        public string Module { get; set; }
        public string FileName { get; set; }
        //public Stream UploadedFile { get; set; }
        public string UserId { get; set; }
    }
}
