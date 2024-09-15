using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Candlify.Application.Responses;

namespace Candlify.Application.Features.Events.Commands.CreateEvent
{
    public class CreateEventCommandResponse: BaseResponse
    {
        public CreateEventDto? Event { get; set; } = default;

        public CreateEventCommandResponse() : base()
        {
        }
    }
}
