import { NgModule } from "@angular/core";
import { BrowserModule } from "@angular/platform-browser";
import { FormsModule } from "@angular/forms";
import { HttpModule } from "@angular/http";
import { RouterModule } from "@angular/router";

import "rxjs/Rx"

import { AppRouting } from "./app.routing";
import { AppComponent } from "./app.component";

import { MemberService } from "../app/member/member.service";
import { FamilyService } from "../app/family/family.service";

import { FamilyDetailEditComponent } from "../app/family/family-detail-edit.component";
import { FamilyDetailViewComponent } from "./family/family-detail-view.component";
import { FamilyListComponent } from "../app/family/family-list.component";
import { HomeComponent } from "../app/home/home.component";
import { LoginComponent } from "../app/login/login.component";
import { MemberListComponent } from "../app/member/member-list.component";
import { NavBarComponent } from "../app/nav/nav-bar.component";
import { PageNotFoundComponent } from "../app/misc/page-not-found.component";
import { MemberDetailEditComponent } from "./member/member-detail-edit.component";
import { MemberDetailViewComponent } from "./member/member-detail-view.component";


@NgModule({
    // directives, components and pipes
    declarations: [
        AppComponent,
        FamilyDetailEditComponent,
        FamilyDetailViewComponent,
        FamilyListComponent,
        HomeComponent,
        LoginComponent,
        MemberListComponent,
        MemberDetailEditComponent,
        MemberDetailViewComponent,
        NavBarComponent,
        PageNotFoundComponent
    ],

    // modules
    imports: [
        AppRouting,
        BrowserModule,
        FormsModule,
        HttpModule,
        RouterModule
     ],

     exports: [],

     // providers
    providers: [
        MemberService,
        FamilyService
    ],

    bootstrap: [
        AppComponent
    ]
})
export class AppModule {}