let sortButton = document.getElementById('toSort');
let sortList = document.getElementById('sortList');
let sortStatus = false;

sortButton.onclick = function(){
	sortStatus = !sortStatus;
	if(sortStatus){
		sortList.style.display = 'block';
	}else{
		sortList.style.display = 'none';
	}
}
sortList.onclick = function(e){
	sortButton.textContent = e.target.textContent;
	sortList.style.display = 'none';
	sortStatus = false;
	let type = e.target.dataset.type;
	console.log(type);
}

let subscribeButton = document.getElementById('subscribe');

subscribeButton.onclick = function(){
	let subButton = document.getElementById('subEmail');
	// SEND DATA TO SERVER!
	//subButton.value
}