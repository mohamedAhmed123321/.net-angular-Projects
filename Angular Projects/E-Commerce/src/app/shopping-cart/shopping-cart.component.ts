import { Component  } from '@angular/core';

import { CartService } from '../../services/classes/CartService.service';
import { CartModel } from '../../models/CartModel.model';
@Component({
  selector: 'app-shopping-cart',
  templateUrl: './shopping-cart.component.html',
  styleUrl: './shopping-cart.component.css'
})
export class ShoppingCartComponent {

  cart:CartModel={Items:[],Total:0};
  constructor(private cartService:CartService){
  this.cart=this.cartService.getCart();
}
ngOnInit(): void {


    let body=<HTMLDivElement> document.body;
    let script = document.createElement('script');
    script = document.createElement('script');
    script.innerHTML='';
    script.src = '../../assets/js/script.js';
    script.async = true;
    script.defer = true;
    body.appendChild(script);

}
RemoveItem(id:number){
  this.cartService.removeFromCart(id);
}

ChangeQty(id:number)
{
  const item = this.cart?.Items.find(i => i.ItemId === id);
  if (item) {
    // Update the total for the item
    item.Total = item.SalesPrice * item.Qty;

    // Recalculate the cart's total price
    this.cartService.recalculateCartTotal();

    this.cartService.saveCart();
    this.cart = this.cartService.getCart();
  }

}
}
