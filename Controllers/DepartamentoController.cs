using API_Dep_Fun.Models;
using API_Dep_Fun.Repositorios.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API_Dep_Fun.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartamentoController : ControllerBase
    {

        private readonly IDepFunRepositorio _depFunRepositorio;

        public DepartamentoController(IDepFunRepositorio depFunRepositorio)
        {
            _depFunRepositorio = depFunRepositorio;
        }


        [HttpGet("BuscarDeps")]
        public async Task<ActionResult<List<Departamento>>> BuscarTodosDepartamentos() 
        {
            List<Departamento> departamentos = await _depFunRepositorio.BuscarTodosDepartamentos();
            return Ok(departamentos);
        }

        [HttpGet("BuscarDep/{id_dep}")]
        public async Task<ActionResult<Departamento>> BuscarDepartamento(int id_dep)
        {
            Departamento departamento = await _depFunRepositorio.BuscarDepartamento(id_dep);
            return Ok(departamento);
        }

        [HttpPost("AdicionarDep")]

        public async Task<ActionResult<Departamento>> AdicionarDepartamento([FromBody] Departamento departamento) 
        {
            Departamento departamentoModel = await _depFunRepositorio.AdicionarDepartamento(departamento);
            return Ok(departamentoModel);
        }

        [HttpPut("AtualizarDep/{id_dep}")]

        public async Task<ActionResult<Departamento>> AtualizarDepartamento([FromBody] Departamento departamento, int id_dep)
        {
            departamento.Id = id_dep;
            Departamento departamentoModel = await _depFunRepositorio.AtualizarDepartamento(departamento, id_dep);
            return Ok(departamentoModel);
        }

        [HttpDelete("ApagarDep/{id_dep}")]

        public async Task<ActionResult<Departamento>> ApagarDepartamento(int id_dep)
        {
            bool apagado = await _depFunRepositorio.ApagarDepartamento(id_dep);
            return Ok(apagado);
        }

    }
}
