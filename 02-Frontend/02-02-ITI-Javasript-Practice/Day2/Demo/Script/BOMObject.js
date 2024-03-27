var win;
function openWin(){
    clearInterval(timerID)
   win = open('../HTML/popup.html','','width=150,height=150')
}

function MoveWin(){
    // win.moveTo(150,150)
    win.moveBy(20,20)
    win.focus()//new pop up
    // focus()//main page
}

function startCount(){
    window.setTimeout(function(){
        alert('time out')
    },5000)
    //clearInterval(timerID)
}
var timerID;
function Start2(){
    timerID= setInterval(function(){
        alert('time out')
    },5000)
}

// var timerID = setInterval(function(){
//     console.log('internal fn')
// },5000)

// var myfun = function(){
//  return "fun"   
// }

// console.log(myfun())

//functions
//1)statement function
function fun(a,b){

    return 'test function'
}
//2)assign function to variable
// mynewFun()//error
var mynewFun = function(n,m){
    console.log('msg')
}
//3)anonymus-call back function
// setTimeout(function(){},500)

//4)anonymus
//Immediate invoke function
// IIFE patten
(function(){



    function myfun(){}


    console.log('msg')
}())
