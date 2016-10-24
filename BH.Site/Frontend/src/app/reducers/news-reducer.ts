import { ActionReducer, Action } from '@ngrx/store';
import { FILL_NEWS_RESULTS, INIT_NEWS_SEARCH } from '../actions';

export const searchResult: ActionReducer<bh.store.ISearchResult> = (state: bh.store.ISearchResult, {type, payload}: Action) => {
    switch (type) {
        case INIT_NEWS_SEARCH:
            return {
                totalRecords: 0,
                news: []
            }

        case FILL_NEWS_RESULTS:
            return payload

        default:
            return state;
    }
}