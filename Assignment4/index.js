const images = ['./assets/image1.png', './assets/image2.png', './assets/image3.png',
                './assets/image4.png', './assets/image5.png', './assets/image6.png',
                './assets/image7.png', './assets/image8.png', './assets/image9.png',]
const freePositions = [0, 0, 0, 0, 0, 0, 0, 0, 0];

function sleep(ms) {
  return new Promise(resolve => setTimeout(resolve, ms));
}

class Puzzle {
  constructor() {
    this.pieces = document.querySelectorAll(".row .columns");
    this.initializePuzzle();
  }

  /* Method to initialize the puzzle.
  *
  */
  initializePuzzle() {

    // add random images to the 9 cells of the puzzle
    for (let piece of this.pieces) {
      let index = Math.floor(Math.random() * 9)

      // ALLOW CELLS TO HAVE IMAGES DROPPED ON THEM
      piece.setAttribute('ondragover', allowDrop);
      piece.setAttribute('ondrop', onDrop);

      // ADD IMAGES TO CELLS
      while (freePositions[index] === 1) {
        index = Math.floor(Math.random() * 9)
      }
      freePositions[index] = 1;
      // creating the img node that will display the desired piece.
      const imgNode = document.createElement('img');
      imgNode.src = images[index];
      imgNode.setAttribute('id', `img${index}`);
      imgNode.setAttribute('ondragstart', onDrag);

      // append the piece to the puzzle
      piece.appendChild(imgNode);
    }

    document.addEventListener('dragstart', onDrag);
    document.addEventListener('dragover', allowDrop);
    document.addEventListener('drop', onDrop);
  }

  get puzzlePieces() {
    return this.pieces;
  }

  isPuzzleFinished() {
    const imgs = document.querySelectorAll("img");

    let counter = 0;
    for (let img of imgs) {
      if (img.id !== `img${counter}`) {
        return;
      }
      counter ++;
    }
    alert('You won!');
  }
}

const puzzle = new Puzzle();

// ACTUAL METHOD FOR DRAG AND DROP
function onDrag(e) {
  e.dataTransfer.setData('text', e.target.id);
}

function allowDrop(e) {
  e.preventDefault();
}

function onDrop(e) {
  e.preventDefault();
  const draggedImageId = e.dataTransfer.getData('text');

  const draggedImageElement = document.getElementById(draggedImageId);
  const droppedImageElement = e.target;
  const draggedImageParent = draggedImageElement.parentElement;
  const droppedImageParent = droppedImageElement.parentElement;

  draggedImageParent.removeChild(draggedImageElement);
  droppedImageParent.removeChild(droppedImageElement);

  draggedImageParent.appendChild(droppedImageElement);
  droppedImageParent.appendChild(draggedImageElement);

  sleep(1000);
  puzzle.isPuzzleFinished()
}

