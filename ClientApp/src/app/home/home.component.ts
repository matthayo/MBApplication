import { Component } from "@angular/core";
//import { expand } from "rxjs/operator/expand";
import { Router, ActivatedRoute } from "@angular/router";

@Component({
    selector: "home",
    templateUrl: "./home.component.html"
})

export class HomeComponent{
    title = "Inventory Management System";

    card_1_title = "Families";
    card_1_button = "Family List";

    card_2_title = "Members"
    card_2_button = "Member List"

    constructor(private router: Router,
                private activatedRoute: ActivatedRoute){ }

    goToFamilyList(){
        this.router.navigate(["families"]);
    }

    goToMembersList(){
        this.router.navigate(["members"]);
    }

}
