let destinations = [];
let currentIndex = 0;

function getDestinations() {
  let xmlhttp = new XMLHttpRequest();
  xmlhttp.open("GET", "getdestinations.php", true)
  xmlhttp.send()

  xmlhttp.onreadystatechange = function() {
    if (this.readyState == 4 && this.status == 200) {
      destinations = JSON.parse(this.responseText);
      let listContainer = document.querySelector('.destination-list');
      let listElement = document.createElement('ul');
      let length = destinations.length < 4 ? destinations.length : 4;
      console.log(listContainer)
      console.log(destinations);
      for (let i = 0; i < length; i++) {
        let liElem = document.createElement('li');
        liElem.innerHTML = '<p>ID: ' + destinations[i + currentIndex].id +' </p>'
        listElement.appendChild(liElem);
      }
      currentIndex += length;
      listContainer.appendChild(listElement);

    }
  }
}

const fetchBtn = document.querySelector('.fetch');

const slideBtnL = document.querySelector('.slide-left');
const slideBtnR = document.querySelector('.slide-right');

fetchBtn.addEventListener('click', () => {
  getDestinations()
});

slideBtnL.addEventListener('click', () => {
  if (currentIndex > 4) {
    if (currentIndex % 4 !== 0) {
      currentIndex -= (currentIndex % 4);
    } else {
      currentIndex -= 4
    }
      let listContainer = document.querySelector('.destination-list');
      let destDist = document.querySelector('ul');
      listContainer.removeChild(destDist);

      let listElement = document.createElement('ul');
      for (let i = 0; i < 4; i++) {
        let liElem = document.createElement('li');
        liElem.innerHTML = '<p>ID: ' + destinations[currentIndex + i - 4].id +' </p>'
        listElement.appendChild(liElem);
      }
      currentIndex += length;
      listContainer.appendChild(listElement);

  }
});

slideBtnR.addEventListener('click', () => {
  if (currentIndex < destinations.length && destinations.length > 3) {
    let nextDest = destinations.length - currentIndex;

    let length = nextDest < 4 ? nextDest : 4;

    let listContainer = document.querySelector('.destination-list');
    let destDist = document.querySelector('ul');
    listContainer.removeChild(destDist);

    let listElement = document.createElement('ul');
    for (let i = 0; i < length; i++) {
      let liElem = document.createElement('li');
      liElem.innerHTML = '<p>ID: ' + destinations[i + currentIndex].id +' </p>'
      listElement.appendChild(liElem);
    }
    currentIndex += length;
    listContainer.appendChild(listElement);
  }
});

