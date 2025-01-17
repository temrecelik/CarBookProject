﻿using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.Mediator.Commands.FooterAdressCommands
{
    public class RemoveFooterAdressCommand :IRequest
    {
        public RemoveFooterAdressCommand(int ıd)
        {
            Id = ıd;
        }

        public int Id { get; set; }
    }
}
