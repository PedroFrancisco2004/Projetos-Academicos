//------------------------------------------------------------------------------------------\\
//Autores: Rúben Ricardo Rodrigues Amaral nº2220848 ; Pedro Miguel Ideias Francisco nº2220879\\
//Unidade Curricular: Fundamentos de Programação
//Data: Janeiro 2023
//Escola: Escola Superior de Tecnologia e Gestão - Leiria
//--------------------------------------------------------------------------------------------\\


//bibliotecas de pré-processamento
#include <stdio.h>
#include <stdlib.h>
#include <locale.h>
#include <stdbool.h>
#include <ctype.h>
#include <string.h>
#include <time.h>

//constantes
#define MAX_PARTICIPANTE 5000
#define MAX_ATIVIDADES 200
#define MAX_INSCRICOES 10000

//--- Estrutura de Dados das ( <<<Inscricoes>>> )---//
typedef struct {
    int identificador_sequencia;
    int identificador_participante;
    int identificador_atividade;
    float valor_pago;
    char data[11];
    char hora[6];

} t_inscricao;

//--- Estrutura de Dados das ( <<<Atividades>>> )---//
typedef struct {

    int identificador_sequencia;
    char designacao[20];
    char data[11];
    char hora[6];
    char local[15];
    char tipo_atividade[20];
    char associacao_estudantes[10];
    float valor_inscricao;

} t_atividade;

//--- Estrutura de Dados dos ( <<<Participantes>>> )---//
typedef struct {

    int identificador_sequencia;
    char nome [40];
    char escola [10];
    char nif[11];
    char email[40];
    char telefone[10];

} t_participante;


//--------------------- Funções dos (<<< Menus e Sub-Menus >>>)-----------------------//
char menu_principal(char opcao );
char registo_consulta_de_dados_participantes(char sub_opcao);
char registo_consulta_das_atividades(char sub_opcao);
char registo_consulta_das_inscricoes(char sub_opcao);
char consultar_estatisticas (char sub_opcao);
char menu_guardar_ler_ficheiros(char sub_opcao);
char confirmar_saida(char opcao_sair);



//------------------------ Funções de Validações dos Dados (Participantes)---------------------------//
int validar_string(char str[]);
void obter_string(char mensagem[], char str []);
int obter_NIF(t_participante vetor_participantes[], int numero_participantes);
void obter_email(char str[]);
void obter_telefone(t_participante vetor_participantes[], int numero_participantes);
float obter_float( char mensagem[140]);
int procurar_participante(t_participante vetor_participantes[], int id);
void obter_participante (t_participante vetor_participantes[],t_inscricao vetor_inscricoes[], int indice);
int procurar_atividade(t_atividade vetor_atividades[], int id);
void obter_atividade(t_atividade vetor_atividades[], t_inscricao vetor_inscricoes[], int indice);
int obter_dia(t_atividade vetor_atividades[],int dia);
int obter_mes(t_atividade vetor_atividades[],int mes);
int obter_ano(t_atividade vetor_atividades[],int ano);
void obter_data(t_atividade vetor_atividades[], int dia, int mes, int ano, int indice);
int obter_hora(t_atividade vetor_atividades[], int hora, int indice);
int obter_minutos(t_atividade vetor_atividades[], int minutos, int indice);
int obter_hora_minutos(t_atividade vetor_atividades[],int minutos, int hora, int indice);
void obter_data_hora_atual(t_inscricao vetor_inscricoes[], int indice);

//------------------------ Funções de Lista de dados e Lêr Tipos de dados( Atividades ) ---------------------------//
int escolha_atividade(t_atividade vetor_atividades[], int indice);
int escolha_associacao_estudantes (t_atividade vetor_atividades[], int indice);

//------------------------ Funções de Lista de dados ( Participantes ) ---------------------------//
int escolha_escola (t_participante vetor_participantes[],int indice);




//*******************************************************************\\
//--------------Funcionalidades do programa (Funções)----------------\\
//*******************************************************************\\


//---------- Funções das Estatísticas --------------//
int numero_atividades_realizadas(t_atividade vetor_atividades[]);
int percentagem_inscricoes_escola(t_inscricao vetor_inscricoes[], t_participante vetor_participantes[]);
int valor_inscricoes_entre_datas(t_atividade vetor_atividades[], t_inscricao vetor_inscricoes[]);


//---------- Funções dos dados dos(<<< Participantes >>>) do Programa -----------//
int registar_dados_participantes(t_participante vetor_participantes[],int numero_participantes, char opcao_sair);
int gravar_dados_participantes(t_participante vetor_participantes[], int numero_participantes);
int ler_dados_participantes(t_participante participantes[]);
void mostrar_dados_participantes(t_participante participantes[]);


//---------- Funções dos dados das (<<< Atividades >>>) do Programa --------------//
int registar_dados_das_atividades(t_atividade vetor_atividades[], int numero_atividades, char opcao_sair, t_inscricao vetor_inscricoes[]);
int gravar_dados_atividades(t_atividade vetor_atividades[], int numero_atividades);
int ler_dados_atividades(t_atividade vetor_atividades[]);
void mostrar_dados_atividades(t_atividade vetor_atividades[]);


//---------- Funções dos dados das (<<< Inscrições >>>) do Programa --------------//
int registar_dados_inscricoes(t_inscricao vetor_inscricoes[], t_participante vetor_participantes[], t_atividade vetor_atividades[], char opcao_sair, int numero_inscricoes);
int gravar_dados_inscricoes(t_inscricao vetor_inscricoes[], int numero_inscricoes);
int ler_dados_inscricoes(t_inscricao vetor_inscricoes[]);
void mostrar_dados_inscricoes(t_inscricao vetor_inscricoes[]);



