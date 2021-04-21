using System.Threading.Tasks;
using harbour.model__views;

namespace harbour.integration
{
    public interface IOpenWeather
    {
        double GetWindSpeed();
    }
}