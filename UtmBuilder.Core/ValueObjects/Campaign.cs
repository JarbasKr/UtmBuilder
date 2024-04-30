using UtmBuilder.Core.ValueObjects.Exceptions;

namespace UtmBuilder.Core.ValueObjects;

public class Campaign : ValueObject
{
    
    /// <summary>
    /// 
    /// </summary>
    /// <param name="source">The referrer (e.g google, newsletter)</param>
    /// <param name="medium">Marketing medium (e.g cpc, banner)</param>
    /// <param name="name">Product, promo code, slogan</param>
    /// <param name="id">The ads campaign id</param>
    /// <param name="term">Identify the paid keywords </param>
    /// <param name="content">Use to differentiate ads</param>
    public Campaign(string source, string medium, string name, string? id = null, string? term = null, string? content = null)
    {
        Source = source;
        Medium = medium;
        Name = name;
        Id = id;
        Term = term;
        Content = content;

        InvalidCampaignException.ThrowIfNull(source,"Source is invalid.");
        InvalidCampaignException.ThrowIfNull(Name,"Name is invalid");
        InvalidCampaignException.ThrowIfNull(Medium,"Medium is invalid");
    }

    public string Medium { get; set;}
    public string Name { get; set;}
    public string Source { get; set; }
    public string? Id { get; set; }
    public string? Term { get; set; }
    public string? Content { get; set; }
}