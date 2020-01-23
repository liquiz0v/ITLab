let estimate = document.getElementById('estimate');

estimate.onmousemove = function(event){
	let stars = document.querySelectorAll('#estimate > li');
	let val = event.target.dataset.val;
	// Clear old 
	for(let i = 0; i < 5; i++){
		stars[i].textContent = '✩';
	}
	if(val){
		for(let i = 0; i < val; i++){
			stars[i].textContent = '★';
		}
	}
};