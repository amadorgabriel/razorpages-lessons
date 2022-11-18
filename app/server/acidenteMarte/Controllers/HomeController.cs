using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using acidenteMarte.Models;

namespace acidenteMarte.Controllers{
    public class HomeController : Controller{
        
        //Cria a Lista
        List<RelatoModel> listaRelatos = new List<RelatoModel> ();
    
        //Cria cada Relato
        RelatoModel relato1 = new RelatoModel("Jurandir da Silva", "jurandir@gmail.com", DateTime.Now, "Uma casa desabou no Leste");
        RelatoModel relato2 = new RelatoModel("Fulano da Costa Mendes", "fulano@yahoo.com", DateTime.Now, "A barreria que continha terra desabou");
        RelatoModel relato3 = new RelatoModel("Isaac Newton Tavares", "isaac@outlook.com", DateTime.Now, "Houve um acidente de trânsito na Avenida Principal");

        public IActionResult Index(){
            //Se houver, chame a lista do repositório
            listaRelatos.Add(relato1);
            listaRelatos.Add(relato2);
            listaRelatos.Add(relato3);

            ViewData["ListaAcidentes"] = listaRelatos;
            ViewData["Title"] = "Home - Página Inicial";
            return View();
        } 

        [HttpPost]
        public IActionResult Cadastrar(IFormCollection formulario){
            RelatoModel novoRelato = new RelatoModel(
                formulario["nome"], 
                formulario["email"],
                DateTime.Parse(formulario["data"]),
                formulario["msg"]
            );
            
            //Se houver salvar objeto pelo repositório
            listaRelatos.Add(novoRelato);

            ViewData["Title"] = "Scania - Sucesso no Cadastro";
            ViewBag.NomePessoa = novoRelato.NomeRelator;
            return View("_SucessPage");
        }

    }
}