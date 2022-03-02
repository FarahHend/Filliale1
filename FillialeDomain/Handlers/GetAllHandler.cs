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
    public class GetAllHandler<T> : IRequestHandler<GetAll<T>, IEnumerable<T>> where T : class
    {
        private readonly IRepository<T> repository;

        public GetAllHandler(IRepository<T> Repository)
        {
            repository = Repository;
        }


        public Task<IEnumerable<T>> Handle(GetAll<T> request, CancellationToken cancellationToken)
        {
            var result = repository.GetList(request.Condition, request.Includes);
            return Task.FromResult(result);
        }
    }
}
