import { Action } from '@ngrx/store';

export const INIT_NEWS_SEARCH = 'INIT_NEWS_SEARCH';
export function initNewsSearch(criteria: bh.entities.ISearchCriteria): Action {
    return {
        type: INIT_NEWS_SEARCH,
        payload: criteria
    }
}

export const FILL_NEWS_RESULTS = 'FILL_NEWS_RESULTS';
export function fillNewsResults(results: bh.store.ISearchResult): Action {
    return {
        type: FILL_NEWS_RESULTS,
        payload: results
    };
}
