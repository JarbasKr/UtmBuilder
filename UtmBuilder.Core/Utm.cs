using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using UtmBuilder.Cora.Extensions;
using UtmBuilder.Core.ValueObjects;
using UtmBuilder.Core.ValueObjects.Exceptions;

namespace UtmBuilder.Core;

public class Utm
{
    public Utm(Url url1, Campaign campaign1)
    {
        url = url1;
        campaign = campaign1;

    }
    public Url url { get; set; }
    public Campaign campaign{ get; set; }

    public static implicit operator string(Utm utm){

        return utm.ToString();
    }
    
    public static implicit operator Utm(string link){
        if(string.IsNullOrEmpty(link)){
            throw new InvalidUrlException();
        }

        var url = new Url(link);
        var segments = url.Address.Split(separator:"?");
        if (segments.Length == 1){
            throw new InvalidUrlException("No segments were provided");
        }

        var pars = segments[1].Split("&");
        var source = pars.Where(x => x.StartsWith("utm_source")).FirstOrDefault("").Split("=")[1];
        var medium = pars.Where(x => x.StartsWith("utm_medium")).FirstOrDefault("").Split("=")[1];
        var name = pars.Where(x => x.StartsWith("utm_campaign")).FirstOrDefault("").Split("=")[1];
        var id = pars.Where(x => x.StartsWith("utm_id")).FirstOrDefault("").Split("=")[1];
        var term = pars.Where(x => x.StartsWith("utm_term")).FirstOrDefault("").Split("=")[1];
        var content = pars.Where(x => x.StartsWith("utm_content")).FirstOrDefault("").Split("=")[1];

        var utm = new Utm (
            new Url(segments[0]),  new Campaign(source, medium, name, id, term, content));

        return utm;
    }

    public override string ToString(){
        var segments = new List<string>();

        segments.AddIfNotNull("utm_source", campaign.Source);
        segments.AddIfNotNull("utm_medium", campaign.Medium);
        segments.AddIfNotNull("utm_campaign", campaign.Name);
        segments.AddIfNotNull("utm_id", campaign.Id ?? string.Empty);
        segments.AddIfNotNull("utm_term", campaign.Term?? string.Empty);
        segments.AddIfNotNull("utm_content", campaign.Content ?? string.Empty);

        return $"{url.Address}?{string.Join("&", segments)}";
        }

    
    // https://balta.io?
    // utm_source=Youtube&
    // utm_medium=social&
    // utm_campaign=BF2022&
    // utm_id = dotnet&
    // utm_content=video-sobre-implicit-operator
}


