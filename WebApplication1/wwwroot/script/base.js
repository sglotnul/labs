export const PRODUCT_KEY = "product";

export async function tryGetData(url){
    let response = await fetch(url);

    if (response.ok) {
        return await response.json();
    }

    return [];
}

export function createTextElement(tag, text, className){
    let element = document.createElement(tag);

    if (text)
        element.innerHTML = text;
    
    if (className)
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

export function decimalFormat(decimal){
    return (Math.round(decimal * 100) / 100).toFixed(2);
}

export function createProductKey(id){
    return `${PRODUCT_KEY}-${id}`;
}

export function* getProductsFromCart(){
    for (let i = 0; i < localStorage.length; i++){
        let key = localStorage.key(i);
        if (!key.startsWith(PRODUCT_KEY))
            continue;

        yield JSON.parse(localStorage.getItem(key));
    }
}

export function setCartQuantity(){
    let count = 0;
    let totalPrice = 0;

    for (let item of getProductsFromCart()){
        totalPrice += item.price * item.quantity;
        count += item.quantity;
    }
    
    let span = document.getElementById("cart-info");
    span.innerHTML = `Your cart: ${count} items, ${decimalFormat(totalPrice)} P`;
}

setCartQuantity();
await setCategories();