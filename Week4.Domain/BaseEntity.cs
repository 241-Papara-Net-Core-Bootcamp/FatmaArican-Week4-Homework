using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week4.Domain
{
    public class BaseEntity
    {
        public int Id { get; set; }
        public DateTime CreateDate { get; set; }
        public string CreateBy { get; set; }
        public DateTime UpdateDate { get; set; }
        public string UpdateBy { get; set; }
        public bool IsDeleted { get; set; }
    }
}
