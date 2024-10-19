﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.DTOs;
using MediatR;

namespace Application.Use_Cases.Queries
{
    public class GetBookByIdQuery : IRequest<BookDto>
    {
        public Guid Id { get; set; }

    }
}
