const dateFormat = 'DD-MMM-YYYY';
const dateTimeFormat = 'DD-MMM-YYYY HH:mm';
moment.locale();  

const formatDateString = (dateToFormat, withTime) => {
    if (!dateToFormat || dateToFormat.trim().length === 0) {
        return dateToFormat;
    }
    return moment(new Date(dateToFormat)).lang("ru").format(withTime ? dateTimeFormat : dateFormat);
};

