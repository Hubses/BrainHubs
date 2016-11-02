import { Component, Output, EventEmitter } from '@angular/core';
import {ActivatedRoute, Params} from '@angular/router';
import {Location} from '@angular/common';
import {Router} from '@angular/router';

import { DashboardComponent } from '../../news/dashboard/dashboard.component';
import './navbar.component.css';

@Component({
    selector: 'bh-navbar',
    template: require('./navbar.component.html')
})
export class NavbarComponent {
    @Output() public onBrandClick: EventEmitter<any> = new EventEmitter();

    constructor(
        private route: ActivatedRoute,
        private location: Location,
        private router: Router) {

    }

    public brandClick(): void {
        this.onBrandClick.emit();
    }
    public gotoMain(): void {
        let link = ['/']
        this.router.navigate(link);
    }
}