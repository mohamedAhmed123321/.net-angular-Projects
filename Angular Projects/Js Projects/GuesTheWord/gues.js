gues={
    words:[
        "Admire",
        "Advent",
        "Beacon",
        "Belief",
        "Breeze",
        "Bright",
        "Castle",
        "Chance",
        "Cherry",
        "Choice",
        "Circle",
        "Clever",
        "Column",
        "Corner",
        "Create",
        "Custom",
        "Detail",
        "Device",
        "Divide",
        "Driven",
        "Embark",
        "Engage",
        "Enjoys",
        "Exceed",
        "Expand",
        "Fabric",
        "Future",
        "Glance",
        "Graced",
        "Growth",
        "Honest",
        "Impact",
        "Kindly",
        "Laughs",
        "Lesson",
        "Manage",
        "Motive",
        "Kindly",
        "Lights",
        "Wounds",
        "Boldly",
        "Facing",
        "Always",
        "Future",
        "Memory",
        "Friend",
        "Shares",
        "Lively",
        "Varied",
        "Season"
    ],
    guesWord:"",
    createDivs:function(num,hints){
    document.querySelector("h1").innerHTML="Gues The Word";
    document.querySelector("footer").innerHTML="Gues The Word Game created by mohamed ahmed";
    
    hint=  document.querySelector(".hint");
    hintSpan= document.querySelector("span");
    hintSpan.innerHTML=hints;

        gues.guesWord=gues.words[Math.floor(Math.random()*gues.words.length)]
        console.log(gues.guesWord)
        for(i=1;i<=num;i++){
            div=document.createElement("div");
            div.classList.add(`try-${i}`);
            if(i!==1)   div.classList.add(`disabled`);
            span=document.createElement("span");
            span.innerHTML=`try ${i}`;
            div.appendChild(span)
            for(j=1;j<=num;j++){
                input=document.createElement("input");
                if(div.classList.contains("disabled")){
                    input.disabled = true;
                }
                input.classList.add(`try-${i}-input-${j}`);
                input.type = "text";
                input.maxLength = 1;
                input.addEventListener('input', function(event) {
                    event.target.value = event.target.value.toUpperCase();
                    nextElemment=this.nextElementSibling;
                    if(nextElemment && event.target.value !=="")nextElemment.focus()
                });

                input.addEventListener('keydown', function(event) {
                    if (event.key === 'ArrowRight') 
                        {
                            nextElemment=this.nextElementSibling;
                            if(nextElemment )nextElemment.focus()
                        }
                    else if(event.key === 'ArrowLeft'){
                        previousElemment=this.previousElementSibling;
                        if(previousElemment)previousElemment.focus()
                    }
                    else if(event.key === 'Backspace'){
                        previousElemment=this.previousElementSibling;
                        if(previousElemment){
                            this.value="";
                            previousElemment.focus()
                            previousElemment.value=""
                        }
                    }
                });

                div.appendChild(input)
            }
            // console.log(div)
            inputsHolder= document.querySelector(".game-holder .inputs");
            inputsHolder.appendChild(div)

        }
    },
    checkWord:function(){

       isCorrect=true;
       inputs=document.querySelectorAll(".inputs > div:not(.disabled) > input")
       for(i=0;i<inputs.length;i++){
        if(inputs[i].value.toLowerCase()===gues.guesWord[i].toLowerCase())
            inputs[i].classList.add("in-place")
        else if(gues.guesWord.toLowerCase().includes(inputs[i].value.toLowerCase()) && inputs[i].value!=="")
        {  
               inputs[i].classList.add("not-in-place")
               isCorrect=false;
        }
        else
          {  
            inputs[i].classList.add("wrong")
            isCorrect=false;
          }
       }
       if(isCorrect===false){
        currentDiv=document.querySelector(".inputs > div:not(.disabled)");
        currentDiv.classList.add("disabled");
        nextElemment=currentDiv.nextElementSibling;
        if(nextElemment===null)
            {
                msg=document.querySelector(".game-holder .msg");
                span=  msg.querySelector("span");
                
                msgText=document.createTextNode("you lose the word is");
                spanTex=document.createTextNode(gues.guesWord);

                msg.appendChild(msgText)      
                span.appendChild(spanTex)
                msg.appendChild(span)
                document.querySelector(".check").disabled=true;
                document.querySelector(".hint").disabled=true;
                return;
            }
        nextElemment.classList.remove("disabled")
       _inputs= nextElemment.children;
        for(i=1;i<_inputs.length;i++){
            _inputs[i].disabled=false;
            if(i===1)
                _inputs[1].focus();
        }

       }
       else{
        msg=document.querySelector(".game-holder .msg");
        span=  msg.querySelector("span");
        
        msgText=document.createTextNode("congratulation the word is");
        spanTex=document.createTextNode(gues.guesWord);

        msg.appendChild(msgText)      
        span.appendChild(spanTex)
        msg.appendChild(span);
        inputs.forEach(element => {
            element.disabled=true;
        });
          document.querySelector(".check").disabled=true;
          document.querySelector(".hint").disabled=true;
        return;
       }
    },
    hint:function(){
        span=  document.querySelector(".hint > span");
        // console.log(span)
        if(parseInt(span.innerHTML)!==0){

            inputs=document.querySelectorAll(".inputs > div:not(.disabled) > input");

            specialInputs=  document.querySelectorAll(".in-place");
            inPlaceWord="";

          if(specialInputs.length>0){
            specialInputs.forEach((el)=>{
                inPlaceWord+= el.value.toLowerCase();
              })
          }

            randomNum=Math.floor(Math.random()* inputs.length);
            ranfomChar=  gues.guesWord[randomNum].toLowerCase();

            if(inPlaceWord.includes(ranfomChar)){
               Array.from(gues.guesWord).forEach(function(el){
                if(!inPlaceWord.includes(el)){
                   ranfomChar=el
                }
                else
                 ranfomChar="";
               });
            }
            if(ranfomChar!==""){
            input=inputs[gues.guesWord.toLowerCase().indexOf(ranfomChar.toLowerCase())];

            noInputFound=false;
            
            if(input.value!==""){
                let noInputFound = false;
                    noInputFound = Array.from(inputs).some((el) => el.value === "");

                if(!noInputFound)
                    return

                Array.from(inputs).some((el, index) => {
                    if (el.value === "") {
                        alert(el.value); // Alert the empty value
                        el.value = gues.guesWord[index].toUpperCase(); // Update the input value
                        span.innerHTML--; // Decrement the span value
                        return true; // Return true to stop the iteration
                    }
                    return false; // Continue the iteration
                });
             
             
                return;
            }

            input.value=ranfomChar.toUpperCase();
            span.innerHTML--;
            }
            
        }
    }
}
document.onload=gues.createDivs(6,2);
check=  document.querySelector(".check");
check.onclick=()=>{
  gues.checkWord();
};
hint=  document.querySelector(".hint");
hint.onclick=()=>{
  gues.hint();
};