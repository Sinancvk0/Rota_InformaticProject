
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class Service:BaseModel
    {
        public required string Description { get; set; }
        public required string Image  { get; set; }
    }
}
