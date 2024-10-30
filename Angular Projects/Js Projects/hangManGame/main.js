class HangmanGame {
  constructor() {
    this.letters = "abcdefghijklmnopqrstuvwxyz";
    this.lettersArray = Array.from(this.letters);
    this.lettersContainer = document.querySelector(".letters");
    this.words = {
      programming: [
        "php",
        "javascript",
        "go",
        "scala",
        "fortran",
        "r",
        "mysql",
        "python",
      ],
      movies: [
        "Prestige",
        "Inception",
        "Parasite",
        "Interstellar",
        "Whiplash",
        "Memento",
        "Coco",
        "Up",
      ],
      people: [
        "Albert Einstein",
        "Hitchcock",
        "Alexander",
        "Cleopatra",
        "Mahatma Ghandi",
      ],
      countries: ["Syria", "Palestine", "Yemen", "Egypt", "Bahrain", "Qatar"],
    };
    this.wrongAttempts = 0;
    this.theDraw = document.querySelector(".hangman-draw");
    this.init();
  }

  init() {
    this.generateLetters();
    this.selectRandomWord();
    this.setCategoryInfo();
    this.createGuessSpans();
    document.addEventListener("click", this.handleLetterClick.bind(this));
  }

  generateLetters() {
    this.lettersArray.forEach((letter) => {
      let span = document.createElement("span");
      span.className = "letter-box";
      span.textContent = letter;
      this.lettersContainer.appendChild(span);
    });
  }

  selectRandomWord() {
    let allKeys = Object.keys(this.words);
    let randomPropNumber = Math.floor(Math.random() * allKeys.length);
    this.randomPropName = allKeys[randomPropNumber];
    this.randomPropValue = this.words[this.randomPropName];
    let randomValueNumber = Math.floor(
      Math.random() * this.randomPropValue.length
    );
    this.randomValueValue = this.randomPropValue[randomValueNumber];
  }

  setCategoryInfo() {
    document.querySelector(".game-info .category span").textContent =
      this.randomPropName;
  }

  createGuessSpans() {
    let lettersGuessContainer = document.querySelector(".letters-guess");
    let lettersAndSpace = Array.from(this.randomValueValue);
    lettersAndSpace.forEach((letter) => {
      let emptySpan = document.createElement("span");
      if (letter === " ") {
        emptySpan.className = "with-space";
      }
      lettersGuessContainer.appendChild(emptySpan);
    });
    this.guessSpans = document.querySelectorAll(".letters-guess span");
  }

  handleLetterClick(e) {
    if (e.target.className === "letter-box") {
      e.target.classList.add("clicked");
      let theClickedLetter = e.target.textContent.toLowerCase();
      let theChosenWord = Array.from(this.randomValueValue.toLowerCase());
      let theStatus = false;

      theChosenWord.forEach((wordLetter, wordIndex) => {
        if (theClickedLetter === wordLetter) {
          theStatus = true;
          this.guessSpans.forEach((span, spanIndex) => {
            if (wordIndex === spanIndex) {
              span.textContent = theClickedLetter;
            }
          });
        }
      });

      if (!theStatus) {
        this.wrongAttempts++;
        this.theDraw.classList.add(`wrong-${this.wrongAttempts}`);
        document.getElementById("fail").play();
        if (this.wrongAttempts === 8) {
          this.endGame(false);
          this.lettersContainer.classList.add("finished");
        }
      } else {
        document.getElementById("success").play();
        if (this.checkWin()) {
          this.endGame(true);
          this.lettersContainer.classList.add("finished");
        }
      }
    }
  }

  checkWin() {
    let allCorrect = true;
    this.guessSpans.forEach((span) => {
      if (span.textContent === "" && !span.classList.contains("with-space")) {
        allCorrect = false;
      }
    });
    return allCorrect;
  }

  endGame(won) {
    let div = document.createElement("div");
    div.className = "popup";
    if (won) {
      div.innerHTML = `You win! The word is <span>${this.randomValueValue}</span>`;
    } else {
      div.innerHTML = `Game Over, The Word Is <span>${this.randomValueValue}</span>`;
    }
    document.body.appendChild(div);
  }
}

document.addEventListener("DOMContentLoaded", () => {
  new HangmanGame();
});
