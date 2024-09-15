using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Candlify.Application.Contracts.Persistence;
using Candlify.Domain.Entities;
using MediatR;

namespace Candlify.Application.Features.Events.Commands.CreateEvent
{
    public class CreateEventCommandHandler(IMapper mapper, IEventRepository eventRepository) : IRequestHandler<CreateEventCommand, CreateEventCommandResponse>
    {
        public async Task<CreateEventCommandResponse> Handle(CreateEventCommand request, CancellationToken cancellationToken)
        {
            var createEventCommandResponse = new CreateEventCommandResponse();

            var validator = new CreateEventCommandValidator(eventRepository);
            var validationResult = await validator.ValidateAsync(request, cancellationToken);
            if (validationResult.Errors.Count > 0)
            {
                createEventCommandResponse.Success = false;
                createEventCommandResponse.ValidationErrors = [];
                foreach (var error in validationResult.Errors)
                {
                    createEventCommandResponse.ValidationErrors.Add(error.ErrorMessage);
                }
            }
            else
            {
                var newEvent = new Event() { Name = request.Name };
                await eventRepository.AddAsync(newEvent);
                createEventCommandResponse.Event = mapper.Map<CreateEventDto>(newEvent);
            }

            return createEventCommandResponse;
        }
    }
}
