using Angular7NetCoreStore.Domain.Shared.Commands;
using FluentValidation.Results;
using System.Collections.Generic;
using System.Linq;

namespace Angular7NetCoreStore.Domain.Commands.Outputs
{
    public class CommandResult : ICommandResult
    {
        public CommandResult(bool success, string message, object data)
        {
            Success = success;
            Message = message;
            Data = data;
        }

        public CommandResult(ValidationResult validationResult)
        {
            Success = validationResult.IsValid;
            ErrorMessages = validationResult.Errors.Select(e => e.ErrorMessage);
        }

        public CommandResult(bool success, IEnumerable<string> errorMessages)
        {
            Success = success;
            ErrorMessages = errorMessages;
        }

        public CommandResult(bool success, string errorMessage)
        {
            Success = success;
            ErrorMessages = new List<string> { errorMessage };
        }

        public bool Success { get; set; }
        public string Message { get; set; }
        public object Data { get; set; }
        public IEnumerable<string> ErrorMessages { get; set; }
    }
}
