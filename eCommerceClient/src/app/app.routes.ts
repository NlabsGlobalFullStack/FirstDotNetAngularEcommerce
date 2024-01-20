import { Routes } from '@angular/router';
import { LayoutComponent } from './ui/layout/layout.component';
import { HomeComponent } from './ui/home/home.component';
import { ShoppingCartComponent } from './ui/shopping-cart/shopping-cart.component';
import { OrderComponent } from './ui/order/order.component';
import { LoginComponent } from './ui/login/login.component';
import { RegisterComponent } from './ui/register/register.component';
import { DashboardLayoutComponent } from './ui/layout/dashboard-layout/dashboard-layout.component';
import { DhomeComponent } from './ui/dashboard/dhome/dhome.component';

export const routes: Routes = [
    {
        path: "",
        component: LayoutComponent,
        children: [
            {
                path: "",
                component: HomeComponent
            },
            {
                path: "shopping-carts",
                component: ShoppingCartComponent
            },
            {
                path: "orders",
                component: OrderComponent
            },
            {
                path: "login",
                component: LoginComponent
            },
            {
                path: "register",
                component: RegisterComponent
            }
        ]
    },    
    {
        path: "dashboard",
        component: DashboardLayoutComponent,
        children: [
            {
                path: "",
                component: DhomeComponent
            }
        ]
    }
];
