import { Component, OnInit } from "@angular/core";
import { Router } from "@angular/router";

@Component({
    selector: "start",
    templateUrl: "app/app.component.html"
})
export class AppComponent { 
    title = "Angular App";
    logo: string;
    
    constructor(public router: Router){
        this.logo = "assets/img/logo.png";
    }

    isActive(data: any[]): boolean{
        return this.router.isActive(
            this.router.createUrlTree(data), 
            true);
   }

   OnInit(){}
   
}