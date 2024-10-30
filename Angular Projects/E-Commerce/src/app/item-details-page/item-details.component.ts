import {AfterViewInit, Component, OnInit  } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import {ItemService} from "../../services/classes/item.service"
import {ItemModel} from "../../models/ItemModel.model";
import {CartService} from "../../services/classes/CartService.service"
import Swal from 'sweetalert2';
declare var $: any;
@Component({
  selector: 'app-item-details',
  templateUrl: './item-details.component.html',

})
export class ItemDetailsComponent implements AfterViewInit {
  itemId: number=0;
  item:ItemModel|null=null;
  relatedProdect:ItemModel[]=[];
  constructor(private route:ActivatedRoute,private itemService:ItemService,private cartService:CartService){}
  ngAfterViewInit(): void
   {


   this.route.params.subscribe(params => {
      this.itemId = parseInt(params['id']);
      this.itemService.GetAllPopularItems().subscribe((data)=>{
        data.length=6;
        this.relatedProdect=data;
      });
      this.itemService.GetById(this.itemId).subscribe((data)=>
      {
        this.item=data;

        let body=<HTMLDivElement> document.body


        let script = document.createElement('script');
        script.innerHTML='';
        script.src = '../../assets/js/slick.js';
        script.async = true;
        script.defer = true;
        body.appendChild(script);

        script = document.createElement('script');
        script.innerHTML='';
        script.src = '../../assets/js/footer-reveal.min.js';
        script.async = true;
        script.defer = true;
        body.appendChild(script);

        script = document.createElement('script');
        script.innerHTML='';
        script.src = '../../assets/js/script.js';
        script.async = true;
        script.defer = true;
        body.appendChild(script);

      });
    });
}
AddToCart()
{
  if(this.item)
  {
    this.cartService.addToCart(this.item);
    Swal.fire({
      title: 'Success!',
      text: 'Item added to the cart successfully.',
      icon: 'success',
      confirmButtonText: 'OK'
    });
  }
}

}
