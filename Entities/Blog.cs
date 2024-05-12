using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class Blog:BaseModel
    {
        public required  string Description { get; set; }
        public required string Image { get; set; }
        public required string Tags { get; set; }

        public string? Description2 { get; set; }

        public string? Image2 { get; set;}
        public string? Image3 { get; set; }

    }
}
