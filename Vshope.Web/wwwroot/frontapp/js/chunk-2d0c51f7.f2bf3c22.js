(window["webpackJsonp"]=window["webpackJsonp"]||[]).push([["chunk-2d0c51f7"],{"3e6e":function(t,e,u){"use strict";u.r(e);var a=function(){var t=this,e=t.$createElement,u=t._self._c||e;return u("v-container",{attrs:{"fill-height":"",fluid:"","grid-list-xl":""}},[u("v-layout",{attrs:{wrap:""}},[u("v-flex",[u("material-card",{staticClass:"mt-0",attrs:{color:t.color,title:t.$t("common.vkAuth"),"max-width":"600px"}},[u("v-container",{attrs:{"py-0":"","px-3":""}},[u("v-layout",{attrs:{column:""}},[u("v-flex",[u("v-text-field",{attrs:{label:t.$t("vkAuth.status"),value:t.$t(t.vkAuthModel.status),readonly:""}})],1)],1)],1)],1)],1)],1)],1)},s=[],o=u("db72"),l=u("2f62"),n={data:function(){return{vkAuthModel:{status:"vkAuth.statusPending"}}},computed:Object(o["a"])({},Object(l["e"])("app",["color"])),mounted:function(){var t=this,e=this.$route.query.code;this.vkRequest(e).then((function(){t.vkAuthModel.status="vkAuth.statusSuccess"})).catch((function(){t.vkAuthModel.status="vkAuth.statusError"}))},methods:Object(o["a"])({},Object(l["b"])("auth",["vkRequest"]))},c=n,r=u("2877"),i=Object(r["a"])(c,a,s,!1,null,null,null);e["default"]=i.exports}}]);
//# sourceMappingURL=chunk-2d0c51f7.f2bf3c22.js.map