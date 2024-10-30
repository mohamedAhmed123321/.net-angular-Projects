import { Component, AfterViewInit } from '@angular/core';
import { ItemService } from "../../services/classes/item.service";
import { ItemModel } from '../../models/ItemModel.model';
@Component({
  selector: 'app-home-page',
  templateUrl: './home-page.component.html',
  styleUrls: ['./home-page.component.sass'] // Corrected this property
})
export class HomePageComponent implements AfterViewInit {
  sliderItems: ItemModel[] = [];
  popularItems: ItemModel[] = [];
  newItems: ItemModel[] = [];
  allItems: ItemModel[] = [];
  constructor(private itemService:ItemService) {
  }

  ngAfterViewInit(): void {

    this.itemService.GetAllSlider().subscribe((data) => {
      this.sliderItems = data;

    });

    this.itemService.GetAllPopularItems().subscribe((data) => {
      this.popularItems = data;
    });

    this.itemService.GetAllNewItems().subscribe((data) => {
      this.newItems = data;
    });

    this.itemService.GetAllItems().subscribe((data) => {
      this.allItems = data;
      console.log(data);

      // Load scripts
      this.loadScript('../../assets/js/slick.js');
      this.loadScript('../../assets/js/footer-reveal.min.js');
      this.loadScript('../../assets/js/script.js');
    });
  }

  private loadScript(src: string): void {
    const script = document.createElement('script');
    script.src = src;
    script.async = true;
    script.defer = true;
    document.body.appendChild(script);
  }
}
