import { NgModule } from "@angular/core";
import { BrowserModule } from "@angular/platform-browser";
import { HttpModule } from "@angular/http";
import { RouterModule } from "@angular/router";
import { Observable } from "rxjs/Rx";
import "rxjs/Rx";

import { AppRouting } from "./app.routing";
import { AppComponent } from "./app.component";

import { MemberService } from "../app/member/member.service";

import { HomeComponent } from "../app/home/home.component";
import { MemberListComponent } from "../app/member/member-list.component";
import { NavBarComponent } from "../app/nav/navbar.component";

@NgModule({
    // directives, components and pipes
    declarations: [
        AppComponent,
        HomeComponent,
        MemberListComponent,
        NavBarComponent
    ],

    // modules
    imports: [
       AppRouting,
        BrowserModule,
        HttpModule,
       RouterModule
     ],

     exports: [],

     // providers
    providers: [
        MemberService
    ],

    bootstrap: [
        AppComponent
    ]
})
export class AppModule {}