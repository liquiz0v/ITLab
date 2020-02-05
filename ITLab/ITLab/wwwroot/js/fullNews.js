let estimate = document.getElementById('estimate');
let GeneralNewsId = document.querySelector('.fullNewsIdForComments').textContent;
render_news(GeneralNewsId);

estimate.onmousemove = function (event) {
    let stars = document.querySelectorAll('#estimate > li');
    let val = event.target.dataset.val;
    // Clear old 
    for (let i = 0; i < 5; i++) {
        stars[i].textContent = '✩';
    }
    if (val) {
        for (let i = 0; i < val; i++) {
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

    document.querySelector('.send_news_comment_area').value = "";

    /*start2 action , refresh comments*/
    render_news(d2,"refresh");
    
};

function render_news(d2, type = "render") {
   
    let xmlhttp = new XMLHttpRequest();
    let formData2 = new FormData();
    xmlhttp.open("POST", "/Landing/Comments", true);
    xmlhttp.setRequestHeader('X-Requested-With', 'XMLHttpRequest');
    formData2.append("Content-Type", "application/x-www-form-urlencodedl");
    formData2.set("NewsId", d2);
    console.log("id is " + d2);


    xmlhttp.send(formData2);




    xmlhttp.onload = function () {

        var obj = JSON.parse(xmlhttp.response);

        let commentsArr = [];

        for (item in obj) {
            let commentObj = new Comments(obj[item].id, obj[item].commentText, obj[item].timeDate, obj[item].commentatorId, obj[item].newsId);
            commentsArr.push(commentObj.toHtmlString());
        }
        let commentsHtmlString = "";
        for (item in commentsArr) {
            commentsHtmlString += commentsArr[item];
        }

        console.log(commentsHtmlString);
        if (type == "refresh") {
            document.getElementById('comments_block').innerHTML = commentsHtmlString;
        }
        else {
            document.getElementById('comments_block').innerHTML += commentsHtmlString;
        }
       

    };

    /*end2*/
}

class Comments {
    constructor(id, commentText, timeDate, commentatorId, newsId, commentatorName = "Александр Петров") {
        this.id = id;
        this.commentText = commentText;
        this.timeDate = timeDate;
        this.commentatorId = commentatorId;
        this.newsId = newsId;
        this.commentatorName = commentatorName;//добавить на беке возврат имени, завтыкал
    }

    toHtmlString() {
        let htmlString = '<div class="one_comment">' +

            '<div class="commentatorName">Имя:  ' + this.commentatorName + '</div>'
            +
            '<div class="сommentTimeDate">Дата:   ' + this.timeDate + '</div>'
            +
            '<div class="сommentText">Комментарий:   ' + this.commentText + '</div>'


            + '</div>';

        return htmlString;
    }
}

let subscribe_on_news = document.getElementById('subscribe_on_news');
subscribe_on_news.onclick = function () {

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
};

