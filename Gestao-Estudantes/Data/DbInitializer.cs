using Gestao_Estudantes.Models;
using System.Diagnostics;

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

            var alexander = new Estudante
            {
                Nome = "Carson",
                Apelido = "Alexander",
                DataInscricao = DateTime.Parse("2016-09-01")
            };

            var alonso = new Estudante
            {
                Nome = "Meredith",
                Apelido = "Alonso",
                DataInscricao = DateTime.Parse("2018-09-01")
            };

            var anand = new Estudante
            {
                Nome = "Arturo",
                Apelido = "Anand",
                DataInscricao = DateTime.Parse("2019-09-01")
            };

            var barzdukas = new Estudante
            {
                Nome = "Gytis",
                Apelido = "Barzdukas",
                DataInscricao = DateTime.Parse("2018-09-01")
            };

            var li = new Estudante
            {
                Nome = "Yan",
                Apelido = "Li",
                DataInscricao = DateTime.Parse("2018-09-01")
            };

            var justice = new Estudante
            {
                Nome = "Peggy",
                Apelido = "Justice",
                DataInscricao = DateTime.Parse("2017-09-01")
            };

            var norman = new Estudante
            {
                Nome = "Laura",
                Apelido = "Norman",
                DataInscricao = DateTime.Parse("2019-09-01")
            };

            var olivetto = new Estudante
            {
                Nome = "Nino",
                Apelido = "Olivetto",
                DataInscricao = DateTime.Parse("2011-09-01")
            };

            var Estudantes = new Estudante[]
            {
                alexander,
                alonso,
                anand,
                barzdukas,
                li,
                justice,
                norman,
                olivetto
            };

            context.AddRange(Estudantes);

            var abercrombie = new Docente
            {
                Nome = "Kim",
                Apelido = "Abercrombie",
                DataContrato = DateTime.Parse("1995-03-11")
            };

            var fakhouri = new Docente
            {
                Nome = "Fadi",
                Apelido = "Fakhouri",
                DataContrato = DateTime.Parse("2002-07-06")
            };

            var harui = new Docente
            {
                Nome = "Roger",
                Apelido = "Harui",
                DataContrato = DateTime.Parse("1998-07-01")
            };

            var kapoor = new Docente
            {
                Nome = "Candace",
                Apelido = "Kapoor",
                DataContrato = DateTime.Parse("2001-01-15")
            };

            var zheng = new Docente
            {
                Nome = "Roger",
                Apelido = "Zheng",
                DataContrato = DateTime.Parse("2004-02-12")
            };

            var Docentes = new Docente[]
            {
                abercrombie,
                fakhouri,
                harui,
                kapoor,
                zheng
            };

            context.AddRange(Docentes);

            var AtribuicaoEscritorios = new AtribuicaoEscritorio[]
            {
                new AtribuicaoEscritorio {
                    Docente = fakhouri,
                    Localizacao = "Smith 17" },
                new AtribuicaoEscritorio {
                    Docente = harui,
                    Localizacao = "Gowan 27" },
                new AtribuicaoEscritorio {
                    Docente = kapoor,
                    Localizacao = "Thompson 304" }
            };

            context.AddRange(AtribuicaoEscritorios);

            var english = new Departamento
            {
                Nome = "English",
                Orcamento = 350000,
                DataInicio = DateTime.Parse("2007-09-01"),
                Administrador = abercrombie
            };

            var mathematics = new Departamento
            {
                Nome = "Mathematics",
                Orcamento = 100000,
                DataInicio = DateTime.Parse("2007-09-01"),
                Administrador = fakhouri
            };

            var engineering = new Departamento
            {
                Nome = "Engineering",
                Orcamento = 350000,
                DataInicio = DateTime.Parse("2007-09-01"),
                Administrador = harui
            };

            var economics = new Departamento
            {
                Nome = "Economics",
                Orcamento = 100000,
                DataInicio = DateTime.Parse("2007-09-01"),
                Administrador = kapoor
            };

            var Departamentos = new Departamento[]
            {
                english,
                mathematics,
                engineering,
                economics
            };

            context.AddRange(Departamentos);

            var chemistry = new Curso
            {
                CursoID = 1050,
                NomeC = "Chemistry",
                Pontuacao = 3,
                Departamento = engineering,
                Docentes = new List<Docente> { kapoor, harui }
            };

            var microeconomics = new Curso
            {
                CursoID = 4022,
                NomeC = "Microeconomics",
                Pontuacao = 3,
                Departamento = economics,
                Docentes = new List<Docente> { zheng }
            };

            var macroeconmics = new Curso
            {
                CursoID = 4041,
                NomeC = "Macroeconomics",
                Pontuacao = 3,
                Departamento = economics,
                Docentes = new List<Docente> { zheng }
            };

            var calculus = new Curso
            {
                CursoID = 1045,
                NomeC = "Calculus",
                Pontuacao = 4,
                Departamento = mathematics,
                Docentes = new List<Docente> { fakhouri }
            };

            var trigonometry = new Curso
            {
                CursoID = 3141,
                NomeC = "Trigonometry",
                Pontuacao = 4,
                Departamento = mathematics,
                Docentes = new List<Docente> { harui }
            };

            var composition = new Curso
            {
                CursoID = 2021,
                NomeC = "Composition",
                Pontuacao = 3,
                Departamento = english,
                Docentes = new List<Docente> { abercrombie }
            };

            var literature = new Curso
            {
                CursoID = 2042,
                NomeC = "Literature",
                Pontuacao = 4,
                Departamento = english,
                Docentes = new List<Docente> { abercrombie }
            };

            var Cursos = new Curso[]
            {
                chemistry,
                microeconomics,
                macroeconmics,
                calculus,
                trigonometry,
                composition,
                literature
            };

            context.AddRange(Cursos);

            var Inscricaos = new Inscricao[]
            {
                new Inscricao {
                    Estudante = alexander,
                    Curso = chemistry,
                    Nota = Nota.A
                },
                new Inscricao {
                    Estudante = alexander,
                    Curso = microeconomics,
                    Nota = Nota.C
                },
                new Inscricao {
                    Estudante = alexander,
                    Curso = macroeconmics,
                    Nota = Nota.B
                },
                new Inscricao {
                    Estudante = alonso,
                    Curso = calculus,
                    Nota = Nota.B
                },
                new Inscricao {
                    Estudante = alonso,
                    Curso = trigonometry,
                    Nota = Nota.B
                },
                new Inscricao {
                    Estudante = alonso,
                    Curso = composition,
                    Nota = Nota.B
                },
                new Inscricao {
                    Estudante = anand,
                    Curso = chemistry
                },
                new Inscricao {
                    Estudante = anand,
                    Curso = microeconomics,
                    Nota = Nota.B
                },
                new Inscricao {
                    Estudante = barzdukas,
                    Curso = chemistry,
                    Nota = Nota.B
                },
                new Inscricao {
                    Estudante = li,
                    Curso = composition,
                    Nota = Nota.B
                },
                new Inscricao {
                    Estudante = justice,
                    Curso = literature,
                    Nota = Nota.B
                }
            };

            context.AddRange(Inscricaos);
            context.SaveChanges();
        }
    }
}
