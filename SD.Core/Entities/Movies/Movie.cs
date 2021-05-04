using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace SD.Core.Entities.Movies
{
    public class Movie : IEntity
    {
        /* int, long, smallint, Guid und die Id besitzt => PK (Primary Key) */
        [Key]
        public Guid Id { get; set; }

        [Required]
        [MaxLength(64)]
        [MinLength(3)]
        public string Name { get; set; } = string.Empty;

        public decimal Price { get; set; } = 0M;

        [DataType(DataType.Date), DisplayFormat(DataFormatString= "{0:dd/MM/yy}", ApplyFormatInEditMode= true)]
        public DateTime ReleaseDate { get; set; }


        public int GenreId { get; set; }
        public Genre Genre { get; set; }


        public string MediumTypeCode { get; set; }

        [ForeignKey(nameof(Movie.MediumTypeCode))]
        public MediumType MediumType { get; set; }
    }
}
