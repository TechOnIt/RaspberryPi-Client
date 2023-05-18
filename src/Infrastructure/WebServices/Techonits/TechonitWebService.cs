using TechOnIt.Infrastructure.WebServices.Techonits.Authentications;
using TechOnIt.Infrastructure.WebServices.Techonits.Devices;

namespace TechOnIt.Infrastructure.WebServices.Techonits;

public class TechonitWebService : ITechonitWebService
{
    public IAuthTechonitWebService Auth { get; private set; }
    public IDeviceTechonitWebService Device { get; private set; }

    public TechonitWebService(IAuthTechonitWebService auth,
        IDeviceTechonitWebService device)
    {
        Auth = auth;
        Device = device;
    }
}