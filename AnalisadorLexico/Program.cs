using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnalisadorLexico
{
    class Program
    {
        static int a = 0, b = 0, z = 0, y = 0;
        static String[] texto = System.IO.File.ReadAllLines(@"C:\TESTE.ptl");//colocando todo o texto em array de strings
        //static String[] textolimpo;// para salvar string sem a parte comentada
        static String[] substrings;// quebra de string nos lugares onde tem espaco
        static char[] chars;
       // static char[] charsT;
       // static char[] comentadoC;
       // static string[] comentadoS;
       // static int[] vetor;
        static String compara;
        static String token;
        static String v;
        static String c;
        static char letra;
        //static String letra1;
        static int fracao1 ;
        static Boolean fracao ;


        static void Main(string[] args)
        {
            int numeroLinhas = System.IO.File.ReadAllLines(@"C:\TESTE.ptl").Length;//descobrir o valor de linhas

            Console.WriteLine("Para a execucao de forma legivel do codigo, cada palavra deve ser separado por um ESPACO. ");
            Console.WriteLine("Pressione ENTER para continuar.");
            Console.ReadLine();

            Char delimiter = ' ';


            String linha;


            a = 0;//indice de linha do arquivo
            b = 0;//
            z = 0;//indice do char comentado
            Console.WriteLine("Codigo Comentado :");


            /*-----------------*/
            //separar a parte comentada da parte nao comentada
            while (a < numeroLinhas)    //a indice de linha
            {
                linha = texto[a];//transformando a linha[a] em uma string
                chars = linha.ToCharArray();//transformando a string em array de char
                for (int i = 0; i <= linha.Length - 1; i++)
                {
                    if (chars[i] == '/' || i == chars.Length)
                    {
                        i++;
                        if (chars[i] == '*')
                        {
                            i++;
                            v = v + "'";
                            for (int j = i; j <= linha.Length - 1; j++)
                            {
                                //inseri no vetor de comentario
                                if (chars[j] == '*')
                                {
                                    j++;
                                    if (chars[j] == '/')
                                    {
                                        v = v + "'";
                                        i = j;
                                        j = linha.Length;
                                    }
                                    else
                                    {
                                        j--;//para comentar o '*' anterior
                                        v = v + chars[j].ToString();
                                        j++;
                                        v = v + chars[j].ToString();
                                        // exit();
                                    }

                                }
                                else
                                {
                                    v = v + chars[j].ToString();
                                    //Console.Write(chars[j]);
                                }


                            }

                        }
                        else
                        {
                            i--;
                            c = c + chars[i].ToString();
                        }
                    }
                    else
                        c = c + chars[i].ToString();


                }

                Console.WriteLine("Na linha " + (a + 1) + " " + v + " ->Comentario<-");
                v = "";//limpando string para a prox linha;

                texto[a] = c.ToString();
                c = "";//limpando string para prox linha
                //Console.WriteLine(texto[a]);
                a++;
            }
            Console.WriteLine("Aperte Enter para a proxima parte");
            Console.ReadLine();
            Console.Clear();
            /*------------------*/


            /* quebrando as strings sem comentario para analisar */
            a = 0;//indice de linha
            b = 0;

            while (a < numeroLinhas)
            {
                Console.WriteLine("Linha " + (a + 1) + " ");
                linha = texto[a];//transformando o linha indice 'a' em string
                Console.WriteLine(texto[a]);
                substrings = linha.Split(delimiter);//quebrando em arrays onde tem espacos
                b = 0;//indice do array da linha   


                Console.WriteLine(substrings.Length + " atomos");
                //substring.length devolve a quantidade de palavras que temos na linha
                while (b < substrings.Length)
                {
                    fracao = false;
                    z = 0;//indice da palavra sendo setado a 0     

                    //Console.WriteLine(substrings[b]);//imprime a string a ser analisada
                    compara = substrings[b];
                    compara = compara.ToUpper();//chamando metodo para deixar tudo em CAPS
                    chars = compara.ToCharArray();

                    y = chars.Length;
                    token = "Id nao reconhecido";

                    switch (compara)
                    {
                        case "ALGORITMO":
                            token = "Palavras Reservadas";
                            break;
                        case "ATE":
                            token = "Palavras Reservadas";
                            break;
                        case "CADEIA":
                            token = "Palavras Reservadas";
                            break;
                        case "CARACTER":
                            token = "Palavras Reservadas";
                            break;
                        case "ENQUANTO":
                            token = "Palavras Reservadas";
                            break;
                        case "ENTAO":
                            token = "Palavras Reservadas";
                            break;
                        case "FACA":
                            token = "Palavras Reservadas";
                            break;
                        case "FIM":
                            token = "Palavras Reservadas";
                            break;
                        case "FUNCAO":
                            token = "Palavras Reservadas";
                            break;
                        case "INICIO":
                            token = "Palavras Reservadas";
                            break;
                        case "INTEIRO":
                            token = "Palavras Reservadas";
                            break;
                        case "PARA":
                            token = "Palavras Reservadas";
                            break;
                        case "PASSO":
                            token = "Palavras Reservadas";
                            break;
                        case "PROCEDIMENTO":
                            token = "Palavras Reservadas";
                            break;
                        case "REAL":
                            token = "Palavras Reservadas";
                            break;
                        case "REF":
                            token = "Palavras Reservadas";
                            break;
                        case "RETORNE":
                            token = "Palavras Reservadas";
                            break;
                        case "SE":
                            token = "Palavras Reservadas";
                            break;
                        case "SENAO":
                            token = "Palavras Reservadas";
                            break;
                        case "VARIAVEIS":
                            token = "Palavras Reservadas";
                            break;

                        /*ATOMOS SEM ATRIBUTOS*/

                        case "<-":
                            token = "ATRIBUICAO";
                            break;
                        case ".":
                            token = "PONTO";
                            break;
                        case "(":
                            token = "ABRE_PAR";
                            break;
                        case ")":
                            token = "FECHA_PAR";
                            break;
                        case ";":
                            token = "PONTO_VIRGULA";
                            break;
                        case ",":
                            token = "VIRGULA";
                            break;
                        case "-":
                            token = "SUBTRACAO";
                            break;
                        case "+":
                            token = "ADICAO";
                            break;
                        case "*":
                            token = "MULTIPLICACAO";
                            break;
                        case "/":
                            token = "DIVISAO";
                            break;
                        case "%":
                            token = "RESTO";
                            break;

                        /* OP RELACIONAL*/

                        case "<":
                            token = "ME";
                            break;
                        case "<=":
                            token = "MEI";
                            break;
                        case "=":
                            token = "IG";
                            break;
                        case "<>":
                            token = "DI";
                            break;
                        case ">":
                            token = "MA";
                            break;
                        case ">= ":
                            token = "MAI";
                            break;

                        /* OP LOGICO */

                        case "&":
                            token = "E";
                            break;
                        case "$":
                            token = "OU";
                            break;
                        case "!":
                            token = "NEG";
                            break;

                        /* */


                        case "1":
                            token = "DIGITO";
                            break;
                        case "2":
                            token = "DIGITO";
                            break;
                        case "3":
                            token = "DIGITO";
                            break;
                        case "4":
                            token = "DIGITO";
                            break;
                        case "5":
                            token = "DIGITO";
                            break;
                        case "6":
                            token = "DIGITO";
                            break;
                        case "7":
                            token = "DIGITO";
                            break;
                        case "8":
                            token = "DIGITO";
                            break;
                        case "9":
                            token = "DIGITO";
                            break;
                        case "0":
                            token = "DIGITO";
                            break;

                        case "A":
                            token = "LETRA";
                            break;
                        case "B":
                            token = "LETRA";
                            break;
                        case "C":
                            token = "LETRA";
                            break;
                        case "D":
                            token = "LETRA";
                            break;
                        case "E":
                            token = "LETRA";
                            break;
                        case "F":
                            token = "LETRA";
                            break;
                        case "G":
                            token = "LETRA";
                            break;
                        case "H":
                            token = "LETRA";
                            break;
                        case "I":
                            token = "LETRA";
                            break;
                        case "J":
                            token = "LETRA";
                            break;
                        case "K":
                            token = "LETRA";
                            break;
                        case "L":
                            token = "LETRA";
                            break;
                        case "M":
                            token = "LETRA";
                            break;
                        case "N":
                            token = "LETRA";
                            break;
                        case "O":
                            token = "LETRA";
                            break;
                        case "P":
                            token = "LETRA";
                            break;
                        case "Q":
                            token = "LETRA";
                            break;
                        case "R":
                            token = "LETRA";
                            break;
                        case "S":
                            token = "LETRA";
                            break;
                        case "T":
                            token = "LETRA";
                            break;
                        case "U":
                            token = "LETRA";
                            break;
                        case "V":
                            token = "LETRA";
                            break;
                        case "X":
                            token = "LETRA";
                            break;
                        case "Y":
                            token = "LETRA";
                            break;
                        case "Z":
                            token = "LETRA";
                            break;
                        case "W":
                            token = "LETRA";
                            break;


                    }



                    if (token == "Id nao reconhecido")
                    {
                        while (z < chars.Length - 1)// analisar se a palavra tem caracter do alfabeto ou numeros "Identificador"
                        {
                            /*******/
                            // Console.WriteLine(y);
                            z = 0;
                            letra = chars[z];//palavra pra array de chars


                            // vendo se eh inteiro ou float

                            if (letra == '0' || letra == '1' || letra == '2' || letra == '3' ||
                            letra == '4' || letra == '5' || letra == '6' || letra == '7' ||
                            letra == '8' || letra == '9' && z == 0 && token == "Id nao reconhecido")
                            {
                                z++;
                                if (z != compara.Length-1)
                                {
                                    letra = chars[z];//vendo se os proximos caracteres sao letras ou numeros
                                    token = "Digito";

                                    while ((letra == '0' || letra == '1' || letra == '2' || letra == '3' ||
                                        letra == '4' || letra == '5' || letra == '6' || letra == '7' ||
                                        letra == '8' || letra == '9' || letra == '.') && z < y-1 )
                                    {
                                        
                                        if (letra == '.')
                                        {
                                            token = "OP_FRACAO";
                                            fracao = true;
                                            fracao1 = fracao1 + 1;
                                        }                                             
                                        z++;
                                        letra = chars[z];                                        
                                        
                                    }

                                    
                                }
                                token = "NUMERO_INTEIRO";
                                if (fracao == true)
                                {
                                    token = "OP_FRACAO";
                                }
                                if (fracao1 > 1)
                                {
                                    token = "Id nao reconhecido";
                                }

                            }


                            /*
                            
                            if (chars[z] == '1' || chars[z] == '2' || chars[z] == '3' || chars[z] == '4' ||
                            chars[z] == '5' || chars[z] == '6' || chars[z] == '7' || chars[z] == '8' ||
                            chars[z] == '9' || chars[z] == '0' && z == 0 && token != "Id nao reconhecido")
                            {
                                z++;
                                if (z != compara.Length-1)
                                {
                                    token = "NUMERO_INTEIRO";

                                    letra = chars[z];
                                    while (letra == '1' || letra == '2' || letra == '3' || letra == '4' ||
                                        letra == '5' || letra == '6' || letra == '7' || letra == '8' ||
                                        letra == '9' || letra == '0' || letra == '.' && z < y - 1)
                                    {
                                        token = "NUMERO_INTEIRO";
                                        if (chars[z] == '.')
                                        {
                                            fracao = true;
                                        }
                                                                                                                 
                                            

                                        if (fracao == true)
                                        {
                                            token = "OP_FRACAO";
                                        }
                                        z++;


                                    }
                                }

                            }
                            */

                            /*****/
                            //vendo se o primeiro caracter eh letra



                            if (letra == 'A' || letra == 'B' || letra == 'C' || letra == 'D' ||
                            letra == 'E' || letra == 'F' || letra == 'G' || letra == 'H' ||
                            letra == 'I' || letra == 'J' || letra == 'K' || letra == 'L' ||
                            letra == 'M' || letra == 'N' || letra == 'O' || letra == 'P' ||
                            letra == 'Q' || letra == 'R' || letra == 'S' || letra == 'T' ||
                            letra == 'U' || letra == 'V' || letra == 'X' || letra == 'Y' ||
                            letra == 'W' || letra == 'Z' && z == 0 && token != "Id nao reconhecido")
                            {
                                
                                z++;

                                if (z != compara.Length)
                                {
                                    letra = chars[z];//vendo se os proximos caracteres sao letras ou numeros
                                    token = "Identificador";
                                    while ((letra == 'A' || letra == 'B' || letra == 'C' || letra == 'D' ||
                                        letra == 'E' || letra == 'F' || letra == 'G' || letra == 'H' ||
                                        letra == 'I' || letra == 'J' || letra == 'K' || letra == 'L' ||
                                        letra == 'M' || letra == 'N' || letra == 'O' || letra == 'P' ||
                                        letra == 'Q' || letra == 'R' || letra == 'S' || letra == 'T' ||
                                        letra == 'U' || letra == 'V' || letra == 'X' || letra == 'Y' ||
                                        letra == 'W' || letra == 'Z' || letra == '0' || letra == '1' ||
                                        letra == '2' || letra == '3' || letra == '4' || letra == '5' ||
                                        letra == '6' || letra == '7' || letra == '8' || letra == '9') && z < y - 1)
                                    {
                                        z++;
                                        letra = chars[z];
                                        token = "Identificador";
                                    }
                                }


                            }

                            /*********/


                        }
                    }

                    Console.WriteLine("Linha " + (a + 1) + " - " + substrings[b] + " -  " + token);
                    //Console.WriteLine(token);

                    b++;
                }
                Console.WriteLine("----===----");
                a++;
            }


            /********************/
            Console.WriteLine("Digite qualquer tecla para sair.");
            Console.ReadLine();
        }
    }
}
