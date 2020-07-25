

export const serializeBody = (data: any) => {
    let formBody: string[] = [];
    for (let property in data) {
        let value = data[property];
        if (null != value) {
            let encodedKey = encodeURIComponent(property);
            if (Array.isArray(value)) {
                for (let i = 0; i < value.length; i++) {
                    formBody.push(encodedKey + '=' + encodeURIComponent(value[i]));
                }

            } else {
                formBody.push(encodedKey + '=' + encodeURIComponent(value));
            }
        }
    }
    return formBody.join('&');
};

