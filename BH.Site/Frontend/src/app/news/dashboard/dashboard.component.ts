import { Component, Input, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { Location } from '@angular/common';

import { News } from '../news';
import { NewsService } from '../news.service';
import './dashboard.component';


@Component({
    selector: 'bh-dashboard',
    template: require('./dashboard.component.html')
})
export class DashboardComponent implements OnInit {
    newses: News[] = [];

    constructor(
        private newsService: NewsService,
        private router: Router
    ) {

    }

    ngOnInit() {
        this.newsService.getNewses()
            .then(news =>
                this.newses = news.slice(0, 5)
            );
    }
    gotoDetail(news: News): void {
        let link = ['/detail', news.Id];
        this.router.navigate(link);
    }
}