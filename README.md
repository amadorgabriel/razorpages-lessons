# Acidente Marte Web App ![Tech ASP.NET](https://img.shields.io/badge/tech-asp.net-brightgreen.svg?style=flat) ![Tech Razor](https://img.shields.io/badge/tech-razor-brightgreen.svg?style=flat) ![App Web](https://img.shields.io/badge/app-web-brightgreen.svg?style=flat) ![Tech .Net](https://img.shields.io/badge/tech-.net-brightgreen.svg?style=flat) 

Passo a passo para a contrução do projeto contido neste repositório. Foco em razor pages sem repositories e database(dados fixos)

**Sumário** :pushpin:
- [ ] [Pré-Requisitos](#ancora1);
- [ ] [Criando a Aplicação](#ancora2);
- [ ] [Manipulando Estrutura](#ancora3);
- [ ] [Criando Models](#ancora4);
- [ ] [Controllers](#ancora5);
- [ ] [Views Razor](#ancora6);
    - [Home](#subancora0);
    - [Shared](#subancora1);
- [ ] [Configurando o Startup](#ancora7);
- [ ] [Desafio](#ancora);



<a id="ancora1" />

## Pré-Requisitos :shipit: 
- Ter Instalado .NET SDK (Software Development Kit) atualizado (3.1.201);
- Ter Instalado Visual Studio Code atualizado;
- Ter em mãos o código Html/Css concluído;

<a id="ancora2" />

## Criando a Aplicação :clipboard:
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

Para rodar sua aplicação digite `dotnet run` e aguarde um pouco, o terminal mostrará duas diferentes urls escolha e uma acesse.


<a id="ancora3" />

## Manipulando Estrutura :open_file_folder:
Abra seu projeto no Visual Studio Code, veja que foram criadas alguns arquivos e pastas esse é o minimo para o projeto funcionar, e para saber mais sobre cada um dos items visite [esta página.](https://docs.microsoft.com/en-us/aspnet/core/tutorials/razor-pages/razor-pages-start?view=aspnetcore-3.1&tabs=visual-studio-code#examine-the-project-files) 

1. Na pasta mãe crie uma pasta chamada 'Refs' e cole os arquivos [Html/Css](https://github.com/amadorsenai/RazorPages_2020_T1/tree/master/Html_Css), servirá de referencia para manipular e organizar os arquivos. 
2. Na pasta **'wwwroot > css'**  substitua o arquivo existente por seu ***arquivo css também da pasta Refs'**;
3. Adequando ao padrão ou arquitetura de projeto [MVC](https://tableless.com.br/mvc-afinal-e-o-que/) substitua o nome da pasta **'Pages'** para **'Views'**;
4. Na pasta Views exclua as demais páginas pré-criadas, deixe somente a pasta **'Shared'** e crie outra pasta chamada **'Home'**;
5. Na pasta mãe crie duas outras pastas, **'Controllers'** e **'Models'** usaremo-as depois. Sua hierarquia deve estar assim:

 ![Hierarquia](https://github.com/amadorsenai/RazorPages_2020_T1/blob/master/assets/00.png)


<a id="ancora4" />

## Criando Models :closed_book:
Nossa aplicação listará casos de acidentes, devemos criar nossos models/modelos pois todos casos cadastrados possuem as mesmas características, por exemplo:

**Características de um Relato de Acidente:**
- Nome relator;
- Data ocorrido;
- Relato em si (texto);

Para criar o model na prática, primeiro na pasta **'Models'** crie o arquivo **'RelatoModel.cs'**. Dentro dele adicione o seguinte código para criar uma classe pública (pode ser acessada de outro arquivo) com os atributos de um caso de acidente.


```C#
using System;

namespace acidenteMarte.Models {
    public class RelatoModel{
        
        public int Id {get; set;}
        public string NomeRelator {get; set;}
        public string Email {get; set;}
        public DateTime Data {get; set;}
        public string Mensagem {get;set;}
        
        //CONSTRUTOR - Método que facilita a criação de objetos;
        public RelatoModel(string nome, string email, DateTime data, string msg)
        {
            this.NomeRelator = nome;
            this.Email = email;
            this.Data = data;
            this.Mensagem = msg;
        }

    }
}
```

- Saiba mais sobre construtores [aqui](https://docs.microsoft.com/pt-br/dotnet/csharp/programming-guide/classes-and-structs/constructors)


<a id="ancora5" />

## Controllers :gear:
> Os controlers como irão fazer o trabalho duro de manipular dados assim como redirecionar páginas. Cada página terá o seu próprio controlador.  

Dentro da pasta 'Controllers' adicione o arquivo **HomeController.cs**;

1. Vamos começar criando a estrutura base de um controlador:

```C#
using Microsoft.AspNetCore.Mvc;

namespace acidenteMarte.Controllers{
    public class HomeController : Controller{
        
    }
}
```

2. Agora vamos criar nossas listas de acidentes. Nossa aplicação não terá um Banco de Dados para receber e cadastrar informações, os dados serão fixos.

```C#
        //Cria a Lista
        List<RelatoModel> listaRelatos = new List<RelatoModel> ();
        
        //Cria cada Relato
        RelatoModel relato1 = new RelatoModel("a", "a@a.com", DateTime.Now(), "aa");
        RelatoModel relato2 = new RelatoModel("b", "b@b.com", DateTime.Now(), "bb");
        RelatoModel relato3 = new RelatoModel("c", "c@c.com", DateTime.Now(), "cc");
        
        //Adiciona os relatos nas listas
        listaRelatos.Add(relato1);
        listaRelatos.Add(relato2);
        listaRelatos.Add(relato3);
```

3. Dentro da classe criada insira o método **Index()**:

```C#
public IActionResult Index(){
     //Armazenao que será a tag '<title>' do html
     ViewData["Title"] = "Home - Página Inicial";
     
     //Armazena a lista de relatos
     ViewData["ListaAcidentes"] = listaRelatos;
     
     //Direciona para o index.cshtml
     return View();
} 
```

3. Agora vamos criar o método de Cadastro:

- `[HttpPost]` - Define o tipo de [webRequest](http://www.macoratti.net/16/11/c_webreq1.htm), isto é se recebe, envia, atualiza ou deleta dados. 
- [`IFormCollection`](https://docs.microsoft.com/en-us/dotnet/api/microsoft.aspnetcore.http.iformcollection?view=aspnetcore-3.1) - Dados de um `<form>` transportafo pela url.
- `return View(nomePagina)` - Retorna a página com nome especificado, caso esteja vazio será retornada a página com o nome do método pai.

```C#
[HttpPost]
public IActionResult Cadastrar(IFormCollection formulario){
    //Cria objeto e atribui valores
    RelatoModel novoRelato = new RelatoModel();
    novoRelato.NomeRelator = form["nome"];
    novoRelato.Email = form["email"];
    novoRelato.Data = form["data"];
    novoRelato.Mensagem = form["msg"];

    listaRelatos.Add(novoRelato);
    return View("Index");
}
```

<a id="ancora6" />

## Views Razor :computer:	
> As páginas razor misturam a sintaxe do C# com HTML por isso os arquivos razor possui a terminação '.cshtml'. :bulb: 
Vamos criar nossa página inicial, para isso crie o arquivo ***Views > Home > Index.cshtml***

<a id="subancora0" />

### Home 
 1. Acesse a página **index.html,** copie o conteúdo da tag ``<main>`` e cole no seu recém-criado **Index.cshtml**. As demais partes como ``<nav>`` ou ``<footer>`` serão colocadas em arquivos diferentes. Nas primeiras linhas do arquivo adicione os seguintes códigos:

```C#
@{  //Para escrever código C# no arquivo razor use essa estrutura com @{}
    
    //Isto define usaremos um modelo para página com nome '_Layout.cshtml' 
    Layout = "_Layout";
    
    //Armazena em uma variável a lista criada no HomeController
    var listaAcidente = ViewData["ListaAcidentes"];

}
```

2. Vamos fazer dois ajustes para tornar a página dinâmica. Primeiro encontre no arquivo o formulário com `class="formCad"` e insira dois atributos que farão que os **dados sejam enviados ao controller quanto o botão for pressionado:**

```Html
<form class="formCad" method="POST" action='@Url.Action("Cadastrar","Home")'>
```

3. Para finalizar a Home falta apenas a listagem, para isso encontre a `<div>` com `class="boxLista"` e modifique seu conteúdo de modo que fique desta forma:

```C#
<article class="boxLista">

    @foreach (var item in listaAcidente)
    {
        <div class="itemLista">
            <div>
                <h4>@item.NomeRelator</h4>
                <p>@item.Data</p>
            </div>

            <p>@item.Mensagem</p>
            <hr />
        </div>
      }
       
</article>
```

> Veja que misturando o C# com html a página fica mais dinâmica pois não importam quantos items tenha a lista o `foreach` irá criar uma nova div com os dados correspondentes. Compare aqui, este deve ser o resultado final do arquivo [Index.cshtml](https://github.com/amadorsenai/RazorPages_2020_T1/blob/master/Projeto%20Razor/acidenteMarte/Views/Home/Index.cshtml)

<a id="subancora1" />

### Shared
> Esta pasta armazena os componentes que se repetem ou são compartilhados entre as páginas, isto é a navbar o Layout e em algumas vezez até o footer.

Com a página inicial criada vamos criar o **_HeaderNavBar** e o **_layout**. Dentro de **Shared** possuem dois arquivos:
- ***'_ValidationScripts'*** (a ser excluído);
- ***'_Layout.cshtml'*** (esse é o modelos da página Home que fizemos a referência).

#### _HeaderNavBar.cshtml

1. Crie o arquivo ***'_HeaderNavBar.cshtml'*** dentro da pasta **Shared**, este será o componente navBar;
2. Dentro dele insira sua ``<nav>`` do **index.html**;
3. Teremos de alterar os caminhos **href** de ambas tags **``<a>``** de modo que este seja o resultado final:

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


- **``@ViewData[]``** - Váriavel que viaja entre Controller e Views e pode armazenar diferentes tipos de dados;
- **``@RenderBody()``** - Renderiza/carrega o conteúdo das páginas que referenciam o ``_Layout.cshtml``;  
- **``@RenderSection()``** - Permite determinar se renderiza/carrega seções específicas dentro da página;


Essa estrutura está estilizada conforme o modelo da aplicação pré-criada portanto devemos adequar a nossas necessidades:
1. Exclua todo o conteúdo e substitua pelo que se encontra no **index.html**;
2. Exclua agora o que esta dento da tag ``<main>`` e inira a função ``@RenderBody()``;
3. Dentro do head ``<title>`` modifique o texto pela variável ``<title> @ViewData["Title"] </title``;
4. Insira o novo caminho do css dentro ``<link>`` na propriedade **href** substituindo o **'./'** por **'~/'** assim como ``<link href="~/css/globalStyle.css">`` (O til encontra o caminho do arquivo independente do ponto de partida);
5. Substitua o que está dentro da tag ``<header>`` por:

``` 
@{
    //Irá carregar a navBar que criada
    Html.RenderPartial("_HeaderNavBar");
}
```

Assim deve estar o layout.cshtml:

 ![Layout.cshtml](https://github.com/amadorsenai/RazorPages_2020_T1/blob/master/assets/02.png)


<a id="ancora7" />

## Configurando o Startup :scroll:
Para enfim rodarmos nosso projeto precisamos dizer qual arquivo deve ser lido primeiro. O ***Startup.cs*** possui as configrações para o projeto rodar, é lá que vamos inserir nossa configuração. Para isso vamos aos passos: 

- No método **Configure Services** (linha 24) configuramos opções espeíficas de serviços, nele vamos retirar o ``services.AddRazorPages()`` e substituir pelo:

```C#
      //Seta a versão do MVC
      services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_3_0);
      //Desabilita opção de roteamento quc conflita com MVC
      services.AddMvc(option => option.EnableEndpointRouting = false);
```

- Agora no método **Configure** escolhemos quais configurações queremos fazer uso. Em nossa aplicação não precisaremos de algumas configurações:

```C#
app.UseRouting();

app.UseAuthorization();

app.UseEndpoints(endpoints =>
{
      endpoints.MapRazorPages();
});
```

 - Devemos ao final do método 'Configure' inserir a configuração que define que quando a aplicação rodar, deverá ser redirecionada através de rotas para o HomeController no método Index(que retorna a página):

```C#
app.UseMvc(routes =>
{
      routes.MapRoute(
            name: "default",
            template: "{controller=Home}/{action=Index}/{id?}"); //DEFININDO A PAGINA PRINCIPAL COMO HOME
});
```


:tada: Parabéns você concluiu o projeto, e persistiu até o final :tada:,  agora rode o projeto com **``dotnet run``** no terminal e aproveie!


<a id="ancora7"/>

## DESAFIO :trophy:

Agora que criou o projeto do total e absoluto zero você precisa praticar, o desafio é o seguinte:

'Você deve desenvolver a página 'CentrosComunicaçao.html' em uma integração para o projeto, colocá-la em funcionamento para isso terá de criar novos métodos, view etc'

Enfim, até mais e boa sorte. 
