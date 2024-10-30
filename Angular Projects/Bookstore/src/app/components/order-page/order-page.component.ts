import { Component, OnInit } from '@angular/core';
import { CartModel } from '../../models/CartModel.model';
import {CartService} from "../../services/classes/CartService.service"
@Component({
  selector: 'app-order-page',
  templateUrl: './order-page.component.html',
  styleUrl: './order-page.component.scss'
})
export class OrderPageComponent  implements OnInit{
  orders:CartModel={Items:[],Total:0}
constructor(private cartService:CartService)
{
  this.orders=cartService.getOrder();
  console.log(this.cartService.getOrder())
}
ngOnInit(): void {
   let body=<HTMLDivElement> document.body;
   let script = document.createElement('script');
   script = document.createElement('script');
   script.innerHTML='';
   script.src = '../../../assets/js/script.js';
   script.async = true;
   script.defer = true;
   body.appendChild(script);

}
}
