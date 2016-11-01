import { Component, Input, OnInit } from '@angular/core';
import { ActivatedRoute, Params } from '@angular/router';
import { Location } from '@angular/common';

import { CategoryService } from '../../category.service';
import { Category } from '../../category';

@Component({
    selector: 'bh-category-detail',
    template: require('./category-detail.component.html')
})
export class NewsDetailComponent implements OnInit {
    constructor(private categoryService: CategoryService,
        private route: ActivatedRoute,
        private location: Location) {

    }

    ngOnInit(): void {
        this.route.params.forEach((params: Params) => {
            let id = +params['id'];
            this.categoryService.getCategory(id)
                .then(news => this.news = news)
        })
    }

    @Input() news: News;

    goBack(): void {
        this.location.back();
    }

}
