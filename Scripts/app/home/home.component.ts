import { Component } from "@angular/core";

@Component({
    selector: "home",
    //templateUrl: "./home.component.html"
    template: `
        <h2>{{title}}</h2>
        <div class="col-md-6">
            <h3>List of Families</h3>
            <family-list class="lists"></family-list>
        </div>
    `
})

export class HomeComponent{
    title = "Welcome View";
}