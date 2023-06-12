using AnketFinal.Model;
using Newtonsoft.Json;

namespace AnketFinal.Services;

public class AnketService
{
    //HttpClient httpClient;
    //public AnketService()
    //{
    //    httpClient = new HttpClient();
    //}
    
    Root anketList = new();
    public async Task<Root>GetAnkets()
    {
        //if (anketList.Count > 0)
        //    return anketList;
 

        using var stream = await FileSystem.OpenAppPackageFileAsync("Results.json");
        using var reader = new StreamReader(stream);
        string contents = await reader.ReadToEndAsync();
        anketList = JsonConvert.DeserializeObject<Root>(contents);

        return anketList;
    }
}
