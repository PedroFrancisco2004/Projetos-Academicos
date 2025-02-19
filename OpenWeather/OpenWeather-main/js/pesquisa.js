function Obter_Cidade() {
  var cidade = document.getElementById('barra_pesquisa');

  document.getElementById('cidade2').style.display = "none";
  document.getElementById('cidade').style.visibility = "visible";

  let weather = {
    apiKey: "74d90f8a0dc103698bf1cb634e5dc227",

    fetchWeather: function (city) {
      fetch(
        //vai buscar o código da API com os dados inseridos
        "https://api.openweathermap.org/data/2.5/weather?q=" + cidade.value + "&units=metric&appid=" + this.apiKey + "&lang=pt"
      )
        //se a cidade for inválida
        .then((response) => {
          if (!response.ok) {
            alert("...Cidade não encontrada...");
            throw new Error("...Cidade não encontrada...");
          }
          return response.json();
        })
        //se a cidade existir
        .then((data) => this.displayWeather(data));
    },

    displayWeather: function (data) {
      //constante para ir buscar os valores desejados à API
      const { lat, lon } = data.coord;
      const { name } = data;
      const { icon, description } = data.weather[0];
      const { temp, pressure, humidity } = data.main;
      const { speed } = data.wind;

      //altera os valores existentes
      document.querySelector(".cidade").innerText = name;
      document.querySelector(".icon").src = "https://openweathermap.org/img/wn/" + icon + ".png";
      document.querySelector(".latitude").innerText = "Latitude: " + lat;
      document.querySelector(".longitude").innerText = "Longitude: " + lon;
      document.querySelector(".descricao").innerText = description;
      document.querySelector(".temperatura").innerText = "Temperatura: " + temp + "°C";
      document.querySelector(".humidade").innerText = "Humidade: " + humidity + "%";
      document.querySelector(".vento").innerText = "Vento: " + speed + " m/s";
      document.querySelector(".pressao").innerHTML = "Pressão Atmosférica: " + pressure + "hPa";
    },
  };

  let forecast = {
    apiKey: "74d90f8a0dc103698bf1cb634e5dc227",

    fetchForecast: function (city) {
      fetch(
        //vai buscar o código da API com os dados inseridos
        "http://api.openweathermap.org/data/2.5/forecast?q=" + cidade.value + "&units=metric&appid=" + this.apiKey + "&lang=pt"
      )
        //se a cidade for inválida
        .then((response) => response.json())
        //se a cidade existir
        .then((data) => this.displayForecast(data));
    },

    displayForecast: function (data) {
      for (i = 8, j = 2; i <= data.list.length; i += 8, j++) {
        for (k = 0, y = 7; k < 5; k++, y++) {
          //limpar o código HTML existente naquele setor
          document.querySelector('.quadrado' + y).innerHTML = '';

          //cria o elemento desejado
          let flex2 = document.createElement('div');
          //define os atributos ao elemento criado
          flex2.setAttribute('class', 'flex');
          //define onde o elemento cria se vai fixar no código HTML
          document.querySelector('.quadrado' + y).appendChild(flex2);

          let img2 = document.createElement('img');
          img2.setAttribute('class', 'icon');
          img2.src = "https://openweathermap.org/img/wn/" + data.list[k].weather[0].icon + ".png";
          flex2.appendChild(img2);

          let desc2 = document.createElement('div');
          desc2.setAttribute('class', 'descricao');
          desc2.innerText = data.list[k].weather[0].description;
          flex2.appendChild(desc2);

          let data_hora2 = document.createElement('div');
          data_hora2.setAttribute('class', 'data_hora');
          data_hora2.innerText = new Date(data.list[k].dt * 1000).toLocaleDateString('pt-pt', { day: 'numeric', month: 'short', hour: 'numeric', minute: 'numeric' });
          document.querySelector('.quadrado' + y).appendChild(data_hora2);

          let temp2 = document.createElement('div');
          temp2.setAttribute('class', 'temperatura');
          temp2.innerText = "Temperatura: " + data.list[k].main.temp + "ºC";
          document.querySelector('.quadrado' + y).appendChild(temp2);

          let press2 = document.createElement('div');
          press2.setAttribute('class', 'pressao');
          press2.innerText = "Pressão Atmosférica: " + data.list[k].main.pressure + "hPa";
          document.querySelector('.quadrado' + y).appendChild(press2);

          let hum2 = document.createElement('div');
          hum2.setAttribute('class', 'humidade');
          hum2.innerText = "Humidade: " + data.list[k].main.humidity + "%";
          document.querySelector('.quadrado' + y).appendChild(hum2);

          let vento2 = document.createElement('div');
          vento2.setAttribute('class', 'vento');
          vento2.innerText = "Vento: " + data.list[k].wind.speed + " m/s";
          document.querySelector('.quadrado' + y).appendChild(vento2);
        }
        //limpar o código HTML existente naquele setor
        document.querySelector('.quadrado' + j).innerHTML = '';

        //cria o elemento desejado
        let flex = document.createElement('div');
        //define os atributos ao elemento criado
        flex.setAttribute('class', 'flex');
        //define onde o elemento cria se vai fixar no código HTML
        document.querySelector('.quadrado' + j).appendChild(flex);

        let img = document.createElement('img');
        img.setAttribute('class', 'icon');
        //verificação se chegou ao ultimo valor da lista caso sim tira um valor da lista para apresentar os valores
        if (i == 40) {
          img.src = "https://openweathermap.org/img/wn/" + data.list[i - 1].weather[0].icon + ".png";
        } else {
          img.src = "https://openweathermap.org/img/wn/" + data.list[i].weather[0].icon + ".png";
        }
        flex.appendChild(img);

        let desc = document.createElement('div');
        desc.setAttribute('class', 'descricao');
        if (i == 40) {
          desc.innerText = data.list[i - 1].weather[0].description;
        } else {
          desc.innerText = data.list[i].weather[0].description;
        }
        flex.appendChild(desc);

        let data_hora = document.createElement('div');
        data_hora.setAttribute('class', 'data_hora');
        if (i == 40) {
          data_hora.innerText = new Date(data.list[i - 1].dt * 1000).toLocaleDateString('pt-pt', { weekday: 'long', day: 'numeric', month: 'short' });
        } else {
          data_hora.innerText = new Date(data.list[i].dt * 1000).toLocaleDateString('pt-pt', { weekday: 'long', day: 'numeric', month: 'short' });
        }
        document.querySelector('.quadrado' + j).appendChild(data_hora);

        let temp_min = document.createElement('div');
        temp_min.setAttribute('class', 'temperatura');
        if (i == 40) {
          temp_min.innerText = "Temperatura Mínima: " + data.list[i - 1].main.temp_min + "ºC";
        } else {
          temp_min.innerText = "Temperatura Mínima: " + data.list[i].main.temp_min + "ºC";
        }
        document.querySelector('.quadrado' + j).appendChild(temp_min);

        let temp_max = document.createElement('div');
        temp_max.setAttribute('class', 'temperatura');
        if (i == 40) {
          temp_max.innerText = "Temperatura Máxima: " + data.list[i - 1].main.temp_max + "ºC";
        } else {
          temp_max.innerText = "Temperatura Máxima: " + data.list[i].main.temp_max + "ºC";
        }
        document.querySelector('.quadrado' + j).appendChild(temp_max);

        let press = document.createElement('div');
        press.setAttribute('class', 'pressao');
        if (i == 40) {
          press.innerText = "Pressão Atmosférica: " + data.list[i - 1].main.pressure + "hPa";
        } else {
          press.innerText = "Pressão Atmosférica: " + data.list[i].main.pressure + "hPa";
        }
        document.querySelector('.quadrado' + j).appendChild(press);

        let hum = document.createElement('div');
        hum.setAttribute('class', 'humidade');
        if (i == 40) {
          hum.innerText = "Humidade: " + data.list[i - 1].main.humidity + "%";
        } else {
          hum.innerText = "Humidade: " + data.list[i].main.humidity + "%";
        }
        document.querySelector('.quadrado' + j).appendChild(hum);

        let vento = document.createElement('div');
        vento.setAttribute('class', 'vento');
        if (i == 40) {
          vento.innerText = "Vento: " + data.list[i - 1].wind.speed + " m/s";
        } else {
          vento.innerText = "Vento: " + data.list[i].wind.speed + " m/s";
        }
        document.querySelector('.quadrado' + j).appendChild(vento);
      }
    }
  }
  weather.fetchWeather(cidade);
  forecast.fetchForecast(cidade);
};

