new WOW().init();

function counterAnimation(allCount, animationTime, delta, el){
	let counter = 0;
    animationTime /= allCount / delta;

    let t = setInterval(function(){
    	counter += delta;
      	el.textContent = counter;
      	if(counter >= allCount) clearInterval(t);
    }, animationTime);
}

function toElem(elem){
	elem.scrollIntoView({block: 'start', behavior: 'smooth'});
}