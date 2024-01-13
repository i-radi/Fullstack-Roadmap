

//Built-in Objects
//1)Number Object
//2)String Object
//3)Math Object--static
//4)Array Object
//a)Literal way
var arr = []
arr[0]=1
arr[1]="abc"
arr[2]=true
arr[5]=function(){
    return "new fun"
}

var arr2 =[1,2,,,,,6]

// console.log(arr)
// console.log(arr2)
//b)Constructor way
var myArr= new Array(5)
myArr[10]=123

var newArray = new Array("red","green","blue")

//printing array
for(var i=0; i<newArray.length;i++){
    console.log(newArray[i])
}


//push and pop function act as stack
var testArray = [1,2,3]//last in first out
testArray.push(5)//last index in array
testArray.push(9)
var x = testArray.pop()
testArray.push(100)

//shift and unshift--first index in array
testArray.unshift(7)
var y = testArray.shift()

//Array reverse
testArray.reverse()
// //join
// console.log(testArray.join())
// console.log(testArray.join('*'))
// console.log(testArray.join('--'))

// console.log(testArray.toString())

// var copyArray = testArray//refernce
// testArray[0]=50//will effect both arrays

var copyArray =[]
for(var j=0;j<testArray.length;j++){
    copyArray[j] = testArray[j]
}
// testArray[0]=50

testArray.sort()//search parameter for sort function


//Associative Array
var assocArray =[]
assocArray["1"]=123//XXXXXXXXXXXXXXX index
assocArray["xyz"]=true
assocArray["xyz2"]=function(){}
//fon..in
assocArray[0]=5555

for(key in assocArray){//elem ---key of array
    console.log(key+":::"+assocArray[key])
}

console.log(assocArray)
