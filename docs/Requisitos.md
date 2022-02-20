# Requisitos da Aplicação

Voltar ao [Início](../Readme.md) 

## Usuários
- Os `usuários` **devem** conter um nome
- Os `usuários` **devem** conter um login
- Os `usuários` **devem** conter uma senha
- Os `usuários` **devem** conter um email


## Equipe
- [x] As `equipes` **devem** conter um nome
- [x] As `equipes` **devem** conter pelo menos um `participante`
- [x] As `equipes` **podem** conter um `lider`

# Participante
- [x] participantes são usuários do sistema que integram projetos
- [x] participantes **devem** ter nome
- [x] podem participar de um ou mais projetos
- [x] podem pertencer a uma ou mais equipes

# Lider Equipe
- pode liderar uma ou mais equipes
- podem criar projetos
- pode criar equipes

## Projeto
- [x] Os `projetos` **devem** conter um nome
- [x] Os `projetos` **devem** conter um descrição
- [x] Os `projetos` **podem** conter uma data de início
- [x] Os `projetos` **podem** conter uma data de fim
- [x] Os `projetos` **podem** conter vários `fluxo de trabalho`
- Os `projetos` **devem** conter pelo menos uma `equipe de usuários` ****
- Os projetos **podem** conter um participante ou equipe `responsável`

## Fluxo de Trabalho
- [x] Os `fluxos de trabalho` deve conter um título
- [x] Os `fluxos de trabalho` deve estar associado a um `projeto`
- [x] Os `fluxos de trabalho` deve conter `fases`

## Tarefas

- As `tarefas` **devem** conter um título
- As `tarefas` **devem** conter uma descrição
- As `tarefas` **podem** conter um `responsável`
- As `tarefas` **podem** conter uma data de previsão de entrega
- As `tarefas` **devem** conter um `tipo`
- As `tarefas` **podem** ser classificadas por tipo
- As `tarefas` **podem** conter uma `área`
- As `tarefas` **podem** conter `interações`
- As `tarefas` **devem** conter um estado/situação
- As `tarefas` **devem** conter um `histórico`
- As `tarefas` **podem** conter `anexos`
- As `tarefas` **devem** pertencer a um `fluxo de trabalho`

## Áreas
- As `áreas` podem conter subareas

## Interações

- As interações devem conter uma descrição
- As interações devem conter uma data/hora criação
- As interações devem conter um usuário
- As interações devem pertencer a uma tarefa
- As interações podem ser removidas

