window.onload = function () {
    let addToCart = document.getElementsByClassName("add-btn");

    for (let i = 0; i < addToCart.length; i++) {
        addToCart[i].addEventListener("click", onCart);
    }
}

//call cart event
function onCart(event) {
    let elem = event.currentTarget;
    let productId = elem.getAttribute("product_id");

    let quantity = elem.parentElement.parentElement.parentElement.parentElement.parentElement.parentElement.querySelector(".quantity").getAttribute("product_quantity");

    
    

    if (elem.getAttribute("name") == "cart_button") {
        let action = "/Gallery/Click";
        let total = parseInt(quantity)+1;
        elem.parentElement.parentElement.parentElement.parentElement.parentElement.parentElement.querySelector(".quantity").setAttribute("product_quantity", total);
        elem.parentElement.parentElement.parentElement.parentElement.parentElement.parentElement.querySelector(".quantity").setAttribute("value", total);
        updateCart(action, productId);
    }

}

function updateCart(action, productId) {
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