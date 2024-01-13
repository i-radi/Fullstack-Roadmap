document.body.onclick = () =>{
const node = document.getElementsByTagName("img")[0];
const clone = node.cloneNode(true);
document.getElementsByTagName("div")[3].appendChild(clone);
document.getElementsByTagName("div")[0].classList.remove('center')
document.getElementsByTagName("div")[0].classList.add('right')
}

