import {Component, Input, OnInit} from '@angular/core';
import {ActivatedRoute, Params} from '@angular/router';
import {Location} from '@angular/common';
import {NewsService} from '../news.service';
import {News} from '../news';

import './news-detail.component.css';

@Component({
    selector: 'bh-news-detail',
    template: require('./news-detail.component.html')
})
export class NewsDetailComponent implements OnInit {
    constructor(private newsService:NewsService,
                private route:ActivatedRoute,
                private location:Location) {

    }

    ngOnInit():void {
        this.route.params.forEach((params:Params) => {
            let id = +params['id'];
            this.newsService.getNews(id)
                .then(news => this.news = news)
        })
    }

    @Input() news:News;

    goBack():void {
        this.location.back();
    }

}
