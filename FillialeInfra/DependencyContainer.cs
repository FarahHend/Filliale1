using FillialeData.Context;
using FillialeData.Repository;
using FillialeDomain.Commands;
using FillialeDomain.Handlers;
using FillialeDomain.Interfaces;
using FillialeDomain.Models;
using FillialeDomain.Queries;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace FillialeInfra
{
    public class DependencyContainer
    {
        public static void RegisterServices(IServiceCollection services)
        {
            services.AddTransient<FillialeContext>();
         

            services.AddTransient<IRepository<Filliale>, Repository<Filliale>>();
            services.AddTransient<IRequestHandler<Post<Filliale>, string>, PostHandler<Filliale>>();
            services.AddTransient<IRequestHandler<PostId<Filliale>, Filliale>, PostIdHandler<Filliale>>();
            services.AddTransient<IRequestHandler<GetAll<Filliale>, IEnumerable<Filliale>>, GetAllHandler<Filliale>>();
            services.AddTransient<IRequestHandler<GetById<Filliale>, Filliale>, GetByIdHandler<Filliale>>();
            services.AddTransient<IRequestHandler<Put<Filliale>, string>, PutHandler<Filliale>>();
            services.AddTransient<IRequestHandler<Delete<Filliale>, string>, DeleteHandler<Filliale>>();


        }
    }
}
