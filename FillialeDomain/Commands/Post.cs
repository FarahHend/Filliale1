using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace FillialeDomain.Commands
{
    public class Post<T> : IRequest<string> where T : class
    {
        public Post(T obj)
        {
            Obj = obj;
        }
        public T Obj { get; }



    }
}
