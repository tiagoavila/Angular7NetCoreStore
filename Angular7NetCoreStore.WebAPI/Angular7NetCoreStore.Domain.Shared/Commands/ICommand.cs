using FluentValidation.Results;

namespace Angular7NetCoreStore.Domain.Shared.Commands
{
    public interface ICommand
    {
        ValidationResult ValidationResult { get; set; }

        bool IsValid();
    }
}
