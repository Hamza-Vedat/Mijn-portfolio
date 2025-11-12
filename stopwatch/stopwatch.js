let show = document.querySelector("p");
let show1 = document.querySelector("h2");

let starten = document.querySelector(".start");
let stoppen = document.querySelector(".stop");
let resetten = document.querySelector(".restart");

let i = 0;
let interval;
let uren = 0;
let minuten = 0;
let seconden = 0;

function klok1() 
{
  interval = setInterval(klok, 1000);

  function klok() 
  {
    i++;
    seconden = i;
    if (seconden > 59) 
      {
      i = 0;
      seconden = 0;
      minuten++;
      if (minuten > 59) 
        {
        minuten = 0;
        uren++;
      }
    }

    show1.textContent = uren + " : " + minuten + " : " + seconden;
  }
}

starten.onclick = function() 
{
  klok1();
};

stoppen.onclick = function() 
{
  clearInterval(interval);
};

resetten.onclick = function() 
{
  clearInterval(interval);
  uren = 0;
  minuten = 0;
  seconden = 0;
  i = 0;
  show1.textContent = uren + " : " + minuten + " : " + seconden;
};
