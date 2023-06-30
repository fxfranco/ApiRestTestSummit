using Application.Entities;

namespace Application.Service
{
    public interface IValidInput
    {
        public Task<DataDict> SetInput(DataDict input);
    }
}
