# Acidente Marte Web App 
Passo a passo para a contrução do projeto com foco em razor syntax, pages views em ASP.NET Core. 

**Sumário**
- [ ] Pré-Requisitos;
- [ ] Criando a Aplicação;
- [ ] Manipulando Estrutura;
- [ ] Views Razor;
- [ ] Controller;


## Pré-Requesitos
- Ter Instalado .NET SDK (Software Development Kit) atualizado (3.1.201);
- Ter Instalado Visual Studio Code atualizado;
- É recomendavél ter em mãos o código Html/Css;

## Criando a Aplicação
Iremos criar uma aplicação pré-pronta para facilitar o aprendizado, portanto **abra o terminal no diretório aonde deseja salvar seu projeto** e rode os seguintes comantos:

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
3. Adequando ao padrão ou arquitetura de projeto [MVC](https://tableless.com.br/mvc-afinal-e-o-que/) substitua o nome da pasta **'Pages'** para **'Views'**;
4. Na pasta Views exclua as demais páginas pré-criadas, deixe somente a pasta **'Shared'**(Esta pasta armazena estruturas de html que se repetem entre páginas como navbar e/ou footer) e crie outra pasta chamada **'Home'**;


## Views Razor
> As páginas razor misturam a sintaxe do C# com HTML por isso os arquivos razor possui a terminação '.cshtml'. :bulb: 
Vamos criar nossa página inicial, para isso crie o arquivo ***Views > Home > Index.cshtml***

### Home 
- Dentro da sua pasta 'Refs' acesse a página **index.html,** copie o conteúdo da tag ``<main>`` e cole no seu recém-criado **Index.cshtml**. As demais partes como ``<nav>`` ou ``<footer>`` serão colocadas em arquivos diferentes. 

- E por fim, nas primeiras linhas do arquivo adicione os seguintes códigos:

```C#
@{  //Para escrever código C# no arquivo razor use essa estrutura com @{}
    
    //Isto define que a página irá pegar o conteúdo do arquivo e transformar em html puro a partir de um layout.
    Layout = "_Layout";
}
```

No arquivo há o conteúdo da página porém está pendente a estutura básica do html, essa estrutura se encontrará no arquivo **Layout.cshtml** que o referênciamos com o código acima. A prática de separar partes do código é recomendada pois deixa o código mais fácil de ser lido. Neste passo este deve ser o resultado final:

 ![Index.cshtml](https://github.com/amadorsenai/RazorPages_2020_T1/blob/master/assets/01.png)

### Shared
Com a página inicial criada vamos codar a **_HeaderNavBar** e o **_layout** para podermos rodar o projeto.

Dentro de **Shared** possuem dois arquivos:
- ***'_ValidationScripts'*** (a ser excluída);
- ***'_Layout.cshtml'*** (esse é o modelos que fizemos a referência).

#### _HeaderNavBar.cshtml

1. Crie o arquivo ***'_HeaderNavBar.cshtml'*** dentro da pasta shared, este será o componente navBar;
2. Dentro dele insira sua ``<nav>`` do **index.html**;
3. Teremos de alternar os caminhos ``href`` de ambas tags **``<a>``** de modo que este seja o resultado final:

```Html
<nav>
    <h1>Scania</h1>
    <div>
        <ul class="ulMenu">
            <li class="liMenu"><a asp-controller="Home" asp-action="Index">Home</a></li>
            <li class="liMenu"><a href='@Url.Action("Index", "Centros")'>Centros de Comunicação</a></li>
        </ul>
    </div>
</nav>
```

- [***``asp-controller``***](https://docs.microsoft.com/pt-br/aspnet/core/mvc/views/working-with-forms?view=aspnetcore-3.1#the-form-action-tag-helper) - Define o controler que a página será direcionada;
- [***``asp-action``***](https://docs.microsoft.com/pt-br/aspnet/core/mvc/views/working-with-forms?view=aspnetcore-3.1#the-form-action-tag-helper) - Define o método que a página será direcionada;
- [***``@Url.Action``***](https://docs.microsoft.com/en-us/dotnet/api/system.web.mvc.urlhelper.action?view=aspnet-mvc-5.2) - Define o controler e o método que a página será direcionada.

Obs.: Quando clicarmos em um botão do menu será mandada uma requisição para o controller que nos redicionará para a página desejada. 


#### Layout.cshtml

> O [Layout](https://docs.microsoft.com/pt-br/aspnet/core/mvc/views/layout?view=aspnetcore-3.1#what-is-a-layout) é onde cada seção de uma página se encontra, é também a base da nossa página home. Se navegar pelo arquivo verá que é a estrutura html pendente na página que criamos com a adição de alguns novos conceitos: 


- **``@ViewData[]``** - Váriavel que pode armazenar diferentes tipos de dados, nesse caso o texto do ``<title>`` da página;
- **``@RenderBody()``** - Renderiza/carrega o conteúdo das páginas que referenciam o ``_Layout.cshtml``;  
- **``@RenderSection()``** - Permite determinar se renderiza/carrega seções específicas dentro da página;


Essa estrutura está estilizada conforme o modelo da aplicação pré-criada portanto para adequar a nossas necessidades devemos:.
1. Excluir todo o conteúdo(``ctrl + A`` + ``ctrl + X``) e substituir com toda a estrutura do **index.html**;
2. Exclua agora o que esta dento da tag ``<main>`` deixando-as vazias e inira a função ``@RenderBody()``;
3. Dentro do head ``<title>`` modifique o texto por: ``<title> @ViewData["Title"] </title";
4. Dentro do head ``<link>`` na propriedade **href** altere o novo caminho do css substituindo o **'./'** por **'~/'**``<link href="~/css/globalStyle.css">`` (O til encontra o caminho independente do ponto de partida);
5. Substitua o que está dentro da tag ``<header>`` por:

````html
@{
    //Irá carregar a navBar que criada
    Html.RenderPartial("_HeaderNavBar");
}
```

Assim deve estar o layout.cshtml:

 ![Layout.cshtml](https://github.com/amadorsenai/RazorPages_2020_T1/blob/master/assets/02.png)


## Controllers

La vamos nós..
