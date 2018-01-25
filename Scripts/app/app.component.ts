import { Component } from "@angular/core";
import { Router } from "@angular/router";

@Component({
    selector: "start",
    //templateUrl: "./app.component.html"
    template: `
        <nav-bar></nav-bar>
<h1 class="header">{{title}}</h1>
<div class="main-container">
    <hr>
    <!--<router-outlet></router-outlet>-->
    <home></home>

</div>
    `
})
export class AppComponent { 
    title = "Angular App";
    constructor(){ }
    
 /*   constructor(public router: Router){
        }

    isActive(data: any[]): boolean{
        return this.router.isActive(
            this.router.createUrlTree(data), 
            true);
   }
   */
}