int main() {

//-------------------------------------------------------- Inicio Main ------------------------------------------------//
    setlocale(LC_ALL, "Portuguese");

    //-----------Variaveis pra as funções (Data) e (Hora)-------//
    int dia, mes, ano, hora, minuto;

    //-----------Opções do Menu e Sub-menus-------//
    char opcao, sub_opcao, opcao_sair;


    //------------Valores Default-----------------//
    int numero_participantes = 0;
    int numero_inscricoes = 0;
    int numero_atividades = 0;

    //----------------------------------Declaração dos vetores das estruturas de dados (Structs)----------------------------------//
    t_participante vetor_participantes[MAX_PARTICIPANTE] = { NULL };
    t_atividade vetor_atividades[MAX_ATIVIDADES];
    t_inscricao vetor_inscricoes[MAX_INSCRICOES];

    //----------------------------------- Chamar Funções para ler os Ficheiros de dados --------------------------------------//
    numero_atividades = ler_dados_atividades(vetor_atividades);
    numero_inscricoes = ler_dados_inscricoes(vetor_inscricoes);
    numero_participantes = ler_dados_participantes(vetor_participantes);


//************************************************************************************************************************************//
//--------------------------------------------------------Menus e Sub-Menus ----------------------------------------------------------//
//************************************************************************************************************************************//

    do {
        //--------Menu Principal----------//
        opcao = menu_principal(opcao);
        switch(opcao) {

        //------------1ª opção (menu principal)----------//

        case '1': {
            do {
                system ("cls");
                fflush(stdin);
                sub_opcao = registo_consulta_de_dados_participantes (sub_opcao);//Registo e consulta dos participantes (Sub-Menu)

                //Opção do (Sub-Menu)
                switch (sub_opcao) {

                //--------Opcão Registar (Sub-Menu <<<Participantes>>>)----------//

                case '1': {
                    if (numero_participantes >= MAX_PARTICIPANTE )
                        printf("\nErro: Vetor esta cheio!\n");
                    else {
                        numero_participantes = registar_dados_participantes(vetor_participantes, numero_participantes, opcao_sair);
                        //gravar_dados_participantes(vetor_participantes, numero_participantes);
                        getchar();
                        break;
                    }
                }
                //--------Opção Consulta (Sub-menu <<<Participantes>>>)----------//

                case '2': {
                    if (numero_participantes == 0) {
                        printf("\nErro: Nao foram inseridos participantes!\n");
                        getchar();
                    } else {

                        system("cls");
                        mostrar_dados_participantes(vetor_participantes);
                        break;
                    }
                }
                //--------Opcão Voltar (Sub-Menu <<<Participantes>>>)------------//

                case '9': {
                    system ("cls");
                    fflush(stdin);
                    break;
                }
                //--------Qualquer outra Opção (Sub-Menu <<<Participantes>>>)----//

                default: {
                    system ("cls");
                    fflush(stdin);
                    printf("Opção Inválida!");
                    getchar();
                }
                }
            } while (sub_opcao != '9');
        }
        break;

        //--------2ª opção (menu principal)------------//

        case '2': {
            do {
                system ("cls");
                sub_opcao = registo_consulta_das_atividades(sub_opcao);
                switch (sub_opcao) { //Opção do (Sub-Menu)

                //--------Opcão Registar (Sub-Menu <<<Atividades>>>)------------//

                case '1': {
                    if (numero_atividades >= MAX_ATIVIDADES ) {


                        printf("\nErro: Vetor esta cheio!\n");
                    } else {
                        system("cls");
                        numero_atividades = registar_dados_das_atividades(vetor_atividades,numero_atividades,opcao_sair,vetor_inscricoes);
                        //gravar_dados_atividades(vetor_atividades, numero_atividades);
                        break;
                    }
                }
                //--------Opção Consulta (Sub-menu <<<Atividades>>>)------------//

                case '2': {
                    if  (numero_atividades == 0) {
                        printf("\nErro: Nao foram inseridas atividades!\n");
                        getchar();
                    } else {
                        system("cls");
                        mostrar_dados_atividades(vetor_atividades);
                        break;
                    }
                }
                //--------Opcão Voltar (Sub-Menu <<<Atividades>>>)------------//

                case '9': {

                    system ("cls");
                    fflush(stdin);
                    break;
                }
                //--------Qualquer outra Opção (Sub-Menu <<<Atividades>>>)------------//

                default: {

                    system ("cls");
                    fflush(stdin);
                    printf("Opção Inválida!");
                    getchar();

                }
                }
            } while (sub_opcao != '9');
        }
        break;

        //--------3ª opção (menu principal)------------//

        case '3': {
            do {
                system ("cls");
                sub_opcao = registo_consulta_das_inscricoes(sub_opcao);

                switch (sub_opcao) {

                //--------Opcão Registar (Sub-Menu <<<Inscrições>>>)----------//

                case '1': {
                    if (numero_inscricoes >= MAX_INSCRICOES ) {
                        printf("\nErro: Vetor esta cheio!\n");
                    } else {
                        system("cls");
                        numero_inscricoes = registar_dados_inscricoes(vetor_inscricoes, vetor_participantes, vetor_atividades, opcao_sair, numero_inscricoes);
                        break;
                    }
                }
                //--------Opcão Consultar (Sub-Menu <<<Inscrições>>>)---------//

                case '2': {
                    if (numero_inscricoes == 0) {
                        printf("\nErro: Nao foram inseridas inscrições!\n");
                        getchar();
                    } else {
                        system("cls");
                        mostrar_dados_inscricoes(vetor_inscricoes);
                        break;
                    }
                }
                //--------Opcão Voltar (Sub-Menu <<<Inscrições>>>)------------//

                case '9': {
                    system ("cls");
                    fflush(stdin);
                    break;
                }
                //--------Qualquer outra Opção (Sub-Menu <<<Inscrições>>>)----//

                default: {
                    system ("cls");
                    fflush(stdin);
                    printf("Opção Inválida!");
                    getchar();
                }
                }
            } while (sub_opcao != '9');
        }
        break;

        //--------4ª opção (menu principal)------------//

        case '4': {
            do {
                system ("cls");
                sub_opcao = consultar_estatisticas(sub_opcao);

                switch (sub_opcao) {

                //--------Opcão Número de atividades realizadas por cada associação: (Sub-Menu <<<Dados Estatísticos>>>)----//

                case '1': {
                    if (numero_atividades == 0) {
                        printf("Não foram Inseridas Atividades!");
                        getchar();

                    } else {
                        system("cls");
                        numero_atividades_realizadas(vetor_atividades);
                        getchar();
                        break;
                    }

                }
                //--------Opcão Percentagem de inscrições por escola (Sub-Menu <<<Dados Estatísticos>>>)----//

                case '2': {
                    if (numero_participantes == 0) {
                        printf("Não foram Inseridos Participantes!");
                        getchar();
                        break;
                    } else {
                        system("cls");
                        percentagem_inscricoes_escola(vetor_inscricoes,vetor_participantes);
                        getchar();
                        break;
                    }
                }
                //-------- Opção Valor total das inscrições entre duas datas por tipo de atividade (Sub-Menu <<<Dados Estatísticos>>>)----//

                case '3': {
                    system ("cls");
                    fflush(stdin);
                    printf("Valor");
                    getchar();
                    //chamar função
                    break;
                }
                //--------Opção Voltar (Sub-Menu Dados <<<Estatísticos>>>)----//

                case '9': {
                    system ("cls");
                    fflush(stdin);
                    break;
                }
                //--------Qualquer outra Opção (Sub-Menu <<<Dados Estatísticos>>>)----//

                default: {
                    system ("cls");
                    fflush(stdin);
                    printf("Opção Inválida!");
                    getchar();
                }
                }
            } while (sub_opcao != '9');
        }
        break;

        //--------Opcão Saír (Menu-Principal)----//

        case '9': {
            system("cls");
            fflush(stdin);
            printf("Programa a encerrar...");
            break;
        }

        //--------Qualquer outra opção (Menu-Principal)----//

        default: {
            printf("Opção Inválida!");
            fflush(stdin);
            getchar();
        }
        }
    } while (opcao != '9');
    return 0;

}


