// Imports
import { Component, OnInit } from "@angular/core";
import { Router, ActivatedRoute } from "@angular/router";
import { Observable } from "rxjs/Observable";

import { Member } from "./member";
import { MemberService } from "./member.service";

// Decorators
@Component ({
    selector: "member-detail-edit",
    templateUrl: "app/member/member-detail-edit.component.html"
})

// Export
export class MemberDetailEditComponent {
    title = "Member Detail Edit"
    member: Member;

    constructor(private memberService: MemberService,
                private router: Router,
                private activatedRoute: ActivatedRoute){}

    onInit(){
        var id = +this.activatedRoute.snapshot.params["id"];

        if(id){
            this.memberService.get(id).subscribe(
                member => this.member = member
            );
        }
        else if (id === 0){
            console.log("Id is 0: adding a new member ...");
            this.member = new Member(0,
                                    null,
                                    null,
                                    null,
                                    null,
                                    null,
                                    null,  
                                    null, 
                                    null,   
                                    null
                                );
        }
        else{
            console.log("Invalid id: routing back to home");
            this.router.navigate([""]);
        }
    }

    onInsert(member: Member){
        this.memberService.add(member).subscribe(
            (data) => {
                this.member = data;
                console.log("Member " + this.member.Id + " has been added");
                this.router.navigate(["member/view", this.member.Id]);       
            },
            (error) => console.log(error)
        );
    }

    onUpdate(member: Member){
        this.memberService.update(member).subscribe(
            (data) => {
                this.member = data;
                console.log("Member " + this.member.Id + " has been added.");
                this.router.navigate(["member/view", this.member.Id])
                },
                (error) => console.log(error)
            );
    }

    onMemberDetailView(member: Member) {
        this.router.navigate(["member/view", member.Id]);
    }

    backToMembersList() {
        this.router.navigate(["members"]);
    }


}