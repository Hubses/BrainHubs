import { Component, Input } from '@angular/core';

import './categories-list.component.css';

@Component({
    selector: 'bh-categories-list',
    template: require('./categories-list.component.html')
})
export class CategoriesListComponent {
    @Input() public categories: any[];
}