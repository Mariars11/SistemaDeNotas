using System;

namespace Revisao
{
    class Program
    {
        static void Main(string[] args)
        {
            Aluno[] alunos = new Aluno[5]; //cria um array de aluno que aloca 5
            var indiceAluno = 0;
            string opcaoUsuario = ObterOpcaoUsuario(); //metodo obteropçãousuario

            while (opcaoUsuario.ToUpper() != "X")
            {
                switch (opcaoUsuario)
                {
                    case "1":
                        Console.Write("\nInforme o nome do Aluno(a): ");
                        var aluno = new Aluno();
                        aluno.Nome = Console.ReadLine(); //possibilita que as notas sejam alocadas no array do aluno

                        Console.Write("Informe a nota do aluno: ");
                        
                        if (decimal.TryParse(Console.ReadLine(), out decimal nota)){ //tryparse elimina a necessidade de tratamento de exceção
                            aluno.Nota = nota;
                        }
                        else{
                            throw new ArgumentException("Valor da nota deve ser decimal");
                        }

                        alunos[indiceAluno] = aluno; //ajeita as informações salvas aqui, em array, aluno1, aluno2 ...
                        indiceAluno++;

                        break;
                    case "2":
                        foreach(var a in alunos){ //para cada aluno imprima isso
                            if (!string.IsNullOrEmpty(a.Nome)){
                                Console.WriteLine($"[ALUNO(A): {a.Nome} - NOTA: {a.Nota}]");
                            }
                           
                        }
                        break;
                    case "3":
                        decimal notaTotal = 0;
                        var numAlunos = 0;
                        for(int i= 0; i < alunos.Length; i++){
                            if (!string.IsNullOrEmpty(alunos[i].Nome)){
                                notaTotal = notaTotal +alunos[i].Nota;
                                numAlunos++;
                            }
                        }
                        var mediaGeral = notaTotal / numAlunos;
                        ConceitoEnum conceitoGeral;
                        if (mediaGeral < 2){
                            conceitoGeral = ConceitoEnum.E;
                        }
                            else if (mediaGeral < 4){
                                conceitoGeral = ConceitoEnum.D;
                            }
                                else if (mediaGeral < 6){
                                    conceitoGeral = ConceitoEnum.C;
                                }
                                    else if (mediaGeral < 8){
                                        conceitoGeral = ConceitoEnum.B;
                                    }
                                        else{ 
                                            conceitoGeral = ConceitoEnum.A;
                                        }
                        Console.WriteLine($"A MÉDIA DE NOTAS: [{mediaGeral}] O CONCEITO: ({conceitoGeral})");

                        break;
                    default:
                        throw new ArgumentOutOfRangeException(); //valor informado está fora do range de opções
                     
                }
            //para que o usuário tenha a opçao de realizar novamente o procedimento

                opcaoUsuario = ObterOpcaoUsuario(); 
            }
        }
        private static string ObterOpcaoUsuario()
        {
            Console.WriteLine("\n=== Informe a opção desejada ===");
            Console.WriteLine("(1) - [Inserir novo aluno]\n(2) - [Listar alunos]\n(3) - [Calcular média geral]\n(X) - [Sair]\n");
            Console.Write("Informe: ");
            string opcaoUsuario = Console.ReadLine();
            return opcaoUsuario;
        }
    }
}
