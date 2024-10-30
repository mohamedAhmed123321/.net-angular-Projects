// object constractor
// let Calculator=function()
// {
//     this.Firstname="ahmed";
//     this.LastName="mohamed";
//     this.WriteText=function()
//     {
//         console.log("this is the object function");
//     }
// }
//let cal=new Calculator();
//cal.WriteText();
//object litrals
// let Calculatir=
// {
//     firstName:"ahmned",
//     LastName:"Moahmned",
//     age:20,
//     WriteText:function()
//     {
//         console.log("this is the object function");
//     }
// }
// Calculatir.WriteText();

let Calculator = {
  InputText: document.getElementById("txtInput"),
  FirstValue: null,
  Operator: 0,
  NewOperation: true,
  CurrentValues: [],
  WriteText: function (button) {
    if (Calculator.InputText.valu !== "" && this.NewOperation === false) {
      Calculator.InputText.value = button.value;
      NewOperation = true;
      return;
    } else Calculator.InputText.value += button.value;
  },
  OperatorClick: function (CurrentOperator) {
    if (Calculator.InputText.value === "") {
      alert("Please enter first value");
      return;
    }

    this.FirstValue = parseFloat(Calculator.InputText.value);
    Calculator.InputText.value = "";
    this.Operator = CurrentOperator;
  },
  Calculation: function () {
    if (this.FirstValue === null) {
      alert("please enter first value");
      return;
    }

    if (Calculator.InputText.value === "") {
      alert("Please enter second value");
      return;
    }
    let newValue = parseFloat(Calculator.InputText.value);
    let result = 0;
    switch (this.Operator) {
      case "1":
        result = this.FirstValue + newValue;

        break;
      case "2":
        result = this.FirstValue - newValue;
        break;
      case "3":
        result = this.FirstValue * newValue;
        break;
      case "4":
        result = this.FirstValue / newValue;
        break;
    }
    Calculator.InputText.value = result;
    this.CurrentValues.push(result);
    console.log(this.CurrentValues);
    let valuesInScreen = document.querySelector("#DivValues .results");
    valuesInScreen.innerHTML = "";
    // for(let i=0;i<this.CurrentValues.length;i++)
    // {
    //     valuesInScreen.innerHTML+="<li>"+this.CurrentValues[i]+"</li>";
    // }

    this.CurrentValues.forEach(function (arrayValue, i) {
      valuesInScreen.innerHTML += "<li>" + arrayValue + "</li>";
    });

    console.log(this.CurrentValues.length);

    //this.CurrentValues.splice(0,1);
    //this.CurrentValues.splice(2,1,6,7);

    // remove the first item
    //this.CurrentValues.shift();
    // add an item to the first position
    //this.CurrentValues.unshift("ali");
    console.log(this.CurrentValues);
    // join array elements
    //valuesInScreen.innerText=this.CurrentValues.join('\n');
    // remove last item
    //this.CurrentValues.pop();
    //may insert or remove
    // this.CurrentValues.splice(2,1,5,6);
    // this.CurrentValues.splice(0,3);
    this.FirstValue = null;
    this.Operator = 0;
    this.NewOperation = false;
    // this.InputText.value="";
  },
  ClearData: function () {
    this.InputText.value = "";
    this.FirstValue = null;
    this.Operator = 0;
    this.NewOperation = true;
  },
  DoSomething: () => {},
};

// (function HellowApp()
// {
//     console.log("welcome to my function");
// }()

// let app=function HellowApp()
// {
//     console.log("welcome to my function");
// };

// app();

// let app=(firstName,LastName="js")=>
// {
//     console.log("welcome to my function");
//     console.log(LastName);
//     return {
//         firstname:"ali",
//         LastName:"Shahin"
//     }
// }

let newArrray = ["mohamed", "ahmed"]; //
// let functionReturnValue=app("ali");
// console.log(functionReturnValue );

// let app=(...myarray)=>
// {
//     console.log("welcome to my function");
//     console.log(myarray);
//     return {
//         firstname:"ali",
//         LastName:"Shahin"
//     }
// }

//app(newArrray[0],newArrray[1]);

//app(...newArrray);

//app(5,2,7,8,3);

let app = (firstname = "walid", OnSave) => {
  console.log("welcome to my function");
  console.log(firstname);
  OnSave();
  return {
    firstname: "ali",
    LastName: "Shahin",
  };
};

function DataSaveByuser() {
  console.log("i am in anther function");
}

app("walid", DataSaveByuser);
