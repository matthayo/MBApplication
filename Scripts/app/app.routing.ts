import { ModuleWithProviders } from "@angular/core";
import { Routes, RouterModule } from "@angular/router";

import { HomeComponent } from "./home.component";

const appRoutes: Routes = [
    {
        path: "home",
        component: HomeComponent
    },
    {
        path: "",
        redirectTo: "/home",
        pathMatch: "full"
    }


];

export const AppRouting: ModuleWithProviders = RouterModule.forRoot(appRoutes);