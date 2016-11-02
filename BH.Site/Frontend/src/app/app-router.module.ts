import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';

import { NewsDetailComponent } from './news/news-detail/news-detail.component';
import { NewsComponent } from './news/news.component';
import { DashboardComponent } from './news/dashboard/dashboard.component';

const routes: Routes = [

    { path: '', component: DashboardComponent },
    { path: 'home', component: NewsComponent },
    { path: 'dashboard', redirectTo: '' },
    { path: 'detail/:id', component: NewsDetailComponent },
    { path: 'category/:id', component: NewsDetailComponent },
];

@NgModule({
    imports: [RouterModule.forRoot(routes)],
    exports: [RouterModule]
})
export class AppRoutingModule { }

