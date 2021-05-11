using MediatR;
using SD.Core.Application.Movies.Queries;
using SD.Core.Entities.Movies;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SD.Application.Movies
{
    public class MovieQueryHandler : IRequestHandler<GetAllMoviesQuery, IEnumerable<Movie>>
    {

        public async Task<IEnumerable<Movie>> Handle(GetAllMoviesQuery query, CancellationToken cancellationToken)
        {
            var movies = new List<Movie>();
            return await Task.FromResult(movies);
        }

    }
}