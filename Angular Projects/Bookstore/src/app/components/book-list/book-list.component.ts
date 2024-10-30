
import { Component, OnInit  } from '@angular/core';
import {  ItemService} from '../../services/classes/item.service';
import {  ItemModel} from '../../models/ItemModel.model';

@Component({
  selector: 'app-book-list',
  templateUrl: './book-list.component.html',
})
export class BookListComponent implements OnInit {
  books:Array<ItemModel>=[];
  constructor(private itemService:ItemService){}
  ngOnInit(): void {


     this.itemService.GetAllItems().subscribe((data)=>
      {
        this.books=data;

      let body=<HTMLDivElement> document.body;
      let script = document.createElement('script');
      script = document.createElement('script');
      script.innerHTML='';
      script.src = '../../../assets/js/script.js';
      script.async = true;
      script.defer = true;
      body.appendChild(script);
      });

  }
}
