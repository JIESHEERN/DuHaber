using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class Comment
    {
        public int CommentID { get; set; }
        public string Description { get; set; }
        public New New { get; set; }
        public int NewID { get; set; }
    }
}
