using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace Candlify.Application.Features.Events.Commands.CreateEvent
{
    public class CreateEventCommand : IRequest<CreateEventCommandResponse>
    {
        public string Name { get; set; }
        public DateTime Date {get; set; }

        public override string ToString()
        {
            return $"Event name: {Name}; Date: {Date}";
        }
    }
}
