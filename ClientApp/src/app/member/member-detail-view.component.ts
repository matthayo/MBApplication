//Imports
import { Component, OnInit, Inject } from "@angular/core";
import { Router, ActivatedRoute } from "@angular/router";
import { Member } from "./member";
import { MemberService } from "./member.service";
import { HttpClient } from "@angular/common/http";
// import { MemberDetailEditComponent } from "./member-detail-edit.component";

// Decorators
@Component({
    selector: "member-detail-view",
    templateUrl: "./member-detail-view.component.html"
})

//Export
export class MemberDetailViewComponent {
    title = "Member Detail View";
    member: Member;
    url: any;

    constructor(//private memberService: MemberService,
                private http: HttpClient,
                private router: Router,
                private activatedRoute: ActivatedRoute,
                @Inject('BASE_URL') baseUrl: string) {
      this.http = http;
      this.url = baseUrl;
                }

    ngOnInit(){
        var id = +this.activatedRoute.snapshot.params["id"];

        if(id){
            // this.memberService.get(id).subscribe(
          this.http.get<Member>(this.url + "api/Members/" + id).subscribe(
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
