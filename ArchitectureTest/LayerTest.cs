using Microsoft.VisualStudio.TestPlatform.ObjectModel;
using NetArchTest.Rules;
using Shouldly;
using TestResult = NetArchTest.Rules.TestResult;

namespace ArchitectureTest
{
    public class LayerTest : BaseTest
    {
        // Domain Layer
        [Test]
        public void Domain_Should_not_Depend_On_Any_Layer()
        {
            List<string> Assemblies = [
                ApplicationAssembly.GetName().Name,
                InfrastructureAssembly.GetName().Name,
                PresentationAssembly.GetName().Name
                ];

            foreach (var assembly in Assemblies)
            {
                TestResult result = Types.InAssembly(DomainAssembly)
                .ShouldNot()
                .HaveDependencyOn(assembly)
                .GetResult();
                result.IsSuccessful.ShouldBeTrue();
            }
        }
    }
}