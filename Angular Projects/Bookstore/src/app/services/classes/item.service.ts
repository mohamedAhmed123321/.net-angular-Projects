import { Injectable } from '@angular/core';
import {ItemInterface} from "../interfaces/itemInterface"
import { ItemModel } from '../../models/ItemModel.model';
import { Observable ,of} from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class ItemService implements ItemInterface {

  constructor() { }
  GetAllItems():Observable< Array<ItemModel>> {
    const items = localStorage.getItem('book');
    let popularItems: Array<ItemModel> =[]
    if (items) {

         popularItems = JSON.parse(items);
        return of(popularItems);
    }
  return of(popularItems);
  }
  GetAllPopularItems(): Observable<Array<ItemModel>>
   {
      // Check for data in local storage
      const items = localStorage.getItem('book');
      let popularItems: Array<ItemModel> =[]
      if (items) {

          popularItems = JSON.parse(items);
          popularItems=popularItems.slice(0,10)
          return of(popularItems);
      }
    return of(popularItems);
  }

  GetAllNewItems(): Observable< Array<ItemModel>>  {
      // Check for data in local storage
      const items = localStorage.getItem('book');
      let popularItems: Array<ItemModel> =[]
      if (items) {

          popularItems = JSON.parse(items);
          popularItems=popularItems.slice(12,16)
          return of(popularItems);
      }
    return of(popularItems);
  }
  GetAllSlider(): Observable< Array<ItemModel>>  {
       // Check for data in local storage
       const items = localStorage.getItem('book');
       let popularItems: Array<ItemModel> =[]
       if (items) {

           popularItems = JSON.parse(items);
           popularItems=popularItems.slice(6,10)
           return of(popularItems);
       }
     return of(popularItems);
  }
  GetById(id: number): Observable<ItemModel> {
    let items = localStorage.getItem('book');
    let allItems: Array<ItemModel> = [];

    if (items) {
        allItems = JSON.parse(items);

        // Use find to get the item based on its ItemId
        const item = allItems.find(i => i.ItemId === id);

        // If found, return the item as an observable
        if (item) {
            return of(item);
        }
    }

    // If item not found or local storage is empty, return an empty observable
    return of();
}


   SaveItem(item: ItemModel) {
    // Retrieve the items from local storage
    const items = localStorage.getItem('book');
    let allItems: Array<ItemModel> = [];

    if (items) {
        allItems =JSON.parse(items);
    }


    if (item.ItemId === 0) {
        // If ItemId is 0, treat it as a new item
        const maxId = allItems.length > 0 ? Math.max(...allItems.map(i => i.ItemId)) : 0;
        item.ItemId = maxId + 1;
        allItems.push(item); // Add new item to the array
    } else {
        // If ItemId is not 0, find the item by id and replace it
        const index = allItems.findIndex(i => i.ItemId === item.ItemId);
        if (index !== -1) {
            // Replace the existing item with the same id
            allItems[index] = item;
        }
    }

    // Save the updated list back to local storage
    localStorage.setItem('book', JSON.stringify(allItems));
}

  RemoveItem(itemId:number)
  {
    let items = localStorage.getItem('book');
    let allItems: Array<ItemModel> = [];

    if (items)
      {
        allItems = JSON.parse(items);
        // Find the index of the item to remove by its ItemId
        const index = allItems.findIndex(i => i.ItemId === itemId);

        if (index !== -1)
           {
                // Remove the item from the array
                allItems.splice(index, 1);
                // Save the updated list back to localStorage
                localStorage.setItem('item', JSON.stringify(allItems));
           }

      }
  }
}
