import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { FormsModule } from '@angular/forms';
import { HttpModule } from '@angular/http';
import {
    AngularFireModule,
    AuthMethods,
    AuthProviders,
    AngularFire
} from "angularfire2";

import { AppComponent } from './app.component';
import { NewsDetailComponent } from './news/news-detail/news-detail.component';
import { NewsComponent } from './news/news.component';
import { DashboardComponent } from './news/dashboard/dashboard.component';

import { NewsService } from './news/news.service';
import { CategoryService } from './category.service';
import { NewsCard } from './news/news-card/news-card'
import { AppRoutingModule } from './app-router.module';

import { ComponentsModule } from './components';

import { firebaseConfig } from './config/firebase.config';


@NgModule({
    imports: [
        BrowserModule,
        FormsModule,
        AppRoutingModule,
        HttpModule,
        ComponentsModule,
        AngularFireModule.initializeApp(firebaseConfig)
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