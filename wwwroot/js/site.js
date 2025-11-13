// Please see documentation at https://learn.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
function changePage(status) {
    console.log("Changing page-----" + status);
    var url = "../api/home";
    if (status == "wedding") {
        url = "../api/Wedding";
    }
    else if (status == "birthday") {
        url = "../api/birthday";
    }

    console.log("Loading view:", url);

    fetch(url)
        .then(response => {
            if (!response.ok) throw new Error('Network response was not ok');
            return response.text();
        })
        .then(data => {
            document.write(data);
        })
        .catch(error => console.error('Fetch error:', error));
}

function weddingProduct(product) {
    var route = "";
    if (product == 'tables') {
        route = "api/wedding/tables";
    }
    else if (product == 'chaffing') {
        route = "api/wedding/chaffing";
    }
    else if (product == 'dessert') {
        route = "api/wedding/desserttable";
    }
    else if (product == 'arch') {
        route = "api/wedding/arch";
    }
    else if (product == 'backlash') {
        route = "api/wedding/backlash";
    }
    else if (product == 'tent') {
        route = "api/wedding/tent";
    }
    else if (product == '') {
        route = "api/wedding";
    }
    console.log("Loading product:", product);
    fetch(route)
        .then(response => {
            if (!response.ok) throw new Error('Network response was not ok');
            return response.text();
        })
        .then(data => {
            document.write(data);
        })
        .catch(error => console.error('Fetch error:', error));
}


function birthdayProduct(product) {
    var route = "api/birthday/";
    if (product == 'minecraft') {
        route += "minecraft";
    }
    else if (product == 'babyShark') {
        route += "babyShark";
    }
    else if (product == 'cocomelon') {
        route += "cocomelon";
    }
    else if (product == 'bluey') {
        route += "bluey";
    }
    else if (product == 'peppa') {
        route += "peppa";
    }
    else if (product == 'frozen') {
        route += "frozen";
    }
    else if (product == 'pony') {
        route += "pony";
    }
    else if (product == 'spiderman') {
        route += "spiderman";
    }
    console.log("Url :" + route);
    console.log("Loading product:", product);
    fetch(route)
        .then(response => {
            if (!response.ok) throw new Error('Network response was not ok');
            return response.text();
        })
        .then(data => {
            document.write(data);
        })
        .catch(error => console.error('Fetch error:', error));
}