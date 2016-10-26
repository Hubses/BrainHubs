import { Injectable } from '@angular/core';

import { News } from './news';
import { NEWSES } from './news-mock';

@Injectable()
export class NewsService {
    getNewses(): Promise<News[]> {
        return Promise.resolve(NEWSES);
    }
    // See the "Take it slow" appendix
    getNewsesSlowly(): Promise<News[]> {
        return new Promise<News[]>(resolve =>
            setTimeout(resolve, 2000)) // delay 2 seconds
            .then(() => this.getNewses());
    }
}
