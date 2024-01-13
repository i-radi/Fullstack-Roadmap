function addText(elem){
    // var value = elem.value
    document.getElementById('txt1').value += elem.value
}

function removeLast(){
    var value = document.getElementById('txt1').value
    document.getElementById('txt1').value = value.substring(0,value.length-1)
}


function clearValue(){
    document.getElementById('txt1').value = ""
}