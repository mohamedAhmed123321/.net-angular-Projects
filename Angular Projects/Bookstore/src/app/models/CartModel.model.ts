import {CartItemModel} from "./CartItemModel.model"
export interface CartModel {
  Items:Array<CartItemModel>
  Total:number
}
