// var data = location.search.substring(1,location.search.length)
// var info = data.split('&')
// var assoArray =[]
// for(var i=0 ; i<info.length; i++){
//     assoArray[info[i].split('=')[0]] = info[i].split('=')[1]
// }

// document.querySelector("#usrName").innerHTML += assoArray['usrName']
// document.querySelector("#usrAdd").innerHTML += assoArray['usrAdd']
// document.querySelector("#usrGender").innerHTML += assoArray['usrGender']
// document.querySelector("#usrMail").innerHTML += assoArray['usrMail']
// document.querySelector("#usrPhone").innerHTML += assoArray['usrPhone']

const params = new Proxy(new URLSearchParams(window.location.search), {
  get: (searchParams, prop) => searchParams.get(prop),
});

document.querySelector("#usrName").innerHTML += params.usrName
document.querySelector("#usrAdd").innerHTML += params.usrAdd
document.querySelector("#usrGender").innerHTML += params.usrGender
document.querySelector("#usrMail").innerHTML += params.usrMail
document.querySelector("#usrPhone").innerHTML += params.usrPhone









