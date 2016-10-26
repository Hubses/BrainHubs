import { Injectable } from '@angular/core';

import { News } from './news';
import { NEWSES } from './news-mock';

@Injectable()
export class NewsService {

    getHeroes(): News[] {
        return NEWSES;
    }
}
