using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace DevResume.Domain.Models
{
    public class FileDataModel
    {
        public string Name { get; set; }
        public Stream Data { get; set; }
    }
}
