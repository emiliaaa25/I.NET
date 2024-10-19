using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Use_Cases.Commands;
using AutoMapper;
using Domain.Repositories;
using MediatR;

namespace Application.Use_Cases.ComandHandlers
{
    public class UpdateBookCommandHandler : IRequestHandler<UpdateBookCommand, Guid>
    {
        private readonly IBookRepository repository;
        private readonly IMapper mapper;

        public UpdateBookCommandHandler(IBookRepository repository, IMapper mapper)
        {
            this.repository = repository;
            this.mapper = mapper;
        }

        public async Task<Guid> Handle(UpdateBookCommand request, CancellationToken cancellationToken)
        {
            if (request.Id == Guid.Empty)
            {
                throw new ArgumentException("Id cannot be empty");
            }

            var book = await repository.GetByIdAsync(request.Id) ?? throw new ArgumentException("Book not found");
            mapper.Map(request, book);
            await repository.UpdateAsync(book);

            return book.Id;
        }


    }
}
