System.register(["@angular/core","@angular/router","../auth.service"],function(exports_1,context_1){"use strict";var core_1,router_1,auth_service_1,HeaderComponent,__decorate=this&&this.__decorate||function(decorators,target,key,desc){var d,c=arguments.length,r=c<3?target:null===desc?desc=Object.getOwnPropertyDescriptor(target,key):desc;if("object"==typeof Reflect&&"function"==typeof Reflect.decorate)r=Reflect.decorate(decorators,target,key,desc);else for(var i=decorators.length-1;i>=0;i--)(d=decorators[i])&&(r=(c<3?d(r):c>3?d(target,key,r):d(target,key))||r);return c>3&&r&&Object.defineProperty(target,key,r),r},__metadata=this&&this.__metadata||function(k,v){if("object"==typeof Reflect&&"function"==typeof Reflect.metadata)return Reflect.metadata(k,v)};context_1&&context_1.id;return{setters:[function(core_1_1){core_1=core_1_1},function(router_1_1){router_1=router_1_1},function(auth_service_1_1){auth_service_1=auth_service_1_1}],execute:function(){HeaderComponent=function(){function HeaderComponent(router,authService){this.router=router,this.authService=authService,this.title="Inventory App",this.logo="assets/img/logo.png"}return HeaderComponent.prototype.isActive=function(data){return this.router.isActive(this.router.createUrlTree(data),!0)},HeaderComponent.prototype.OnInit=function(){},HeaderComponent=__decorate([core_1.Component({selector:"app-header",templateUrl:"app/header/header.component.html"}),__metadata("design:paramtypes",[router_1.Router,auth_service_1.AuthService])],HeaderComponent)}(),exports_1("HeaderComponent",HeaderComponent)}}});
//# sourceMappingURL=header.component.js.map