//-------------------------Estrutura do Menu Principal----------------------------//
char menu_principal(char opcao) {
    system ("cls");
    printf("|======================================|");
    printf("                 MENU                   ");
    printf("|======================================|");
    printf("\n1 - Registar e consultar os dados dos participantes: ");
    printf("\n2 - Registar e consultar os dados das atividades: ");
    printf("\n3 - Registar e consultar os dados das inscrições: ");
    printf("\n4 - Estatísticas");
    printf("\n\n9 - Saír ");
    printf("\n|======================================================================================================================|");
    printf("\n\nSelecione opcao (1-4) >> ");
    scanf(" %c", &opcao);
    fflush(stdin);


    return opcao;
}

//-------------------------Estrutura do Menu de Registo e consulta de dados dos <<<Participantes>>> (Sub-Menu)----------------------------//
char registo_consulta_de_dados_participantes (char sub_opcao) {

    system ("cls");
    printf("|====================================|");
    printf(" Registo e Consulta de dados (Participantes)");
    printf("|====================================|");
    printf("1 - Registar ");
    printf("\n2 - Consultar ");
    printf("\n\n9 - Voltar");
    printf("\n|======================================================================================================================|");
    printf("\n\nSelecione opcao (1-2) >> ");
    scanf(" %c", &sub_opcao);
    fflush(stdin);

    return sub_opcao;
}
//-------------------------Estrutura do Menu de Registo e Consulta das <<<Atividades>>> (Sub-Menu)----------------------------//
char registo_consulta_das_atividades (char sub_opcao) {
    system ("cls");
    printf("|====================================|");
    printf(" Registo e Consulta de dados (Atividades)");
    printf("|====================================|");
    printf("\n1 - Registar ");
    printf("\n2 - Consultar ");
    printf("\n\n9 - Voltar");
    printf("\n|======================================================================================================================|");
    printf("\n\nSelecione opcao (1-2) >> ");
    scanf(" %c", &sub_opcao);
    fflush(stdin);

    return sub_opcao;
}
//-------------------------Estrutura do Menu de Registo e Consulta das <<<inscrições>>> (Sub-menu)----------------------------//
char registo_consulta_das_inscricoes (char sub_opcao) {
    system ("cls");
    printf("|====================================|");
    printf(" Registo e Consulta de dados (Inscrições)");
    printf("|====================================|");
    printf("\n1 - Registar");
    printf("\n2 - Consultar");
    printf("\n\n9 - Voltar");
    printf("\n|======================================================================================================================|");
    printf("\n\nSelecione opcao (1-2) >> ");
    scanf(" %c", &sub_opcao);
    fflush(stdin);

    return sub_opcao;
}

//-------------------------Estrutura do Menu de <<<Dados Estatísticos>>> (Sub-menu)----------------------------//
char consultar_estatisticas (char sub_opcao) {
    system ("cls");
    printf("|====================================|");
    printf("          Dados Estatísticos          ");
    printf("|====================================|");
    printf("\n1 - Número de atividades realizadas por cada associação: ");
    printf("\n2 - Percentagem de inscrições por escola: ");
    printf("\n3 - Valor total das inscrições por tipo de atividade (entre duas datas): ");
    printf("\n\n9 - Voltar");
    printf("\n|======================================================================================================================|");
    printf("\n\nSelecione opcao (1-3) >> ");
    scanf(" %c", &sub_opcao);
    fflush(stdin);

    return sub_opcao;

}

