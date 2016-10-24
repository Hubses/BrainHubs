import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { BitRunsStoreModule } from './store';

import { AppComponent } from './app-component';
import { NewsContainerComponent } from './containers';

import { NewsService } from './common';

@NgModule({
    imports: [
        BrowserModule,
        BitRunsStoreModule
    ],
    declarations: [
        AppComponent,
        NewsContainerComponent
    ],
    providers: [NewsService],
    bootstrap: [AppComponent]
})
export class AppModule { }