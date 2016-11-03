import { Component, Input, OnInit } from '@angular/core';
import { ActivatedRoute, Params } from '@angular/router';
import { Location } from '@angular/common';
import { NewsService } from '../news.service';
import { News } from '../news';
import { Router } from '@angular/router';
import './news-detail.component.css';

@Component({
    selector: 'bh-news-detail',
    template: require('./news-detail.component.html')
})
export class NewsDetailComponent implements OnInit {
    @Input() news: News;

    newses: News[] = [];

    public get listReferenceNewsId(): number[] {
        if (this.news.ReferenceNewsId == null) {
            let listId: number[] = [];
            for (let i = 0; i < 10; i++) {
                let randomNumber = this.getRandomInt(0,220);
                listId.push(this.newses[randomNumber].Id);
            }
            return listId;
        } else {
            return this.news.ReferenceNewsId;
        }

    }
    private getRandomInt(min: number, max: number): number {
        return Math.floor(Math.random() * (max - min + 1)) + min;
    }


    public getLinkReferenceNews(numberNews: number): void {
        let idReferenceNews: number = this.newses[numberNews - 1].Id;
        let link = ['/detail', idReferenceNews];
        this.router.navigate(link);
        window.scrollTo(0, 0);
    }

    public getHeaderReferenceNews(numberNews: number): string {
        return this.newses[numberNews - 1].Header;
    }

    constructor(private newsService: NewsService,
        private route: ActivatedRoute,
        private location: Location,
        private router: Router) {

    }

    ngOnInit(): void {
        window.scrollTo(0, 0);
        this.SetNews();
        this.SetNewses();
    }

    goBack(): void {
        this.location.back();
    }

    SetNews(): void {
        this.route.params.forEach((params: Params) => {
            let id = +params['id'];
            this.newsService.getNews(id)
                .then(news => this.news = news)
        })
    }

    SetNewses(): void {
        this.newsService.getNewses()
            .then(news =>
                this.newses = news
            );
    }
}
