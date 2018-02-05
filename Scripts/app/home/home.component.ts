import { Component } from "@angular/core";
import { expand } from "rxjs/operator/expand";

@Component({
    selector: "home",
    templateUrl: "app/home/home.component.html"
})

export class HomeComponent{
    title = "Welcome to the Member Management System";
}