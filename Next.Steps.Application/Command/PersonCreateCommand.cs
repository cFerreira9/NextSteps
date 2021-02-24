﻿using MediatR;
using Next.Steps.Application.Dto;

namespace Next.Steps.Application.Command
{
    public class PersonCreateCommand : IRequest
    {
        public PersonWriteDto Person;
    }
}