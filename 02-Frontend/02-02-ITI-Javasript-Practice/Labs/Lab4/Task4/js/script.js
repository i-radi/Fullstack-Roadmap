var img1 =parseInt( getComputedStyle(document.getElementsByTagName('img')[0]).left)
var img2 =parseInt( getComputedStyle(document.getElementsByTagName('img')[1]).left)
var img3 =parseInt( getComputedStyle(document.getElementsByTagName('img')[2]).top)
var timer
var flag = false
function start(){
    if (!flag){
    flag = true
    document.getElementsByTagName('input')[0].value = 'Stop'
    timer= setInterval(function(){
    img1 +=10
    img2 -=10
    img3 -=10

    document.images[0].style.left =img1+"px"
    document.images[1].style.left =img2+"px"
    document.images[2].style.top =img3+"px"

    if(img1>=460)img1 =0
    if(img2<=20)img2 =470
    if(img3<=20)img3 =480
    },100)
    }
    else{
    flag = false
    document.getElementsByTagName('input')[0].value = 'Start'
    clearInterval(timer)
    }
}

function reset(){
    document.images[0].style.left ="20px"
    document.images[1].style.left ="470px"
    document.images[2].style.top ="480px"
    img1 = 20 
    img2 = 470
    img3 = 480
}