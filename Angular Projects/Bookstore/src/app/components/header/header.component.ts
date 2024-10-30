import { Component, OnInit,Renderer2,PLATFORM_ID, Inject  } from '@angular/core';
import { isPlatformBrowser } from '@angular/common';
import { Router } from '@angular/router';
import { AuthService } from '../../services/classes/auth.service';
declare var $: any;
@Component({
  selector: 'app-header',
  templateUrl: './header.component.html',
  styleUrl: './header.component.scss'
})
export class HeaderComponent implements OnInit{
  constructor(private router: Router,private auth:AuthService,  @Inject(PLATFORM_ID) private platformId: object){}

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
  LogOut()
  {
    this.auth.logout();
    this.router.navigate(['/login']);
  }
}
