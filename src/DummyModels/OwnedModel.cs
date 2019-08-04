using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DummyModels
{
    [Owned]
    public class OwnedModel
    {
        [Column(nameof(RequiredField))]
        [Required]
        public string RequiredField { get; set; }
    }
}
