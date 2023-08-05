using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Text;

namespace EventManagement.BusinessLayer.ViewModels
{
    public class EventViewModel
    {
        [Key]
        public long Id { get; set; }
        [Required]
        [StringLength(20, MinimumLength = 3, ErrorMessage = "Minimum 3 Maximum 20 characters")]
        public string Name { get; set; }

        [Required]
        [StringLength(200, MinimumLength = 5, ErrorMessage = "Minimum 5 Maximum 200 characters")]
        public string Description { get; set; }

        [Required]
        public string Status { get; set; }
    }
}
