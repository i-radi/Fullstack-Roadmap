// onload = function(){

    function next(){
        var src = Number(document.querySelector('#img1').src.slice(-5,-4)) + 1
        if (src > 0 && src < 6) {
            document.querySelector('#img1').src = `../img/${src}.jpg`
        }
    }
    var timerID
    function auto(){
        var src = Number(document.querySelector('#img1').src.slice(-5,-4))
        timerID = setInterval(function(){
            if (src > 5) src = 1
            document.querySelector('#img1').src = `../img/${src++}.jpg` 
        },1000)
    }
    function stop(){
        clearInterval(timerID)
    }
    function previous(){
        var src = Number(document.querySelector('#img1').src.slice(-5,-4)) - 1
        if (src > 0 && src < 6) {
            document.querySelector('#img1').src = `../img/${src}.jpg`
        }
    }
/////////////////////////////////////////////////////////////////////////////////////
   onload=()=>{ var count = 2
    timerId = setInterval(function(){
        if (count > 6) {
            count = 2
            document.querySelector(`#img6`).src = `../img/yellow.png` 

        }
        document.querySelector(`#img${count++}`).src = `../img/orange.png` 
        if (count>3) {
            document.querySelector(`#img${count-2}`).src = `../img/yellow.png` 
        }
        },1000)
    }
    function reset(){
        for (let i = 2; i < 7; i++) {
            document.querySelector(`#img${i}`).src = `../img/yellow.png` 
        }
    }
    function hover(elem){
        clearInterval(timerId)
        reset()
        elem.src = `../img/orange.png` 
    }
    function unhover(elem){
        elem.src = `../img/yellow.png` 
        window.onload()
    }
/////////////////////////////////////////////////////////////////////////////////////
    function submit(){
        var name = document.querySelector('input[name="name"]').value
        var age = document.querySelector('input[name="age"]').value
        var gender
        if (document.querySelector('input[id="male"]').checked) {
            gender = 'male'  
        }
        else{
            gender = 'female' 
        }
        var colorIndex = document.querySelector('select[id="colors"]').selectedIndex
        var color = document.querySelector('select[id="colors"]').options[colorIndex].value
        createCookie('name',name) 
        createCookie('age',age) 
        createCookie('gender',gender) 
        createCookie('color',color) 
        createCookie('count',1) 
        location.assign('../html/welcome.html')
    }
        // }