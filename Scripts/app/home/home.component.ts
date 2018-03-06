import { Component } from "@angular/core";
import { expand } from "rxjs/operator/expand";
import { Router, ActivatedRoute } from "@angular/router";

@Component({
    selector: "home",
    templateUrl: "app/home/home.component.html"
})

export class HomeComponent{
    title = "Member Management System";

    constructor(private router: Router,
                private activatedRoute: ActivatedRoute){ }
    
    goToFamilyList(){
        this.router.navigate(["families"]);
    }

    goToMembersList(){
        this.router.navigate(["members"]);
    }

}