function Localizacao() {
  navigator.geolocation.getCurrentPosition((success) => {
    let { latitude, longitude } = success.coords;

    fetch(
      //vai buscar o código da API com os dados inseridos
      "https://api.openweathermap.org/data/2.5/weather?lat=" + latitude + "&lon=" + longitude + "&units=metric&appid=74d90f8a0dc103698bf1cb634e5dc227&lang=pt"
    )
      //se a cidade for inválida
      .then((response) => response.json())
      //se a cidade existir
      .then((data) => displayWeather2(data));
  })
}

function displayWeather2(data) {
  //constante para ir buscar os valores desejados à API
  const { lat, lon } = data.coord;
  const { name } = data;
  const { icon, description } = data.weather[0];
  const { temp, pressure, humidity } = data.main;
  const { speed } = data.wind;

  //altera os valores existentes
  document.querySelector(".cidade1").innerText = name;
  document.querySelector(".icon1").src = "https://openweathermap.org/img/wn/" + icon + ".png";
  document.querySelector(".descricao1").innerText = description;
  document.querySelector(".latitude1").innerText = "Latitude: " + lat;
  document.querySelector(".longitude1").innerText = "Longitude: " + lon;
  document.querySelector(".temperatura1").innerText = "Temperatura: " + temp + "°C";
  document.querySelector(".humidade1").innerText = "Humidade: " + humidity + "%";
  document.querySelector(".vento1").innerText = "Vento: " + speed + " m/s";
  document.querySelector(".pressao1").innerText = "Pressão Atmosférica: " + pressure + "hPa";
}

Localizacao();