import * as base from "./base.js";

function addToCart(product){
    let existingProduct = JSON.parse(localStorage.getItem(base.createProductKey(product.id)));
    if (existingProduct)
    {
        existingProduct.quantity++;
    }
    else{
        existingProduct = { ...product };
        existingProduct.quantity = 1;
    }

    localStorage.setItem(base.createProductKey(product.id), JSON.stringify(existingProduct));

    base.setCartQuantity();
}

let responseData = await base.tryGetData("/products" + window.location.search);

let container = document.getElementById("products");
for (let product of responseData){
    let element = document.createElement("container-item");
    element.className = "product-item"

    element.appendChild(base.createTextElement("h2", product.name));
    element.appendChild(base.createTextElement("h3", product.description));
    element.appendChild(base.createTextElement("label", base.decimalFormat(product.price) + " Р", "price-label"));

    let addToCartButton = base.createTextElement("label", "Add to cart", "add-to-cart-label");
    addToCartButton.onclick = () => addToCart(product);

    element.appendChild(addToCartButton);

    container.appendChild(element);
}