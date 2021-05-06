using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace SD.Core.Entities.Movies
{

    public enum MediumTypeEnum
    {
        BR,
        BR4K,
        BR3D,
        BRHDR,
        DVD,
        ST,
    }

    [Table("MediumType")]
    public class MediumType : IEntity
    {
        public MediumType()
        {
            this.Movies = new HashSet<Movie>();
        }

        [Key]
        [MaxLength(8)]
        public string Code { get; set; }

        [Required]
        [MaxLength(32)]
        public string Name { get; set; }

        public ICollection<Movie> Movies { get; }

    }
}
