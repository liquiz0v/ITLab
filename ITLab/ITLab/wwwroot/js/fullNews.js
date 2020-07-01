
render_comments();

let estimate = document.getElementById('estimate');
//let GeneralNewsId = document.querySelector('.fullNewsIdForComments').textContent;
//render_news(GeneralNewsId);

render_short_news_block('fullNews_shortNews_block');

render_full_news_block(window.location.search);

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

    let d1 = document.querySelector('.send_news_comment_area').value;
    let d2 = document.querySelector('.fullNewsIdForComments').textContent;

    let xmlhttp = new XMLHttpRequest();
    let formData = new FormData();
    xmlhttp.open("POST", "/Landing/CreateComment", true);
    xmlhttp.setRequestHeader('X-Requested-With', 'XMLHttpRequest');
    formData.append("Content-Type", "application/x-www-form-urlencoded");
    formData.set("CommentText", d1);
    formData.set("CommentatorId", 1); // после авторизации сделать
    formData.set("NewsId", d2);
    xmlhttp.onload = function () {
        xmlhttp.responseText; // ответ
    };

    xmlhttp.send(formData);

    document.querySelector('.send_news_comment_area').value = "";

    /*start2 action , refresh comments*/
    render_comments(d2, "refresh");

};

function render_comments(d2, type = "render") {

    let xmlhttp = new XMLHttpRequest();
    let formData2 = new FormData();
    xmlhttp.open("POST", "/Landing/GetComments", true);
    xmlhttp.setRequestHeader('X-Requested-With', 'XMLHttpRequest');
    formData2.append("Content-Type", "application/x-www-form-urlencoded");
    formData2.set("newsId", d2);


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

        if (type == "refresh") {
            document.getElementById('comments_block').innerHTML = commentsHtmlString;
        }
        else {
            document.getElementById('comments_block').innerHTML += commentsHtmlString;
        }

    };
}

class Comments {
    constructor(id, commentText, timeDate, commentatorId, newsId, commentatorName = "Александр Петров") {
        this.id = id;
        this.commentText = commentText;
        this.timeDate = timeDate;
        this.commentatorId = commentatorId;
        this.newsId = newsId;
        this.commentatorName = commentatorName; //добавить на беке возврат имени, завтыкал
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
        alert('done');
    };

    xmlhttp.send(formData);

    document.getElementById('subEmail').value = "";
};


//GENERATE FULL NEWS
let newsRequestData = document.getElementById('');

