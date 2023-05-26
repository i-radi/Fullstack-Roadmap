//bubbling mode
// document.getElementById('parent').onclick=function(event){
//     console.log('parent')
// }
// document.getElementById('child').onclick=function(event){
//     console.log('child')
//      event.stopPropagation()
// }
// document.getElementById('lastchid').onclick=function(event){
//     console.log('lastchid')
//     event.stopPropagation()
// }

// capturing mode
document.getElementById('child').addEventListener('click',function(event){
    console.log('child')
    // event.stopPropagation()
},true)

document.getElementById('parent')
.addEventListener('click',function(event){
    console.log('parent')
    // event.stopPropagation()
},true)//true--->capturing mode
//default value fot third paremter is false---->Bubbling mode

document.getElementById('lastchid').addEventListener('click',function(event){
    console.log('lastchid')
    //  event.stopPropagation()
},true)


//Two modes
//1)Default mode Bubbling mode
//child handle event then parent
//2)Capturing mode
//parent handle evet then child



// document.getElementById('parent').onclick=function(){
//     console.log('parent')
// }


// document.getElementById('parent').onclick=function(){
//     console.log('hello')
// }

// var x =10


// x = 50

// document.getElementById('parent').addEventListener('click',function(){
//     console.log('parent')
// })
// document.getElementById('parent').addEventListener('click',function(){
//     console.log('hello')
// })














