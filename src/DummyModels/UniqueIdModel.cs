using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace DummyModels
{
    public class UniqueIdModel
    {
        [NotMapped]
        [Required, Column(Order = 0), MinLength(36), MaxLength(36)]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid UniqueId { get; set; }
    }
}
