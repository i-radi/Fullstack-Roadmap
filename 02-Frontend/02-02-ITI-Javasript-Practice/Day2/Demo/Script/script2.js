//Arguments

function add(){
    console.log(arguments)
    var sum=0
    for(var i=0;i<arguments.length;i++){
        sum+=arguments[i]
    }
    return sum
}

console.log(add(1,2,3,4,5))


//5)Date Object
//Constructor way only
var date = new Date()
