//Imports
import { Component, OnInit } from "@angular/core";
import { Router } from "@angular/router";

//Decorator
@Component({
    selector: "start",
    templateUrl: "app/app.component.html"
})

//Export
export class AppComponent { 
    title = "Angular App";
    
    constructor(public router: Router){ }

    isActive(data: any[]): boolean{
        return this.router.isActive(
            this.router.createUrlTree(data), 
            true);
   }

   OnInit(){}
   
}