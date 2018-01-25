import { Component } from "@angular/core";
import { expand } from "rxjs/operator/expand";

@Component({
    selector: "nav-bar",
    //templateUrl: "./navbar.component.html"
    template: `
    <div class="navbar navbar-default">
    <div class="container-fluid">
        <div class="navbar-header">
            <a class="navbar-brand"> Angular App</a>
        </div>

        <div class="collapse navbar-collapse">
            <ul class="nav navbar-nav">
                <li>
                    <a>Members</a>
                </li>
                <li>
                    <a>Families</a>
                </li>
                <li>
                    <a>Premises</a>
                </li>
            </ul>
        </div>
    </div>
</div>
    `
})

export class NavBarComponent{
    
}