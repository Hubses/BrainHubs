import { Component, OnInit } from '@angular/core';
import { AngularFire, AuthProviders, AuthMethods, FirebaseListObservable } from 'angularfire2';

// import '../w3.css'
import './news/dashboard/dashboard.component.css'
import './app.component.css';

import { News } from './news/news';
import { NewsService } from './news/news.service';
import { NewsComponent } from './news/news.component';

import { CategoryService } from './category.service';

@Component({
    selector: 'bh-app',
    template: require('./app.component.html'),
})

export class AppComponent implements OnInit {
    public categories: bh.entities.ICategory[];

    public isSidebarOpen: boolean;

    constructor(private af: AngularFire, private categoryService: CategoryService) {
        const news$: FirebaseListObservable<any> = af.database.list('news');

        news$.subscribe(
            val => console.log(val)
        )
    }

    getCategories(): void {
        this.categoryService.getCategories().then(categories => this.categories = categories);
    }

    ngOnInit(): void {
        this.getCategories();
    }

    public openSidebar(): void {
        this.isSidebarOpen = true;
    }

    public closeSidebar(): void {
        this.isSidebarOpen = false;
    }

}