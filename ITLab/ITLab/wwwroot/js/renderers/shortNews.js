
//GENERATE NEWS

let render_short_news_block = (blockForRenderId, type = 'render') => {


    let xmlhttp = new XMLHttpRequest();
    let formData2 = new FormData();
    xmlhttp.open("POST", "/Landing/GetShortNews", true);
    xmlhttp.setRequestHeader('X-Requested-With', 'XMLHttpRequest');
    formData2.append("Content-Type", "application/x-www-form-urlencoded");
    //formData2.set("newsId", d2);

    xmlhttp.send(formData2);


    xmlhttp.onload = function () {

        let obj = JSON.parse(xmlhttp.response);
        console.log(obj);
        let newsArr = [];

        for (item in obj) {
            let newsObj = new News(
                obj[item].id,
                obj[item].title,
                obj[item].shortDescription,
                obj[item].commentsCount,
                obj[item].viewsCount,
                obj[item].headPhoto,
                obj[item].timeDate
            );
            newsArr.push(newsObj.generateHtml());
        }
        let newsHtmlString = "";
        for (item in newsArr) {
            newsHtmlString += newsArr[item];
        }

        console.log(newsHtmlString);
        if (type == "refresh") {
            document.getElementById(blockForRenderId).innerHTML = newsHtmlString;
        }
        else {
            document.getElementById(blockForRenderId).innerHTML = newsHtmlString;
        }

    };

    /*end2*/
}
class News {
    constructor(id, title, shortDescription, commentsCount, viewsCount, headPhoto, timeDate) {
        this.Id = id;
        this.Title = title;
        this.ShortDescription = shortDescription;
        this.CommentsCount = commentsCount;
        this.ViewsCount = viewsCount;
        this.HeadPhoto = headPhoto;
        this.TimeDate = timeDate;
    }

    generateHtml() {
        var newsDate = formatDateString(this.TimeDate);

        let fullNewsLink = `${window.location.href}Landing/FullNews/${this.Id}`;

        let htmlString = `<div class="slider-news news_block">
        
        <div class="news-date">
            <span>${newsDate}</span>
            
        </div>
        <div class="slider-news-header" style="background-image: url('${this.HeadPhoto}')"></div>
        <div class="news-body">
            <span>«${this.Title}</span>
            <p><span>${this.CommentsCount}</span> комментариев / <span>${this.ViewsCount}</span> просмотров</p>
            <p>
                ${this.ShortDescription}
            </p>
        </div>
        <a  href="${fullNewsLink}">
            <div class="news-button">
                <button>Подробнее</button>
            </div>
        </a>
    </div>`;
        return htmlString;
    }
}

//GENERATE NEWS