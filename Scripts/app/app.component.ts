import { Component } from "@angular/core";
import { Router } from "@angular/router";

@Component({
    selector: "start",
    templateUrl: "app/app.component.html"
})
export class AppComponent { 
    title = "Angular App";
    
    constructor(public router: Router){
        }

    isActive(data: any[]): boolean{
        return this.router.isActive(
            this.router.createUrlTree(data), 
            true);
   }
   
}