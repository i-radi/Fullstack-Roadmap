//Ajax
//1)create xhr Object
var xhr = new XMLHttpRequest()
//2)open request
xhr.open('GET','https://jsonplaceholder.typicode.com/users')
// xhr.open('GET','../std.json')

// xhr.open('GET','../textfile.txt')
//3)Handle event onreadystatechange
xhr.onreadystatechange =function(){
    // console.log(xhr.readyState)
    if(xhr.readyState == 4){
        if(xhr.status >=200 && xhr.status <300){
            // console.log('success')
            document.getElementsByTagName('h1')[0].innerHTML = ""
            console.log( xhr.responseText)
            var data = JSON.parse(xhr.responseText)
            console.log(data)
            for(var i=0;i<data.length;i++){
                document.getElementsByTagName('h1')[0].innerHTML+=data[i].name+":::"+data[i].address.geo.lat+"<br>"
            }
            // JSON.stringify()
        }
        else{

        }
    }
}
//4)sending request
xhr.send('')