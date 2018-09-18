System.register(["@angular/core","@angular/router","./family.service"],function(exports_1,context_1){"use strict";var core_1,router_1,family_service_1,FamilyDetailViewComponent,__decorate=this&&this.__decorate||function(decorators,target,key,desc){var d,c=arguments.length,r=c<3?target:null===desc?desc=Object.getOwnPropertyDescriptor(target,key):desc;if("object"==typeof Reflect&&"function"==typeof Reflect.decorate)r=Reflect.decorate(decorators,target,key,desc);else for(var i=decorators.length-1;i>=0;i--)(d=decorators[i])&&(r=(c<3?d(r):c>3?d(target,key,r):d(target,key))||r);return c>3&&r&&Object.defineProperty(target,key,r),r},__metadata=this&&this.__metadata||function(k,v){if("object"==typeof Reflect&&"function"==typeof Reflect.metadata)return Reflect.metadata(k,v)};context_1&&context_1.id;return{setters:[function(core_1_1){core_1=core_1_1},function(router_1_1){router_1=router_1_1},function(family_service_1_1){family_service_1=family_service_1_1}],execute:function(){FamilyDetailViewComponent=function(){function FamilyDetailViewComponent(familyService,router,activatedRoute){this.familyService=familyService,this.router=router,this.activatedRoute=activatedRoute,this.title="Detailed Family View"}return FamilyDetailViewComponent.prototype.ngOnInit=function(){var _this=this,id=+this.activatedRoute.snapshot.params.id;id?this.familyService.get(id).subscribe(function(family){return _this.family=family}):0===id?(console.log("Id is 0: adding a new family unit..."),this.router.navigate(["family/edit",0])):(console.log("Invalid id: routing back to home"),this.router.navigate([""]))},FamilyDetailViewComponent.prototype.onFamilyDetailEdit=function(family){this.router.navigate(["family/edit",family.Id])},FamilyDetailViewComponent.prototype.backToFamiliesList=function(){this.router.navigate(["families"])},FamilyDetailViewComponent=__decorate([core_1.Component({selector:"family-detail-view",templateUrl:"app/family/family-detail-view.component.html"}),__metadata("design:paramtypes",[family_service_1.FamilyService,router_1.Router,router_1.ActivatedRoute])],FamilyDetailViewComponent)}(),exports_1("FamilyDetailViewComponent",FamilyDetailViewComponent)}}});
//# sourceMappingURL=family-detail-view.component.js.map
