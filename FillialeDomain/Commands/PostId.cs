using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace FillialeDomain.Commands
{
    public class PostId<T> : IRequest<T> where T : class
    {
        public T Obj { get; }
        public PostId(T obj)
        {
            Obj = obj;
        }



    }
}
