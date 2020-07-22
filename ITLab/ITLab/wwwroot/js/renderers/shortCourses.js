let render_short_course_block = (blockForRenderId, type = 'render') => {


    let xmlhttp = new XMLHttpRequest();
    let formData2 = new FormData();
    xmlhttp.open("POST", "/api/Course/GetShortCourse", true);
    xmlhttp.setRequestHeader('X-Requested-With', 'XMLHttpRequest');
    formData2.append("Content-Type", "application/x-www-form-urlencoded");
    //formData2.set("newsId", d2);

    xmlhttp.send(formData2);


    xmlhttp.onload = function () {

        let obj = JSON.parse(xmlhttp.response);
        console.log(obj);
        let coursesArr = [];

        for (item in obj) {
            let courseObj = new Course()
            {
                    obj[item].CourseId,
                    obj[item].Name,
                    obj[item].Description,
                    obj[item].headPhoto,
                    obj[item].Photos,
                    obj[item].Lessons,
                    obj[item].Schedule
            };

            coursesArr.push(courseObj.generateHtml());
        }
        let courseHtmlString = "";

        for (item in newsArr) {
            courseHtmlString += coursesArr[item];
        }

        //console.log(newsHtmlString);
        if (type == "refresh") {
            document.getElementById(blockForRenderId).innerHTML = courseHtmlString;
        }
        else {
            document.getElementById(blockForRenderId).innerHTML = courseHtmlString;
        }

    };

    /*end2*/
}

class Course {
    constructor(courseId, name, description, headPhoto, photos, lessons, schedule) {
        this.CourseId = courseId;
        this.Name = name;
        this.Description = description;
        this.HeadPhoto = headPhoto;
        this.Photos = photos;
        this.Lessons = lessons;
        this.Schedule = schedule;
    }

    generateHtmlDates() {
    }

    generateHtml() {

        const htmlString = `<div class="cours-block wow fadeInDown" data-wow-delay="0.5s">
                    <div class="cours-header">
                        <div class="cours-bg i1"></div>
                        <div class="cours-name">${this.Name}</div>
                    </div>
                    <div class="cours-body">
                        <div class="decore-line"></div>
                        <div class="cours-time">
                            <ul>
                                <li>Среда</li>
                                <li>Суббота</li>
                            </ul>
                            <ul>
                                <li><img src="~/images/clock.png">  17:00 - 18:30</li>
                                <li><img src="~/images/clock.png">  13:00 - 14:30</li>
                            </ul>
                        </div>
                        <div class="cours-button">
                            <button onclick="openModal()">Записаться на занятие</button>
                            <button>Подробнее о курсе</button>
                        </div>
                    </div>
                </div>`;
    }
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

        let fullNewsLink = `https://localhost:5001/Landing/FullNews?newsId=${this.Id}`; // Не забыть поменять на наш будущий домен.

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