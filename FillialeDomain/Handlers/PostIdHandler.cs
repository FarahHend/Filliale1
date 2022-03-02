using FillialeDomain.Commands;
using FillialeDomain.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace FillialeDomain.Handlers
{
    public class PostIdHandler<T> : IRequestHandler<PostId<T>, T> where T : class
    {

        private readonly IRepository<T> repository;
        public PostIdHandler(IRepository<T> Repository)
        {
            repository = Repository;
        }
        public Task<T> Handle(PostId<T> request, CancellationToken cancellationToken)
        {
            var result = repository.AddId(request.Obj);
            return Task.FromResult(result);
        }

    }
}
