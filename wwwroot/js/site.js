// Please see documentation at https://learn.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

if (typeof cartItems === 'undefined') {
    var cartItems = [];
}
console.log("running Getitems");
if (typeof itemTypesMap === 'undefined') {
    var itemTypesMap = null;
}

/*if (cartItems.length < 1) {
    getItems();
    cartItems.push("alan");
    console.log(cartItems);
}*/

async function loadItemTypes() {
    const cached = sessionStorage.getItem('itemTypes');

    if (!cached) {
        console.log("Fetching item types from server...");
        const response = await fetch('/items/item');
        const itemTypesArray = await response.json();

        // Convert array to object with code as key
        itemTypesMap = {};
        itemTypesArray.forEach(item => {
            itemTypesMap[item.code] = item;
        });

        // Store in sessionStorage
        sessionStorage.setItem('itemTypes', JSON.stringify(itemTypesMap));
        console.log("Item types loaded and cached");
    } else {
        console.log("Using cached item types");
        itemTypesMap = JSON.parse(cached);
    }

    console.log("ItemTypes Map:", itemTypesMap);
    return itemTypesMap;
}

// Usage
(async () => {
    await loadItemTypes();

    // Access by code
    const item = itemTypesMap['bbs-cb-001'];
    console.log("Item with code bbs-cb-001:", item);

    // Or with bracket notation for dynamic codes
    const code = 'pep-tb-001';
    const item2 = itemTypesMap[code].bond;
    console.log("Second item's bond : ", item2)
})();
console.log("Printing Item types : ", itemTypesMap);
console.error(itemTypesMap[2]);
// Call it when page loads
loadItemTypes();
function getItems() {
    var route = "../items/item";
    fetch(route)
        .then(response => {
            if (!response.ok) throw new Error('Could not get list of items')
            return response.text();
        })
        .then(data => {
            console.log(data);
        })
        .catch(error => console.error('Fetch error: ', error));
}
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


function addToCart(item) {
    
}