//-------------------------Faz apenas a validação, usando os codigos do Ascii.-----------------------------//
//-------------------------Não vai apanhar acentos porque nao incluímos esses codigos.---------------------//
int validar_string(char str[50]) {
    for(int i = 0; i < strlen(str) ; i++) {
        {
            char c = str[i];
            if ( !(c >= 65 && c <= 90) && !(c >= 97 && c <= 122) && c != 32) { //not ( A-Z ) e ( a-z ) e ( espaço )
                return 0; // Inválido
            }
        }
    }
    return 1; // Válido
}

//------------------------Obter a String, fazendo o printf, o scanf juntamente com a validação---------------------//
void obter_string(char mensagem[], char str []) {
    int tamanho_minimo = 3;
    do {
        printf(mensagem);
        fflush(stdin);
        gets(str);

        if (!validar_string(str) || strlen(str) < tamanho_minimo) {
            printf("Dados invalidos! insira um dado em formato texto.");
            printf("\nA string deve ter no mínimo: %d caracteres.\n", tamanho_minimo);
            getchar();
        }

    } while(!validar_string(str)|| strlen(str) < tamanho_minimo);
}

//-------------------------Validar numero do NIF---------------------//
int obter_NIF(t_participante vetor_participantes[], int numero_participantes) {
    char *endptr;
    long int nif;
    do {
        //strtol = converte string para long int
        printf("\nInsira o NIF (0 - 9 digitos): ");
        fgets(vetor_participantes[numero_participantes].nif, sizeof(vetor_participantes[numero_participantes].nif), stdin);
        nif = strtol(vetor_participantes[numero_participantes].nif, &endptr, 10);


        //atribuir valor participantes à variável nif
        if (*endptr != '\n') {
            printf("Entrada inválida! Tente novamente.\n");
        } else if (strlen(vetor_participantes[numero_participantes].nif) != 10) {
            printf("NIF inválido: o NIF deve ter 9 digitos.\n");
        }
        //strlen = dá tamanho da string
    } while (*endptr != '\n'|| strlen(vetor_participantes[numero_participantes].nif) != 10);
    printf("Dado válido!\n");

    return nif;
}
//---------------------Validar dado do tipo Email---------------------//
void obter_email(char str []) {
    //Loop até que o dado tenha o caractere '@'
    do {
        printf("\nInsira o Email: ");
        gets(str);

        // Verifique se o dado tem o caractere @
        if (strchr(str,  '@') == NULL) {
            printf("Email Inválido!!\n");
            printf(" Aviso: O caractere '@' é obrigatório!!!\n");

        } else if (strlen(str) < 6 || strlen(str) > 50 ) {
            printf("Tamanho minimo do email tem que ser 5 caracteres!");
            printf("\nTamanho máximo do email pode ser 50 caracteres!");
        }
            //Verifica se o input do utilizador tem "@"
    } while (strchr(str, '@') == NULL || strlen(str) < 5 || strlen(str) > 50 );
    printf("Email Válido");
}
//---------------------Validar dado do tipo nº Telefone---------------------//
void obter_telefone(t_participante vetor_participantes[], int indice) {
    int valido = 0;
    do {
        printf("\nInsira o número de telefone: ");
        scanf("%s", &vetor_participantes[indice].telefone);
        // Verifica se o número de telefone tem 9 dígitos
        if (strlen(&vetor_participantes[indice].telefone) != 9) {
            printf("Número de telefone inválido!! \nO número de telefone deve ter 9 dígitos.\n");
            continue;
        }
        // Verifica se todos os dígitos são números
        for (int i = 0; i < 9; i++) {
            if (!isdigit(&vetor_participantes[indice].telefone[i])) {
                printf("Número de telefone inválido!!! Todos os dígitos devem ser números.\n");
                continue;
            }
        }
        // Se chegamos aqui, o número de telefone é válido
        valido = 1;
    } while (valido == 0);
    printf("Número de telefone válido.\n");
}
//---------------------Validar o Dia no tipo de dados (Data)---------------------//
int obter_dia(t_atividade vetor_atividades[], int dia) {

    int result;
    do {
        printf("\nInsira o dia:");
        result = scanf("%d", &dia); //resultado válido


        //se o resultado for inválido:
        if (dia > 31 || dia < 1 || result != 1) {
            printf("\nData Inválida!");
            printf("\nO Dia tem que estar entre ( 01 e 31 )");
            printf("\nValor inválido. Insira somente números inteiros.\n");
            getchar();
        }

        else {
            printf("Data válida!");

        }
    } while (dia > 31 || dia < 1 || result != 1);

    return dia;
}

//---------------------Validar o Mês no tipo de dados (Data)---------------------//
int obter_mes(t_atividade vetor_atividades[],int mes) {

    do {
        printf("\nInsira o mês: ");
        int result = scanf("%d",&mes);

        //se o resultado for inválido:
        if ( mes > 12 || mes < 1 || result != 1) {
            printf("\nData Inválida!");
            printf("\nO Mes tem que estar entre ( 01 e 12 )");
            printf("\nValor inválido. Insira somente números inteiros.\n");
            getchar();
        } else {
            printf("Data válida!");
        }

    } while (mes > 12 || mes < 1 );
    return mes;
}

//---------------------Validar o Ano no tipo de dados (Data)---------------------//
int obter_ano(t_atividade vetor_atividades[],int ano) {

    int result;
    do {
        printf("\nInsira o ano: ");
        result = scanf("%d", &ano);

        //se o resultado for inválido:
        if (ano <= 2022 || result != 1) {
            printf("\nData Inválida!");
            printf("\nO Ano tem que começar a partir de 2023");
            printf("\nValor inválido. Insira somente números inteiros.\n");
            getchar();

        } else {
            printf("Data válida!");
            break;
        }
    } while (ano <= 2022 || result != 1 );

    return ano;
}

