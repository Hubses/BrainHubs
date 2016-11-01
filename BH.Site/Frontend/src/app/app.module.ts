import {NgModule} from '@angular/core';
import {BrowserModule} from '@angular/platform-browser';
import {FormsModule} from '@angular/forms';
import {HttpModule} from '@angular/http';

import {InMemoryWebApiModule} from 'angular-in-memory-web-api';
import {InMemoryDataService} from './in-memory-data.service';

import {AppComponent} from './app.component';
import {NewsDetailComponent} from './news/news-detail/news-detail.component';
import {NewsComponent} from './news/news.component';
import {DashboardComponent} from './news/dashboard/dashboard.component';

import {NewsService} from './news/news.service';
import {CategoryService} from './category.service';
import {NewsCard} from './news/news-card/news-card'
import {AppRoutingModule} from './app-router.module';

import { ComponentsModule } from './components';

@NgModule({
    imports: [
        BrowserModule,
        FormsModule,
        AppRoutingModule,
        HttpModule,
        InMemoryWebApiModule.forRoot(InMemoryDataService),
        ComponentsModule
    ],
    declarations: [
        AppComponent,
        NewsDetailComponent,
        NewsComponent,
        DashboardComponent,
        NewsCard
    ],
    providers: [NewsService, CategoryService],
    bootstrap: [AppComponent]
})
export class AppModule {
}