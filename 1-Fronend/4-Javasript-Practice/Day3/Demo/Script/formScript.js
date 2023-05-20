document.forms[0].onsubmit = function(){
    if(!confirm('Do you want to submit')){
        return false//stop submittion process
    }
}

function save(){
    var value = document.querySelector('#txt1').value
    var today = new Date()
    today.setMonth(today.getMonth()+1)
    console.log(today.toUTCString())
    document.cookie="usrname="+value+";expires="+today.toUTCString()
}

function deleteCookie(cookieName){
    var today = new Date()
    today.setMonth(today.getMonth()-1)
    document.cookie="usrname=;expires="+today.toUTCString()
}

function createCookie(nameCookie,Value,expiryDate){
    if(expiryDate!=undefined){}
}

//create Cookie
//delete cookie
//get cookie
//getAllcookie
//hasCookie


function getAllcookie(){
    var data = document.cookie.split('; ')
    var userData=[]
    for(var i=0;i<data.length;i++){
        var info = data[i].split('=')
        var key=info[0]
        var value=info[1]
        userData[key]=value
    }
    return userData
}












