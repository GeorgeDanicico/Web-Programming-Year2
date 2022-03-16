
let words = $('div')[0].innerText.split(' ');
let htmlWords = [];

for (let i = 0; i < words.length; i++) {
  words[i] = '<span>' + words[i] + '</span>';
}

innerHTML = words.join(' ');

// console.log(innerHTML);

$('div')[0].innerHTML = innerHTML;

$('span').click(function(){

  let text = $(this).text();
  
  const spans = $('span');

  for (let i = 1; i <= spans.length; i++) {
    let span = $(`span:nth-child(${i})`);
    
    if (span.text() === text) {
      span.addClass('highlight');
    }
  }

});