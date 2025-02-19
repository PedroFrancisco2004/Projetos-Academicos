let weather = {
  apiKey: "74d90f8a0dc103698bf1cb634e5dc227",

  cidade1: "Alcochete", cidade2: "Coimbra", cidade3: "Alcobaça", cidade4: "Braga", cidade5: "Faro", cidade6: "Sintra",

  fetchWeather: function (city) {
    for (i = 1; i < 7; i++) {
      switch (i) {
        case 1:
          cidade = this.cidade1;
          break;
        case 2:
          cidade = this.cidade2;
          break;
        case 3:
          cidade = this.cidade3;
          break;
        case 4:
          cidade = this.cidade4;
          break;
        case 5:
          cidade = this.cidade5;
          break;
        case 6:
          cidade = this.cidade6;
          break;
      }
      fetch(
        //vai buscar o código da API com os dados inseridos
        "https://api.openweathermap.org/data/2.5/weather?q=" + cidade + "&units=metric&appid=" + this.apiKey + "&lang=pt"
      )
        //se a cidade for inválida
        .then((response) => {
          if (!response.ok) {
            alert("No weather found.");
            throw new Error("No weather found.");
          }
          return response.json();
        })
        //se a cidade existir
        .then((data) => this.displayWeather(data));
    }
  },

  //vai criar o código para mostrar cada cidade
  displayWeather: function (data) {
    //cria o elemento desejado
    let quadrado = document.createElement('div');
    //define os atributos ao elemento criado
    quadrado.setAttribute('class', 'quadrado');
    //define onde o elemento cria se vai fixar no código HTML
    document.querySelector('.row').appendChild(quadrado);

    let nome = document.createElement('h2');
    nome.setAttribute('class', 'cidade');
    nome.innerText = data.name;
    quadrado.appendChild(nome);

    let flex = document.createElement('div');
    flex.setAttribute('class', 'flex');
    quadrado.appendChild(flex);

    let img = document.createElement('img');
    img.setAttribute('class', 'icon');
    img.src = "https://openweathermap.org/img/wn/" + data.weather[0].icon + ".png";
    flex.appendChild(img);

    let desc = document.createElement('div');
    desc.setAttribute('class', 'descricao');
    desc.innerText = data.weather[0].description;
    flex.appendChild(desc);

    let temp = document.createElement('div');
    temp.setAttribute('class', 'temperatura');
    temp.innerText = "Temperatura: "+data.main.temp + "ºC";
    quadrado.appendChild(temp);

    let latitude = document.createElement('div');
    latitude.setAttribute('class', 'latitude');
    latitude.innerText = "Latitude: " + data.coord.lat;
    quadrado.appendChild(latitude);

    let longitude = document.createElement('div');
    longitude.setAttribute('class', 'longitude');
    longitude.innerText = "Longitude: " + data.coord.lon;
    quadrado.appendChild(longitude);

    let press = document.createElement('div');
    press.setAttribute('class', 'pressao');
    press.innerText = "Pressão Atmosférica: " + data.main.pressure + "hPa";
    quadrado.appendChild(press);

    let hum = document.createElement('div');
    hum.setAttribute('class', 'humidade');
    hum.innerText = "Humidade: " + data.main.humidity + "%";
    quadrado.appendChild(hum);

    let vento = document.createElement('div');
    vento.setAttribute('class', 'vento');
    vento.innerText = "Vento: " + data.wind.speed + " m/s";
    quadrado.appendChild(vento);
  },
};

//corre automaticamente o script todo
weather.fetchWeather()