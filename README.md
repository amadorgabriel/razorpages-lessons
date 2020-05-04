# Acidente Marte Web App 
Projeto FrontEnd com foco em razor syntax, pages views em ASP.NET Core.

**Sumário**
- [ ] Pré-Requisitos;
- [ ] Criando a Aplicação;
- [ ] Iniciando as Alterações;


## Pré-Requesitos
- Ter Instalado .NET SDK (Software Development Kit) atualizado (3.1.201);
- Ter Instalado Visual Studio Code atualizado;
- É recomendavél já ter criado o código Html/Css;

## Criando a Aplicação
Iremos criar uma aplicação pré-pronta para facilitar o processo, portanto **abra o terminal no diretório aonde deseja salvar seu projeto** e rode os seguintes comantos:

```
dotnet new webApp -o acidenteMarte 
cd acidenteMarte
```

- `dotnet new` irá cria um novo projeto;
- `webApp` define o tipo da aplicação;
- `-o` cria uma pasta chamada "acidenteMarte" para armazenar o projeto;
- `cd` ou **Change directory** levará para um caminho destino;
- `acidenteMarte` será o nome do nosso projeto.

Para rodar sua aplicação digite `dotnet run` e aguarde um pouco, o terminal mostrará duas diferentes urls escolha e acesse uma delas.


## Iniciando as Alterações
Abra seu projeto no Visual Studio Code, veja que foram criadas alguns arquivos e pastas esse é o minimo para o projeto funcionar, e para saber mais sobre cada um dos items visite [esta página.](https://docs.microsoft.com/en-us/aspnet/core/tutorials/razor-pages/razor-pages-start?view=aspnetcore-3.1&tabs=visual-studio-code#examine-the-project-files) 

Na pasta mãe crie uma pasta chamada 'Refs' e cole os arquivos [Html/Css](Html_Css/), servirá de referencia para manipular e organizar os arquivos. Sua hierarquia deve estar assim:

 ![Hierarquia](http://https://github.com/amadorsenai/RazorPages_2020_T1/assets/00.png)
