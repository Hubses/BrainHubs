import { Injectable } from '@angular/core';
import { Store } from '@ngrx/store';

import * as actions from '../actions';

@Injectable()
export class NewsService {

    public constructor(private store: Store<bh.store.INewsStore>) { }

    public initNews(criteria: bh.entities.ISearchCriteria): void {
        this.store.dispatch(actions.initNewsSearch(criteria));
    }

    public searchNews(criteria: bh.entities.ISearchCriteria): void {
        this.store.dispatch(actions.fillNewsResults({
            totalRecords: 2,
            news: [
                {
                    title: 'news 1 title',
                    text: 'news 1 text'
                },
                {
                    title: 'news 2 title',
                    text: 'news 2 text'
                }
            ]
        }));
    }
}