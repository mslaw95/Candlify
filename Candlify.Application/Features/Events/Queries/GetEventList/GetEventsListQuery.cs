﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace Candlify.Application.Features.Events.Queries.GetEventList
{
    public class GetEventsListQuery : IRequest<List<EventsListVm>>
    {

    }
}
