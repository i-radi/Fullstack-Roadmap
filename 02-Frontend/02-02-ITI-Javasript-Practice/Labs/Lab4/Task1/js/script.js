function getData(){
    var url = 'https://jsonplaceholder.typicode.com/users/'
    var page = Number(document.getElementById('txt').value)
    url = page > 0 && page < 11 ? url +=page : url 
    
    var xhr = new XMLHttpRequest();
    xhr.open('GET', url)
    xhr.send('')
    xhr.onreadystatechange = function() {
        document.getElementById("setData").innerHTML = ''
        if (this.readyState == 4 && this.status >= 200 && this.status < 300) {
            var data = JSON.parse(this.responseText)
            if (page > 0 && page < 11){
                document.getElementById("setData").innerHTML += data.name+'<br/>' 
            }
            else{
                for (var i = 0; i < data.length; i++) {
                    document.getElementById("setData").innerHTML += data[i].name+'<br/>' 
                    }
            }
            }
        else{
            console.log(this.readyState)
        }
    }
}