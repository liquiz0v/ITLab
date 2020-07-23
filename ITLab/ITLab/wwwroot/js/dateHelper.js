const dateFormat = 'DD-MMM-YYYY';
const dateTimeFormat = 'DD-MMM-YYYY HH:mm';
moment.locale();  

const formatDateString = (dateToFormat, withTime) => {
    if (!dateToFormat || dateToFormat.trim().length === 0) {
        return dateToFormat;
    }
    return moment(new Date(dateToFormat)).lang("ru").format(withTime ? dateTimeFormat : dateFormat);
};

const getTime = (dateToFormat) => {
    if (!dateToFormat || dateToFormat.trim().length === 0) {
        return dateToFormat;
    }

    const time = "h:mm";

    return moment(new Date(dateToFormat)).lang("ru").format(time);
};

const numberToDayOfWeek = (number) => {
    if (!number) {
        return number;
    }

    return moment(new Date(number)).format('dddd');
};
