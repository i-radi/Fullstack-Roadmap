document.getElementById('btn1').onclick=function(){
    var n=123.45
    console.log(n.toFixed(120))
}

document.querySelectorAll('#btn2')[1].addEventListener('click',function(){
    console.log('syntax error')
})

document.getElementsByTagName('input')[2].onclick = function(){
    console.log(x)
}

document.getElementById('btn4').onclick = function(){
    console.logg('type error')
}