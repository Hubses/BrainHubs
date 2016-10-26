import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { FormsModule } from '@angular/forms';

import { AppComponent } from './app.component';
import { NewsDetailComponent } from './news/news-detail/news-detail.component';
import { NewsComponent } from './news/news.component';
import { DashboardComponent } from './news/dashboard/dashboard.component';

import { NewsService } from './news/news.service';

import { RouterModule } from '@angular/router';



@NgModule({
    imports: [
        BrowserModule,
        FormsModule,
        RouterModule.forRoot([
            { path: '', redirectTo: '/dashboard', pathMatch: 'full' },
            { path: 'home', component: NewsComponent },
            { path: 'dashboard', component: DashboardComponent }
        ])
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