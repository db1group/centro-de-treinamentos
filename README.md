# Centro de treinamentos

## O que é?
O *centro de treinamentos* é o caminho proposto pela DB1 para um colaborador se tornar um _desenvolvedor ideal_.  
Um sistema de gestão de aprendizagem apresentará agrupamentos e conteúdos previamente selecionados a serem estudados pelos candidatos.
Este é um guia que aponta o caminho de evolução e, a partir dele, os candidatos devem validar seus conhecimentos utilizando outras ferramentas.

> Atualmente o programa contará com um foco em desenvolvedores de backend e ele é fortemente influenciado pelas tecnologias dos projetos em execução pela DB1.

## Como contribuir?
A contribuição com a estrutura ou materiais do centro de treinamentos será feita pela submissão de pull requests à este repositório.
O arquivo [centroTreinamento.json](Assets/Result/centroTreinamento.json) é a fonte dos dados e deverá ser editado na intenção de incluir/editar/remover conteúdos.
O sistema de gestão de aprendizagem, atualmente, reflete essa estrutura de forma manual, isto é, o conteúdo será incluido/editado/removido com intervenção humana, logo, um pull request que "refatora" a estrutura de forma global como espaçamento ou ordenação dos atuais componentes será descartado.

### Arquivo fonte de dados
Neste repositório, há o arquivo [centroTreinamento.json](Assets/Result/centroTreinamento.json) que contém uma estrutura conforme a seguinte:
```json
{
  "Skills": [
    {
      "Name": "Name",
      "Tracks": [
        {
          "Name": "Name",
          "Objective": "Objective",
          "Objectives": [
            {
              "Name": "Name",
              "Level": 1,
              "Learnables": [
                {
                  "Name": "Name",
                  "Contents": [
                    {
                      "Description": "Description",
                      "Link": "Link",
                      "Type": "Type",
                      "Language": "Language",
                      "Order": 1
                    }
                  ]
                }
              ]
            }
          ]
        }
      ]
    }
  ]
}
```
#### Skill
Ou `Competência`, é um agrupador de trilhas, por exemplo, _Competência de codificador mestre_. Ao completar as trilhas propostas, é esperado que o colaborador adquira essa competência.

#### Track
Ou `Trilha`, agrupa objetivos específicos de um objetivo macro, por exemplo, _Trilha de excelência em código_.

#### Objective
Ou `Objetivo`, agrupa "aprendíveis". Por exemplo, _objetivo de desenvolver código legível, através de boas práticas de programação e padrões de qualidade, utilizando ferramentas de análise estática de código como apoio_.

#### Learnable
Ou `aprendível`, agrupa conteúdos. É, em suma, um assunto bastante concreto que precisa ser conhecido. Por exemplo: _ferramentas de análise estática de código_.

#### Contents
Ou `Conteúdo`, é um conteúdo previamente selecionado (curado) por colaboradores da DB1 (analisado do ponto de vista de praticidade, didática e qualidade). Quando o aprendível é algo subjetivo, os conteúdos podem ser dicas descritivas do assunto.

### Passo a passo
1. Clone este repositório
2. Edite o arquivo [centroTreinamento.json](Assets/Result/centroTreinamento.json) com novos materiais ou estrutura
3. Faça o commit, push e abra um pull request contendo a edição
   1. Neste PR, escreva um breve resumo do que está sendo submetido
   2. Toda interação/comunicação será feita por meio do pull request

## Contatos
A gestão deste conteúdo é responsabilidade do time de gestão de pessoas e feedbacks podem ser encaminhados para gp@db1.com.br

# Conteúdo deste repositório
Este repositório git contém os recursos tecnológicos que possam ser utilizados na elaboração do centro de treinamento. Cada novo item versionado neste repositório será descrito nas seções a seguir.

## Projeto Converter
Este foi um projeto criado para converter um material inicial no arquivo JSON fonte das informações. Tal projeto será mantido aqui para histórico ou para algum evenutual uso futuro. A estrutura básica deste programa faz as seguintes tarefas:

- Lê uma base de dados `.accdb` e gera um arquivo `JSON`
- Lê o arquivo `JSON` e gera arquivos `md` (markdown) com um esqueleto do centro de treinamento

Conforme mencionado, o código está preparado para ler um arquivo feito em MS Access, também versionado neste repositório, que contém os dados originais dos materiais do centro de treinamento. *Atenção*, este arquivo não será mantido, isto é, o arquivo `.accdb` não será atualizado a partir do JSON depois que as contribuições forem aceitas por meio de pull requests.

### Tecnologias
- Aplicação console escrita em C# (.net core 3.1)
- Utiliza Entity Framework para ler o arquivo `.accdb`
- Utiliza serializador padrão para geração do arquivo `.json`
- Utiliza classes de domínio para geração de arquivos `.md`

### Input
- Arquivo [centroTreinamento.accdb](Assets/centroTreinamento.accdb)
### Outputs
- Arquivo [centroTreinamento.json](Assets/Result/centroTreinamento.json) (contendo o banco de dados representado em JSON)
- Arquivos `.md` com a representação do centro de treinamento. O material completo pode ser visto [aqui](Assets/Result)

## Próximos passos
- Criação de trilhas para outras áreas
- Após consolidação da estrutura em POC do Sensei LMS, gerar arquivos .csv que funcionem com a estrutura 