//---------------------Obter Data ---------------------//
void obter_data(t_atividade vetor_atividades[], int dia, int mes, int ano, int indice) {

    dia = obter_dia(vetor_atividades, dia);
    mes = obter_mes(vetor_atividades, mes);
    ano = obter_ano(vetor_atividades, ano);

    //sprintf = junta variaveis inteiras em string
    sprintf(vetor_atividades[indice].data,"%d-%d-%d", dia,mes,ano);
    printf("\nA data escolhida foi: ( %s )", vetor_atividades[indice].data);
}
//---------------------Obter Horas ---------------------//
int obter_hora(t_atividade vetor_atividades[], int hora, int indice) {

    int result;

    // Pedir a hora ao utilizador até que ele forneça uma hora no formato correto!
    do {
        printf("\nInsira a hora entre (0 e 23): ");
        result = scanf("%d", &hora);

        //se o resultado for inválido:
        if (hora < 0 || hora > 23 || result != 1)
            printf("\nHora inválida! Tem que estar entre ( 0 e 23 )");
        printf("\nA hora só pode conter digitos");
        getchar();

    } while (hora < 0 || hora > 23 || result != 1);
    return hora;

}

//---------------------Obter Minutos ---------------------//
int obter_minutos(t_atividade vetor_atividades[], int minutos, int indice) {

    int result;

    do {
        printf("\nInsira os minutos entre (0 e 59)\n ");
        result = scanf("%d", &minutos);

        //se o resultado for inválido:
        if (minutos < 0 || minutos > 59 || result != 1)
            printf("Hora inválida, tem que estar entre (0 e 59\n");
        getchar();

    } while (minutos < 0 || minutos > 59 || result != 1);
    return minutos;
}

//---------------------Obter Horas e Minutos (Hora completa) ---------------------//
int obter_hora_minutos(t_atividade vetor_atividades[],int minutos, int hora, int indice) {

    hora = obter_hora(vetor_atividades, hora, indice);
    minutos = obter_minutos(vetor_atividades, minutos, indice);

    //sprintf = junta variaveis inteiras em string
    sprintf(vetor_atividades[indice].hora,"%d:%d", hora,minutos);
    printf("\nA hora escolhida foi: ( %s )", vetor_atividades[indice].hora);

}

//---------------------Obter Data e Hora Atual ---------------------//
void obter_data_hora_atual(t_inscricao vetor_inscricoes[], int indice) {

    //formula de deteção de hora e data automática
    time_t rawtime;
    struct tm * timeinfo;

    time(&rawtime);
    timeinfo = localtime(&rawtime);
    printf("Data atual: %d/%d/%d\n", timeinfo->tm_mday, timeinfo->tm_mon + 1, timeinfo->tm_year + 1900);
    printf("Hora atual: %d:%d:%d\n", timeinfo->tm_hour, timeinfo->tm_min, timeinfo->tm_sec);

    //sprintf = junta variaveis inteiras em string
    sprintf(vetor_inscricoes[indice].data,"%d-%d-%d", timeinfo ->tm_mday, timeinfo->tm_mon + 1, timeinfo->tm_year + 1900);
    printf("\nA Data escolhida foi: ( %s )", vetor_inscricoes[indice].data);

    sprintf(vetor_inscricoes[indice].hora,"%d:%d:%d", timeinfo->tm_hour, timeinfo->tm_min, timeinfo->tm_sec);
    printf("\nA Hora escolhida foi: ( %s )", vetor_inscricoes[indice].hora);

}

//---------------------Validar Dados do valor Pago---------------------//
float obter_float(char mensagem[140] ) {
    char valor_float[20];
    do {
        printf(mensagem);
        scanf("%s", valor_float);
        int i;

        if (valor_float >= '0'  && valor_float <= '9' && valor_float == ',' ) {
            printf("O valor tem que ser positivo!\n");
        }
    } while (valor_float >= '0'  && valor_float <= '9' && valor_float == ',' );
    printf("O valor digitado é um float válido!\n");

    return atof(valor_float);//Converter de char para float
}


//---------------------Escolha das Escolas---------------------//
int escolha_escola(t_participante vetor_participantes[],int indice) {

    char escola[5][10] = {"ESTG", "ESECS", "ESSLEI", "ESAD", "ESTM"};
    int opcao;
    //calcular o numero de opções com base no tamanho do array char escola
    int num_opcoes = sizeof(escola) / sizeof (escola[0]);
    do {
        printf("Escolha a Escola (1-%d):\n", num_opcoes);
        for (int i = 0; i < num_opcoes; i++) {

            printf("%d) %s\n", i+1, escola[i] );
        }
        if (scanf("%d", &opcao) != 1 || opcao < 0 || opcao > 4) {
            printf("Escola inválida! Escolha entre (1 e 5).\n");
        }
    } while (getchar() != '\n'); // limpa input buffer

    //Imprime a opção escolhida do utilizador
    printf("Opcão escolhida foi: (%s)\n", escola[opcao-1]);
    strcpy(vetor_participantes[indice].escola, escola[opcao-1]);

    return 0;
}
//---------------------Escolha dos tipos de Atividade---------------------//
int escolha_atividade(t_atividade vetor_atividades[], int indice) {

    char atividade[5][10] = {"Académica", "Lazer", "Cultura", "Desporto", "Formação","Outra"};
    int opcao;
    int num_opcoes = sizeof(atividade) / sizeof (atividade[0]);
    do {
        printf("Escolha o tipo da Atividade (1-%d):\n", num_opcoes);
        for (int i = 0; i < num_opcoes; i++) {

            printf("%d) %s\n", i+1, atividade[i] );
        }
        if (scanf("%d", &opcao) != 1 || opcao < 0 || opcao > 5) {
            printf("Escola inválida! Escolha entre (1 e 5).\n");
        }
    } while (getchar() != '\n'); // limpa input buffer

    //Imprime a opção escolhida do utilizador
    printf("Opcão escolhida foi: (%s)\n", atividade[opcao-1]);
    strcpy(vetor_atividades[indice].tipo_atividade, atividade[opcao-1]);

    return 0;
}