function render_full_news_block(d2 = null, type = "render") {
    const queryString = `/Landing/GetFullNews/?newsid=1`;   //Нужно как то вытянуть параметр строки

    let xmlhttp = new XMLHttpRequest();
    let formData2 = new FormData();
    xmlhttp.open("GET", `${queryString}`, true);
    xmlhttp.setRequestHeader('X-Requested-With', 'XMLHttpRequest');
    formData2.append("Content-Type", "application/x-www-form-urlencoded");
    //formData2.set("newsId", d2);

    xmlhttp.send(formData2);

    xmlhttp.onload = function () {

        let obj = JSON.parse(xmlhttp.response);
        let basicNewsArr = [];
        let additionalNewsArr = [];
        let commentsArr = [];
        let photosArr = [];
        let videosArr = [];

        let newsObj = new FullNews(
            obj.id,
            obj.title,
            obj.fullDescription,
            obj.commentsCount,
            obj.viewsCount,
            obj.headPhoto,
            obj.timeDate,
            obj.photos,
            obj.videos,
            obj.comments);


        basicNewsArr.push(newsObj.generateBasicNewsHtml());
        additionalNewsArr.push(newsObj.generateAdditionalNewsHtml());

        for (let item in newsObj.Photos) {
            photosArr.push(newsObj.generatePhotosHtml(newsObj.Photos[item]));
        };

        for (let item in newsObj.Videos) {
            videosArr.push(newsObj.generateVideosHtml(newsObj.Videos[item]));
        };

        // for (let item in newsObj.Comments) {
        //     commentsArr.push(newsObj.generateCommentsHtml(newsObj.Comments[item]));
        // };
        
        //reused comments renderer instead 
        
            

        let basicNewsHtmlString = "";
        let additionalNewsHtmlString = "";
        let commentHtmlString = "";
        let photosHtmlString = "";
        let videosHtmlString = "";

        basicNewsHtmlString += basicNewsArr;
        additionalNewsHtmlString += additionalNewsArr;
        
        for (item in photosArr){
            photosHtmlString += photosArr[item];
        }

        for (item in videosArr){
            videosHtmlString += videosArr[item];
        }

        for (item in commentsArr) {
            commentHtmlString += commentsArr[item];
        }
      
        

        if (type == "refresh") {
            document.getElementById('basic_news').innerHTML = basicNewsHtmlString;
            document.getElementById('videos').innerHTML = additionalNewsHtmlString;
            document.getElementById('photos').innerHTML = photosHtmlString;
            document.getElementById('additional_news').innerHTML = videosHtmlString;
            document.getElementById('comments').innerHTML = commentHtmlString;
        }

        else {
            document.getElementById('basic_news').innerHTML += basicNewsHtmlString;
            document.getElementById('videos').innerHTML += videosHtmlString;
            document.getElementById('photos').innerHTML += photosHtmlString;
            document.getElementById('additional_news').innerHTML += additionalNewsHtmlString;
            document.getElementById('comments').innerHTML += commentHtmlString;
        }

        
    };

    /*end2*/
}

class FullNews {
    constructor(id, title, fullDescription, commentsCount, viewsCount, headPhoto, timeDate, photos, videos, comments) {
        this.Id = id;
        this.Title = title;
        this.FullDescription = fullDescription;
        this.CommentsCount = commentsCount;
        this.ViewsCount = viewsCount;
        this.HeadPhoto = headPhoto;
        this.TimeDate = timeDate;
        this.Photos = photos;
        this.Videos = videos;
        this.Comments = comments;
    }

    generateBasicNewsHtml() {
        var newsDate = formatDateString(this.TimeDate);

        let fullNewsLink = `${window.location.href}Landing/FullNews?newsId=${this.Id}`;

        let htmlString = `<div class="news_statistic">
                            <div class="fullNewsIdForComments" style="display:none">${this.Id}</div>
                            <p class="st_info">${newsDate} / ${this.CommentsCount} комментариев / ${this.ViewsCount} <span>5.0</span> 3 голоса</p>
                         </div>`;
        return htmlString;
    }

    generateAdditionalNewsHtml() {
        let htmlString = `<h3>
                              ${this.Title}
                          </h3>
                          <p>
                              ${this.FullDescription}
                          </p>`;

        return htmlString;
    };

    generateCommentsHtml(comment) { //По идее не нужно тк уже есть метод в классе Comments (перенес сюда)
        let htmlString = `<div class="one_comment">
                            <div class="commentatorName">Имя: ${comment.fullName}</div>
                            <div class="сommentTimeDate">Дата:  ${formatDateString(comment.timeDate)}</div>
                            <div class="сommentText">Комментарий: ${comment.commentText}</div>
                          </div>`;

        return htmlString;
    };

    generatePhotosHtml(photo) {
        let htmlString = `<img src=${photo.link} alt="Alternate Text" class="fullNewsImage" />`;
        return htmlString;
    };

    generateVideosHtml(video) {
        let htmlString = `<iframe src=${video.link} width="900" height="506" frameborder="0" allow="accelerometer; autoplay; encrypted-media; gyroscope; picture-in-picture" allowfullscreen></iframe>`;
        return htmlString;
    };
}


let toITLabDateString = (date) => {
    var resultDate = new Date(date);

    var result = {
        month: resultDate.getMonth(),
        day: resultDate.getDay()
    }
    return result;
};
//GENERATE FULL NEWS











