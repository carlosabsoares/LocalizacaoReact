using Inlog.Desafio.Backend.Application.Commands;
using Inlog.Desafio.Backend.Application.Commands.AppVeiculos.GetVeiculos;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Inlog.Desafio.Backend.WebApi.Controllers;

[ApiController]
[Route("[controller]")]
public class VeiculoController : ControllerBase
{
    private readonly ILogger<VeiculoController> _logger;
    private readonly IMediator _mediator;

    public VeiculoController(ILogger<VeiculoController> logger, IMediator mediator)
    {
        _logger = logger;
        _mediator = mediator;
    }

    [HttpPost("Cadastrar")]
    public async Task<IActionResult> Cadastrar([FromBody] PostVeiculosCommand dadosDoVeiculo)
    {
        // TODO: Cadastrar um veiculo em memoria ou banco de dados
        var result = await _mediator.Send(dadosDoVeiculo);

        if (!result.Success)
        {
            return new BadRequestObjectResult(result.Data);
        }
        return Ok();
    }

    [HttpGet("Listar")]
    public async Task<IActionResult> ListarVeiculosAsync(
        [FromQuery] GetListarVeiculosQuery query)
    {
        // TODO: retornar todos veiculos
        var result = await _mediator.Send(query);

        if (!result.Success)
        {
            return new BadRequestObjectResult(result.Data);
        }
        return Ok(result.Data);
    }
}