//---------------------Escolha da Associação de Estudantes---------------------//
int escolha_associacao_estudantes(t_atividade vetor_atividades[], int indice) {

    char associacao[5][10] = {"AE-ESTG", "AE-ESECS", "AE-ESSLEI", "AE-ESAD","AE-ESTM"};
    int opcao;
    int num_opcoes = sizeof(associacao) / sizeof (associacao[0]);
    do {
        printf("Escolha a Associacao de Estudantes (1-%d):\n", num_opcoes);
        for (int i = 0; i < num_opcoes; i++) {

            printf("%d) %s\n", i+1, associacao[i] );
        }
        if (scanf("%d", &opcao) != 1 || opcao < 0 || opcao > 4) {
            printf("Escola inválida! Escolha entre (1 e 5).\n");
        }
    } while (getchar() != '\n'); // limpa input buffer

    //Imprime a opção escolhida do utilizador
    printf("Opcão escolhida foi: (%s)\n", associacao[opcao-1]);
    strcpy(vetor_atividades[indice].associacao_estudantes, associacao[opcao-1]);

    return 0;
}
//-------------------------Opção pra confirmar a saída do utilizador---------------------//
char confirmar_saida(char opcao_sair) {

    system("cls");
    printf("Registo guardado com sucesso!");
    printf("\n\nPretende continuar a gravar? (S) OU (N):");
    scanf(" %c", &opcao_sair);
    opcao_sair = toupper(opcao_sair);


    return opcao_sair;
}

//-------------------------Registar os Dados dos <<<Participantes>>>---------------------//
int registar_dados_participantes(t_participante vetor_participantes[],int numero_participantes, char opcao_sair) { //Registo dos dados Alunos
    int indice = numero_participantes;
    do {

        system("cls");
        printf("\nIdentificador do participante: (%d)", indice+1);
        vetor_participantes[indice].identificador_sequencia = indice+1;
        obter_string("\nInsira o nome do Participante: ",vetor_participantes[indice].nome);
        escolha_escola(vetor_participantes, indice);
        fflush(stdin);
        obter_NIF(vetor_participantes, indice);
        obter_email(vetor_participantes[indice].email);
        obter_telefone(vetor_participantes,indice);
        system("cls");
        opcao_sair = confirmar_saida(opcao_sair);
        gravar_dados_participantes(vetor_participantes, indice);
        indice = indice +1;
    } while (opcao_sair != 'N');

    return indice;
}
//-------------------------Gravar dados dos <<<Participantes>>> no ficheiro---------------------//
int gravar_dados_participantes(t_participante vetor_participantes[], int numero_participantes) {
    FILE *ficheiro;
    ficheiro = fopen("participantes.dat", "wb");

    if (ficheiro == NULL) {
        printf( "Não foi Possivel criar o ficheiro");
        exit(1);
    } else {
        fwrite(vetor_participantes, sizeof(t_participante), MAX_PARTICIPANTE, ficheiro);
        fwrite(&numero_participantes, sizeof(int),1, ficheiro);
        fclose(ficheiro);
        printf("Escrita dos dados dos Participantes com sucesso!");
        getchar();
    }

}

//-------------------------Ler Ficheiro com os dados dos <<<Participantes>>>---------------------//
int ler_dados_participantes(t_participante vetor_participantes[]) {
    int numero_participantes_lido = 0;
    FILE *ficheiro;
    ficheiro = fopen("participantes.dat", "rb");
    if (ficheiro == NULL)
        printf ("Não foi possível abrir o ficheiro!");
    else {
        fread(vetor_participantes, sizeof(t_participante), MAX_PARTICIPANTE, ficheiro);
        fclose(ficheiro);
        for(int i = 0; i< MAX_PARTICIPANTE; i++) {
            if (vetor_participantes[i].identificador_sequencia == NULL) {
                numero_participantes_lido = i;
                break;
            }
        }
    }
    return numero_participantes_lido;
}

//-------------------------Mostrar o vetor de estrutura do tipo <<<Participantes>>>---------------------//
void mostrar_dados_participantes(t_participante vetor_participantes[]) {

    printf("\n(Dados dos Participantes)\n");
    for(int i = 0; i < MAX_PARTICIPANTE; i++) {
        if (vetor_participantes[i].identificador_sequencia != NULL) {
            printf("\n(ID): %d", vetor_participantes[i].identificador_sequencia);
            printf("\nNome: %s", vetor_participantes[i].nome);
            printf("\nEscola: %s",vetor_participantes[i].escola);
            printf("\nNIF: %s", vetor_participantes[i].nif);
            printf("Email: %s",vetor_participantes[i].email);
            printf("\nTelefone: %s\n", vetor_participantes[i].telefone);

        } else {
            printf("\n->Total de Registos: (%d)",i);
            getchar();
            break;


        }
    }

}
//--------------------------------Registar os Dados das <<<Atividades>>>---------------------------------//
int registar_dados_das_atividades(t_atividade vetor_atividades[], int numero_atividades, char opcao_sair, t_inscricao vetor_inscricoes[]) {
    char valor_inscricao[11];
    int dia,mes,ano, hora, minutos;
    int indice = numero_atividades;
    do {

        printf("\nIdentificador da Atividade: (%d)", indice+1);
        vetor_atividades[indice].identificador_sequencia = indice+1;
        obter_string("\n\nInsira a designação da atividade: ",vetor_atividades[indice].designacao);
        obter_data(vetor_atividades,dia,mes,ano, indice);
        obter_hora_minutos(vetor_atividades, minutos, hora, indice);
        obter_string("\nInsira o Local: ",vetor_atividades[indice].local);
        escolha_atividade(vetor_atividades, indice);
        escolha_associacao_estudantes (vetor_atividades, indice);
        vetor_atividades[indice].valor_inscricao = obter_float("\n\nDigite o valor da inscricao: ");
        opcao_sair = confirmar_saida(opcao_sair);
        gravar_dados_atividades(vetor_atividades,numero_atividades);
        indice = indice +1;
    } while (opcao_sair != 'N');
    return indice;
}

