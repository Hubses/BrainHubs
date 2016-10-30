import { Component, OnInit } from '@angular/core';

import './side.component.css';

import { Sidebar } from './sidebar';
import { SidebarService } from './sidebar.service';

@Component({
    selector: 'bh-sidebar',
    template: require('./sidebar.component.html'),
    providers: [SidebarService]
})

export class SidebarComponent {
    title = 'Categories';
    category: Sidebar[];
    selectedCategory: Sidebar;
    constructor(
        private sidebarService: SidebarService
    ) { }

    // getCategories(): void {
    //     this.sidebarService.getSidebar(category => this.category = category);
    // }

    // ngOnInit(): void {
    //     this.getCategories();
    // }

    // w3_open(): void {
    //     document.getElementById("mySidenav").style.display = "block";
    //     document.getElementById("myOverlay").style.display = "block";
    // }

    // w3_close() {
    //     document.getElementById("mySidenav").style.display = "none";
    //     document.getElementById("myOverlay").style.display = "none";
    // }
}