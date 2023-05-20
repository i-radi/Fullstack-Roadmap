var x =10
var y ="abc"

var obj ={
    objName:"OBJ",
    addr:"abcs",
    display:function(){
        return this.objName+this.addr
    }
}

console.log(obj.test)
obj.test="abc"

console.log(Object.keys(obj))
console.log()
obj.hasOwnProperty("addr")//true