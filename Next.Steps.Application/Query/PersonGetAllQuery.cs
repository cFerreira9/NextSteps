using MediatR;
using Next.Steps.Application.Dto;
using System.Collections.Generic;

namespace Next.Steps.Application.Query
{
    public class PersonGetAllQuery : IRequest<string>
    {
    }
}