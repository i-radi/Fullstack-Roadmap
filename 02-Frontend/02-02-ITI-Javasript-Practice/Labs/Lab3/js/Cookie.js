//create Cookie
function createCookie(nameCookie,Value,expiryDate){
    if(expiryDate!=undefined){
        document.cookie=`${nameCookie}=${Value}; expires=${expiryDate.toUTCString()}`
    }
    else{
        document.cookie=`${nameCookie}=${Value}`
    }
}
//delete cookie
function deleteCookie(cookieName){
    var today = new Date()
    today.setMonth(today.getMonth()-1)
    document.cookie= cookieName+"=;expires="+today.toUTCString()
}
//get cookie
function getCookie(cookieName){
    return getAllCookie()[cookieName]
}
//getAllcookie
function getAllCookie(){
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
//hasCookie
function hasCookie(cookieName){
    return Boolean(getAllCookie()[cookieName])
}