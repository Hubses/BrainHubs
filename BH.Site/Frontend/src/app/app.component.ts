import { Component, OnInit } from '@angular/core';

import '../w3.css'

import { News } from './news/news';
import { NewsService } from './news/news.service';
import { NewsComponent } from './news/news.component';

@Component({
    selector: 'bh-app',
    template: require('./app.component.html'),
})

export class AppComponent {
    title = 'Tour of Newses';
}