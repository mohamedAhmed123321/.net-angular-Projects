import { Injectable } from '@angular/core';
import { CartItemModel } from "../../models/CartItemModel.model";
import { ItemModel } from "../../models/ItemModel.model";
import { CartModel } from '../../models/CartModel.model';
import Swal from 'sweetalert2';
@Injectable({
  providedIn: 'root'
})
export class CartService {
  private cartKey = 'cart';
  private orderKey = 'order';
  private cart: CartModel = {Items:[],Total:0};
  private order: CartModel = {Items:[],Total:0};

  constructor() {
    this.loadCart();
    this.loadOrder();
  }

  // Load cart from LocalStorage
  private loadCart(): void {
    const storedCart = localStorage.getItem(this.cartKey);
    this.cart = storedCart ? JSON.parse(storedCart) : { Items: [], Total: 0 };
  }
  private loadOrder(): void {
    const storedOrder = localStorage.getItem(this.orderKey);
    this.order = storedOrder ? JSON.parse(storedOrder) : { Items: [], Total: 0 };
  }
  // Save cart to LocalStorage
  saveCart(): void {
    localStorage.setItem(this.cartKey, JSON.stringify(this.cart));
  }

  saveOrder(): void {
    localStorage.setItem(this.orderKey, JSON.stringify(this.order));
  }

  // Add or update item in the cart
  addToCart(item: ItemModel):void {
    if (!this.cart) {
      this.cart = { Items: [], Total: 0 };
    }

    const existingItem = this.cart.Items.find(i => i.ItemId === item.ItemId);

    if (existingItem) {
      // Update the quantity and total if the item exists
      existingItem.Qty++;
      existingItem.Total = existingItem.Qty * existingItem.SalesPrice;
    } else {
      // Add new item to the cart
      const newCartItem: CartItemModel = {
        ItemId: item.ItemId,
        ImageName: item.ImageName,
        Qty: 1,
        ItemName: item.ItemName,
        SalesPrice: item.SalesPrice,
        Total: item.SalesPrice
      };
      this.cart.Items.push(newCartItem);

    }

    // Recalculate the cart total
    this.recalculateCartTotal();
    this.saveCart();
  }
  addToOrder(item: ItemModel):void {
    if (!this.order) {
      this.order = { Items: [], Total: 0 };
    }

    const existingItem = this.order.Items.find(i => i.ItemId === item.ItemId);

    if (existingItem) {
      // Update the quantity and total if the item exists
      existingItem.Qty++;
      existingItem.Total = existingItem.Qty * existingItem.SalesPrice;
    } else {
      // Add new item to the cart
      const newCartItem: CartItemModel = {
        ItemId: item.ItemId,
        ImageName: item.ImageName,
        Qty: 1,
        ItemName: item.ItemName,
        SalesPrice: item.SalesPrice,
        Total: item.SalesPrice
      };
      this.order.Items.push(newCartItem);

    }

    // Recalculate the cart total
    this.recalculateOrderTotal();
    this.saveOrder();
  }
  // Remove an item from the cart by its ID
  removeFromCart(itemId: number): void {
    if (!this.cart) return;
    Swal.fire({
      title: 'Are you sure?',
      text: "delete",
      icon: 'warning',
      showCancelButton: true,
      confirmButtonColor: '#3085d6',
      cancelButtonColor: '#d33',
      confirmButtonText: 'Yes'
    }).then((result) => {
      if (result.isConfirmed) {
        if(this.cart){
          this.cart.Items = this.cart.Items.filter(item => item.ItemId !== itemId);

          // Recalculate the cart total
          this.recalculateCartTotal();
          this.saveCart();
          Swal.fire(
            'success!',
            'Deleted Successfully!',
            'success'
        );
        }
      }
    });
    // Remove the item

  }

  // Recalculate the total price of the cart
   recalculateCartTotal(): void {
    if (this.cart) {
      this.cart.Total = this.cart.Items.reduce((acc, item) => acc + item.Total, 0);
    }
  }
  recalculateOrderTotal(): void {
    if (this.cart) {
      this.order.Total = this.order.Items.reduce((acc, item) => acc + item.Total, 0);
    }
  }
  // Get all items in the cart
  getCart(): CartModel  {
    return this.cart;
  }
  getOrder(): CartModel  {
    return this.order;
  }
  // Clear the cart
  clearCart(): void {
    this.cart = { Items: [], Total: 0 };
    this.saveCart();
  }

  clearOrder(): void {
    this.order = { Items: [], Total: 0 };
    this.saveOrder();
  }
}
