

onload = ()=>{
var userName = getCookie('name')
var gender = getCookie('gender')
var color = getCookie('color')
var count = getCookie('count')

document.querySelector('img').src = `../img/${gender}.png`
document.querySelector('#name').innerHTML = userName
document.querySelector('#name').style.color = color
document.querySelector('#count').innerHTML = count
document.querySelector('#count').style.color = color
createCookie('count',++count) 

}