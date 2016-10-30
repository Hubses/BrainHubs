import { Component, OnInit } from '@angular/core';

import '../w3.css'
import './news/dashboard/dashboard.component.css'

import { News } from './news/news';
import { NewsService } from './news/news.service';
import { NewsComponent } from './news/news.component';

@Component({
    selector: 'bh-app',
    template: require('./app.component.html'),
})

export class AppComponent {
    title = 'Tour of Newses';

    // w3_open(): void {

    //     document.getElementById("mySidenav").style.display = "block";
    //     document.getElementById("myOverlay").style.display = "block";
    // }
    // w3_close() {
    //     document.getElementById("mySidenav").style.display = "none";
    //     document.getElementById("myOverlay").style.display = "none";
    // }

}