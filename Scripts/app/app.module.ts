import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { HttpModule } from '@angular/http';
import { Observable } from "rxjs/Rx";
import "rxjs/Rx";

import { AppComponent } from './app.component';

@NgModule({
    //directives, components and pipes
    declarations: [
        AppComponent
    ],
    
    //Modules
    imports: [
        BrowserModule,
        HttpModule
     ],
    
     exports: [],
    
     // providers
    providers: [],

    bootstrap: [
        AppComponent
    ]
})
export class AppModule {}