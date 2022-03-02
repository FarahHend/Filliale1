using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace FillialeDomain.Commands
{
    public class Put<T> : IRequest<string> where T : class
    {
        public Put(T obj)
        {
            Obj = obj;
        }

        public T Obj { get; set; }
    }
}
