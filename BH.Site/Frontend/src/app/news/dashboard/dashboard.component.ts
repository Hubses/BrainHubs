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
    defaultImageUrl: string = 'http://img.tyt.by/620x620s/n/prezident/03/8/lukashenko_31102016-1.jpg';
    constructor(
        private newsService: NewsService,
        private router: Router
    ) {

    }

    ngOnInit() {
        this.newsService.getNewses()
            .then(news =>
                this.newses = news.slice(0, 36)
            );
    }
    gotoDetail(news: News): void {
        let link = ['/detail', news.Id];
        this.router.navigate(link);
    }
}