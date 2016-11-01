import { Component, OnInit, Pipe, PipeTransform } from '@angular/core';
import './news.component.css'

import { News } from './news';
import { NewsService } from './news.service';

@Component({
    selector: 'bh-news',
    template: require('./news.component.html')

})
export class NewsComponent implements OnInit {
    newses: News[];
    selectedNews: News;

    constructor(private newsService: NewsService) { }

    getNews(): void {
        this.newsService.getNewses().then(newses => this.newses = newses);
    }

    ngOnInit(): void {
        this.getNews();
    }

    onSelect(news: News): void {
        this.selectedNews = news;
    }
}