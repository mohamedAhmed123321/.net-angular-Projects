 import {ItemModel} from "../../models/ItemModel.model";
 import { Observable } from 'rxjs';
 export interface ItemInterface
 {
  GetAllItems():Observable< Array<ItemModel>>;
  GetAllPopularItems():Observable< Array<ItemModel>>;
  GetAllNewItems():Observable< Array<ItemModel>>;
  GetAllSlider():Observable <Array<ItemModel>>;
  GetById(id:number):Observable <ItemModel>;
 }
