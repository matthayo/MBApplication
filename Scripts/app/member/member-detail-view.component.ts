//Imports
import { Component, OnInit } from "@angular/core";
import { Router, ActivatedRoute } from "@angular/router";
import { Member } from "./member";
import { MemberService } from "./member.service";
// import { MemberDetailEditComponent } from "./member-detail-edit.component";

// Decorators
@Component({
    selector: "member-detail-view",
    templateUrl: "app/member/member-detail-view.component.html"
})

//Export
export class MemberDetailViewComponent {
    title = "Member Detail View";
    member: Member;
    
    constructor(private memberService: MemberService,
                private router: Router,
                private activatedRoute: ActivatedRoute){}

    ngOnInit(){
        var id = +this.activatedRoute.snapshot.params["id"];

        if(id){
            this.memberService.get(id).subscribe(
                member => this.member = member
            );
        }
        else if (id === 0){
            console.log("Id is 0: Adding a new member ...");
            this.router.navigate(["member/edit", 0]);
        }
        else{
            console.log("Invalid id: routing to members list");
            this.router.navigate(["members"]);
        }
    }

    onMemberDetailEdit(member: Member){
        this.router.navigate(["member/edit", member.Id]);
        return false;
    }

    backToMembersList(){
        this.router.navigate(["members"]);
    }
    
}