using Application.Abstract;
using Application.Enum;
using Newtonsoft.Json;

namespace Application.Entities
{
    public class NumericService : DataService
    {
        public NumericService(DataDict dataDict) : base(dataDict)
        {
            this.Dictionary = dataDict;
        }

        protected override async Task<ServiceState> Process()
        {
            try
            {
                HttpClient client = new HttpClient();
                var result = await client.GetAsync("https://api.coinbase.com/v2/exchange-rates?currency=USD");
                var content = await result.Content.ReadAsStringAsync();
                Rootobject dataJson = JsonConvert.DeserializeObject<Rootobject>(content.ToString());
                this.Dictionary.Text = ServiceState.Accepted + " - " + (double.Parse(this.Dictionary.Text) * double.Parse(dataJson.data.rates.COP)).ToString();
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
