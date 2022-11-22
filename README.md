## Projeto de estágio da faculdade

### API desenvolvida em .NET 6 e C#, documentada com Swagger.
### Foi desenvolvido um site back-office para gerenciar serviços que a empresa realiza tais como: pintura, serviços elétricos, hidraúlicos, alvenaria e pequenos reparos. O projeto será utilizado pelo admnistrador da empresa, onde ele poderá realizar orçamentos, agendamentos, relatórios e mais. Uma API desenvolvida em .NET 6 com C# (e também: Entity Framework Core, LINQ...) o banco de dados relacional SQLServer, para o frontend usamos HTML5, CSS3, Javascript e biblioteca ReactJs.

### Seguindo um padrão de Design Patterns e Clean Code, utilizamos o AspNet Core junto com o CQRS e Mediator para organizar ainda melhor nosso projeto. Fazendo com que ele tenha um nível profissional de projeto e que qualquer pessoa com um breve conhecimento possa dar manutenção e entender como funciona ele ao todo.

### O projeto tem integração com o S3 da AWS para armazenar as imagens em cloud. Para fazer o upload da foto no S3, você deve criar um bucket lá e configurar a localização dele e suas credenciais no arquivo CloudStorageService e também o nome do bucket em todos lugares que tem a variável bucket = " " (2 lugares) e a variável BucketName = " " (1 lugar)
### Caso não queria, pode usar o armazenamento local para as imagens mesmo, é só trocar as referência de CloudStorageService para LocalStorageService.

### Para o frontend consumir a API do backend usamos o Axios.

### O projeto é um CRUD completo, onde temos entidades que podem ser Criadas, Atualizadas, Removidas e Mostradas na tela. Tem também uma parte de relatórios que faz um filtro por data (Diário, Semanal, Mensal).
