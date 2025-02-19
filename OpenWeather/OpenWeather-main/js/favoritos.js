function Obter_Favorito() {
  try
  {
    //obter valor no textbox
    var cidade = document.getElementById('barra_pesquisa').value;

    //array para criar array de objetos
    let cidades = new Array();

    //verificar se existe cidades guardadas no localstorage
    if(localStorage.hasOwnProperty("cidades")){
      //converte de string para objeto
      cidades = JSON.parse(localStorage.getItem("cidades"));
    }

    //adiciona novo objeto cidade ao array criado
    cidades.push({cidade});

    // Guardar no localstorage
    localStorage.setItem("cidades", JSON.stringify(cidades));
    alert("Cidade guardada com sucesso!");
  }
  catch{
    alert("...Cidade não inserida...\n...Insira de novo...");
  }
}