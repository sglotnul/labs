export async function tryGetData(url){
    let response = await fetch(url);

    if (response.ok) {
        return await response.json();
    }

    return [];
}

export function createTextElement(tag, text, className){
    let element = document.createElement(tag);
    element.innerHTML = text;
    element.className = className;

    return element;
}

export async function setCategories(){
    let responseData = await tryGetData("/all-categories");

    let container = document.getElementById("categories");
    for (let category of responseData){
        let element = createTextElement("container-item", category['name'], "category-item");
        
        let link = document.createElement("a");
        link.href = `/?categoryId=${category["id"]}`;

        link.appendChild(element);

        container.appendChild(link);
    }
}

export function setCartQuantity(){
    let count = 0;
    let totalPrice = 0;

    for (let i = 0; i < localStorage.length; i++){
        let key = localStorage.key(i);
        if (!key.startsWith(productKey))
            continue;

        let item = JSON.parse(localStorage.getItem(key));
        totalPrice += item.price * item.quantity;
        count += item.quantity;
    }

    let cartBar = document.querySelector("cart-bar");
    let span = createTextElement("span", `Your cart: ${count} items, ${(Math.round(totalPrice * 100) / 100).toFixed(2)} P`, "cart-bar-label");

    cartBar.innerHTML = "";
    cartBar.appendChild(span);
    cartBar.appendChild(createTextElement("button", "Checkout"));
}

setCartQuantity();
await setCategories();