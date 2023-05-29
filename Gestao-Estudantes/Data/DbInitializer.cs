using Gestao_Estudantes.Models;

namespace Gestao_Estudantes.Data
{
    public class DbInitializer
    {
        public static void Initialize(Gestao_EstudantesContext context)
        {
            if (context.Estudantes.Any())
            {
                return; // significa que a base de dados já tem dados
            }

            var estudantes = new Estudante[]
            {
                new Estudante{Nome="Carson",Apelido="Alexander",DataInscricao=DateTime.Parse("2019-09-01")},
                new Estudante{Nome="Meredith",Apelido="Alonso",DataInscricao=DateTime.Parse("2017-09-01")},
                new Estudante{Nome="Arturo",Apelido="Anand",DataInscricao=DateTime.Parse("2018-09-01")},
                new Estudante{Nome="Gytis",Apelido="Barzdukas",DataInscricao=DateTime.Parse("2017-09-01")},
                new Estudante{Nome="Yan",Apelido="Li",DataInscricao=DateTime.Parse("2017-09-01")},
                new Estudante{Nome="Peggy",Apelido="Justice",DataInscricao=DateTime.Parse("2016-09-01")},
                new Estudante{Nome="Laura",Apelido="Norman",DataInscricao=DateTime.Parse("2018-09-01")},
                new Estudante{Nome="Nino",Apelido="Olivetto",DataInscricao=DateTime.Parse("2019-09-01")}
            };
            context.Estudantes.AddRange(estudantes);
            context.SaveChanges();

            var cursos = new Curso[]
            {
                new Curso{Id=5324, NomeC="Cálculo", Pontuacao=20},
                new Curso{Id=5243, NomeC="Matemática", Pontuacao=20},
                new Curso{Id=5132, NomeC="Física", Pontuacao=20},
                new Curso{Id=5021, NomeC="Química", Pontuacao=20}
            };
            context.Cursos.AddRange(cursos);
            context.SaveChanges();

            var inscriacaos = new Inscricao[]
            {
                new Inscricao { EstudanteID = 1, CursoID = 5324, Nota = Nota.A },
                new Inscricao { EstudanteID = 1, CursoID = 5243, Nota = Nota.D },
                new Inscricao { EstudanteID = 2, CursoID = 5132, Nota = Nota.B },
                new Inscricao { EstudanteID = 3, CursoID = 5021, Nota = Nota.C }
            };
            context.Inscricaos.AddRange(inscriacaos);
            context.SaveChanges();
        }
    }
}
