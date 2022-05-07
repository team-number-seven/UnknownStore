using System;
using UnknownStore.Common.CQRS;

namespace UnknownStore.BusinessLogic.CQRS.Commands.ModelCommands.CreateModel
{
    public record CreateModelResponse(Guid ModelId) : ResponseBase;
}