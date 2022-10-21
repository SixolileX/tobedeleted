using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using tobedeleted.Interface;

namespace tobedeleted.Entities
{
    public class MediaType: IPrimaryProperties
    {
        public int Id { get; set; }

        [Required]
        [StringLength(200, MinimumLength = 2)]
        public string Title { get; set; }

        [Required]
        public string ThumbnailmagePath { get; set; }

        [ForeignKey("MediaTypeId")]
        public ICollection<CategoryItem> CategoryItems { get; set; }
    }
}
