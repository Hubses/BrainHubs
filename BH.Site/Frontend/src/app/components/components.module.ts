import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { SidebarComponent } from './sidebar';
import { CategoriesListComponent } from './categories-list';
import { NavbarComponent } from './navbar';

@NgModule({
    imports: [
        BrowserModule
    ],
    declarations: [
        SidebarComponent,
        CategoriesListComponent,
        NavbarComponent
    ],
    exports: [
        SidebarComponent,
        CategoriesListComponent,
        NavbarComponent
    ]
})
export class ComponentsModule { }