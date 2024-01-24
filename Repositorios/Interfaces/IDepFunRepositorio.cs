using API_Dep_Fun.Models;

namespace API_Dep_Fun.Repositorios.Interfaces
{
    public interface IDepFunRepositorio
    {
        Task<List<Departamento>> BuscarTodosDepartamentos();
        Task<Departamento> BuscarDepartamento(int id_dep);
        Task<Departamento> AdicionarDepartamento(Departamento departamento);
        Task<Departamento> AtualizarDepartamento(Departamento departamento, int id_dep);
        Task<bool> ApagarDepartamento(int id_dep);

        Task<List<Funcionario>> BuscarTodosFuncionarios(int id_dep);
        Task<Funcionario> BuscarFuncionario(int id_dep, int id_fun);
        Task<Funcionario> AdicionarFuncionario(Funcionario funcionario);
        Task<Funcionario> AtualizarFuncionario(Funcionario funcionario, int id_fun);
        Task<bool> ApagarFuncionario(int id_dep,int id_fun);

    }
}
