import * as base from "./base.js";

function DataException(message){
    this.message = message;
}

function getStringData(id){
    return document.getElementById(id).value;
}

function validateRequiredString(value, message){
    if (value.length == 0){
        throw new DataException(message);
    }
    return value;
}

export async function sendOrder(e){
    e.preventDefault();
    let productIds = Array.from(base.getProductsFromCart()).map(p => +p.id);
    
    try{
        validateRequiredString(productIds, "cart is empty");

        let body = {
            name: validateRequiredString(getStringData("Name"), "Name field is required"),
            line1: getStringData("Line1"),
            line2: getStringData("Line1"),
            line3: getStringData("Line3"),
            city: validateRequiredString(getStringData("City"), "City field is required"),
            state: getStringData("State"),
            zip: validateRequiredString(getStringData("Zip"), "Zip field is required"),
            country: validateRequiredString(getStringData("Country"), "Country field is required"),
            giftWrap: getStringData("GiftWrap") == "true",
            orderIds: productIds
        }

        let response = await fetch("/order",{
            method: 'POST',
            headers: {
                'Content-Type': 'application/json;charset=utf-8'
            },
            body: JSON.stringify(body)
        });

        alert(await response.text());
    }
    catch (e){
        if (e instanceof DataException){
            alert(e.message);
        }
        else{
            alert("Unexpected error");
        }
    }
}

document.getElementById("form").onsubmit = sendOrder;