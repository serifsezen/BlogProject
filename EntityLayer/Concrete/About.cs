using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
   public class About
    {
        [Key]
        public int AboutId { get; set; }

        public string AboutContent1 { get; set; }

        [StringLength(100)]
        public string AboutImage1 { get; set; }

        public string AboutContent2 { get; set; }

        [StringLength(100)]
        public string AboutImage2 { get; set; }

        public string AboutContentShort { get; set; }

        public string AboutContentShortImage { get; set; }
    }
}
