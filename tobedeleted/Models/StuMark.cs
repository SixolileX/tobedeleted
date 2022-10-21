using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace tobedeleted.Models
{
    public class StuMark
    {
        [Key]
        public int MarkId { get; set; }
        [DisplayName("Student Name")]
        public string LearnerIdUser { get; set; }
        [DisplayName("Subject Name")]
        public string SubjectName { get; set; }
        [DisplayName("Term 1")]
        public string Term1 { get; set; }
        [DisplayName("Term 2")]
        public string Term2 { get; set; }
        [DisplayName("Term 3")]
        public string Term3 { get; set; }
        [DisplayName("Term 4")]
        public string Term4 { get; set; }
    }
}
