import { Routes } from '@angular/router';
import { NoUserLayoutComponent } from './components/shared/no-user-layout/no-user-layout.component';
import { UserLayoutComponent } from './components/shared/user-layout/user-layout.component';
import { AdminLayoutComponent } from './components/shared/admin-layout/admin-layout.component';
import { LoginRegisterPageComponent } from './components/shared/login-register-page/login-register-page.component';
import { TicketResultsSearchComponent } from './components/search/ticket-results-search/ticket-results-search.component';

export const routes: Routes = [
    {
        path:'',
        redirectTo: 'nouser',
        pathMatch: 'full'
    },
    {
        path: 'nouser',
        component: NoUserLayoutComponent
    },
    {
        path: 'user',
        component: UserLayoutComponent
    },
    {
        path: 'admin',
        component: AdminLayoutComponent,
        // canActivate: ,
    },
    {
        path: 'auth',
        component:LoginRegisterPageComponent
    },
    {
        path: 'search-ticket-results',
        component: TicketResultsSearchComponent
    }
];
