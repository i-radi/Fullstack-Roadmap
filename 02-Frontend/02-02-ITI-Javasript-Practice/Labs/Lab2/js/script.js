// onload = function(){

    
    function aggResult (){
        var number = new Array()
        var sum = 0, mul = 1, div=0 ,num
        for (var i = 0; i < 3; i++) {
            num =prompt("Enter Number")
            if (num != 0 && isFinite(num)){
                number[i]=(Number(num))
                sum +=number[i]
                mul *=number[i]
                div = (div == 0) ? number[i] :div /=number[i] ;
            }
        }
        document.querySelector('#sum').innerHTML = `Sum of the 3 values ${number[0]} + ${number[1]} + ${number[2]} = ${sum}`
        document.querySelector('#mul').innerHTML = `Multiplication of the 3 values ${number[0]} * ${number[1]} * ${number[2]} = ${mul}`
        document.querySelector('#div').innerHTML = `Division of the 3 values ${number[0]} / ${number[1]} / ${number[2]} = ${div}`
    }

    function clrContent (){
        document.querySelector('#sum').innerHTML = ''
        document.querySelector('#mul').innerHTML = ''
        document.querySelector('#div').innerHTML = ''
    }

    function sortNumbers (){
        var numArray = new Array()
        for (var i = 0; i < 5; i++) {
            numArray.push(Number(prompt("Enter Number")))
        }
        document.querySelector('#sort').innerHTML = `you've entered the values of ${numArray} `
        document.querySelector('#sortAsc').innerHTML = `your values after being sorted ascending ${numArray.sort( (a, b) => a - b)}`
        document.querySelector('#sortDesc').innerHTML = `your values after being sorted descending ${numArray.sort( (a, b) => b - a)}`
    }
    function clrContent2 (){
        document.querySelector('#sort').innerHTML = ''
        document.querySelector('#sortAsc').innerHTML = ''
        document.querySelector('#sortDesc').innerHTML = ''
    }

    function calcArea (){
        var num = Number(prompt("Enter Number"))
        alert(`Total Area : ${Math.round(Math.PI*(num*num))}`)
        }
 
    function calcSqrt (){
        var num = Number(prompt("Enter Number"))
        alert(`Total Square Root : ${Math.sqrt(num).toFixed(2)}`)
    }
    function calcCos (){
        var num = Number(prompt("Enter Number"))
        document.querySelector('#cos').innerHTML = `cos ${num}&deg; is ${Math.cos(num*Math.PI/180).toFixed(4)}`
     }
    function clrContent3 (){
        document.querySelector('#cos').innerHTML = ''
    }

    var win;
    var timerID;
    function createWindow (){
        win = open('../html/welcome.html','','width=250,height=150')
        timerID = setInterval(function(){win.moveBy(20,20)},300)
        
    }
    function stopMovement (){
        clearInterval(timerID)
        win.focus()
     }

     function openTypingPage (){
        open('../html/typingMsg.html','','width=450,height=250')
     }

     function openScrollingPage (){
        open('../html/scrolling.html','','width=450,height=250')
     }


// }