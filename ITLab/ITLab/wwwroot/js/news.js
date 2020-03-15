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
    let d1 = document.getElementById('subEmail').value;
    let xmlhttp = new XMLHttpRequest();
    let formData = new FormData();
    xmlhttp.open("POST", "/Landing/NewsSubscr", true);
    xmlhttp.setRequestHeader('X-Requested-With', 'XMLHttpRequest');
    formData.append("Content-Type", "application/x-www-form-urlencodedl");
    formData.set("Email", d1);
    xmlhttp.onload = function () {
        console.log(xmlhttp.responseText); // ответ
    };

    xmlhttp.send(formData);

    document.getElementById('subEmail').value = "";
}
