function changeSource(elem,imagename){
    console.log(this)//default binding
    console.log(elem)
    // document.images[index].src = "../Images/marshall_c.jpg" 
    elem.src= imagename
}

// function returnSource(elem,imagename){
//     //document.images[index].src = "../Images/marshall_bw.jpg" 
//     elem.src= imagename

// }
var flag=true//text
function fun(){
    if(flag){
        document.querySelector('input[type="text"]').type = "password"; 
        flag = false
    }
    else{
        document.querySelector('input[type="password"]').type = "text";
        flag=true
    }

}

function displayContent(txt){
    document.getElementById('dv1').innerHTML =txt.value
}

//onchange
//onfocus
//onblur


function displayOption(){
    var menu = document.getElementById('menu')
   // console.log(menu.options)
    //get selected index
    // var index = menu.selectedIndex;
    // var value = menu.options[index].value
    
    // document.getElementById('div2').innerHTML = value


    //var counter=0
    //var indexArr=[]
    document.getElementById('div2').innerHTML=""
    for(var i=0;i<menu.options.length;i++){
        if(menu.options[i].selected){
            //indexArr[counter]=menu.options[i]
            //counter++
            document.getElementById('div2').innerHTML+= menu.options[i].value
        }

    }
   // console.log(indexArr)
}






