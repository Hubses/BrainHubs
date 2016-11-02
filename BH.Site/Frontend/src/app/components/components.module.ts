import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { SidebarComponent } from './sidebar';
import { CategoriesListComponent } from './categories-list';

@NgModule({
    imports: [
        BrowserModule
    ],
    declarations: [
        SidebarComponent,
        CategoriesListComponent
    ],
    exports: [
        SidebarComponent,
        CategoriesListComponent
    ]
})
export class ComponentsModule { }