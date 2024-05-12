using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class Solution:BaseModel
    {
        public required string Description { get; set; }
        public required string Image { get; set; }
    }
}
