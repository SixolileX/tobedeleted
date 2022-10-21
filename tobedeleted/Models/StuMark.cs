using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace tobedeleted.Models
{
    public class StuMark
    {
        [Key]
        public int MarkId { get; set; }
        public string LearnerIdUser { get; set; }
        public string SubjectName { get; set; }
        public string Term1 { get; set; }
        public string Term2 { get; set; }
        public string Term3 { get; set; }
        public string Term4 { get; set; }
    }
}
