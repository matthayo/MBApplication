//Imports
import { Component, OnInit } from "@angular/core";
import { Route } from "@angular/router";

//Decorators
@Component({
    selector: "app-header",
    templateUrl: "app/header/header.component.html"
})

//Export
export class HeaderComponent {
    title = "Inventory App";
    logo: string;

    constructor() {
        this.logo = "assets/img/logo.png";
    }

}