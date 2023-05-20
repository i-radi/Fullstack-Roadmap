//
document.querySelectorAll('[type="button"]')[0].onclick=function(){
    // document.body.firstElementChild.classList.toggle('c1')
    var left =parseInt( getComputedStyle(document.getElementsByTagName('img')[0]).left)
   
    var timer= setInterval(function(){
    
    // left = parseInt(left)
        left -=20
        document.images[0].style.left =left+"px"
        console.log(left)
        if(left<=-60){
            document.images[0].style.left ="1000px"
            clearInterval(timer)
        }
    },500)
    // console.log(getComputedStyle(document.getElementsByTagName('img')[0]).left)
    // var left = getComputedStyle(document.getElementsByTagName('img')[0]).left
    // left = parseInt(left)
    // left -=20
    // document.images[0].style.left =left+"px"
}

//access first elemnt child
document.body.firstElementChild
//add attribute
document.body.firstElementChild.setAttribute('id','h1id')
//adding class
// document.body.firstElementChild.classList.add('c1')
// document.body.firstElementChild.classList.remove('c1')



//stylesheets
// document.styleSheets[0].cssRules


document.querySelector('#btn').onclick=function(){
    //create element
    var elem = document.createElement('p')
    elem.innerText="abc"
    //create text or content
    var txt = document.createTextNode("Simple Text Node")
    //added text inside p tag
    elem.append(txt)
    //add p tag inside body
    document.body.appendChild(elem)
    //insertBefore--------------->try in lab
}















