import {Injectable} from '@angular/core';
import {Headers, Http} from '@angular/http';

import 'rxjs/add/operator/toPromise';

import {CATEGORIES} from './category-mock';

@Injectable()
export class CategoryService {
    constructor() {

    }

    getCategories():Promise<bh.entities.ICategory[]> {
        return Promise.resolve(CATEGORIES);
    }

    getCategory(id:number) {
        return this.getCategories().then(newses => newses.find(category => category.id === id));
    }
}
