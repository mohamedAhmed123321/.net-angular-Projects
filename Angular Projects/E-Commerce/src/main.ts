import { enableProdMode } from '@angular/core';
import { platformBrowserDynamic } from '@angular/platform-browser-dynamic';
import { AppModule } from './app/app.module';
import { environment } from './environments/environment';

if (environment.production) {
  enableProdMode(); // Enable production mode if the environment is set to production
}

platformBrowserDynamic()
  .bootstrapModule(AppModule) // Bootstrap the AppModule
  .catch(err => console.error(err)); // Catch and log any errors during bootstrapping
