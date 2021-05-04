using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace SD.Core.Entities.Movies
{
    public class Genre : IEntity
    {

        public Genre()
        {
            this.Movies = new HashSet<Movie>();
        }

        [Key]
        public Guid Id { get; set; }

        public int MoviesId { get; }

        [StringLength(maximumLength: 32, MinimumLength = 2)]
        public string Name { get; set; }


        public virtual ICollection<Movie> Movies { get; set; }

    }
}
