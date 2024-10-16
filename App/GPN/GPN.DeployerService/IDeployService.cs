using System.Threading.Tasks;

namespace GPN.InternalDeployer
{
    public interface IDeployService
    {
        Task Deploy(int? num = null);
    }
}
