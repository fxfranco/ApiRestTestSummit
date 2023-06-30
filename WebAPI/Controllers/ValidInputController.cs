using Application.Entities;
using Application.Enum;
using Application.Service;
using Microsoft.AspNetCore.Mvc;
using WebAPI.DTOs;

namespace WebAPI.Controllers
{
    [ApiController]
    [Route("Input")]
    public class ValidInputController : ControllerBase
    {
        private readonly IValidInput validInput;

        public ValidInputController(IValidInput _validInput)
        {
            this.validInput = _validInput;
        }

        [HttpPost]
        [Route("validarInput")]
        public async Task<DataDict> ValidarInput([FromBody] InputDTO inputDTO)
        {
            if (inputDTO == null) {
                return new DataDict
                {
                    MessageError = "No hay datos",
                    Text = ServiceState.Aborted.ToString(),
                };
            }

            if (inputDTO.Input.Length<=0)
            {
                return new DataDict
                {
                    MessageError = "No hay texto",
                    Text = ServiceState.Rejected.ToString(),
                };
            }

            return await this.validInput.SetInput(new DataDict
            {
                MessageError = "",
                Text = inputDTO.Input
            });
        }
    }
}
