import { Component, Input } from '@angular/core';
import { News } from '../news';

@Component({
    selector: 'bh-news-detail',
    template: require('./news-detail.component.html')
})
export class NewsDetailComponent {
    @Input() news: News;
}
