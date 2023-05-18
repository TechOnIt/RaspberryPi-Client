using TechOnIt.Infrastructure.WebServices.Techonits.Authentications;
using TechOnIt.Infrastructure.WebServices.Techonits.Devices;

namespace TechOnIt.Infrastructure.WebServices.Techonits;

public interface ITechonitWebService
{
    public IAuthTechonitWebService Auth { get; }
    public IDeviceTechonitWebService Device { get; }
}