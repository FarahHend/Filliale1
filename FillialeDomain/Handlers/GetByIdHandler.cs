using FillialeDomain.Interfaces;
using FillialeDomain.Queries;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace FillialeDomain.Handlers
{
    public class GetByIdHandler<T> : IRequestHandler<GetById<T>, T> where T : class
    {

        private readonly IRepository<T> repository;

        public GetByIdHandler(IRepository<T> Repository)
        {
            repository = Repository;
        }
        public Task<T> Handle(GetById<T> request, CancellationToken cancellationToken)
        {
            var result = repository.Get(request.Condition, request.Includes);
            return Task.FromResult(result);
        }


    }
}
