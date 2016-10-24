import { Component, OnInit } from '@angular/core';
import { Store } from '@ngrx/store';
import { Observable } from 'rxjs';

import * as actions from '../../actions';

import { NewsService } from '../../common';

import './news-container-component.css';

@Component({
    selector: 'bh-news-container',
    template: require('./news-container-component.html')
})
export class NewsContainerComponent implements OnInit {
    public news: Observable<bh.entities.INews[]>;

    public constructor(
        private store: Store<bh.store.INewsStore>,
        private newsService: NewsService
    ) { }

    public ngOnInit(): void {
        this.newsService.initNews(null);

        this.news = this.store.select(s => s.searchResult)
            .map(result => result.news);
    }

    public search(): void {
        this.newsService.searchNews(null);
    }
}