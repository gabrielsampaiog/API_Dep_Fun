using API_Dep_Fun.Data;
using API_Dep_Fun.Models;
using API_Dep_Fun.Repositorios.Interfaces;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;

namespace API_Dep_Fun.Repositorios
{
    public class DepFunRepositorio : IDepFunRepositorio
    {
        private readonly DepFunContext _dbContext;
        public DepFunRepositorio(DepFunContext depFunContext)
        {
            _dbContext = depFunContext;
        }


        public async Task<Departamento> BuscarDepartamento(int id_dep)
        {
            return await _dbContext.Departamentos.FirstOrDefaultAsync(x => x.Id == id_dep);
        }

        public async Task<List<Departamento>> BuscarTodosDepartamentos()
        {
            return await _dbContext.Departamentos.ToListAsync();
        }


        public async Task<Departamento> AdicionarDepartamento(Departamento departamento)
        {
            await _dbContext.Departamentos.AddAsync(departamento);
            await _dbContext.SaveChangesAsync();

            return departamento;
        }

        public async Task<Departamento> AtualizarDepartamento(Departamento departamento, int id_dep)
        {
            Departamento departamentoPorId = await BuscarDepartamento(id_dep);

            if (departamentoPorId == null) {
                throw new Exception($"O departamento de ID: {id_dep} não foi encontrado no banco de dados.");
            }

            departamentoPorId.Id = departamento.Id;
            departamentoPorId.Nome = departamento.Nome;
            departamentoPorId.Sigla = departamento.Sigla;

            _dbContext.Departamentos.Update(departamentoPorId);
            await _dbContext.SaveChangesAsync();

            return departamentoPorId;
        }

        public async Task<bool> ApagarDepartamento(int id_dep)
        {
            Departamento departamentoPorId = await BuscarDepartamento(id_dep);

            if (departamentoPorId == null)
            {
                throw new Exception($"O departamento de ID: {id_dep} não foi encontrado no banco de dados.");
            }

            _dbContext.Departamentos.Remove(departamentoPorId);
            await _dbContext.SaveChangesAsync();
            return true;
        }




        public async Task<Funcionario> BuscarFuncionario(int id_dep, int id_fun)
        {

            return await _dbContext.Funcionarios.FirstOrDefaultAsync(x => x.DepartamentoId == id_dep && x.Id == id_fun);

        }


        public async Task<List<Funcionario>> BuscarTodosFuncionarios(int id_dep)
        {
            return await _dbContext.Funcionarios.Where(x => x.DepartamentoId == id_dep).ToListAsync();
        }


        public async Task<Funcionario> AdicionarFuncionario(Funcionario funcionario)
        {
            await _dbContext.Funcionarios.AddAsync(funcionario);
            await _dbContext.SaveChangesAsync();

            return funcionario;
        }


        public async Task<Funcionario> AtualizarFuncionario(Funcionario funcionario, int id_fun)
        {
            Funcionario funcionarioPorId = await BuscarFuncionario(funcionario.DepartamentoId,id_fun);

            if (funcionarioPorId == null)
            {
                throw new Exception($"O funcionário de ID: {id_fun} não foi encontrado no banco de dados.");
            }

            funcionarioPorId.Id = funcionario.Id;
            funcionarioPorId.Nome = funcionario.Nome;
            funcionarioPorId.Foto = funcionario.Foto;
            funcionarioPorId.RG = funcionario.RG;
            funcionarioPorId.DepartamentoId = funcionario.DepartamentoId;

            _dbContext.Funcionarios.Update(funcionarioPorId);
            await _dbContext.SaveChangesAsync();


            return funcionarioPorId;
        }


        public async Task<bool> ApagarFuncionario(int id_dep,int id_fun)
        {
            Funcionario funcionarioPorId = await BuscarFuncionario(id_dep, id_fun);

            if (funcionarioPorId == null)
            {
                throw new Exception($"O funcionário de ID: {id_fun} não foi encontrado no banco de dados.");
            }

            _dbContext.Funcionarios.Remove(funcionarioPorId);
            await _dbContext.SaveChangesAsync();
            return true;
        }
    }
}
