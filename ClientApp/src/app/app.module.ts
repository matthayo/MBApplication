import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';

import { AppComponent } from './app.component';
import { AboutUsComponent } from './aboutUs/about-us.component';
import { FamilyDetailEditComponent } from './family/family-detail-edit.component';
import { FamilyDetailViewComponent } from './family/family-detail-view.component';
import { FamilyListComponent } from './family/family-list.component';
import { FooterComponent } from './footer/footer.component';
import { HeaderComponent } from './header/header.component';
import { HomeComponent } from './home/home.component';
import { LoginComponent } from './login/login.component';
import { LogOutComponent } from './login/logout.component';
import { MemberListComponent } from './member/member-list.component';
import { MemberDetailEditComponent } from './member/member-detail-edit.component';
import { MemberDetailViewComponent } from './member/member-detail-view.component';
import { NavBreadcrumbComponent } from './nav/nav-breadcrumb.component';
import { NavFamilyComponent } from './nav/nav-family.component';
import { NavPaginationComponent } from './nav/nav-pagination.component';
import { PageNotFoundComponent } from './misc/page-not-found.component';
import { AppRouting } from './app.routing';
import { MemberService } from './member/member.service';
import { FamilyService } from './family/family.service';

@NgModule({
  declarations: [
    AppComponent,

    AboutUsComponent,
    FamilyDetailEditComponent,
    FamilyDetailViewComponent,
    FamilyListComponent,
    FooterComponent,
    HeaderComponent,
    HomeComponent,
    LoginComponent,
    LogOutComponent,
    MemberListComponent,
    MemberDetailEditComponent,
    MemberDetailViewComponent,
    NavBreadcrumbComponent,
    NavFamilyComponent,
    NavPaginationComponent,
    PageNotFoundComponent
  ],
  imports: [
    AppRouting,
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    HttpClientModule,
    FormsModule,
  ],
  providers: [
    MemberService,
    FamilyService
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