//-------------------------Procurar Atividade <<<Atividades>>>---------------------//
int procurar_atividade(t_atividade vetor_atividades[], int id) {
    int result = -1;
    if (id > 0) {


        for(int i = 0; vetor_atividades[i].identificador_sequencia != NULL; i++) {
            if (vetor_atividades[i].identificador_sequencia == id ) {
                result = 1;
            }
        }
    }
    return result;
}

//-------------------------Procurar Participante <<<Participantes>>>---------------------//
int procurar_participante(t_participante vetor_participantes[], int id) {
    int result = -1;

    if (id > 0) {
        for(int i = 0; vetor_participantes[i].identificador_sequencia != NULL; i++) {

            if (vetor_participantes[i].identificador_sequencia == id  ) {
                result = 1;

            }
        }
    }
    return result;
}

//-------------------------Obter atividade <<<Inscrições>>>---------------------//
void obter_atividade(t_atividade vetor_atividades[], t_inscricao vetor_inscricoes[], int indice) {
    int atividade_procurar;
    do {
        printf("\n\nInsira o id da Atividade (Com base na lista de cima): ");
        scanf("%d", &vetor_inscricoes[indice].identificador_atividade);
        atividade_procurar = procurar_atividade(vetor_atividades, vetor_inscricoes[indice].identificador_atividade);

        if (atividade_procurar == -1) {
            printf("ID não existe!!");
        } else {
            printf("ID válido!");
            break;
        }


    } while (atividade_procurar == -1);
}

//-------------------------Obter Participante <<<Inscrições>>>---------------------//
void obter_participante (t_participante vetor_participantes[],t_inscricao vetor_inscricoes[], int indice) {
    int atividade_procurar;
    do {

        printf("\n\nInsira o id do Participante (Com base na lista de cima): ");
        scanf("%d", &vetor_inscricoes[indice].identificador_participante);
        atividade_procurar = procurar_participante(vetor_participantes, vetor_inscricoes[indice].identificador_participante);

        if (atividade_procurar == -1) {
            printf("ID não existe!!");
        } else {
            printf("ID válido!");
            break;
        }


    } while (atividade_procurar == -1);

}
//-------------------------Ler Ficheiro com os dados das <<<Atividades>>>---------------------//
int ler_dados_atividades(t_atividade vetor_atividades[]) {
    int numero_atividades_lido = 0;
    FILE *ficheiro;
    ficheiro = fopen("atividades.dat", "rb");
    if (ficheiro == NULL)
        printf ("Não foi possível abrir o ficheiro!");
    else {
        fread(vetor_atividades, sizeof(t_atividade), MAX_ATIVIDADES, ficheiro);
        fclose(ficheiro);
        for(int i = 0; i< MAX_ATIVIDADES; i++) {
            if (vetor_atividades[i].identificador_sequencia == NULL) {
                numero_atividades_lido = i;
                break;
            }
        }
    }
    return numero_atividades_lido;
}

//-------------------------Gravar dados das <<<Atividades>>> no ficheiro---------------------//
int gravar_dados_atividades(t_atividade vetor_atividades[], int numero_atividades) {
    FILE *ficheiro;
    ficheiro = fopen("atividades.dat", "wb");

    if (ficheiro == NULL) {
        printf( "Não foi Possivel criar o ficheiro");
        exit(1);
    } else {
        fwrite(vetor_atividades, sizeof(t_atividade),MAX_ATIVIDADES, ficheiro);
        fwrite(&numero_atividades, sizeof(int),1, ficheiro);
        fclose(ficheiro);
        printf("\nEscrita dos dados das Atividades com sucesso!");
        getchar();

    }

}

//-------------------------Mostrar o vetor de estrutura do tipo <<<Atividades>>>--------------------//
void mostrar_dados_atividades(t_atividade vetor_atividades[]) {

    printf("\n\n(Dados das Atividades)");
    for(int i = 0; i< MAX_ATIVIDADES; i++) {
        if (vetor_atividades[i].identificador_sequencia != NULL) {

            t_atividade atividade = vetor_atividades[i];

            printf("\nID: (%d)", vetor_atividades[i].identificador_sequencia);
            printf("\nDesignação: %s", vetor_atividades[i].designacao);
            printf("\nData: %s",vetor_atividades[i].data);
            printf("\nHora: %s", vetor_atividades[i].hora);
            printf("\nLocal: %s",vetor_atividades[i].local);
            printf("\nTipo de atividade: %s", vetor_atividades[i].tipo_atividade);
            printf("\nAssociação de Estudantes: %s", vetor_atividades[i].associacao_estudantes);
            printf("\nValor da Inscrição: %.2f", vetor_atividades[i].valor_inscricao);
            printf("\n\n");
        } else {
            printf("\n->Total de Registos: (%d)",i);
            getchar();
            break;
        }
    }
}

