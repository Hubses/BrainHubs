import { Component, Input, Output, EventEmitter } from '@angular/core';

import './sidebar.component.css';

@Component({
    selector: 'bh-sidebar',
    template: require('./sidebar.component.html')
})
export class SidebarComponent{
    @Input() public isOpen: boolean;

    @Output() public onOverlayClick: EventEmitter<boolean> = new EventEmitter<boolean>();

    public close(): void {
        this.onOverlayClick.emit();
    }
}