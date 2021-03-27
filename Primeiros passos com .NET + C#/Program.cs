﻿using System;

namespace Revisao
{
    class Program
    {
        static void Main(string[] args)
        {
            Aluno[] alunos = new Aluno[5];
            var indiceAluno = 0;

           string opcaoUsuario = ObterOpcaoUsuario();

            while (opcaoUsuario.ToUpper() != "X")
            {
                switch (opcaoUsuario)
                {
                    case "1":
                    //TODO: adicionar aluno
                    Console.Write("Informe o nome do ALuno: ");
                    var aluno = new Aluno();
                    aluno.Nome = Console.ReadLine();

                    Console.Write("Informe a Nota do Aluno: ");
                    if(decimal.TryParse(Console.ReadLine(), out decimal nota)){
                        aluno.Nota = nota;
                    }
                    else
                    {
                        throw new ArgumentException("Valor da nota deve ser decimal");
                    }

                    alunos[indiceAluno] = aluno;
                    indiceAluno++;

                    break;

                    case "2":
                    //TODO: listar aluno
                    foreach (var a in alunos)
                    {
                        if(!string.IsNullOrEmpty(a.Nome)){
                            Console.WriteLine($"ALUNO: { a.Nome} - NOTA: {a.Nota}");
                        }

                    }

                    break;

                    case "3":
                    //TODO: calcular média geral
                    decimal  notaTotal = 0;
                    var nrAluno = 0;
                    for (int i = 0; i < alunos.Length; i++)
                    {
                        if(!string.IsNullOrEmpty(alunos[i].Nome)){
                            notaTotal = notaTotal + alunos[i].Nota;
                            nrAluno++;
                        }
                    }

                    var mediaGeral = notaTotal / nrAluno;
                    Conceito conceitoGeral;

                    if(mediaGeral < 2){
                        conceitoGeral = Conceito.E;
                    }
                    else if(mediaGeral < 4){
                        conceitoGeral = Conceito.D;
                    }
                    else if(mediaGeral < 6)
                    {
                        conceitoGeral = Conceito.C;
                    }
                    else if(mediaGeral < 8){
                        conceitoGeral = Conceito.B;
                    }
                    else{
                        conceitoGeral = Conceito.A;
                    }

                    Console.Write($"MÉDIA GERAL: {mediaGeral} - CONCEITO: {conceitoGeral}");
                    Console.WriteLine();
 
                    break;
                    
                    default:
                    throw new ArgumentOutOfRangeException();
                }
                
                 opcaoUsuario = ObterOpcaoUsuario();                
            }
        }

            private static string ObterOpcaoUsuario(){
                Console.WriteLine();
                Console.WriteLine("Informe a opção desejada: ");
                Console.WriteLine();
                Console.WriteLine("1 - Inserir Novo Aluno");
                Console.WriteLine("2 - Lista alunos");
                Console.WriteLine("3 - Calcular Média Geral");
                Console.WriteLine("X - Sair");
                Console.WriteLine();

                string opcaoUsuario = Console.ReadLine();
                return opcaoUsuario;
            }
    }
}
