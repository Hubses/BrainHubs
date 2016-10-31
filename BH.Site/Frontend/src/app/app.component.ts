import { Component, OnInit } from '@angular/core';

import '../w3.css'
import './news/dashboard/dashboard.component.css'

import { News } from './news/news';
import { NewsService } from './news/news.service';
import { NewsComponent } from './news/news.component';

import { Category } from './category';
import { CategoryService } from './category.service';

@Component({
    selector: 'bh-app',
    template: require('./app.component.html'),
})

export class AppComponent implements OnInit {
    categories: Category[];

    constructor(private categoryService: CategoryService) { }

    getCategories(): void {
        this.categoryService.getCategories().then(categories => this.categories = categories);
    }

    ngOnInit(): void {
        this.getCategories();
    }
    openMenu(): void {

        document.getElementById("mySidenav").style.display = "block";
        document.getElementById("myOverlay").style.display = "block";
    }
    CloseMenu() {
        document.getElementById("mySidenav").style.display = "none";
        document.getElementById("myOverlay").style.display = "none";
    }

}