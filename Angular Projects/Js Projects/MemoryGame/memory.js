class MemoryGame {
  constructor() {
    this.numberOfUnlock = []; // Save image src here
    this.numberOfBoxs = []; // Save boxes here
    this.boxes = document.querySelectorAll(".box");
    this.orderBoxes = [...Array(this.boxes.length).keys()];
    this.shuffle(this.orderBoxes);
    this.orderBoxs();
    this.addEventListeners();
    this.interval = null;
    this.tries = 0;
    this.getFormStrodge();
  }

  shuffle(array) {
    let current = array.length,
      random,
      temp;
    while (current > 0) {
      random = Math.floor(Math.random() * current);
      current--;
      [array[current], array[random]] = [array[random], array[current]];
    }
    return array;
  }

  orderBoxs() {
    this.boxes.forEach((element, index) => {
      element.style.order = this.orderBoxes[index];
    });
  }

  addEventListeners() {
    this.boxes.forEach((element) => {
      element.addEventListener("click", () => this.handleBoxClick(element));
    });

    document.querySelector(".control span").onclick = () =>
      this.handleControlClick();
  }

  handleBoxClick(element) {
    if (this.numberOfBoxs.length === 2) return;

    element.style.transform = "translateX(0) rotateY(0)";
    this.numberOfUnlock.push(element.querySelector("img").src);
    this.numberOfBoxs.push(element);

    if (this.numberOfBoxs.length === 2) {
      setTimeout(() => this.checkMatch(), 1000);
    }
  }

  checkMatch() {
    if (this.numberOfUnlock[0] === this.numberOfUnlock[1]) {
      this.disableBox(this.numberOfBoxs[0]);
      this.disableBox(this.numberOfBoxs[1]);
      document.querySelector("#success").play();
    } else {
      this.incrementTries();
      this.resetBox(this.numberOfBoxs[0]);
      this.resetBox(this.numberOfBoxs[1]);
      document.querySelector("#fail").play();
    }
    this.numberOfUnlock = [];
    this.numberOfBoxs = [];
    if (this.checkAllBoxesMatched()) {
      clearInterval(this.interval);
      const time = document.getElementById("timer").textContent;
      this.recordResult(time);
      Swal.fire({
        title: "Congratulations!",
        text: "You finished before time was up!",
        icon: "success",
        confirmButtonText: "Play Again",
        cancelButtonText: "exist",
        showCancelButton: true,
        allowOutsideClick: false,
      }).then((result) => {
        if (result.isConfirmed) this.resetGame();
        else window.close();
      });
    }
  }

  disableBox(box) {
    box.style.pointerEvents = "none";
    box.style.transform = "translateX(0) rotateY(0)";
  }

  resetBox(box) {
    box.style.transform = "translateX(-100%) rotateY(-180deg)";
  }

  incrementTries() {
    this.tries++;
    document.querySelector(".head .tries span").innerHTML++;
  }

  handleControlClick() {
    const name = prompt("What is your name") || "Unknown";
    document.querySelector(".head .name span").innerHTML = name;
    document.querySelector(".control").style.display = "none";
    this.startTimer();
    this.resetBoxes();
    setTimeout(() => this.hideBoxes(), 1400);
  }

  resetBoxes() {
    this.boxes.forEach((element) => {
      element.style.transform = "translateX(0) rotateY(0)";
    });
  }

  hideBoxes() {
    this.boxes.forEach((element, index) => {
      element.style.transform = "translateX(-100%) rotateY(-180deg)";
      element.style.order = this.orderBoxes[index];
    });
  }

  startTimer() {
    let duration = 60 * 2; // Duration in seconds (5 minutes)
    let display = document.getElementById("timer");
    let timer = duration,
      minutes,
      seconds;

    this.interval = setInterval(() => {
      minutes = parseInt(timer / 60, 10);
      seconds = parseInt(timer % 60, 10);

      minutes = minutes < 10 ? "0" + minutes : minutes;
      seconds = seconds < 10 ? "0" + seconds : seconds;

      display.textContent = minutes + ":" + seconds;

      if (--timer < 0) {
        clearInterval(this.interval);
        display.textContent = "Game Over";
        Swal.fire({
          title: "Time's up!",
          text: "Do you want to play again?",
          icon: "question",
          showCancelButton: true,
          confirmButtonText: "Yes",
          cancelButtonText: "No",
          allowOutsideClick: false,
        }).then((result) => {
          if (result.isConfirmed) {
            this.resetGame();
          } else {
            display.textContent = "Game Over";
            this.disableAllBoxes();
          }
        });
      }
    }, 1000);
  }

  resetGame() {
    this.resetBoxes();
    setTimeout(() => this.hideBoxes(), 1400);
    this.shuffle(this.orderBoxes);
    this.orderBoxs();
    document.querySelector(".head .tries span").innerHTML = 0;
    this.startTimer();
    this.enableAllBoxes();
  }

  disableAllBoxes() {
    this.boxes.forEach((element) => {
      element.style.pointerEvents = "none";
    });
  }

  checkAllBoxesMatched() {
    return [...this.boxes].every((box) => box.style.pointerEvents === "none");
  }
  enableAllBoxes() {
    this.boxes.forEach((element) => {
      element.style.pointerEvents = "painted";
    });
  }
  timeToSeconds(time) {
    let [minutes, seconds] = time.split(":").map(Number);
    return minutes * 60 + seconds;
  }
  recordResult(time) {
    const name = document.querySelector(".head .name span").innerHTML;
    const tries = this.tries;
    const result = { name, tries, time };

    let results = JSON.parse(localStorage.getItem("memoryGameResults")) || [];
    results.push(result);
    localStorage.setItem("memoryGameResults", JSON.stringify(results));
    this.getFormStrodge();
  }
  getFormStrodge() {
    let results = JSON.parse(localStorage.getItem("memoryGameResults")) || [];
    results.sort((a, b) => {
      if (a.tries === b.tries) {
        return this.timeToSeconds(a.time) - this.timeToSeconds(b.time);
      }
      return a.tries - b.tries;
    });

    let infos = "";
    if (results.length > 10) results.length = 10;
    if (results.length > 1) {
      results.forEach((element) => {
        infos += `   <div class="info">
                        <span class="name">
                            ${element.name}
                        </span>
                 <span class="tries">
                                 ${element.tries}
                   </span>
                    </div>
                    `;
      });
      // console.log(infos)
      document.querySelector(".winners .holder").innerHTML = infos;
    } else {
      document.querySelector(".winners").display = "none";
    }
  }
}

// Initialize the game
document.addEventListener("DOMContentLoaded", () => {
  new MemoryGame();
});
