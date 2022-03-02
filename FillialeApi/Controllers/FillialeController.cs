using AutoMapper;
using FillialeApi.DTOs;
using FillialeDomain.Commands;
using FillialeDomain.Models;
using FillialeDomain.Queries;
using MediatR;
using Microsoft.AspNetCore.Components.Routing;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FillialeApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FillialeController : ControllerBase
    {

        public readonly IMediator _mediator;
        private readonly IMapper _mapper;
        public FillialeController(IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;

        }

        #region Standard WebMethods
        [HttpGet("GetAll")]
        public IEnumerable<Filliale> Get()
        {
            return _mediator.Send(new GetAll<Filliale>())
                .Result.Select(comp => _mapper.Map<Filliale>(comp));
        }


        [HttpGet("{id}")]
        public Filliale Get(Guid id)
        {
            //Filliale Filliale = _mediator.Send(new GetById<Filliale>(condition: c => c.FillialeId == id)).Result;
            //return _mapper.Map<FillialeDTO>(Filliale);
            // return _mapper.ProjectTo<FillialeDTO>(_DbContext.Filliale.Where(x => x.FillialeId == id)).ToList();
            //var Filliale = _dbContext.Exercises.Where(x => x.Id == id).ToList();
            //return _mapper.Map<IEnumerable< FillialeDTO>>(Filliale);
            var filliale= _mediator.Send(new GetById<Filliale>(condition: c => c.FillialeId == id)).Result;
            return _mapper.Map<Filliale>(filliale);
        }


        [HttpPost("PostFilliale")]
        public async Task<Filliale> Post(Filliale Filliale)
        {
            return await _mediator.Send(new PostId<Filliale>(Filliale));
        }


        [HttpPut("PutFilliale")]
        public async Task<string> Put(Filliale Filliale)
        {
            return await _mediator.Send(new Put<Filliale>(Filliale));
        }


        [HttpDelete("DeleteFilliale")]
        public async Task<string> Delete(Guid id)
        {
            return await _mediator.Send(new Delete<Filliale>(id));
        }
        #endregion


    }
}
