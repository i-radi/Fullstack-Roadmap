//Location Object
//search-->Querystring

var data = location.search.substring(1,location.search.length)
var info = data.split('&')
var assoArray =[]
for(var i=0 ; i<info.length; i++){
    // var arr = info[i].split('=')
    // var key = arr[0]
    // var value = arr[1]
    assoArray[info[i].split('=')[0]] = info[i].split('=')[1]
}

document.write("Welcome : "+assoArray['usrnm'])

//Location methods
//replace
//assign

function moveNext(){
    // location.assign('http://www.google.com')
    location.replace('http://www.google.com')
    // location.reload()
}


//History Object related tab
//Functions
//history.forward()///move next
//history.back()
// history.go(0)//index
////Index: 0----refresh current page
////Index: 1---move next
////Index: -1----back







