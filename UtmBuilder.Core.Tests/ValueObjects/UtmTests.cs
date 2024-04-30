using UtmBuilder.Core.ValueObjects;

namespace UtmBuilder.Core.Tests;

[TestClass]
public class UtmTests{

    [TestMethod]
    public void ShouldReturnUrlFromUtm()
    {
        var url = new Url("http");
        var cmp = new Campaign("src", "med", "nme", "id", "ter", "ctn");
        var utm = new Utm(url, cmp);
        var result = "https://jarbas.com/?utm_source=src" + "&utm_medium=med" + "&utm_campaign=nme" + "utm_id=id" + "&utm_term=ter" + "utm_content=ctn";

        Assert.AreEqual(result, utm.ToString());
        
    }

}