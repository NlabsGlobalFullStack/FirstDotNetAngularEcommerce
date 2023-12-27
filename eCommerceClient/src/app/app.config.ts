import { ApplicationConfig } from '@angular/core';
import { provideRouter } from '@angular/router';
import { routes } from './app.routes';
import { provideHttpClient } from '@angular/common/http';

// Angular uygulamanızın genel yapılandırmasını sağlayan nesne.
export const appConfig: ApplicationConfig = {
  // Uygulama yapılandırması için sağlanan hizmetleri içeren dizi.
  providers: [
    // HTTP hizmeti sağlayıcısını ekler.
    provideHttpClient(),
    
    // Router hizmeti sağlayıcısını ekler ve tanımlanan rotaları kullanır.
    provideRouter(routes)
  ]
};
