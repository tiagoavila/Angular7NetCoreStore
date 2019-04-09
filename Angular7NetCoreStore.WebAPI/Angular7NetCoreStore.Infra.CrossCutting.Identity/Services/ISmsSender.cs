using System.Threading.Tasks;

namespace Angular7NetCoreStore.Infra.CrossCutting.Identity.Services
{
    public interface ISmsSender
    {
        Task SendSmsAsync(string number, string message);
    }
}
