import {Component, Input, OnInit} from '@angular/core';
import {ActivatedRoute, Params} from '@angular/router';
import {Location} from '@angular/common';
import {NewsService} from '../news.service';
import {News} from '../news';
import {Router} from '@angular/router';
import './news-detail.component.css';

@Component({
    selector: 'bh-news-detail',
    template: require('./news-detail.component.html')
})
export class NewsDetailComponent implements OnInit {
    @Input() news:News;

    newses:News[] = [];

    public get listReferenceNewsId():number[] {
        return this.news.ReferenceNewsId;
    }

    public getLinkReferenceNews(numberNews:number):void {
        let idReferenceNews:number = this.newses[numberNews - 1].Id;
        let link = ['/detail', idReferenceNews];
        this.router.navigate(link);
        window.scrollTo(0,0);
    }

    public getHeaderReferenceNews(numberNews:number):string {
        return this.newses[numberNews - 1].Header;
    }

    constructor(private newsService:NewsService,
                private route:ActivatedRoute,
                private location:Location,
                private router:Router) {

    }

    ngOnInit():void {
        window.scrollTo(0,0);
        this.SetNews();
        this.SetNewses();
    }

    goBack():void {
        this.location.back();
    }

    SetNews():void {
        this.route.params.forEach((params:Params) => {
            let id = +params['id'];
            this.newsService.getNews(id)
                .then(news => this.news = news)
        })
    }

    SetNewses():void {
        this.newsService.getNewses()
            .then(news =>
                this.newses = news
            );
    }
}
