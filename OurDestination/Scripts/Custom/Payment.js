/// <reference path="../jquery-3.4.1.min.js" />

$(document).ready(function () {
    shoppingCart.init();
});

(function () {
    this.shoppingCart = this.shoppingCart || {};
    var ns = this.shoppingCart;

    ns.init = function () {
        var cart = new ns.Cart();
        cart.GetPayment();
        cart.LoadCart();
    };

    ns.Cart = (function () {
        function Cart() { };
        var cart = [];

        function Item()

        function saveCart() {
            localStorage.setItem("purchaseCart", JSON.stringify(cart));
        };
        function loadCart() {
            cart = JSON.parse(localStorage.getItem("purchaseCart"));
        };

        loadCart();

        function addItemToCart(id, name, price, count) {
            for (var i in cart) {
                if (cart[i].id === id) {
                    cart[i].count += count;
                    saveCart();
                    displayCart();
                    totalCartPrice();
                    return;
                }
            }

            var item = new Item(id, name, price, count);
            if (cart == null) {
                cart = [];
                cart.push(item);
            } else {
                cart.push(item);
            }
            saveCart();
            displayCart();
            totalCartPrice();
        };

        function removeItemFromCart(id) {
            for (var i in cart) {
                if (cart[i].id === parseInt(id)) {
                    cart[i].count--;
                    if (cart[i].count < 1) {
                        cart.splice(i, 1);
                    }
                    break;
                }
            }
            saveCart();
        };

        function removeItemFromCartAll(id) {
            for (var i in cart) {
                if (cart[i].id === parseInt(id)) {
                    cart.splice(i, 1);
                    break;
                }
            }
            saveCart();
        }

        function listCart() {
            var cartCopy = [];
            for (var i in cart) {
                var item = cart[i];
                var itemCopy = {};
                for (var i in item) {
                    itemCopy[p] = item[p]
                }
                cartCopy.push(itemCopy);
            }
            return cartCopy;
        }

        function clearCart() {
            cart = [];
            saveCart();
        };

        function totalCountCart() {
            var totalCount = 0;
            for (var i in cart) {
                totalCount += cart[i].count
            }
            return totalCount;
        };


    }());
})();