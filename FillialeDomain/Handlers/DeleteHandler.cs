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
    public class DeleteHandler<T> : IRequestHandler<Delete<T>, string> where T : class
    {
        private readonly IRepository<T> repository;
        public DeleteHandler(IRepository<T> Repository)
        {
            repository = Repository;
        }


        public Task<string> Handle(Delete<T> request, CancellationToken cancellationToken)
        {
            var result = repository.Remove(request.Id);
            return Task.FromResult(result);
        }
    }
}
