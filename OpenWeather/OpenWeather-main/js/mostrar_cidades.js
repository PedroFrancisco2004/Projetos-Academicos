var arr = [];

let resultDIV = document.getElementById('mostrar_cidades');
           resultDIV.innerHTML = "";
           if (localStorage.cidades){             
              arr = JSON.parse(localStorage.getItem('cidades')); 
           }
           
           for(var i in arr){
              let p = document.createElement("p");
              p.innerHTML = arr[i];
              resultDIV.append(p);
           }

function apagar_cidades(){
        arr = [];
        localStorage.cidades = JSON.stringify(arr);  
        location.reload();
}
