import { platformBrowserDynamic } from '@angular/platform-browser-dynamic';
import { AppModule } from './app/app.module';
import {FIREBASE_PROVIDERS, defaultFirebase, AngularFire} from 'angularfire2';


platformBrowserDynamic().bootstrapModule(AppModule);