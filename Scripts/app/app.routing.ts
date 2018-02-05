import { ModuleWithProviders } from "@angular/core";
import { Routes, RouterModule } from "@angular/router";

import { HomeComponent } from "./home/home.component";
import { LoginComponent } from "./login/login.component";
import { PageNotFoundComponent } from "./misc/page-not-found.component";
import { FamilyDetailEditComponent } from "./family/family-detail-edit.component";
import { FamilyDetailViewComponent } from "./family/family-detail-view.component";
import { FamilyListComponent } from "./family/family-list.component";
import { MemberDetailViewComponent } from "./member/member-detail-view.component";
import { MemberDetailEditComponent } from "./member/member-detail-edit.component";
import { MemberListComponent } from "./member/member-list.component";

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
        path: "families",
        component: FamilyListComponent
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
        path: "members",
        component: MemberListComponent
    },
    {
        path: "member/view/:id",
        component: MemberDetailViewComponent
    },
    {
        path: "member/edit/:id",
        component: MemberDetailEditComponent
    },
    {
        path: '**',
        component: PageNotFoundComponent
    }
];

export const AppRoutingProviders: any[] = [];

export const AppRouting: ModuleWithProviders = RouterModule.forRoot(appRoutes);