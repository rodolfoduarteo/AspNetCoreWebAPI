using System.Linq;
using SmartSchool.WebAPI.Models;

namespace SmartSchool.WebAPI.Data
{
    public interface IRepository
    {
         void Add<T>(T entity) where T : class;
         void Update<T>(T entity) where T : class;
         void Remove<T>(T entity) where T : class;
         bool SaveChanges();

         // ALUNOS

         Aluno[] GetAllAlunos(bool includeProfessor);
         Aluno GetAlunoById(int alunoId, bool includeProfessor);
         Aluno[] GetAllAlunosByDisciplinaId(int disciplinaId, bool includeProfessor);

        // PROFESSORES

         Professor[] GetAllProfessores(bool includeAlunos);
         Professor GetProfessoreById(int professorId, bool includeAlunos);
         Professor[] GetAllProfessoresByDisciplinaId(int disciplinaId, bool includeAlunos);

    }
}