using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Lies.Models
{
    public class UploadContent
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [MaxLength(50, ErrorMessage = "Subject Name can not exceed 50 characters")]
        public string Subject { get; set; }
        [Required]
        public IFormFile Content { get; set; }

    }
}
