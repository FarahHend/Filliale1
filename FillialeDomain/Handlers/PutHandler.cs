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
    public class PutHandler<T> : IRequestHandler<Put<T>, string> where T : class
    {
        private readonly IRepository<T> repository;

        public PutHandler(IRepository<T> Repository)
        {
            repository = Repository;
        }
        public Task<string> Handle(Put<T> request, CancellationToken cancellationToken)
        {
            var result = repository.Update(request.Obj);
            //save to database
            return Task.FromResult(result);
        }

    }
}
