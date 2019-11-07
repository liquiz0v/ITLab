new WOW().init();
// Для статистики!!!
let toSt = false;

function counterAnimation(allCount, animationTime, delta, el){
	let counter = 0;
    animationTime /= allCount / delta;

    let t = setInterval(function(){
    	counter += delta;
      	el.textContent = counter;
      	if(counter >= allCount) clearInterval(t);
    }, animationTime);
}

window.addEventListener("scroll", function(){
	let elementTarget = document.getElementById("statistics");
  	if (window.scrollY + document.documentElement.clientHeight
	>= elementTarget.offsetTop + elementTarget.offsetHeight / 2
	&& !toSt){
	    toSt = true;
		let el = document.getElementById('yCounter');
		counterAnimation(2015, 1500, 65, el);

		el = document.getElementById('prCounter');
		counterAnimation(14, 1500, 1, el);

	    el = document.getElementById('pCounter');
		counterAnimation(1000, 1500, 10, el);
	}
});

let arrowDown = document.getElementById('arrowDown');

function toElem(elem){
	elem.scrollIntoView({block: 'start', behavior: 'smooth'});
}