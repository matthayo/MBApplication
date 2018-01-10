import { ModuleWithProviders } from "@angular/core";
import { Routes, RouterModule } from "@angular/router";

import { HomeComponent } from "./home.component";

const appRoutes: Routes = [
    {
        path: "",
        component: HomeComponent
    },

    {
        path: "home",
        redirectTo: ""
    }
];

export const AppRouting: ModuleWithProviders = RouterModule.forRoot(appRoutes);