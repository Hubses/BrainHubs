import { StoreModule, combineReducers } from '@ngrx/store';
import { compose } from '@ngrx/core';
import * as reducers from './reducers';

const initialState: bh.store.INewsStore = {
    searchResult: { totalRecords: 0, news: [] }
};

export const BitRunsStoreModule = StoreModule.provideStore(compose(combineReducers)(reducers), initialState);