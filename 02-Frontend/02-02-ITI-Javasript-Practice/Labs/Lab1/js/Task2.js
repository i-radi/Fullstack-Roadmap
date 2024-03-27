// Task2
var num=-1,sum=0
while (num != 0) {
    do {
        num = Number(prompt("Enter Number"))
    } while (isNaN(num));
    sum += num
}
document.write(`Sum: ${sum}`)
