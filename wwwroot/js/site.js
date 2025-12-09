// Please see documentation at https://learn.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
// Only initialize cart in localStorage if it doesn't exist

if (!localStorage.getItem("newCart")) {
    localStorage.setItem("newCart", "[]");
}
var storedCart = JSON.parse(localStorage.getItem("newCart"));
console.log("Local Storage : ", storedCart);
//console.error("Pushing 999999")
//storedCart.push(99);
localStorage.setItem("newCart", JSON.stringify(storedCart));
var storedCart = JSON.parse(localStorage.getItem("newCart"));
console.log("Local Storage (new): ", storedCart);


if (typeof cartItems === 'undefined') {
    var cartItems = [];
}

cartItems = [...storedCart];


console.error("cart items : ", cartItems);
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
    return itemTypesMap;
}

function getItemType(code) {
    return itemTypesMap[code];
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


console.error(itemTypesMap);
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
function checkItem(itemName) {
    var typeKey = "";
    for (const [key, value] of itemTypesMap) {
        if (itemName === value.itemType) {
            console.log("item type found");
        }
    }
}
function rent() { //table
    console.log("RENT :::: item");
    const productCode = document.getElementById('product').value;
    console.error("Product Code :", productCode);
    const quantity = document.getElementById('quantity').value;
    const startDate = document.getElementById('startDate').value;
    const startTime = document.getElementById('startTime').value;
    const endDate = document.getElementById('endDate').value;
    const endTime = document.getElementById('endTime').value;
    const terms = document.getElementById('myCheckBox');

    //find item 
    let tempItem = itemTypesMap[productCode];
    console.error("Temp item : ", tempItem);
    let price = tempItem.price;
    let bond = tempItem.bond;
    let name = tempItem.name;

    console.log("Product :", product);
    console.log("Quantity :", quantity);
    console.log("Start Date :", startDate);
    console.log("StartTime :", startTime);
    console.log("Price : ", price);
    console.log("end Date :", endDate);
    console.log("endTime :", endTime);
    console.error("Item bond : ", bond);

    // Validation
    if (!product || !quantity || !startDate || !startTime || !endDate || !endTime) {
        alert('Please fill in all fields');
        return;
    }
    console.error("Checked? : ", terms.checked);
    console.log(document.getElementById(myCheckBox));
    if (!terms.checked) {
        alert('Ensure terms and conditions are accepted');
        return;
    }

    // Create rental item
    const rentalItem = {
        productCode,
        quantity: parseInt(quantity),
        startDate,
        startTime,
        endDate,
        endTime,
        price,
        bond,
        name
    };
    var validity = checkValid(rentalItem);
    console.log("Validity of item :", validity);
    pushToCart(rentalItem);
}
function checkValid(rentalItem) {
    var valid = false;
    const code = rentalItem.productCode;
    var totalQty = itemTypesMap[code].totalQuantity;
    console.error("Quantity available", totalQty);
    if (totalQty > rentalItem.quantity) { valid = true }
    else { alert('Item exceeded limits') }
    return valid;
}
function pushToCart(rentalItem) {
    cartItems.push(rentalItem);

    localStorage.setItem("newCart", JSON.stringify(cartItems));
    var tmp = localStorage.getItem("newCart");
    console.log(tmp);

    //storedCart.push(rentalItem);
    //localStorage.setItem("newCart", JSON.stringify(storedCart));
    console.log('Added to cart:', rentalItem);
    alert("Added")
    console.log("New cart itmes :", cartItems);
}
function addToCart() {
    const product = document.getElementById('product').value;
    const quantity = document.getElementById('quantity').value;
    const startDate = document.getElementById('startDate').value;
    const startTime = document.getElementById('startTime').value;
    const endDate = document.getElementById('endDate').value;
    const endTime = document.getElementById('endTime').value;
    let bond = itemTypesMap["bbs-cb-001"].bond;
    const terms = document.getElementById('myCheckBox');

    console.log("Product :", product);
    console.log("Quantity :", quantity);
    console.log("Start Date :", startDate);
    console.log("StartTime :", startTime);
    console.log("end Date :", endDate);
    console.log("endTime :", endTime);
    console.error("Item bond : ", bond);

    //get the item
    let tempItem = itemTypesMap["bbs-cb-001"];
    let price = tempItem.price;

    console.error("Price : ", price);

    // Validation
    if (!product || !quantity || !startDate || !startTime || !endDate || !endTime) {
        alert('Please fill in all fields');
        return;
    }
    console.error("Checked? : ",terms.checked);
    console.log(document.getElementById(myCheckBox));
    if (!terms.checked) {
        alert('Ensure terms and conditions are accepted');
        return;
    }

    // Create rental item
    const rentalItem = {
        product,
        quantity: parseInt(quantity),
        startDate,
        startTime,
        endDate,
        endTime,
        price,
        bond
    };

    // Add to cart (however you're storing your cart - localStorage, array, etc.)
    // Example with array:
    // cart.push(rentalItem);
    cartItems.push(rentalItem);

    localStorage.setItem("newCart", JSON.stringify(cartItems));
    var tmp = localStorage.getItem("newCart");
    console.log(tmp);

    //storedCart.push(rentalItem);
    //localStorage.setItem("newCart", JSON.stringify(storedCart));
    console.log('Added to cart:', rentalItem);
    alert("Added")
    console.log("New cart itmes :", cartItems);
}

document.addEventListener('DOMContentLoaded', function () {
    const page = document.body.dataset.page;

    if (page === 'checkoutyo') {
        console.log("checkoutPage");
        console.log("1");
        loadCheckoutItems();
    }

    // Common code for all pages runs here too
});

function loadCheckoutItems() {
    let rows = '';
    const itemsToOrder = document.createElement('div');
    const div = document.createElement('div');

    let orderPrice = 0;
    let orderBond = 0;

    console.log("Loading checkout Cart");
    if (!Array.isArray(cartItems)) {
        cartItems = [cartItems];
    }
    if(cartItems.length >= 0){
        document.getElementById("checkoutItems").innerHTML = "";
        itemsToOrder.remove();
        let i = 1;
        cartItems.forEach(item => {
            console.log(item.name);
            price = item.price * item.quantity;
            orderPrice += price;
            rows += `<div class="twobox">
            <div id="checkoutItem ${item.productCode}" class="checkoutItem"><p>${i} :: ${item.name}  |Quantity  ${item.quantity}  |  ${price}  <br>  From Date :${item.startDate} -- ${item.endDate}</p>
            <br> Bond :: ${item.bond}</div>
            <div><button onclick="removeProduct('${i-1}')">X</button></div>
            </div>`
            itemsToOrder.append(div);
            i++;
            if (item.bond > orderBond) {
                orderBond = item.bond;
            }
            div.innerHTML = rows;
        })
        document.getElementById('checkoutItems').append(itemsToOrder);
    }
    document.getElementById("price").innerHTML = orderPrice;
    document.getElementById("priceGST").innerHTML = orderPrice * 0.1;
    document.getElementById("priceDiscount").innerHTML = orderPrice * 0;
    document.getElementById("priceBond").innerHTML = orderBond;
    document.getElementById("finalPrice").innerHTML = `$AUD ${Math.round((orderPrice * 1.1 + orderBond)*100)/100}`;
}
function removeProduct(itemNo) {
    let item = cartItems[itemNo]
    console.log("Removing product :", item);
    console.log("All items",cartItems);
    cartItems.splice(itemNo,1);
    console.log("After remove :", cartItems);
    localStorage.setItem("newCart", JSON.stringify(cartItems));
    loadCheckoutItems();
}
function clearStorage() {
    localStorage.clear();
    localStorage.setItem("newCart", "[]");
}

 