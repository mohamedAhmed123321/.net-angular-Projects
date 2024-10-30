import { Component, OnInit  } from '@angular/core';
import {CartService} from "../../services/classes/CartService.service"
import {ItemService} from "../../services/classes/item.service"
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import {FormBuilderService} from "../../services/helpers/FormBuilderService "
import { CartModel } from '../../models/CartModel.model';
import Swal from 'sweetalert2';
import { Router } from '@angular/router';
@Component({
  selector: 'app-billing-info',
  templateUrl: './billing-info.component.html',
  styleUrl: './billing-info.component.css'
})
export class BillingInfoComponent implements OnInit {
  billingForm: FormGroup;
  cart:CartModel={Items:[],Total:0};
  constructor( private builderService: FormBuilderService,private cartService:CartService,private itemService:ItemService,private router:Router) {
    // Initialize the form group
    this.billingForm = builderService.buildBillingForm();
  }

  ngOnInit(): void {

     this.cart= this.cartService.getCart();
      let body=<HTMLDivElement> document.body;
      let script = document.createElement('script');
      script = document.createElement('script');
      script.innerHTML='';
      script.src = '../../assets/js/script.js';
      script.async = true;
      script.defer = true;
      body.appendChild(script);


       script = document.createElement('script');
      script = document.createElement('script');
      script.innerHTML='';
      script.src = 'https://www.paypal.com/sdk/js?client-id=AXugXqnY8yA2tTGSJUpL_7cbmdsaWefzGpkWXoAKBfwvWaea3tJgQFunRycPDCYj1v054K1cAf3SPLOY&currency=USD';
      script.onload = () => this.renderPayPalButton();
      script.async = true;
      script.defer = true;
      body.appendChild(script);

  }
  onSubmit()
  {
    if (this.billingForm.valid) {
      console.log(this.billingForm.value);
    }
  }
  renderPayPalButton() {
    (window as any).paypal.Buttons({
      createOrder: (data: any, actions: any) => {
        return actions.order.create({
          purchase_units: [{
            amount: {
              value: this.cart.Total.toString()
            }
          }]
        });
      },
      onApprove: (data: any, actions: any) => {
        return actions.order.capture().then((details: any) => {
         for(let i=0;i<this.cart.Items.length;i++)
          {
            this.itemService.GetById(this.cart.Items[i].ItemId).subscribe((item)=>
              {
                this.cartService.addToOrder(item);
              })

          }
          console.log(this.cartService.getOrder())
          this.cartService.clearCart();
          Swal.fire({
            title: 'Payment Successful',
            text: `Transaction completed by ${details.payer.name.given_name}`,
            icon: 'success',
            confirmButtonText: 'OK',
            allowOutsideClick:false,
          }).then((result) => {
            if (result.isConfirmed) {
              this.router.navigate(['/myOrders']);
            }
          })
        });
      },
      onError: (err: any) => {
        console.error(err);
        Swal.fire({
          title: 'Payment Error',
          text: 'There was an issue with your payment. Please try again.',
          icon: 'error',
          confirmButtonText: 'OK'
        });
      }
    }).render('#paypal-button-container'); // Display the PayPal button
  }
}
