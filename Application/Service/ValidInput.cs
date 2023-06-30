using Application.Entities;

namespace Application.Service
{
    public class ValidInput : IValidInput
    {
        public async Task<DataDict> SetInput(DataDict dataDict)
        {
            bool isNumber = int.TryParse(dataDict.Text, out int value);            
            if (isNumber)
            {
                NumericService numericService = new NumericService(dataDict);
                await numericService.StartService();
                return numericService.Dictionary;
            }
            AlphanumericService alphanumericService = new AlphanumericService(dataDict);
            await alphanumericService.StartService();
            return alphanumericService.Dictionary;

        }
    }
}
