using System.Collections.Generic;

namespace Angular7NetCoreStore.Domain.Shared.Commands
{
    public interface ICommandResult
    {
        bool Success { get; set; }
        string Message { get; set; }
        object Data { get; set; }
        IEnumerable<string> ErrorMessages { get; set; }
    }
}
