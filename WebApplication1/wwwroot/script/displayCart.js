import * as base from "./base.js";

function setTotalPriceCell(){
    let totalPrice = 0;
    for (let item of base.getProductsFromCart()){
        totalPrice += item.price * item.quantity;
    }

    let cell = document.querySelector(".totalPriceCell");
    cell.innerHTML = `${base.decimalFormat(totalPrice)} P`;
}

function removeFromCart(id){
    localStorage.removeItem(base.createProductKey(id));
}

let element = document.getElementById("cart");

for (let item of base.getProductsFromCart()){
    let itemPrice = item.price * item.quantity;
    
    let row = document.createElement("tr");
    
    row.appendChild(base.createTextElement("td", item.quantity));
    row.appendChild(base.createTextElement("td", item.name));
    row.appendChild(base.createTextElement("td", base.decimalFormat(item.price) + " P"));
    row.appendChild(base.createTextElement("td", base.decimalFormat(itemPrice) + " P"));
    
    let removeButton = base.createTextElement("button", "Remove");
    removeButton.onclick = () => {
        removeFromCart(item.id);
        
        element.removeChild(row);

        setTotalPriceCell();
        base.setCartQuantity();
    };
    
    let buttonCell = base.createTextElement("td");
    buttonCell.appendChild(removeButton);
    
    row.appendChild(buttonCell);
    
    element.appendChild(row);
}

let row = document.createElement("tr");

row.appendChild(base.createTextElement("td", "Total:"));
row.appendChild(base.createTextElement("td", null));
row.appendChild(base.createTextElement("td", null));
row.appendChild(base.createTextElement("td", null, "totalPriceCell"));

element.appendChild(row);

setTotalPriceCell();