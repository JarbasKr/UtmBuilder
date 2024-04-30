using UtmBuilder.Core.ValueObjects;
using UtmBuilder.Core.ValueObjects.Exceptions;

namespace UtmBuilder.Core.Tests.ValueObjects;

[TestClass]
public class CampaignTests
{

    [TestMethod]
    [DataRow("", "", "", true)]
    public void TestCampaign(string source, string medium, string name, bool expectException)
    {
        if (expectException)
        {
            try
            {
                new Campaign (source, medium, name);
            }
            catch (InvalidCampaignException e) when (e.Message.Contains ("Source is invalid"))
            {
                Assert.IsTrue(true);
            }
        }
        else
        {
            new Campaign(source, medium, name);
            Assert.IsTrue(true);
        }
    }
}