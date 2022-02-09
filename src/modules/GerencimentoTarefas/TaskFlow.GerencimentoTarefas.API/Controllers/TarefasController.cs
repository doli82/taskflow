using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using TaskFlow.GerenciamentoTarefas.Domain.Repositories;
using TaskFlow.GerencimentoTarefas.API.Models.Input;

namespace TaskFlow.GerencimentoTarefas.API.Controllers
{
	[Route("api/[controller]")]
    [ApiController]
    public class TarefasController : ControllerBase
    {
        private readonly ITarefaRepository _tarefaRepository;

        public TarefasController(ITarefaRepository tarefaReposity)
        {
            _tarefaRepository = tarefaReposity;
        }

        [HttpPost("registrar")]
        public IActionResult Registrar(TarefaInputModel inputModel)
        {
            return Ok();
        }


    }
}
