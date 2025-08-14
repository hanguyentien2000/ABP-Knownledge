using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.DTOs.Area
{
    public class AreaDto
    {
        public Guid Id { get; set; }
        public string Location { get; set; }
        public float Population { get; set; }
    }

    public class CreateUpdateBookDto
    {
        [Required]
        public string Location { get; set; }

        [Range(0, 9999)]
        public float Population { get; set; }
    }
}
