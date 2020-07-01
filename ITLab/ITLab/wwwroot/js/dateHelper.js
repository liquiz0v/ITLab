const dateFormat = 'DD-MMM-YYYY';
const dateTimeFormat = 'DD-MMM-YYYY HH:mm';

const formatDateString = (dateToFormat, withTime) => {
    if (!dateToFormat || dateToFormat.trim().length === 0) {
        return dateToFormat;
    }
    return moment(new Date(dateToFormat)).format(withTime ? dateTimeFormat : dateFormat);
};

