# Acidente Marte Web App 
Projeto FrontEnd com foco em razor syntax, pages views em ASP.NET Core.

**Sumário**
- [ ] Pré-Requisitos;
- [ ] Criando a Aplicação;
- [ ] Manipulando Estrutura;
- [ ] Página Inicial Razor;


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


## Manipulando Estrutura 
Abra seu projeto no Visual Studio Code, veja que foram criadas alguns arquivos e pastas esse é o minimo para o projeto funcionar, e para saber mais sobre cada um dos items visite [esta página.](https://docs.microsoft.com/en-us/aspnet/core/tutorials/razor-pages/razor-pages-start?view=aspnetcore-3.1&tabs=visual-studio-code#examine-the-project-files) 

1. Na pasta mãe crie uma pasta chamada 'Refs' e cole os arquivos [Html/Css](https://github.com/amadorsenai/RazorPages_2020_T1/tree/master/Html_Css), servirá de referencia para manipular e organizar os arquivos. Sua hierarquia deve estar assim:


 ![Hierarquia](https://github.com/amadorsenai/RazorPages_2020_T1/blob/master/assets/00.png)

2. Na pasta **'wwwroot > css'**  substitua o arquivo existente por seu arquivo css da pasta **'Refs'**;
3. Adequando ao padrão ou arquitetura de projeto MVC substitua o nome da pasta **'Pages'** para **'Views'**;
4. Na pasta Views exclua as páginas pré-criadas, deixe somente a pasta **'Shared'** e crie outra pasta chamada **'Home'**;


## Página Inicial Razor
> As páginas razor misturam a sintaxe do C# com HTML por isso os arquivos razor possui a terminação '.cshtml'. :bulb: 
Vamos criar nossa página inicial, para isso crie o arquivo ***Views > Home > Index.cshtml***

### Index.cshtml
- Dentro da sua página **index Html** copie o conteúdo da tag ``<main>`` e cole no seu recém-criado Index.cshtml. As demais partes como ``<nav>`` ou ``<footer>`` serão colocadas em arquivos diferentes, pois são componentes que todas as páginas compartilham. 

- E por fim, nas primeiras linhas do arquivo adicione os seguintes códigos:

```C#
@{  //Para escrever código C# no arquivo razor use essa estrutura com @{}
    
    //Isto define que a página irá pegar o conteúdo do arquivo e transformar em html puro a partir de um layout.
    Layout = "_Layout";
    
    //Váriavel que carrega o <title> da página;
    ViewData["Titulo_Página"] = "Home - Página Inicial";
}
```

Voce pode ver mais sobre ViewData[] [nesse_link]()  Este deve ser o resultado final:

 ![Index.cshtml](https://github.com/amadorsenai/RazorPages_2020_T1/blob/master/assets/01.png)

### Layout.cshtml

Voce pode já ter percebido que no caminho **Views > Shared** possuem duas pastas, uma delas chamada ***'_ValidationScripts'*** que pode ser excluida e outra que justamente se chama ***'_Layout.cshtml'*** esse é o modelos que fizemos a referência.

> O Layout é uma estrutura comum de hmtl, por exemplo, quando o nosso index.cshtml é acessada pelo nagevador a página chamará o layout que juntos serão mostrados na tela do computador.

- **``@RenderBody()``** - Carrega  
- **``@ViewData``** - 
-
