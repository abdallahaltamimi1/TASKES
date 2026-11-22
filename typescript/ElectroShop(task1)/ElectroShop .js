"use strict";
let StoreName;
let StoreDescription;
let Currency;
let NumberOfAvailable;
let IsCurrentlyOpen = true;
let electronicProducts = ["laptops", "mobile phones", "headphones", "keyboards", "computer accessories"];
let Products = [
    "Laptop", 1500, true,
    "mobile phones", 200, false,
    "headphones", 300, false,
    "keyboards", 20, false,
    "computer accessories", 800, false
];
if (IsCurrentlyOpen) {
    console.log("wellcom");
}
else {
    console.log("sorry the store is closed");
}
for (let index = 1; index < Products.length; index += 3) {
    let price = Products[index];
    if (typeof price === "number") {
        if (price >= 500) {
            console.log("Expensive Product");
        }
        else if (price >= 100) {
            console.log("Medium Price");
        }
        else {
            console.log("Affordable Product");
        }
    }
}
electronicProducts.forEach(element => {
    console.log(element);
});
let count = 0;
for (let index = 1; index < Products.length; index += 3) {
    let price = Products[index];
    if (typeof price === "number" && price > 100) {
        count++;
    }
}
console.log(count); // 4
console.log(count);
function calculateDiscount(price, discount) {
    let finalPrice = price - (price * discount / 100);
    return finalPrice;
}
console.log(calculateDiscount(650, 20)); // 520
function checkProductAvailability(quantity) {
    if (quantity > 0) {
        return "In Stock";
    }
    else {
        return "Out of Stock";
    }
}
console.log(checkProductAvailability(5));
console.log(checkProductAvailability(0));
function displayStoreMessage(message) {
    console.log(message);
}
displayStoreMessage("Welcome to Electronic Store!");
function displayProductInfo(name, price, description, currency = "JOD") {
    console.log("Name:", name);
    console.log("Price:", price, currency);
}
function calculateTotalPrice(...prices) {
    let total = 0;
    prices.forEach(price => {
        total += price;
    });
    return total;
}
console.log(calculateTotalPrice(650, 75, 45)); // 770
let electronicProduct = [
    {
        name: "Laptop",
        description: "Core i5, 8GB RAM",
        price: 650
    },
    {
        name: "Headphones",
        description: "Wireless Bluetooth headphones",
        price: 75
    },
    {
        name: "Keyboard",
        description: "Mechanical gaming keyboard",
        price: 45
    }
];
let button = document.getElementById("loadProducts");
let container = document.getElementById("productsContainer");
button?.addEventListener("click", function () {
    if (container) {
        container.innerHTML = "";
        electronicProduct.forEach(product => {
            container.innerHTML += `
                <h2>${product.name}</h2>
                <p>${product.description}</p>
                <p>Price: ${product.price}</p>
                <hr>
            `;
        });
    }
});
