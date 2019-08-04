using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DummyModels
{
    public class DummyModel
    {
        [Required]
        [Key, Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }

        public OwnedModel OwnedModel { get; set; }
    }
}
