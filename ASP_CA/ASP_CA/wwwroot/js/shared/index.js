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
    let quantity = parseInt(product_quantity);
    let product_price = elem.parentElement.parentElement.querySelector(".quantitytotal").getAttribute("product_total");
    let totalprice = parseInt(product_price);
    let unitprice = totalprice / quantity;

    let totalproductprice = elem.parentElement.parentElement.parentElement.parentElement.querySelector(".quantitytotalprice").getAttribute("product_totalprice");

    if (elem.getAttribute("name") === "plus_button") {
        let action = "/Cart/PlusOne";
        let total = quantity + 1;
        let price = unitprice * total;
        elem.parentElement.querySelector(".quantitylisted").setAttribute("value", total);
        elem.parentElement.querySelector(".quantitylisted").setAttribute("product_quantity", total);

        elem.parentElement.parentElement.querySelector(".quantitytotal").setAttribute("product_total", price);
        elem.parentElement.parentElement.querySelector(".quantitytotal").setAttribute("value", price);

        let grandtotal = parseInt(totalproductprice) + unitprice; 

        elem.parentElement.parentElement.parentElement.parentElement.querySelector(".quantitytotalprice").setAttribute("product_totalprice", grandtotal);
        elem.parentElement.parentElement.parentElement.parentElement.querySelector(".quantitytotalprice").setAttribute("value",grandtotal);

        sendAction(action, productId);
    }
    else if (elem.getAttribute("name") === "minus_button") {
        let action = "/Cart/MinusOne";
        let total = parseInt(product_quantity) - 1;
        let price = unitprice * total;


        let grandtotal = parseInt(totalproductprice) - unitprice;



        if (total < 1)
            alert('Select remove if you want to delete the item');
        else {
            elem.parentElement.querySelector(".quantitylisted").setAttribute("value", total);
            elem.parentElement.querySelector(".quantitylisted").setAttribute("product_quantity", total);
            elem.parentElement.parentElement.querySelector(".quantitytotal").setAttribute("product_total", price);
            elem.parentElement.parentElement.querySelector(".quantitytotal").setAttribute("value", price);
            elem.parentElement.parentElement.parentElement.parentElement.querySelector(".quantitytotalprice").setAttribute("product_totalprice", grandtotal);
            elem.parentElement.parentElement.parentElement.parentElement.querySelector(".quantitytotalprice").setAttribute("value", grandtotal);
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
