import { Routes } from '@angular/router';
import { NoUserLayoutComponent } from './components/shared/no-user-layout/no-user-layout.component';
import { UserLayoutComponent } from './components/shared/user-layout/user-layout.component';
import { AdminLayoutComponent } from './components/shared/admin-layout/admin-layout.component';
import { LoginRegisterPageComponent } from './components/shared/login-register-page/login-register-page.component';
import { TicketResultsSearchComponent } from './components/search/ticket-results-search/ticket-results-search.component';
import { authGuard } from './guard/auth.guard';
import { MainComponent } from './components/shared/main/main.component';
import { UserSearchComponent } from './components/search/user-search/user-search.component';
import { ChangePasswordComponent } from './components/change-password/change-password.component';
import { HistoryComponent } from './components/history/history.component';
import { TicketManagementLayoutComponent } from './components/management/ticket-management-layout/ticket-management-layout.component';
import { AddTicketComponent } from './components/management/add-ticket/add-ticket.component';
import { FindTicketComponent } from './components/management/find-ticket/find-ticket.component';

export const routes: Routes = [
    {
        path:'',
        redirectTo: 'nouser',
        pathMatch: 'full'
    },
    {
        path: 'nouser',
        component: NoUserLayoutComponent,
        children: [
            {
                path: 'search-ticket-results',
                component: TicketResultsSearchComponent
            },
            {
                path: '',
                component: MainComponent
            },
            {
                path: 'main',
                component: MainComponent
            }
        ]
    },
    {
        path: 'user',
        component: UserLayoutComponent,
        canActivate: [authGuard],
        children: [
            {
                path: '',
                component: MainComponent
            },
            {
                path: 'main',
                component: MainComponent
            },
            {
                path: 'search-ticket-results',
                component: TicketResultsSearchComponent
            },
            {
                path: 'change-password',
                component: ChangePasswordComponent
            },
            {
                path: 'history',
                component: HistoryComponent
            }
        ]
    },
    {
        path: 'admin',
        component: AdminLayoutComponent,
        canActivate: [authGuard],
        children: [
            {
                path: '',
                component: UserSearchComponent
            },
            {
                path: 'user-search',
                component: UserSearchComponent
            },
            {
                path: 'change-password',
                component: ChangePasswordComponent
            },
            {
                path: 'ticket-management',
                component: TicketManagementLayoutComponent,
                children: [
                    {
                        path: '',
                        component: AddTicketComponent
                    },
                    {
                        path: 'add-ticket',
                        component: AddTicketComponent
                    },
                    {
                        path: 'find-ticket',
                        component: FindTicketComponent
                    }
                ]
            }
        ]
    },
    {
        path: 'auth',
        component:LoginRegisterPageComponent
    }
];
