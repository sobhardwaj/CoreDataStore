import { platformBrowserDynamic } from '@angular/platform-browser-dynamic';
import { AppModule } from './index';
import { enableProdMode } from '@angular/core';

import { AppSettings } from './routes/appsettings';

if ('Dev' !== AppSettings.ng2ENV) {
    enableProdMode();
}
platformBrowserDynamic().bootstrapModule(AppModule);
