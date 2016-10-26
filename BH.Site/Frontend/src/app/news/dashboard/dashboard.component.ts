import { Component, OnInit } from '@angular/core';

import { News } from '../news';
import { NewsService } from '../news.service';

@Component({
    selector: 'bh-dashboard',
    template: require('./dashboard.component.html')
})
export class DashboardComponent implements OnInit {
    newses: News[] = [];

    constructor(private newsService: NewsService) {

    }

    ngOnInit() {
        this.newsService.getNewses()
            .then(news => this.newses = news.slice(0, 5));
    }
    gotoDetail(news: News): void { /* not implemented yet */ }
}