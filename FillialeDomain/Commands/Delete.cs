using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace FillialeDomain.Commands
{
    public class Delete<T> : IRequest<string> where T : class
    {
        public Delete(Guid id)
        {
            Id = id;
        }
        public Guid Id { get; }

    }
}
