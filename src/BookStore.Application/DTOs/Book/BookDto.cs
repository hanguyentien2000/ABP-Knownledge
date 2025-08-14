using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.DTOs.Book
{
    public class BookDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public float Price { get; set; }
    }

    public class CreateUpdateBookDto
    {
        [Required]
        public string Name { get; set; }

        [Range(0, 9999)]
        public float Price { get; set; }
    }
}
