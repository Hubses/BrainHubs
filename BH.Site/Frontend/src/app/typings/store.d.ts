declare namespace bh.store {
    interface INewsStore {
        searchResult: ISearchResult;
    }

    interface ISearchResult {
        totalRecords: number;
        news: bh.entities.INews[];
    }
}