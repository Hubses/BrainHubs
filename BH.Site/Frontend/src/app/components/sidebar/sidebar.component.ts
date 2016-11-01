import { Component, Input, Output, EventEmitter, OnInit } from '@angular/core';

import './sidebar.component.css';

import { CATEGORIES } from '../../category-mock';
import { Category } from '../../category';
import { CategoryService } from '../../category.service';

@Component({
    selector: 'bh-sidebar',
    template: require('./sidebar.component.html')
})
export class SidebarComponent implements OnInit{
    categories: Category[];

    constructor(private categoryService: CategoryService) {

    }

    @Input() public isOpen: boolean;

    @Output() public onOverlayClick: EventEmitter<boolean> = new EventEmitter<boolean>();

    ngOnInit():void{
        this.getCategories();
    }

    public close(): void {
        this.onOverlayClick.emit();
    }
    getCategories(): void {
        this.categoryService.getCategories().then(categories => this.categories = categories);
    }
}