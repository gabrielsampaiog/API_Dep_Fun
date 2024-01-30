using API_Dep_Fun.Models;
using API_Dep_Fun.Repositorios.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API_Dep_Fun.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FuncionarioController : ControllerBase
    {
        private readonly IDepFunRepositorio _depFunRepositorio;

        public FuncionarioController(IDepFunRepositorio depFunRepositorio)
        {
            _depFunRepositorio = depFunRepositorio;
        }


        [HttpGet("BuscarFuns/{id_dep}")]
        public async Task<ActionResult<List<Funcionario>>> BuscarTodosFuncionarios(int id_dep)
        {
            List<Funcionario> funcionarios = await _depFunRepositorio.BuscarTodosFuncionarios(id_dep);
            return Ok(funcionarios);
        }

        [HttpGet("BuscarFun/{id_fun}")]
        public async Task<ActionResult<Funcionario>> BuscarFuncionario(int id_fun)
        {
            Funcionario funcionario = await _depFunRepositorio.BuscarFuncionario(id_fun);
            return Ok(funcionario);
        }

        [HttpPost("AdicionarFun")]

        public async Task<ActionResult<Funcionario>> AdicionarFuncionario([FromBody] Funcionario funcionario)
        {
            Funcionario funcionarioModel = await _depFunRepositorio.AdicionarFuncionario(funcionario);
            return Ok(funcionarioModel);
        }

        [HttpPut("AtualizarFun/{id_fun}")]

        public async Task<ActionResult<Funcionario>> AtualizarFuncionario([FromBody] Funcionario funcionario, int id_fun)
        {
            funcionario.Id = id_fun;
            Funcionario funcionarioModel = await _depFunRepositorio.AtualizarFuncionario(funcionario, id_fun);
            return Ok(funcionarioModel);
        }

        [HttpDelete("ApagarDep/{id_dep}")]

        public async Task<ActionResult<Funcionario>> ApagarFuncionario(int id_fun)
        {
            bool apagado = await _depFunRepositorio.ApagarFuncionario(id_fun);
            return Ok(apagado);
        }
    }
}
