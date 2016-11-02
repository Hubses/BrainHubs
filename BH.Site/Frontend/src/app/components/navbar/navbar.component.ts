import { Component, Output, EventEmitter } from '@angular/core';

import './navbar.component.css';

@Component({
    selector: 'bh-navbar',
    template: require('./navbar.component.html')
})
export class NavbarComponent {
    @Output() public onBrandClick: EventEmitter<any> = new EventEmitter();

    public brandClick(): void {
        this.onBrandClick.emit();
    }
}