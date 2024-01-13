
// onload = (function() {
function one() {
 document.getElementById("textbox").value += '1';
}
  
function two() {
 document.getElementById("textbox").value += '2';
}
  
function three() {
 document.getElementById("textbox").value += '3';
}
  
function four() {
 document.getElementById("textbox").value += '4';
} 

function five() {
 document.getElementById("textbox").value += '5';
}
  
function six() {
 document.getElementById("textbox").value += '6';
}
  
function seven() {
 document.getElementById("textbox").value += '7';
} 
  
function eight() {
 document.getElementById("textbox").value += '8';
}
  
function nine() {
 document.getElementById("textbox").value += '9';
} 

function zero() {
      document.getElementById("textbox").value += '0';
} 
  
    function dot() {
      document.getElementById("textbox").value += '.';
}
  
  
    function plus() {
 document.getElementById("textbox").value += ' + ';
}
  
    function minus() {
 document.getElementById("textbox").value += ' - ';
}
  
    function multiply() {
 document.getElementById("textbox").value += ' * ';
}
  
    function divide() {
 document.getElementById("textbox").value += ' / ';
}
  
    function modulus() {
 document.getElementById("textbox").value += ' % ';
}
  
  
    function equals() {
 document.getElementById("textbox").value =  eval(document.getElementById("textbox").value);
}  
  
    function clearAll() {
 document.getElementById("textbox").value =  '';
}  

    function CE() {
 document.getElementById("textbox").value =  document.getElementById("textbox").value.slice(0,-1);
}  
  
  
  
// })