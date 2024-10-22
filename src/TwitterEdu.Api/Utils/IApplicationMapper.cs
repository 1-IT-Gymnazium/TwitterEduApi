using NodaTime;

namespace TwitterEdu.Api.Utils;

public interface IApplicationMapper
{
}

public class ApplicationMapper(IClock Clock) : IApplicationMapper
{
    public Instant Now => Clock.GetCurrentInstant();
}
