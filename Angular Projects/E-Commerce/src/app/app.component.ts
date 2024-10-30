import { AfterViewInit, Component } from '@angular/core';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrl: './app.component.css'
})
export class AppComponent implements AfterViewInit {
  title = 'E-Commerce';
  ngAfterViewInit(): void
  {
        let body=<HTMLDivElement> document.body
      let script = document.createElement('script');
      script.innerHTML='';
      script.src = '../assets/js/slick.js';
      script.async = true;
      script.defer = true;
      body.appendChild(script);

      script = document.createElement('script');
      script.innerHTML='';
      script.src = '../assets/js/footer-reveal.min.js';
      script.async = true;
      script.defer = true;
      body.appendChild(script);

      script = document.createElement('script');
      script.innerHTML='';
      script.src = '../assets/js/script.js';
      script.async = true;
      script.defer = true;
      body.appendChild(script);
  }
}
