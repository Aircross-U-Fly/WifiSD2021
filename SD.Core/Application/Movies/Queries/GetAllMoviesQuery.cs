using MediatR;
using SD.Core.Entities.Movies;
using System;
using System.Collections.Generic;
using System.Text;

namespace SD.Core.Application.Movies.Queries
{
    public class GetAllMoviesQuery : IRequest<IEnumerable<Movie>>
    {
        public int Take { get; set; }
        public int Skip { get; set; }
    }
}
