// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

//variavel para controlar a quantidade inicial de camisas na modal
let quantCamisas = 1;

let cart = []; // carinho

const addCart = (addProduct) => document.querySelector(addProduct);

const adicionarNoCarrinho = () => {
  seleciona("addProduct").addEventListener("click", () => {
    console.log("Adicionar no carrinho");
  });
};
