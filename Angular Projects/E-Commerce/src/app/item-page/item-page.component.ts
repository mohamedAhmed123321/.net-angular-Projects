import { Component, OnInit  } from '@angular/core';
import {  ItemService} from '../../services/classes/item.service';
import {  ItemModel} from '../../models/ItemModel.model';

declare var $: any;
@Component({
  selector: 'app-item-page',
  templateUrl: './item-page.component.html',
})
export class ItemPageComponent implements OnInit {
  items:Array<ItemModel>=[];
  constructor(private itemService:ItemService){}
  ngOnInit(): void {


     this.itemService.GetAllItems().subscribe((data)=>
      {
        this.items=data;

      let body=<HTMLDivElement> document.body;
      let script = document.createElement('script');
      script = document.createElement('script');
      script.innerHTML='';
      script.src = '../../assets/js/script.js';
      script.async = true;
      script.defer = true;
      body.appendChild(script);
      });

  }
}
