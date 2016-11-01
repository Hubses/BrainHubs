import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { SidebarComponent } from './sidebar';

import { CategoryService } from '../category.service';

@NgModule({
    imports: [
        BrowserModule
    ],
    declarations: [
        SidebarComponent
    ],
    exports: [
        SidebarComponent
    ],
    providers:[CategoryService]
})
export class ComponentsModule { }