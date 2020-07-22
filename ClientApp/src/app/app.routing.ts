import { NgModule } from "@angular/core";
import { Routes, RouterModule, ROUTES } from "@angular/router";

import { AboutUsComponent } from "./aboutUs/about-us.component";
import { HomeComponent } from "./home/home.component";
import { LoginComponent } from "./login/login.component";
import { LogOutComponent } from "./login/logout.component";
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
        component: HomeComponent,
    },
    {
        path: "home",
        redirectTo: "home"
    },
    {
        path: "login",
        component: LoginComponent,
        data: {
            breadcrumb: "Login"
        }
    },
    {
        path: "logout",
        component: LogOutComponent,
        data: {
            breadcrumb: "Log Out"
        }
    },
    {
        path: "aboutUs",
        component: AboutUsComponent,
        data: {
            breadcrumb: "About Us"
        }
    },
    {
        path: "families",
        component: FamilyListComponent,
        data: {
            breadcrumb: "Families List"
        }
    },
    {
        path: "family/edit/:id",
        component: FamilyDetailEditComponent,
        data: {
            breadcrumb: "Family Detail Edit"
        }
    },
    {
        path: "family/view/:id",
        component: FamilyDetailViewComponent,
        data: {
            breadcrumb: "Family Detail View"
        }
    },
    {
        path: "members",
        component: MemberListComponent,
        data: {
            breadcrumb: "Members List"
        }
    },
    {
        path: "member/edit/:id",
        component: MemberDetailEditComponent,
        data: {
            breadcrumb: "Member Detail Edit"
        }
    },
    {
        path: "member/view/:id",
        component: MemberDetailViewComponent,
        data: {
            breadcrumb: "Member Detail View"
        }
    },
    {
        path: '**',
        component: PageNotFoundComponent
    }
];

@NgModule({
  imports: [
    RouterModule.forRoot(
      appRoutes
      // enableTracing: true
    ),
  ],

  exports: [RouterModule],
})
export class AppRoutingModule {}
