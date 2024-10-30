import { AfterViewInit, Component, Inject, OnInit, PLATFORM_ID, ViewEncapsulation  } from '@angular/core';
import {ItemService} from "../../services/classes/item.service"
import { ItemModel } from '../../models/ItemModel.model';
import { isPlatformBrowser } from '@angular/common';
declare var $: any;

@Component({
  selector: 'app-home-page',
  templateUrl: './home-page.component.html',
  encapsulation: ViewEncapsulation.None
})
export class HomePageComponent implements AfterViewInit {
  sliderItems:ItemModel[]=[];
  popularItems:ItemModel[]=[];
  newItems:ItemModel[]=[];
  allItems:ItemModel[]=[];
  constructor(private itemService:ItemService,@Inject(PLATFORM_ID) private platformId: Object){
  }

  ngAfterViewInit(): void {
    if (isPlatformBrowser(this.platformId))
      {
        let body=<HTMLDivElement> document.body

    this.itemService.GetAllSlider().subscribe((data)=>{

      this.sliderItems=data;
    })
    this.itemService.GetAllPopularItems().subscribe((data)=>{
     this.popularItems=data;

    })
    this.itemService.GetAllNewItems().subscribe((data)=>{
      this.newItems=data;

     })
     this.itemService.GetAllItems().subscribe((data)=>{
      this.allItems=data;
      console.log(data)

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

     })

  }
}

  toasterSucc(){


  }
}
