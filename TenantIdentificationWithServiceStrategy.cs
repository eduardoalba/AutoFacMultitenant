using Autofac.Multitenant;

namespace AutoFacSample
{
    public class TenantIdentificationWithServiceStrategy : ITenantIdentificationStrategy
    {
        private readonly IServiceLevel _serviceLevel;

        public TenantIdentificationWithServiceStrategy(IServiceLevel serviceLevel)
        {
            _serviceLevel = serviceLevel;
        }

        public string Letter { get; set; }

        public bool TryIdentifyTenant(out object tenantId)
        {
            tenantId = _serviceLevel.GetLevelByLetter(Letter);

            if (tenantId == null) return false;

            return true;
        }
    }
}
