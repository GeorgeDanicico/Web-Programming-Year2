using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExamASP_PersonChannel.Models
{
    public class Channel
    {
        public int Id { get; set; }
        public int OwnerId { get; set; }
        public string Name { get; set; }

        public string Description { get; set; }

        public string subscribers { get; set; }

    }
}
