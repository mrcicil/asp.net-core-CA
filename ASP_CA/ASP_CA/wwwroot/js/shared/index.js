window.onload = function () {
    let button = document.getElementsByClassName("quantity-btn");

    for (let i = 0; i < button.length; i++) {
        button[i].addEventListener("click", onButton);
    }
}

function onButton(event) {
    let elem = event.currentTarget;
    let productId = elem.getAttribute("product_id");
    let product_quantity = elem.parentElement.parentElement.querySelector(".quantitylisted").getAttribute("product_quantity");
    let quantity = elem.parentElement.querySelector(".quantitylisted").getAttribute("value");

    if (elem.getAttribute("name") === "plus_button") {
        let action = "/Cart/PlusOne";
        let total = parseInt(product_quantity) + 1;
        elem.parentElement.querySelector(".quantitylisted").setAttribute("value", total);
        elem.parentElement.querySelector(".quantitylisted").setAttribute("product_quantity",total);
        sendAction(action, productId);
    }
    else if (elem.getAttribute("name") === "minus_button") {
        let action = "/Cart/MinusOne";
        let total = parseInt(product_quantity) - 1;

        if (total < 1)
            alert('Select remove if you want to delete the item');
        else {
            elem.parentElement.querySelector(".quantitylisted").setAttribute("value", total);
            elem.parentElement.querySelector(".quantitylisted").setAttribute("product_quantity", total);
            sendAction(action, productId);
        }
        
    }

}

function sendAction(action, productId) {
    let xhr = new XMLHttpRequest();

    xhr.open("POST", action);
    xhr.setRequestHeader("Content-Type", "application/json; charset=utf8");
    xhr.onreadystatechange = function () {
        if (this.readyState === XMLHttpRequest.DONE) {
            // receive response from server
            if (this.status === 200 || this.status === 302) {
                let data = JSON.parse(this.responseText);

                if (this.status === 200) {
                    console.log("Successful operation: " + data.success);
                }
                else if (this.status === 302) {
                    window.location = data.redirect_url;
                }
            }
        }
    };

    xhr.send(JSON.stringify({
        "productId": productId
    }));

}
