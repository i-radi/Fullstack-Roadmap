//Task3
while (true) {
    var str = prompt("Enter Message to check is a Palindrome or Not")
    str = confirm("Check Case Sensitive?") ? str : str.toLowerCase()
    var len = str.length
    for (let i = 0; i < len / 2; i++) {  
        if (str[i] !== str[len - 1 - i]) {  
            alert( 'It is not a palindrome');  
        }  
    }  
    alert( 'It is a palindrome'); 
}