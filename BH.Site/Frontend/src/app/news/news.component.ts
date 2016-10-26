import { Component, OnInit } from '@angular/core';

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

    getHeroes(): void {
        this.newsService.getNewses().then(newses => this.newses = newses);
    }

    ngOnInit(): void {
        this.getHeroes();
    }

    onSelect(news: News): void {
        this.selectedNews = news;
    }
}