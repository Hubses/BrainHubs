import './news-card.css';
import {Component, Input} from '@angular/core';
import {News} from '../news'
import {Router} from '@angular/router';
@Component({
    selector: 'bh-news-card',
    template: require('./news-card.html')
})
export class NewsCard {

    @Input('news') _news:News;

    public get id():number {
        return this._news.Id;
    }

    public get category():string {
        return this._news.Category;
    }

    public get header():string {
        return this._news.Header;
    }

    public get imageUrl():string {
        return this._news.ImageUrl;
    }
    
    constructor(private router:Router) {

    }

    gotoDetail(news:News):void {
        let link = ['/detail', news.Id];
        this.router.navigate(link);
    }

}
