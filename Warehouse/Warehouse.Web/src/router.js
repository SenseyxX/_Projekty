﻿import Vue from "vue";
import Router from "vue-router";
import squadRoutes from "@/pages/squad/router";
import teamRoutes from "@/pages/team/router";
import itemRoutes from "@/pages/item/router";
import loginRoutes from "./pages/login/router";
import profileRoutes from "@/pages/profile/router";
import { AuthenticationResultStorageKey } from "@/shared/constants";

Vue.use(Router);

const routes = [
  squadRoutes,
  teamRoutes,
  itemRoutes,
  loginRoutes,
  profileRoutes,
];

const router = new Router({
  routes: routes,
});

router.beforeEach((to, from, next) => {
  const isValidRoute = routes.some((route) => route.path === to.path);
  const isLoginPageRoute = loginRoutes.path === to.path;

  if (!isValidRoute) {
    next(loginRoutes.path);
  } else if (isLoginPageRoute) {
    next();
  } else {
    const authenticationResult = JSON.parse(
      localStorage.getItem(AuthenticationResultStorageKey)
    );

    if (authenticationResult.jwt) {
      next();
    } else {
      next(loginRoutes.path);
    }
  }
});

export default router;
