using UtmBuilder.Core.ValueObjects;
using UtmBuilder.Core.ValueObjects.Exceptions;

namespace UtmBuilder.Core.Tests.ValueObjects;

[TestClass]
public class UrlTests{

    private const string InvalidUrl = "Fail";
    private const string ValidUrl = "https://jarbas.com";

    [TestMethod("Deve retornar uma exceção quando uma URL for inválida.")]
    [TestCategory("Teste de URL")]
    [ExpectedException(typeof(InvalidUrlException))]
    public void ReturnExceptionWhenUrlIsInvalid()
    {
        new Url(InvalidUrl);
    }

    public void DoesNotReturnExceptionWhenUrlIsInvalid()
    {
        new Url(ValidUrl);
        Assert.IsTrue(true);
    }

    [TestMethod]
    [DataRow(" ")]
    [DataRow("http")]
    [DataRow("fail")]
    [DataRow("https://jarbas.com")]
    
    public void TestUrl(string link, bool expectException){

        if(expectException)
        {
            try
            {
                new Url (link);
                Assert.Fail(link);
            }
            catch (InvalidUrlException e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
        else
        {
            new Url (link);
            Assert.IsTrue(true);
        }
    }
    
}