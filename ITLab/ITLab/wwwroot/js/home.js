// Для статистики
let toSt = false;
render_news_block()
window.addEventListener("scroll", function () {
    let elementTarget = document.getElementById("statistics");
    if (window.scrollY + document.documentElement.clientHeight
        >= elementTarget.offsetTop + elementTarget.offsetHeight / 2
        && !toSt) {
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
let slideLeft = document.getElementById('slideLeft');
let slideRight = document.getElementById('slideRight');
let sliderWrapper = document.querySelector('.slider-wrapper');
let counter = 3;

slideRight.onclick = function () {
    let elem = document.querySelectorAll('.slider-news');
    if (counter < elem.length) {
        sliderWrapper.style.left = sliderWrapper.offsetLeft - 520 + 'px';
        counter++;
        if (counter == elem.length) {
            slideLeft.style.visibility = 'visible';
            slideRight.style.visibility = 'hidden';
        } else {
            slideRight.style.visibility = 'visible';
        }
        slideLeft.style.visibility = 'visible';
    } else {
        slideRight.style.visibility = 'hidden';
    }
}
slideLeft.onclick = function () {
    if (counter > 3) {
        sliderWrapper.style.left = sliderWrapper.offsetLeft + 520 + 'px';
        counter--;
        console.log(counter);
        if (counter == 3) {
            slideLeft.style.visibility = 'hidden';
            slideRight.style.visibility = 'visible';
        } else {
            slideLeft.style.visibility = 'visible';
        }
    } else {
        slideLeft.style.visibility = 'hidden';
        slideRight.style.visibility = 'visible';
    }
}


let sendFeedback = document.getElementById('sendFeedback');
sendFeedback.onclick = function () {
    let d1 = document.querySelector('.fName').value;
    let d2 = document.querySelector('.fTel').value;
    let d3 = document.querySelector('.fAsk').value;

    //let data = { FullName: d1, Phone: d2, Question: d3 };

    let xmlhttp = new XMLHttpRequest();
    let formData = new FormData();
    xmlhttp.open("POST", "/Landing/FeedBack", true);
    xmlhttp.setRequestHeader('X-Requested-With', 'XMLHttpRequest');
    formData.append("Content-Type", "application/x-www-form-urlencodedl");
    formData.set("FullName", d1);
    formData.set("Phone", d2);
    formData.set("Question", d3);
    xmlhttp.onload = function () {
        console.log(xmlhttp.responseText); // ответ
    };

    xmlhttp.send(formData);

    document.querySelector('.fName').value = "";
    document.querySelector('.fTel').value = "";
    document.querySelector('.fAsk').value = "";


    xmlhttp.onreadyechange = function () {
        if (xmlhttp.readyState == XMLHttpRequest.DONE) {
            if (xmlhttp.status == 200) {
                let body = XMLHttpRequest.response;
                body = JSON.parse(body);
                if (body.status) {
                    console.log('nice!');
                } else {

                }
            }
            else if (xmlhttp.status == 400) {
                alert('There was an error 400');
            }
            else {
                alert('something else other than 200 was returned');
            }
        }
    }





    /*
    $.ajax({
        url: '/Landing/FeedBack',
        type: 'POST',

        data: data,
        success: function () {
            console.log("norm");
        },
        error: function () {
            console.log("ne norm");
        }
    });
    */


};

function openModal() {
    document.getElementById('global-filter').style.display = 'block';
    document.getElementById('modalFB').style.display = 'block';
}
function closeModal() {
    document.getElementById('global-filter').style.display = 'none';
    document.getElementById('modalFB').style.display = 'none';
}

//GENERATE NEWS
let newsRequestData = document.getElementById('');

function render_news_block(d2 = null, type = "render") {

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
            document.getElementById('newsBlock').innerHTML = newsHtmlString;
        }
        else {
            document.getElementById('newsBlock').innerHTML += newsHtmlString;
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
        let htmlString = `<div class="slider-news news_block">

        <div class="news-date">
            <span>${this.TimeDate}</span>
        </div>
        <div class="slider-news-header" style="background-image: url('${this.HeadPhoto}')"></div>
        <div class="news-body">
            <span>«${this.Title}</span>
            <p><span>${this.CommentsCount}</span> комментариев / <span>${this.ViewsCount}</span> просмотров</p>
            <p>
                ${this.ShortDescription}
            </p>
        </div>
        <a asp-action="FullNews" src="${this.Id}">
            <div class="news-button">
                <button>Подробнее</button>
            </div>
        </a>
    </div>`;
        return htmlString;
    }
}

//GENERATE NEWS

//хз что снизу
function openModal() {
    document.getElementById('global-filter').style.display = 'block';
    document.getElementById('modalFB').style.display = 'block';
}
function closeModal() {
    document.getElementById('global-filter').style.display = 'none';
    document.getElementById('modalFB').style.display = 'none';
}

document.getElementById('mfb1').onclick = openModal;
document.getElementById('mfb2').onclick = openModal;
document.getElementById('mfb3').onclick = openModal;

document.getElementById('close-modal').onclick = closeModal;


document.getElementById('fb-first-lesson').onclick = function () {
    let name = document.getElementById('ffb-name').value;
    let phone = document.getElementById('ffb-name').value;
    let email = document.getElementById('ffb-name').value;
    let age = document.getElementById('ffb-name').value;

    let data = { name: name, phone: phone, email: email, age: age };

    let xmlhttp = new XMLHttpRequest();

    xmlhttp.open('POST', 'http://localhost:3000');
    xmlhttp.setRequestHeader('Content-Type', 'application/json');
    xmlhttp.send(JSON.stringify(data));

    xmlhttp.onreadyechange = function () {
        if (xmlhttp.readyState == XMLHttpRequest.DONE) {
            if (xmlhttp.status == 200) {
                let body = XMLHttpRequest.response;
                body = JSON.parse(body);
                if (body.status) {
                    console.log('nice!');
                } else {

                }
            }
            else if (xmlhttp.status == 400) {
                alert('There was an error 400');
            }
            else {
                alert('something else other than 200 was returned');
            }
        }
    }
}
