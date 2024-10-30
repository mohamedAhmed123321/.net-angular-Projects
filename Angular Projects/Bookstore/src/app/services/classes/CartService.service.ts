import { Injectable } from '@angular/core';
import { CartItemModel } from "../../models/CartItemModel.model";
import { ItemModel } from "../../models/ItemModel.model";
import { CartModel } from '../../models/CartModel.model';
import Swal from 'sweetalert2';
@Injectable({
  providedIn: 'root'
})
export class CartService {
  private bookKey = 'bookCart';
  private orderKey = 'bookOrder';
  private book: CartModel = {Items:[],Total:0};
  private order: CartModel = {Items:[],Total:0};

  constructor() {
    this.loadCart();
    this.loadOrder();
  }

  // Load book from LocalStorage
  private loadCart(): void {
    const storedCart = localStorage.getItem(this.bookKey);
    this.book = storedCart ? JSON.parse(storedCart) : { Items: [], Total: 0 };
  }
  private loadOrder(): void {
    const storedOrder = localStorage.getItem(this.orderKey);
    this.order = storedOrder ? JSON.parse(storedOrder) : { Items: [], Total: 0 };
  }
  // Save book to LocalStorage
  saveCart(): void {
    localStorage.setItem(this.bookKey, JSON.stringify(this.book));
  }

  saveOrder(): void {
    localStorage.setItem(this.orderKey, JSON.stringify(this.order));
  }

  // Add or update item in the book
  addToCart(item: ItemModel):void {
    if (!this.book) {
      this.book = { Items: [], Total: 0 };
    }

    const existingItem = this.book.Items.find(i => i.ItemId === item.ItemId);

    if (existingItem) {
      // Update the quantity and total if the item exists
      existingItem.Qty++;
      existingItem.Total = existingItem.Qty * existingItem.SalesPrice;
    } else {
      // Add new item to the book
      const newCartItem: CartItemModel = {
        ItemId: item.ItemId,
        ImageName: item.ImageName,
        Qty: 1,
        ItemName: item.ItemName,
        SalesPrice: item.SalesPrice,
        Total: item.SalesPrice
      };
      this.book.Items.push(newCartItem);

    }

    // Recalculate the book total
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
      // Add new item to the book
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

    // Recalculate the book total
    this.recalculateOrderTotal();
    this.saveOrder();
  }
  // Remove an item from the book by its ID
  removeFromCart(itemId: number): void {
    if (!this.book) return;
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
        if(this.book){
          this.book.Items = this.book.Items.filter(item => item.ItemId !== itemId);

          // Recalculate the book total
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

  // Recalculate the total price of the book
   recalculateCartTotal(): void {
    if (this.book) {
      this.book.Total = this.book.Items.reduce((acc, item) => acc + item.Total, 0);
    }
  }
  recalculateOrderTotal(): void {
    if (this.book) {
      this.order.Total = this.order.Items.reduce((acc, item) => acc + item.Total, 0);
    }
  }
  // Get all items in the book
  getCart(): CartModel  {
    return this.book;
  }
  getOrder(): CartModel  {
    return this.order;
  }
  // Clear the book
  clearCart(): void {
    this.book = { Items: [], Total: 0 };
    this.saveCart();
  }

  clearOrder(): void {
    this.order = { Items: [], Total: 0 };
    this.saveOrder();
  }
}
