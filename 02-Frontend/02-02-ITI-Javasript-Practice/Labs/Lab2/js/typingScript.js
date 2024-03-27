var msg = 'Welcome in ITI'.split('')
        current = 0,
        setInterval(function() {
            if(current < msg.length) {
                document.querySelector('#typing').innerHTML += msg[current++]
            }
        }, 300)

setTimeout(function() {
  window.close()
}, 6000)









