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
    public class PostHandler<T> : IRequestHandler<Post<T>, string> where T : class
    {

        private readonly IRepository<T> repository;
        public PostHandler(IRepository<T> Repository)
        {
            repository = Repository;
        }
        public Task<string> Handle(Post<T> request, CancellationToken cancellationToken)
        {
            var result = repository.Add(request.Obj);
            return Task.FromResult(result);
        }

    }
}
