using Application.Abstract;
using Application.Enum;
using Newtonsoft.Json;

namespace Application.Entities
{
    public class AlphanumericService : DataService
    {
        public AlphanumericService(DataDict dataDict) : base(dataDict)
        {
            this.Dictionary = dataDict;
        }

        protected override async Task<ServiceState> Process()
        {
            try
            {
                HttpClient client = new HttpClient();
                string url = "https://api.dictionaryapi.dev/api/v2/entries/en/" + this.Dictionary.Text;
                var result = await client.GetAsync(url);
                var content = await result.Content.ReadAsStringAsync();
                List<Dictionary> dataJson = JsonConvert.DeserializeObject<List<Dictionary>>(content.ToString());
                this.Dictionary.Text = ServiceState.Accepted + " - "+dataJson.FirstOrDefault().meanings.FirstOrDefault().definitions.FirstOrDefault().definition;
                return ServiceState.Accepted;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return ServiceState.Rejected;
            }            
        }        
    }
}
