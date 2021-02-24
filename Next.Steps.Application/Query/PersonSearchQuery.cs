using MediatR;
using Next.Steps.Application.Dto;

namespace Next.Steps.Application.Query
{
    public class PersonSearchQuery : IRequest<PersonReadDto>
    {
    }
}