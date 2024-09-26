using PublicApiGenerator;

namespace ZeroRedact.UnitTest.PublicApi
{
    [TestClass]
    public class PublicApiTest : VerifyBase
    {
        [TestMethod]
        public Task CheckForPublicApiChanges()
        {
            var publicApi = typeof(Redactor).Assembly.GeneratePublicApi();

            return Verifier.Verify(publicApi);
        }
    }
}
