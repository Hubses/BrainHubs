import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { FormsModule } from '@angular/forms';
import { HttpModule }    from '@angular/http';

import { InMemoryWebApiModule } from 'angular-in-memory-web-api';
import { InMemoryDataService }  from './in-memory-data.service';

import { AppComponent } from './app.component';
import { NewsDetailComponent } from './news/news-detail/news-detail.component';
import { NewsComponent } from './news/news.component';
import { DashboardComponent } from './news/dashboard/dashboard.component';

import { NewsService } from './news/news.service';

import { AppRoutingModule } from './app-router.module';


@NgModule({
    imports: [
        BrowserModule,
        FormsModule,
        AppRoutingModule,
        HttpModule,
        InMemoryWebApiModule.forRoot(InMemoryDataService)
    ],
    declarations: [
        AppComponent,
        NewsDetailComponent,
        NewsComponent,
        DashboardComponent
    ],
    providers: [NewsService],
    bootstrap: [AppComponent]
})
export class AppModule { }