import { Component, OnInit, Inject, PLATFORM_ID } from '@angular/core';
import { isPlatformBrowser } from '@angular/common';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import {FormBuilderService} from "../../../services/helpers/FormBuilderService "
import { ItemModel } from '../../../models/ItemModel.model';
import {ItemService} from "../../../services/classes/item.service"
import { Router ,ActivatedRoute} from '@angular/router';
import Swal from 'sweetalert2';
@Component({
  selector: 'app-add-category',
  templateUrl: './add-category.component.html',
  styleUrl: './add-category.component.css'
})
export class AddCategoryComponent implements OnInit{
  addCategoryForm: FormGroup;
  itemId: number=0;
  category:ItemModel={ItemId:0,ItemName:"",PurchasePrice:0,SalesPrice:0,ImageName:"1.jpg"};
  constructor(private activateRout:ActivatedRoute,private route:Router,private itemService:ItemService,@Inject(PLATFORM_ID) private platformId: Object,private fb: FormBuilder ,private formService:FormBuilderService) {

    this.addCategoryForm = formService.AddCategoryForm();
   }



ngOnInit(): void {
  if (isPlatformBrowser(this.platformId))
    {
     let body=<HTMLDivElement> document.body
      let script = document.createElement('script');
      script.innerHTML='';
      script.src = '../../../assets/js/sidebar-menu.js';
      script.async = true;
      script.defer = true;
      body.appendChild(script);

      this.activateRout.params.subscribe(params => {
        this.itemId =parseInt( params['id']);
        this.itemService.GetById(this.itemId).subscribe((data)=>
        {
          this.category=data;


        });
      });
    }
}
onSubmit(){
  console.log(this.category)
  console.log(this.addCategoryForm)
  if(this.addCategoryForm.valid){
    this.itemService.SaveItem(this.category);
    Swal.fire('success!', ' saved successfully.', 'success').then(() => {
      // Navigate to another page after the success message is closed
      this.route.navigate(['/admin/categoryList']); // Replace with your actual route
  });
  }
}
ChangeImage(event:any)
{
  const file = event.target.files[0];
  this.category.ImageName=file.name;
}
Clear()
{
  this.category={ItemId:0,PurchasePrice:0,SalesPrice:0,ItemName:"",description:"",ImageName:"1.jpg"}
}
}
