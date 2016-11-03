import {Component, Input, OnInit} from '@angular/core';
import {Router} from '@angular/router';
import {Location} from '@angular/common';
import {NewsCard} from '../news-card/news-card';
import {News} from '../news';
import {NewsService} from '../news.service';
import './dashboard.component';

import './dashboard.component.css'

import { AngularFire, FirebaseListObservable } from 'angularfire2';

@Component({
    selector: 'bh-dashboard',
    template: require('./dashboard.component.html')
})
export class DashboardComponent implements OnInit {
    //newses:FirebaseListObservable<News[]>;
    newses: News[];
    defaultImageUrl:string = 'http://img.tyt.by/620x620s/n/prezident/03/8/lukashenko_31102016-1.jpg';

    constructor(private newsService:NewsService,
                private router:Router,
                private af:AngularFire) {
                    // this.newses = af.database.list('/news');
    }

    ngOnInit() {
         this.newsService.getNewses()
             .then(news =>
                 this.newses = news
             );
    }
}