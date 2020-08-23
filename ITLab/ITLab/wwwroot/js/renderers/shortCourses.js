let render_short_course_block = (blockForRenderId, type = 'render') => {

    let hname = window.location.hostname;
    let xmlhttp = new XMLHttpRequest();
    let formData2 = new FormData();
    xmlhttp.open("POST", `http://${hname}:82/api/Course/GetCourseSchedule`, true);
    xmlhttp.setRequestHeader('X-Requested-With', 'XMLHttpRequest');
    formData2.append("Content-Type", "application/x-www-form-urlencoded");
    //formData2.set("newsId", d2);

    xmlhttp.send(formData2);

    xmlhttp.onload = function () {

        let object = JSON.parse(xmlhttp.response);
        console.log(object);
        let coursesArr = [];

        for (let i in object) {
            if (Object.prototype.hasOwnProperty.call(object, i)) {
                let courseObj = new Course(
                    object[i].Schedule,
                    object[i].CourseId,
                    object[i].Name,
                    object[i].Description,
                    object[i].HeadPhoto,
                    object[i].Photos,
                    object[i].Lessons,
                    object[i].PhotoLink
                );
                let str = ``;

                if (i % 2 === 0) {
                    str = 'fadeInDown';
                } else {
                    str = 'fadeInUp';
                }

                coursesArr.push(courseObj.generateHtml(str));

            }
        }
        let courseHtmlString = "";

        for (let item in coursesArr) {
            if (Object.prototype.hasOwnProperty.call(coursesArr, item)) {
                courseHtmlString += coursesArr[item];
            }
        }

        //console.log(newsHtmlString);
        if (type === "refresh") {
            document.getElementById(blockForRenderId).innerHTML = courseHtmlString;
        }
        else {
            document.getElementById(blockForRenderId).innerHTML = courseHtmlString;
        }

    };

    /*end2*/
}

class Course {
    constructor(schedule, courseId, name, description, headPhoto, photos, lessons, photoLink) {
        this.Schedule = schedule;
        this.CourseId = courseId;
        this.Name = name;
        this.Description = description;
        this.HeadPhoto = headPhoto;
        this.Photos = photos;
        this.Lessons = lessons;
        this.PhotoLink = photoLink;
    }

    generateHtmlTimes(schedule) {
        let htmlTime = ``;

        for (let i in schedule) {
            let time = getTime(schedule[i].LessonDateFrom)
            console.log(time);
            htmlTime = htmlTime + `<li><img src="/images/clock.png"/> ${getTime(schedule[i].LessonDateFrom)} - ${getTime(schedule[i].LessonDateTo)}</li>`;
        }

        return htmlTime;
    }

    generateHtmlDates(schedule) {
        let htmlDate = ``;

        for (let i in schedule) {
            console.log(numberToDayOfWeek(schedule[i].LessonDateFrom))
            htmlDate = htmlDate + `<li>${numberToDayOfWeek(schedule[i].LessonDateFrom)}</li>`;
        }

        return htmlDate;
    }

    generateHtml(str) {

        const htmlString = `<div class="cours-block wow ${str}" data-wow-delay="0.5s">
                    <div class="cours-header">
                        <div class="cours-bg"><img src="${this.PhotoLink}"></img></div>
                        <div class="cours-name">${this.Name}</div>
                    </div>
                    <div class="cours-body">
                        <div class="decore-line"></div>
                        <div class="cours-time">
                            <ul>
                                ${this.generateHtmlDates(this.Schedule)}
                            </ul>
                            <ul>
                                ${this.generateHtmlTimes(this.Schedule)}
                            </ul>
                        </div>
                        <div class="cours-button">
                            <button onclick="openModal()">Записаться на занятие</button>
                            <button>Подробнее о курсе</button>
                        </div>
                    </div>
                </div>`;

        return htmlString;
    }
}
