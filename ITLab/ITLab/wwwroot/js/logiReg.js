function getById(id) {
    return document.getElementById(id)
}

function displayNone(targetID) {
    let id = targetID;
    let elem = getById(id);
    elem.classList.add("d-none")
    elem.classList.remove("d-flex")
}

function showFlexElem(targetID) {
    let id = targetID;
    let elem = getById(id);
    elem.classList.add("d-flex")
    elem.classList.remove("d-none")
}

function addListener(elem, event, args) {
    elem.addEventListener("click", event(args))
}

// For example buttonId = "#..."
function addEventLogin(buttonId) {
    let element = document.querySelector(buttonId)

    element.addEventListener("click", function() {
        let loginVindow = document.querySelector("#loginWindow")
        console.log(loginVindow)
        if (loginVindow.classList.contains("d-none")) {
            showFlexElem("loginWindow")
                // console.log("HERE - 1")
        } else {
            // console.log("HERE - 2")
            displayNone("loginWindow")
        }
    })
}

// Event listeners
addEventLogin("#logIn")
addEventLogin("#SignIn_login")
addEventLogin("#loginWindow-cover")