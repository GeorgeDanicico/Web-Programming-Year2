let destinations = [];
let currentIndex = 0;

async function getDestinations() {
  let xmlhttp = new XMLHttpRequest();
  xmlhttp.open("GET", "getdestinations.php", true)
  xmlhttp.send()

  xmlhttp.onreadystatechange = function() {
    if (this.readyState == 4 && this.status == 200) {
      destinations = JSON.parse(this.responseText);
      
    }
  }
}


const button = document.getElementsByClassName('destinations')[0];

button.addEventListener('click', async () => {
  getDestinations()
});


