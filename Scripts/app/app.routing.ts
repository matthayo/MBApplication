import { ModuleWithProviders } from "@angular/core";
import { Routes, RouterModule } from "@angular/router";

import { HomeComponent } from "./home/home.component";
import { LoginComponent } from "./login/login.component";
import { PageNotFoundComponent } from "./misc/page-not-found.component";
import { FamilyDetailEditComponent } from "./family/family-detail-edit.component";
import { FamilyDetailViewComponent } from "./family/family-detail-view.component";

const appRoutes: Routes = [
    {
        path: "",
        component: HomeComponent
    },
    {
        path: "home",
        redirectTo: ""
    },
    {
        path: "login",
        component: LoginComponent
    },
    {
        path: "family/edit/:id",
        component: FamilyDetailEditComponent
    },
    {
        path: "family/view/:id",
        component: FamilyDetailViewComponent
    },
    {
        path: '**',
        component: PageNotFoundComponent
    }
];

export const AppRoutingProviders: any[] = [];

export const AppRouting: ModuleWithProviders = RouterModule.forRoot(appRoutes);