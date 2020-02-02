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

let send_news_comment = document.getElementById('send_news_comment');
send_news_comment.onclick = function () {
    console.log("start comment request");

    let d1 = document.querySelector('.send_news_comment_area').value;
    let d2 = document.querySelector('.fullNewsIdForComments').textContent;

    let xmlhttp = new XMLHttpRequest();
    let formData = new FormData();
    xmlhttp.open("POST", "/Landing/CreateComment", true);
    xmlhttp.setRequestHeader('X-Requested-With', 'XMLHttpRequest');
    formData.append("Content-Type", "application/x-www-form-urlencodedl");
    formData.set("CommentText", d1);
    formData.set("CommentatorId", 1); // после авторизации сделать
    formData.set("NewsId", d2);
    xmlhttp.onload = function () {
        console.log(xmlhttp.responseText); // ответ
    };

    xmlhttp.send(formData);

};