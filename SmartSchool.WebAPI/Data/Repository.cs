using System.Linq;
using Microsoft.EntityFrameworkCore;
using SmartSchool.WebAPI.Models;

namespace SmartSchool.WebAPI.Data
{
    public class Repository : IRepository
    {
        private DataContext _context { get; set; }
        public Repository(DataContext context)
        {
            _context = context;

        }
        public void Add<T>(T entity) where T : class
        {
            _context.Add(entity);
        }

        public void Update<T>(T entity) where T : class
        {
            _context.Update(entity);
        }
        public void Remove<T>(T entity) where T : class
        {
            _context.Remove(entity);
        }

        public bool SaveChanges()
        {
            return (_context.SaveChanges() > 0);
        }

        public Aluno[] GetAllAlunos(bool includeProfessor)
        {

            IQueryable<Aluno> query = _context.Alunos;

            if(includeProfessor)
            {
            query = query.Include(a => a.AlunosDisciplinas)
            .ThenInclude(ad => ad.Disciplina)
            .ThenInclude(d => d.Professor);
            }

            query = query.AsNoTracking().OrderBy(a => a.Id);
            return query.ToArray();
        }

        public Aluno GetAlunoById(int alunoId, bool includeProfessor = false)
        {

            var query = _context.Alunos.Where(a => a.Id == alunoId);

            if(includeProfessor)
            {
            query = query
            .Include(x => x.AlunosDisciplinas)
            .ThenInclude(ad => ad.Disciplina)
            .ThenInclude(d => d.Professor);
            }

            return query.AsNoTracking().FirstOrDefault();
        }

        public Aluno[] GetAllAlunosByDisciplinaId(int disciplinaId, bool includeProfessor = false)
        {
            IQueryable<Aluno> query = _context.Alunos;

            if(includeProfessor)
            {
            query = query
            .Include(x => x.AlunosDisciplinas)
            .ThenInclude(ad => ad.Disciplina)
            .ThenInclude(d => d.Professor);
            }

            query = query.AsNoTracking()
                            .OrderBy(a => a.Id)
                            .Where(aluno => aluno.AlunosDisciplinas.Any(ad => ad.DisciplinaId == disciplinaId));

            return query.ToArray();
        }

        public Professor[] GetAllProfessores(bool includeAlunos = false)
        {
            IQueryable<Professor> query = _context.Professores;

            if(includeAlunos)
            {
            query = query.Include(p => p.Disciplina)
                            .ThenInclude(ad => ad.AlunosDisciplinas)
                            .ThenInclude(a => a.Aluno);
            }

            query = query.AsNoTracking().OrderBy(a => a.Id);
            return query.ToArray();
        }

        public Professor GetProfessoreById(int professorId, bool includeAlunos = false)
        {
            IQueryable<Professor> query = _context.Professores;

            if(includeAlunos)
            {
            query = query.Include(p => p.Disciplina)
            .ThenInclude(ad => ad.AlunosDisciplinas)
            .ThenInclude(a => a.Aluno);
            }

            query = query.AsNoTracking()
                         .OrderBy(a => a.Id)
                         .Where(p => p.Id == professorId);
            

            return query.FirstOrDefault();
        }

        public Professor[] GetAllProfessoresByDisciplinaId(int disciplinaId, bool includeAlunos = false)
        {
            IQueryable<Professor> query = _context.Professores;

            if(includeAlunos)
            {
            query = query.Include(p => p.Disciplina)
            .ThenInclude(ad => ad.AlunosDisciplinas)
            .ThenInclude(a => a.Aluno);
            }

            query = query.AsNoTracking()
                            .OrderBy(p => p.Id)
                            .Where(professor => professor.Disciplina.Any(x => x.Id == disciplinaId));


            return query.ToArray();
        }
    }
}