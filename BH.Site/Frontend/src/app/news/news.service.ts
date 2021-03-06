import {Injectable} from '@angular/core';
import {Headers, Http} from '@angular/http';

import 'rxjs/add/operator/toPromise';

import {News} from './news';
import {NEWSES} from './news-mock';

@Injectable()
export class NewsService {
    private newsUrl = 'app/news';

    constructor(private http:Http) {

    }

    getCategories():void {

    }

    getNewses():Promise<News[]> {
        return Promise.resolve(NEWSES);
    }

    // See the "Take it slow" appendix
    getNewsesSlowly():Promise<News[]> {
        return new Promise<News[]>(resolve =>
            setTimeout(resolve, 2000)) // delay 2 seconds
            .then(() => this.getNewses());
    }

    getNews(id:number) {
        return this.getNewses().then(newses => newses.find(news => news.Id === id));
    }

    private handleError(error:any):Promise<any> {
        console.error('An error occurred', error); // for demo purposes only
        return Promise.reject(error.message || error);
    }
}
