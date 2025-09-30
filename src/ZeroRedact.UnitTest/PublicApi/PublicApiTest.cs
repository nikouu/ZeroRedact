using PublicApiGenerator;
using System.Runtime.CompilerServices;
using System.Runtime.Versioning;

namespace ZeroRedact.UnitTest.PublicApi
{
    [TestClass]
    public class PublicApiTest : VerifyBase
    {
        [TestMethod]
        public Task CheckForPublicApiChanges()
        {
            var assembly = typeof(Redactor).Assembly;
            var options = new ApiGeneratorOptions
            {
                ExcludeAttributes =
                [
                    typeof(InternalsVisibleToAttribute).FullName!,
                    typeof(TargetFrameworkAttribute).FullName!
                ]
            };

            var publicApi = assembly.GeneratePublicApi(options);

            return Verifier.Verify(publicApi);
        }
    }
}
