import { bootstrapApplication } from '@angular/platform-browser';
import { RouteReuseStrategy, provideRouter, withPreloading, PreloadAllModules } from '@angular/router';
import { IonicRouteStrategy, provideIonicAngular } from '@ionic/angular/standalone';
import { BrowserAnimationsModule, provideAnimations } from '@angular/platform-browser/animations';

import { routes } from './app/app.routes';
import { AppComponent } from './app/app.component';

bootstrapApplication(AppComponent, {
  providers: [
    { provide: RouteReuseStrategy, useClass: IonicRouteStrategy },
    { provide: BrowserAnimationsModule, useValue: BrowserAnimationsModule },
    provideIonicAngular(),
    provideRouter(routes, withPreloading(PreloadAllModules)),
    provideAnimations(),
  ],
});