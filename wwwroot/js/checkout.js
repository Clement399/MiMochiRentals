//Handles the redirection of the form. Sends the data directly to stripe so that we dont have to maintain the code within the 310 PCI
//Compatible regulations

console.error("STRIPING...");
let currentPaymentIntentId = null;
// This is your test publishable API key.
//old-
const stripe = Stripe("pk_test_51ShRUD1kr1CXwBO9d584BG7bfIy7RAYq7hA7oWs7Ddcgh7VrSEQOmaNYkPyauimf0jx8AOaa06ApcnnimgHbhI9M00BRgdtbay");
//const stripe = Stripe("pk_test_51ShRUR1SjyxQIlE1LaRLqdW5UPQviaHqBVTojhCjiMgfSIjDGkvbt95SU45mgFmIiXwgwhyQOrm5uo7GiMypWbBk000IIoLMPq");

// The items the customer wants to buy
const items = [{ id: "depo-test", amount: 99999 }];

document.addEventListener('DOMContentLoaded', function () {
    console.log("DOM loaded, initializing...");
    initialize();

    const form = document.querySelector("#payment-form");
    if (form) {
        form.addEventListener("submit", handleSubmit);
        console.log("Form listener attached");
    } else {
        console.error("Payment form not found!");
    }
});

let elements;


// Fetches a payment intent and captures the client secret
async function initialize() {
    const response = await fetch("/create-payment-intent", {
        method: "POST",
        headers: { "Content-Type": "application/json" },
        body: JSON.stringify({ items }),
    });
    const { clientSecret } = await response.json();
    currentPaymentIntentId = clientSecret.split('_secret_')[0];
    console.error("Client secret :", clientSecret);
    console.error("Payment Intent : ", currentPaymentIntentId);

    const appearance = {
        theme: 'stripe',
        //ERROR ::  button: 'background-color : Blue'
        variables: {
            colorPrimary: '#0000FF', // This sets your blue theme correctly
            colorBackground: '#ffffff',
            colorText: '#30313d',
            borderRadius: '4px',
        }
    };
    elements = stripe.elements({ appearance, clientSecret });

    const options = { mode: 'billing' };
    const paymentElementOptions = {
        layout: "accordion",
    };

    const linkAuthenticationElement = elements.create("linkAuthentication");
    
    const paymentElement = elements.create("payment", paymentElementOptions);
    const addressElement = elements.create('address', options);
    addressElement.mount('#address-element');
    paymentElement.mount("#payment-element");
    linkAuthenticationElement.mount("#link-authentication-element");

}


console.log("Stripe succeded")

async function handleSubmit(e) {
    e.preventDefault();
    console.log("PAY BUTTON CLICKED!");
    setLoading(true);

    console.log("Calling process rental");
    const internalOrder = await processRental();
    console.log("internal order id from processRental :", internalOrder);

    //get the intent id and and order id posted in my paymentintent from api
    console.log("Updating payment intent metadata... ");
    var toPost = JSON.stringify({
        PaymentIntentId: currentPaymentIntentId,
        OrderId: internalOrder
    })
    console.log(toPost);
    await fetch("/updateIntent/metadata", {
        method: "POST",
        headers: { "Content-Type": "application/json" },
        body: JSON.stringify({
            PaymentIntentId: currentPaymentIntentId,
            OrderId: internalOrder
        })
    });

    const { error, paymentIntent } = await stripe.confirmPayment({
        elements,
        // Add this to stay on the page and see the result
        //redirect: 'if_required',
        confirmParams: {
            return_url: window.location.origin + "/home",
        },
    });

    // This point will only be reached if there is an immediate error when
    // confirming the payment. Otherwise, your customer will be redirected to
    // your `return_url`. For some payment methods like iDEAL, your customer will
    // be redirected to an intermediate site first to authorize the payment, then
    // redirected to the `return_url`.
    if (error.type === "card_error" || error.type === "validation_error") {
        showMessage(error.message);
    } else {
        showMessage("An unexpected error occurred.");
    }

    setLoading(false);
}

// ------- UI helpers -------

function showMessage(messageText) {
    const messageContainer = document.querySelector("#payment-message");

    messageContainer.classList.remove("hidden");
    messageContainer.textContent = messageText;

    setTimeout(function () {
        messageContainer.classList.add("hidden");
        messageContainer.textContent = "";
    }, 4000);
}

// Show a spinner on payment submission
function setLoading(isLoading) {
    if (isLoading) {
        // Disable the button and show a spinner
        document.querySelector("#submit").disabled = true;
        document.querySelector("#spinner").classList.remove("hidden");
        document.querySelector("#button-text").classList.add("hidden");
    } else {
        document.querySelector("#submit").disabled = false;
        document.querySelector("#spinner").classList.add("hidden");
        document.querySelector("#button-text").classList.remove("hidden");
    }
}
