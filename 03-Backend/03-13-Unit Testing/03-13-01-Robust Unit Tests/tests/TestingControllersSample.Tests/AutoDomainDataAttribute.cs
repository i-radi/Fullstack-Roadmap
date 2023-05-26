using AutoFixture;
using AutoFixture.AutoMoq;
using AutoFixture.Xunit2;
using TestingControllersSample.Core.Model;

namespace TestingControllersSample.Tests
{
    public class AutoDomainDataAttribute : AutoDataAttribute
    {
        public AutoDomainDataAttribute()
            : base(() =>
            {
                var fixture = new Fixture();
                fixture.Customize<BrainstormSession>(c => c.Do(b => b.AddIdea(fixture.Create<Idea>())));
                fixture.Customize(new AutoMoqCustomization());
                return fixture;
            })
        {
        }
    }
}