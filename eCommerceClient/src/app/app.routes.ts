import { Routes } from '@angular/router';
import { LayoutComponent } from './components/frontend/layout/layout.component';
import { HomeComponent } from './components/frontend/home/home.component';
import { OrderComponent } from './components/frontend/order/order.component';
import { BasketComponent } from './components/frontend/basket/basket.component';
import { LoginComponent } from './components/frontend/login/login.component';
import { RegisterComponent } from './components/frontend/register/register.component';
import { NotFoundComponent } from './components/frontend/not-found/not-found.component';
import { AdminLayoutComponent } from './components/dashboard/admin-layout/admin-layout.component';
import { AdminHomeComponent } from './components/dashboard/admin-home/admin-home.component';
import { AdminNotFoundComponent } from './components/dashboard/admin-not-found/admin-not-found.component';

export const routes: Routes = [
    // Ana sayfa rotası
    {
        path: "",
        component: LayoutComponent,
        children:[
            {
                path: "",
                component: HomeComponent
            },
            {
                path: "orders",
                component: OrderComponent
            },
            {
                path: "baskets",
                component: BasketComponent
            },
            {
                path: "login",
                component: LoginComponent
            },
            {
                path: "register",
                component: RegisterComponent
            },
            {
                path: "**",
                component: NotFoundComponent
            }
        ]
    },
    // Admin sayfa rotası
    {
        path: "dashboard",
        component: AdminLayoutComponent,
        children:[
            {
                path: "dashboard",
                component: AdminHomeComponent
            },
            {
                path: "**",
                component: AdminNotFoundComponent
            }
        ]
    }
];
