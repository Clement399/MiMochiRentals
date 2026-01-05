
console.log("Hello im the forms.js javascript file for forms")
var allForms = document.querySelectorAll("form");
allForms.forEach(f => {
    f.addEventListener('submit', (e) => submitRental(e))
});
console.log("Hello im the forms.js javascript file for forms")
async function submitRental(e) {
    //prevents page reloading
    e.preventDefault();

    const formID = e.target.id;
    console.log("Form submitted : ", formID);

    const formData = new FormData(e.target);
    const data = Object.fromEntries(formData.entries());
    let tempItem = itemTypesMap[data.itemTypeCode];
    console.error("Temp item : ", tempItem);
    let itemTypeCode = data.itemTypeCode;
    let price = tempItem.price;
    let bond = tempItem.bond;
    let name = tempItem.name;
    console.log('Form Data : ', data);
    const terms = document.getElementById('myCheckBox');
    console.error("Checked? : ", terms.checked);
    console.log(document.getElementById(myCheckBox));
    if (!terms.checked) {
        alert('Ensure terms and conditions are accepted');
        //Document.getElementById('termsErrorBox').classlist.remove('hidden');
        return;
    }
    const rentalItem = {
        itemTypeCode,
        quantity: parseInt(data.quantity),
        startDate: data.startDate,
        startTime: data.startTime,
        endDate: data.endDate,
        endTime: data.endTime,
        price,
        bond,
        name
    };
    console.log("Product : ", rentalItem);
    await processRental(rentalItem);
}

async function processRental(rentalItem){
    var validity = await checkValid(rentalItem);
    console.log("Going to check item");
    console.log("Validity of item :", validity);
    if (validity) {
        pushToCart(rentalItem)
    }
    else {
        alert("Item not added");
    }
}