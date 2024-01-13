onload=function(){
    document.getElementById('h1id')//return one element
//update h1 content
document.getElementById('h1id').innerHTML = "<p>lorem</p>"//apply html tag
// document.getElementById('h1id').innerText = "<p>lorem</p>"

console.log( document.getElementsByTagName('p'))

// document.body.innerHTML=""

console.log( document.querySelector('#h1id'))
console.log( document.querySelectorAll('p'))
// document.querySelector('.c')
}

