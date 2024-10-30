import { Component, OnInit,  Inject, PLATFORM_ID } from '@angular/core';
import { isPlatformBrowser } from '@angular/common';

@Component({
  selector: 'app-dashboard',
  templateUrl: './dashboard.component.html',
  styleUrl: './dashboard.component.sass'
})
export class DashboardComponent implements OnInit {
  constructor(@Inject(PLATFORM_ID) private platformId: Object) { }
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

       script = document.createElement('script');
      script.innerHTML='';
      script.src = '../../../assets/js/dashboard/default.js';
      script.async = true;
      script.defer = true;
      body.appendChild(script);

      script = document.createElement('script');
      script.innerHTML='';
      script.src = '../../../assets/js/admin-script.js';
      script.async = true;
      script.defer = true;
      body.appendChild(script);
    }
}
}
