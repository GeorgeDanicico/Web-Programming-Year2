using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FinalExamASP.Models
{
    public class Document
    {
        public int Id { get; set; }
        public string Title { get; set; }

        public string ListOfTemplates { get; set; }
    }
}
