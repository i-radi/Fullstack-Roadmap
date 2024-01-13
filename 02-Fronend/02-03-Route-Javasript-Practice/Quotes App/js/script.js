let quotes = [
    {
        quote:'“Be yourself; everyone else is already taken.”',
        author:'Oscar Wilde'
    },
    {
        quote:"“I'm selfish, impatient and a little insecure. I make mistakes, I am out of control and at times hard to handle. But if you can't handle me at my worst, then you sure as hell don't deserve me at my best.”",
        author:'Marilyn Monroe'
    },
    {
        quote:'“So many books, so little time.”',
        author:'Frank Zappa'
    },
    {
        quote:"“Two things are infinite: the universe and human stupidity; and I'm not sure about the universe.”",
        author:'Albert Einstein'
    },
    {
        quote:'“A room without books is like a body without a soul.”',
        author:'Marcus Tullius Cicero'
    }
]

function selectQuote(){
    index = Math.floor(Math.random() * quotes.length)-1
    document.getElementById('quote').innerHTML = quotes[index].quote;
    document.getElementById('author').innerHTML = quotes[index].author;
}