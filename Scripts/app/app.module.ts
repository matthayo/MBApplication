import { NgModule } from "@angular/core";
import { BrowserModule } from "@angular/platform-browser";
import { HttpModule } from "@angular/http";
import { RouterModule } from "@angular/router";
import { Observable } from "rxjs/Rx";
import "rxjs/Rx";

import { AppRouting } from "./app.routing";
import { AppComponent } from "./app.component";

import { HomeComponent } from "./home.component";

@NgModule({
    // directives, components and pipes
    declarations: [
        AppComponent,
        HomeComponent
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
    providers: [],

    bootstrap: [
        AppComponent
    ]
})
export class AppModule {}