//---------------------------------Registar os Dados das <<<Inscrições>>>------------------------------//
int registar_dados_inscricoes(t_inscricao vetor_inscricoes[], t_participante vetor_participantes[], t_atividade vetor_atividades[],
                              char opcao_sair, int numero_inscricoes) {

    int indice = numero_inscricoes;
    do {

        printf("\n\nIdentificador da inscrição: (%d)", indice+1);
        vetor_inscricoes[indice].identificador_sequencia = indice+1;
        mostrar_dados_participantes(vetor_participantes);
        obter_participante(vetor_participantes, vetor_inscricoes,indice);
        mostrar_dados_atividades(vetor_atividades);
        obter_atividade(vetor_atividades,vetor_inscricoes,indice);
        vetor_inscricoes[indice].valor_pago = obter_float("\n\nDigite o valor Pago: ");
        obter_data_hora_atual(vetor_inscricoes, indice);
        opcao_sair = confirmar_saida(opcao_sair);
        gravar_dados_inscricoes(vetor_inscricoes, indice);
        indice = indice +1;

    } while (opcao_sair != 'N');
    return indice;
}
//------------------------Gravar dados das <<<Inscrições>>> no ficheiro---------------------//
int gravar_dados_inscricoes(t_inscricao vetor_inscricoes[], int numero_inscricoes) {
    FILE *ficheiro;
    ficheiro = fopen("inscricoes.dat", "wb");

    if (ficheiro == NULL) {
        printf( "Não foi Possivel criar o ficheiro");
        exit(1);
    } else {
        fwrite(vetor_inscricoes,sizeof(t_inscricao),MAX_INSCRICOES, ficheiro);
        fwrite(&numero_inscricoes,sizeof(int),1, ficheiro);
        fclose(ficheiro);
        printf("\nEscrita dos dados das Inscrições com sucesso!");
        getchar();

    }
}

//------------------------Ler ficheiros com dados das <<<Inscrições>>>---------------------//
int ler_dados_inscricoes(t_inscricao vetor_inscricoes[]) {
    int numero_inscricoes_lido = 0;
    FILE *ficheiro;
    ficheiro = fopen("inscricoes.dat", "rb");
    if (ficheiro == NULL)
        printf ("Não foi possível abrir o ficheiro!");
    else {
        fread(vetor_inscricoes, sizeof(t_inscricao), MAX_INSCRICOES, ficheiro);
        fclose(ficheiro);
        for(int i = 0; i< MAX_INSCRICOES; i++) {
            if (vetor_inscricoes[i].identificador_sequencia == NULL) {
                numero_inscricoes_lido = i;
                break;
            }
        }
    }
    return numero_inscricoes_lido;
}

//---------------------Mostrar o vetor de estrutura do tipo <<<Inscrições>>>----------------------//
void mostrar_dados_inscricoes(t_inscricao vetor_inscricoes[]) {

    printf("(Dados das Inscrições)\n");
    for(int i = 0; i< MAX_INSCRICOES; i++) {
        if (vetor_inscricoes[i].identificador_sequencia != NULL) {

            printf("\nID: (%d)", vetor_inscricoes[i].identificador_sequencia);
            printf("\nId de participante: %d",vetor_inscricoes[i].identificador_participante);
            printf("\nId da atividade: %d",vetor_inscricoes[i].identificador_atividade);
            printf("\nValor Pago: %.2f", vetor_inscricoes[i].valor_pago);
            printf("\nData: %s",vetor_inscricoes[i].data);
            printf("\nHora: %s", vetor_inscricoes[i].hora);
            printf("\n\n");

        } else {
            printf("\n->Total de Registos: %d\n",i);
            getchar();
            break;
        }
    }

}

//---------------------Numero de Atividades realizadas por cada Associação de Estudantes----------------------//
int numero_atividades_realizadas(t_atividade vetor_atividades[]) {
    int indice;
    int contadores[5]= {0};
    for (int i=0; i < MAX_ATIVIDADES; i++) {

    //strcmp = compara duas strings
        if (strcmp(vetor_atividades[i].associacao_estudantes,"AE-ESTG") == 0)    {
            contadores[0]++;
        } else if (strcmp(vetor_atividades[i].associacao_estudantes,"AE-ESECS")== 0)  {
            contadores[1]++;
        } else if (strcmp(vetor_atividades[i].associacao_estudantes,"AE-ESSLEI") == 0)  {
            contadores[2]++;
        } else if (strcmp(vetor_atividades[i].associacao_estudantes,"AE-ESAD")== 0) {
            contadores[3]++;
        } else if (strcmp(vetor_atividades[i].associacao_estudantes, "AE-ESTM") == 0) {
            contadores[4]++;
        }

    }
    //imprimir resultados
    printf("(Numero de Atividades realizadas por cada Associação de Estudantes)");
    printf("\n\nAE-ESTG: %d", contadores[0]);
    printf("\nAE-ESECS: %d",contadores[1]);
    printf("\nAE-ESSLEI: %d",contadores[2]);
    printf("\nAE-ESAD: %d",contadores[3]);
    printf("\nAE-EST: %d",contadores[4]);
}

//---------------------Percentagens de Inscrições por Escola----------------------//
int percentagem_inscricoes_escola(t_inscricao vetor_inscricoes[], t_participante vetor_participantes[]) {

    int indice;
    float contadores[5]= {0};
    for (int i=0; i < MAX_PARTICIPANTE; i++) {


        //strcmp = compara duas strings
        if (strcmp(vetor_participantes[i].escola,"ESTG") == 0)    {
            contadores[0]++;
        } else if (strcmp(vetor_participantes[i].escola,"ESECS")== 0)  {
            contadores[1]++;
        } else if (strcmp(vetor_participantes[i].escola,"ESSLEI") == 0)  {
            contadores[2]++;
        } else if (strcmp(vetor_participantes[i].escola,"ESAD")== 0) {
            contadores[3]++;
        } else if (strcmp(vetor_participantes[i].escola, "ESTM") == 0) {
            contadores[4]++;
        }
    }
    float total = contadores[0] + contadores[1] + contadores[2] + contadores[3] + contadores[4];
    //imprimir resultados
    printf("(Percentagem de Inscrições por Escola)");
    printf("\n\nESTG: %.2f%%", (contadores[0]++/total)*100);
    printf("\nESECS: %.2f%%", (contadores[1]++/total)*100);
    printf("\nESSLEI: %.2f%%", (contadores[2]++/total)*100);
    printf("\nESAD: %.2f%%", (contadores[3]++/total)*100);
    printf("\nESTM: %.2f%%", (contadores[4]++/total)*100);
}
