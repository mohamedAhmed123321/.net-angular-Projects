



import { Component, OnInit, Inject, PLATFORM_ID } from '@angular/core';
import { isPlatformBrowser } from '@angular/common';
import { ItemService } from '../../services/classes/item.service';
import { ItemModel } from '../../models/ItemModel.model';
import Swal from 'sweetalert2';

@Component({
  selector: 'app-book-list',
  templateUrl: './book-list.component.html',
  styleUrl: './book-list.component.sass'
})
export class AminBookListComponent implements OnInit {
  categorys:ItemModel[]=[];

  constructor(@Inject(PLATFORM_ID) private platformId: Object,private itemService:ItemService)
  {

  }
ngOnInit(): void {
  if (isPlatformBrowser(this.platformId))
    {

      this.itemService.GetAllItems().subscribe((data)=>{
        this.categorys=data;
        let body=<HTMLDivElement> document.body


        let script = document.createElement('script');
        script.innerHTML='';
        script.src = '../../../assets/js/sidebar-menu.js';
        script.async = true;
        script.defer = true;
        body.appendChild(script);

         script = document.createElement('script');
        script.innerHTML='';
        script.src = '../../../assets/js/datatables/jquery.dataTables.min.js';
        script.async = true;
        script.defer = true;
        body.appendChild(script);

        script = document.createElement('script');
        script.innerHTML='';
        script.src = '../../../assets/js/datatables/custom-basic.js';
        script.async = true;
        script.defer = true;
        body.appendChild(script);
          });

    }
}
RemoveItem(itemId: number) {
  // Show SweetAlert confirmation dialog before removing the item
  Swal.fire({
      title: 'Are you sure?',
      text: "delete",
      icon: 'warning',
      showCancelButton: true,
      confirmButtonColor: '#3085d6',
      cancelButtonColor: '#d33',
      confirmButtonText: 'Yes'
  }).then((result) => {
      if (result.isConfirmed) {
        this.itemService.RemoveItem(itemId)
        document.getElementById(itemId.toString())?.remove();
        Swal.fire(
          'Deleted!',
          'Your item has been deleted.',
          'success'
      );
      }
  });
}

}
