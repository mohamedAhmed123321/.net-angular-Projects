import { Component, OnInit,Renderer2,PLATFORM_ID, Inject  } from '@angular/core';
import { isPlatformBrowser } from '@angular/common';
declare var $: any;
@Component({
  selector: 'app-header',
  templateUrl: './header.component.html',
  styleUrl: './header.component.css'
})
export class HeaderComponent implements OnInit{
  constructor(private renderer: Renderer2,  @Inject(PLATFORM_ID) private platformId: object){}

  ngOnInit(): void {
    if (isPlatformBrowser(this.platformId)) {
      // // Dynamically create a script element
      // const script = this.renderer.createElement('script');
      // script.async = true;
      // script.defer = true;
      // script.src = '../../assets/js/script.js'; // Replace with your actual script URL

      // // Append the script to the body (only on the client-side)
      // this.renderer.appendChild(document.body, script);
    }
  }
}
