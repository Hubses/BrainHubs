import { Injectable } from '@angular/core';

import 'rxjs/add/operator/toPromise';

import { Sidebar } from './sidebar';
import { SIDEBAR } from './sidebar-mock';

@Injectable()
export class SidebarService {
    constructor(
    ) {

    }
    getSidebar(): Promise<Sidebar[]> {
       return Promise.resolve(SIDEBAR);
    }
}
